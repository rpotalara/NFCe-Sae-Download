using System;

namespace NfceSaeDownloader.Models
{
    public sealed class NfceChaveInfo
    {
        public string Chave { get; set; }
        public DateTime? DhEmissao { get; set; }
        public string NumeroDocumento
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Chave) || Chave.Length < 34)
                {
                    return string.Empty;
                }

                return Chave.Substring(25, 9);
            }
        }

        public string Serie
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Chave) || Chave.Length < 25)
                {
                    return string.Empty;
                }

                return Chave.Substring(22, 3);
            }
        }
    }
}
