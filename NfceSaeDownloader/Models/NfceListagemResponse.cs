using System;
using System.Collections.Generic;

namespace NfceSaeDownloader.Models
{
    public sealed class NfceListagemResponse
    {
        public string Versao { get; set; }
        public SaeAmbiente Ambiente { get; set; }
        public string VerAplic { get; set; }
        public DateTime? DhReq { get; set; }
        public int CStat { get; set; }
        public string XMotivo { get; set; }
        public DateTime? DhEmisUltNfce { get; set; }
        public List<NfceChaveInfo> Chaves { get; private set; }

        public NfceListagemResponse()
        {
            Chaves = new List<NfceChaveInfo>();
        }

        public bool Sucesso
        {
            get { return CStat == 100 || CStat == 101 || CStat == 107; }
        }

        public bool ListaIncompleta
        {
            get { return CStat == 101; }
        }
    }
}
