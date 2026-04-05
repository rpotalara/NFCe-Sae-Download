namespace NfceSaeDownloader.Infrastructure
{
    public static class SaeConstants
    {
        // Namespace oficial do manual SAE e XSDs
        public const string SaeNamespace = "http://www.portalfiscal.inf.br/nfe";

        // SOAP Actions (Padrão SEFAZ SP para serviços ASMX 1.2)
        public const string ListagemSoapAction = "http://www.portalfiscal.inf.br/nfe/wsdl/NFCeListagemChaves";
        public const string DownloadSoapAction = "http://www.portalfiscal.inf.br/nfe/wsdl/NFCeDownloadXML";

        // Padrões de Layout
        public const string VersaoLayout = "1.00";
    }
}
