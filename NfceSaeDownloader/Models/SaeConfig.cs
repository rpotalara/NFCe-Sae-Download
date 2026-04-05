using System.Security.Cryptography.X509Certificates;

namespace NfceSaeDownloader.Models
{
    public sealed class SaeConfig
    {
        public SaeAmbiente Ambiente { get; set; }
        public string UrlListagem { get; set; }
        public string UrlDownload { get; set; }
        public int TimeoutMs { get; set; }
        public int DelayEntreChamadasMs { get; set; }
        public X509Certificate2 Certificado { get; set; }
        public string DiretorioSaida { get; set; }
    }
}
