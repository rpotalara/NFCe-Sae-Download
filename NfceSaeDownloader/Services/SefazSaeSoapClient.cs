using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using NfceSaeDownloader.Infrastructure;
using NfceSaeDownloader.Models;

namespace NfceSaeDownloader.Services
{
    /// <summary>
    /// Cliente SOAP para comunicação direta com os WebServices da SEFAZ SP (SAE-NFC-e).
    /// </summary>
    public sealed class SefazSaeSoapClient
    {
        private readonly SaeConfig _config;
        private readonly LogService _log;

        /// <summary>
        /// Inicializa uma nova instância do cliente.
        /// </summary>
        public SefazSaeSoapClient(SaeConfig config, LogService log)
        {
            _config = config;
            _log = log;
        }

        /// <summary>
        /// Consome o serviço NFCeListagemChaves para obter chaves de acesso no período informado.
        /// </summary>
        public NfceListagemResponse ListarChaves(DateTime dataHoraInicial, DateTime? dataHoraFinal)
        {
            var ns = SaeConstants.SaeNamespace;
            var payload = new XElement(XName.Get("nfceListagemChaves", ns),
                new XAttribute("versao", SaeConstants.VersaoLayout),
                new XElement(XName.Get("tpAmb", ns), (int)_config.Ambiente),
                new XElement(XName.Get("dataHoraInicial", ns), dataHoraInicial.ToString("yyyy-MM-ddTHH:mm")));

            if (dataHoraFinal.HasValue)
            {
                payload.Add(new XElement(XName.Get("dataHoraFinal", ns), dataHoraFinal.Value.ToString("yyyy-MM-ddTHH:mm")));
            }

            // Valida o XML contra o schema XSD antes de enviar
            XmlValidationService.ValidarListagem(payload);

            // Envolve em nfeDadosMsg com o namespace específico do serviço (correção cStat 242)
            var wrapped = new XElement(XName.Get("nfeDadosMsg", SaeConstants.ListagemServiceNamespace), payload);
            var envelope = BuildSoapEnvelope(wrapped);
            var xml = PostSoap(_config.UrlListagem, SaeConstants.ListagemSoapAction, envelope, _config.Certificado);
            return ParseListagem(xml);
        }

        /// <summary>
        /// Consome o serviço NFCeDownloadXML para obter o XML completo de uma NFC-e específica.
        /// </summary>
        public NfceDownloadResponse DownloadXml(string chave)
        {
            var ns = SaeConstants.SaeNamespace;
            var payload = new XElement(XName.Get("nfceDownloadXML", ns),
                new XAttribute("versao", SaeConstants.VersaoLayout),
                new XElement(XName.Get("tpAmb", ns), (int)_config.Ambiente),
                new XElement(XName.Get("chNFCe", ns), chave));

            // Valida o XML contra o schema XSD antes de enviar
            XmlValidationService.ValidarDownload(payload);

            // Envolve em nfeDadosMsg com o namespace específico do serviço (correção cStat 242)
            var wrapped = new XElement(XName.Get("nfeDadosMsg", SaeConstants.DownloadServiceNamespace), payload);
            var envelope = BuildSoapEnvelope(wrapped);
            var xml = PostSoap(_config.UrlDownload, SaeConstants.DownloadSoapAction, envelope, _config.Certificado);
            return ParseDownload(xml);
        }

        private string BuildSoapEnvelope(XElement payload)
        {
            // Alterado para SOAP 1.2 conforme exigência do servidor SEFAZ
            XNamespace soap = "http://www.w3.org/2003/05/soap-envelope";
            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(soap + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "soap", soap),
                    new XElement(soap + "Body", payload)));

            return doc.ToString(SaveOptions.DisableFormatting);
        }

        private string PostSoap(string url, string soapAction, string envelopeXml, X509Certificate2 certificate)
        {
            _log.Info("POST SOAP -> " + url + " | Action=" + soapAction);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            // SOAP 1.2 utiliza application/soap+xml e o parâmetro action no Content-Type
            request.ContentType = string.Format("application/soap+xml; charset=utf-8; action=\"{0}\"", soapAction);
            request.Accept = "application/soap+xml, text/xml";
            request.Timeout = _config.TimeoutMs;
            request.ReadWriteTimeout = _config.TimeoutMs;

            request.ClientCertificates.Add(certificate);
            request.KeepAlive = true;
            request.ProtocolVersion = HttpVersion.Version11;
            request.ServicePoint.Expect100Continue = false;

            var bytes = Encoding.UTF8.GetBytes(envelopeXml);
            request.ContentLength = bytes.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    var xml = reader.ReadToEnd();
                    _log.Info("Resposta recebida com sucesso. HTTP=" + (int)response.StatusCode);
                    return xml;
                }
            }
            catch (WebException ex)
            {
                var body = string.Empty;
                if (ex.Response != null)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream ?? Stream.Null, Encoding.UTF8))
                    {
                        body = reader.ReadToEnd();
                    }
                }

                _log.Error("Falha SOAP. " + ex.Message + " | Body=" + body);
                throw new ApplicationException("Falha ao consumir o webservice SAE-NFC-e. " + ex.Message + Environment.NewLine + body, ex);
            }
        }

        private NfceListagemResponse ParseListagem(string soapXml)
        {
            var response = new NfceListagemResponse();
            var doc = XDocument.Parse(soapXml);
            var body = FindSoapBody(doc);
            var ret = FindDescendantByLocalName(body, "retNfceListagemChaves");
            if (ret == null)
            {
                throw new ApplicationException("A resposta do serviço NFCeListagemChaves não contém retNfceListagemChaves.");
            }

            response.Versao = GetValue(ret, "versao");
            response.Ambiente = ParseAmbiente(GetValue(ret, "tpAmb"));
            response.VerAplic = GetValue(ret, "verAplic");
            response.DhReq = ParseDate(GetValue(ret, "dhReq"));
            response.CStat = ParseInt(GetValue(ret, "cStat"));
            response.XMotivo = GetValue(ret, "xMotivo");
            response.DhEmisUltNfce = ParseDate(GetValue(ret, "dhEmisUltNfce"));

            foreach (var element in ret.Descendants())
            {
                if (element.Name.LocalName == "chNFCe")
                {
                    response.Chaves.Add(new NfceChaveInfo
                    {
                        Chave = element.Value
                    });
                }
            }

            if (response.DhEmisUltNfce.HasValue)
            {
                foreach (var item in response.Chaves)
                {
                    item.DhEmissao = response.DhEmisUltNfce;
                }
            }

            return response;
        }

        private NfceDownloadResponse ParseDownload(string soapXml)
        {
            var response = new NfceDownloadResponse();
            var doc = XDocument.Parse(soapXml, LoadOptions.PreserveWhitespace);
            var body = FindSoapBody(doc);
            var ret = FindDescendantByLocalName(body, "retNfceDownloadXML");
            if (ret == null)
            {
                throw new ApplicationException("A resposta do serviço NFCeDownloadXML não contém retNfceDownloadXML.");
            }

            response.Versao = GetValue(ret, "versao");
            response.Ambiente = ParseAmbiente(GetValue(ret, "tpAmb"));
            response.VerAplic = GetValue(ret, "verAplic");
            response.DhReq = ParseDate(GetValue(ret, "dhReq"));
            response.CStat = ParseInt(GetValue(ret, "cStat"));
            response.XMotivo = GetValue(ret, "xMotivo");

            var proc = FindDescendantByLocalName(ret, "proc");
            if (proc != null && proc.HasElements)
            {
                response.ProcXml = new XDocument(new XElement(proc));
            }

            return response;
        }

        private static XElement FindSoapBody(XDocument doc)
        {
            foreach (var element in doc.Descendants())
            {
                if (element.Name.LocalName == "Body")
                {
                    return element;
                }
            }

            throw new ApplicationException("Envelope SOAP inválido: Body não encontrado.");
        }

        private static XElement FindDescendantByLocalName(XElement parent, string localName)
        {
            foreach (var element in parent.DescendantsAndSelf())
            {
                if (element.Name.LocalName == localName)
                {
                    return element;
                }
            }

            return null;
        }

        private static string GetValue(XElement parent, string localName)
        {
            var element = FindDescendantByLocalName(parent, localName);
            return element == null ? string.Empty : element.Value;
        }

        private static int ParseInt(string value)
        {
            int parsed;
            return int.TryParse(value, out parsed) ? parsed : 0;
        }

        private static DateTime? ParseDate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            DateTime parsed;
            if (DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out parsed))
            {
                return parsed;
            }

            return null;
        }

        private static SaeAmbiente ParseAmbiente(string value)
        {
            return value == "2" ? SaeAmbiente.Homologacao : SaeAmbiente.Producao;
        }
    }
}
