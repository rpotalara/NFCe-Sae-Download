using System;

namespace NfceSaeDownloader.Models
{
    public sealed class DownloadResult
    {
        public string Chave { get; set; }
        public string Numero { get; set; }
        public string Serie { get; set; }
        public string ArquivoSalvo { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataHora { get; set; }
    }
}
