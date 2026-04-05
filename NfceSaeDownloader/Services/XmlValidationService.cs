using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using NfceSaeDownloader.Infrastructure;

namespace NfceSaeDownloader.Services
{
    public static class XmlValidationService
    {
        public static void ValidarListagem(XElement xml)
        {
            Validar(xml, "nfceListagemChaves_100.xsd");
        }

        public static void ValidarDownload(XElement xml)
        {
            Validar(xml, "nfceDownloadXML_100.xsd");
        }

        private static void Validar(XElement xml, string schemaFileName)
        {
            var schemaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Schemas", schemaFileName);
            if (!File.Exists(schemaPath))
            {
                schemaPath = Path.Combine("Schemas", schemaFileName);
                if (!File.Exists(schemaPath))
                {
                    throw new FileNotFoundException("Schema XSD não encontrado: " + schemaFileName);
                }
            }

            var schemas = new XmlSchemaSet();
            schemas.Add(SaeConstants.SaeNamespace, schemaPath);

            var doc = new XmlDocument();
            using (var reader = xml.CreateReader())
            {
                doc.Load(reader);
            }

            doc.Schemas = schemas;
            string errors = string.Empty;

            doc.Validate((sender, args) =>
            {
                errors += string.Format("[{0}] {1}{2}", args.Severity, args.Message, Environment.NewLine);
            });

            if (!string.IsNullOrEmpty(errors))
            {
                throw new ApplicationException("Falha na validação do XML contra o schema " + schemaFileName + ":" + Environment.NewLine + errors);
            }
        }
    }
}
