using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using NfceSaeDownloader.Infrastructure;
using NfceSaeDownloader.Models;

namespace NfceSaeDownloader.Services
{
    /// <summary>
    /// Classe de alto nível que coordena as operações de listagem e download de NFC-e.
    /// </summary>
    public sealed class SaeNfceDownloader
    {
        private readonly SefazSaeSoapClient _client;
        private readonly SaeConfig _config;
        private readonly LogService _log;
        private readonly StateRepository _state;

        /// <summary>
        /// Inicializa o coordenador de downloads.
        /// </summary>
        public SaeNfceDownloader(SaeConfig config, LogService log)
        {
            _config = config;
            _log = log;
            _client = new SefazSaeSoapClient(config, log);
            _state = new StateRepository(config.DiretorioSaida);
        }

        /// <summary>
        /// Consulta a lista de chaves de acesso no período, aplicando filtros opcionais e salvando o estado do cursor.
        /// </summary>
        public List<NfceChaveInfo> ConsultarChaves(DateTime dataInicial, DateTime dataFinal, bool autoDividirPeriodo, string numeroFiltro, string serieFiltro, string cnpjCertificado)
        {
            var list = new List<NfceChaveInfo>();

            // Inicia a busca recursiva para lidar com o limite de 2000 chaves (cStat 101)
            SearchRange(dataInicial, dataFinal, autoDividirPeriodo, list);

            var query = list.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(numeroFiltro))
            {
                var numero = numeroFiltro.PadLeft(9, '0');
                query = query.Where(x => x.NumeroDocumento == numero);
            }

            if (!string.IsNullOrWhiteSpace(serieFiltro))
            {
                var serie = serieFiltro.PadLeft(3, '0');
                query = query.Where(x => x.Serie == serie);
            }

            var resultado = query
                .GroupBy(x => x.Chave)
                .Select(g => g.First())
                .OrderBy(x => x.Chave)
                .ToList();

            if (resultado.Count > 0)
            {
                var maxDh = resultado.Where(x => x.DhEmissao.HasValue).Select(x => x.DhEmissao.Value).DefaultIfEmpty(dataFinal).Max();
                _state.SaveCursor(_config.Ambiente, cnpjCertificado, maxDh);
            }

            return resultado;
        }

        public DateTime? LoadLastCursor(string cnpjCertificado)
        {
            return _state.LoadCursor(_config.Ambiente, cnpjCertificado);
        }

        /// <summary>
        /// Realiza o download individual dos XMLs para as chaves selecionadas.
        /// </summary>
        public List<DownloadResult> BaixarXmls(IEnumerable<NfceChaveInfo> chaves)
        {
            var result = new List<DownloadResult>();
            Directory.CreateDirectory(_config.DiretorioSaida);

            foreach (var item in chaves)
            {
                var op = new DownloadResult
                {
                    Chave = item.Chave,
                    Numero = item.NumeroDocumento,
                    Serie = item.Serie,
                    DataHora = DateTime.Now
                };

                try
                {
                    var response = _client.DownloadXml(item.Chave);
                    if (!response.Sucesso || response.ProcXml == null)
                    {
                        op.Sucesso = false;
                        op.Mensagem = string.Format("cStat={0} xMotivo={1}", response.CStat, response.XMotivo);
                    }
                    else
                    {
                        var fileName = string.Format("NFCe_65_{0}_{1}_{2}.xml", item.Serie, item.NumeroDocumento, item.Chave);
                        var path = Path.Combine(_config.DiretorioSaida, fileName);
                        response.ProcXml.Save(path);
                        op.ArquivoSalvo = path;
                        op.Sucesso = true;
                        op.Mensagem = "Download concluído";
                    }
                }
                catch (Exception ex)
                {
                    op.Sucesso = false;
                    op.Mensagem = ex.Message;
                    _log.Error("Erro ao baixar chave " + item.Chave + ": " + ex);
                }

                result.Add(op);
                Thread.Sleep(_config.DelayEntreChamadasMs);
            }

            return result;
        }

        /// <summary>
        /// Método recursivo para busca de chaves. Implementa a lógica de subdivisão de períodos (Particionamento Binário)
        /// para contornar o limite de 2000 chaves por consulta da SEFAZ SP.
        /// </summary>
        private void SearchRange(DateTime inicio, DateTime fim, bool autoDividirPeriodo, List<NfceChaveInfo> destino)
        {
            if (fim < inicio)
            {
                return;
            }

            var response = _client.ListarChaves(inicio, fim);
            if (!response.Sucesso)
            {
                throw new ApplicationException(string.Format("Consulta rejeitada. cStat={0} xMotivo={1}", response.CStat, response.XMotivo));
            }

            destino.AddRange(response.Chaves);
            _log.Info(string.Format("Período {0:s} -> {1:s}, cStat={2}, chaves={3}", inicio, fim, response.CStat, response.Chaves.Count));

            if (response.ListaIncompleta && autoDividirPeriodo)
            {
                var pivot = response.DhEmisUltNfce.HasValue && response.DhEmisUltNfce.Value > inicio && response.DhEmisUltNfce.Value < fim
                    ? response.DhEmisUltNfce.Value
                    : inicio.AddMinutes(Math.Max(1, (int)(fim - inicio).TotalMinutes / 2));

                if (pivot <= inicio || pivot >= fim)
                {
                    throw new ApplicationException("A SEFAZ retornou lista incompleta (cStat=101), mas não foi possível particionar o período automaticamente com segurança.");
                }

                destino.RemoveAll(x => x.DhEmissao.HasValue && x.DhEmissao.Value >= pivot);
                SearchRange(inicio, pivot, true, destino);
                SearchRange(pivot, fim, true, destino);
            }
        }
    }
}
