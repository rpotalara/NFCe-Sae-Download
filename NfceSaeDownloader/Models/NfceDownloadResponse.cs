using System;
using System.Xml.Linq;

namespace NfceSaeDownloader.Models
{
    public sealed class NfceDownloadResponse
    {
        public string Versao { get; set; }
        public SaeAmbiente Ambiente { get; set; }
        public string VerAplic { get; set; }
        public DateTime? DhReq { get; set; }
        public int CStat { get; set; }
        public string XMotivo { get; set; }
        public XDocument ProcXml { get; set; }

        public bool Sucesso
        {
            get { return CStat == 200; }
        }
    }
}
