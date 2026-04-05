namespace NfceSaeDownloader.Infrastructure
{
    public static class SaeConstants
    {
        // Namespace oficial do manual SAE e XSDs
        public const string SaeNamespace = "http://www.portalfiscal.inf.br/nfe";

        // SOAP Actions
        public const string ListagemSoapAction = "http://www.portalfiscal.inf.br/nfe/wsdl/NFCeListagemChaves/nfceListagemChaves";
        public const string DownloadSoapAction = "http://www.portalfiscal.inf.br/nfe/wsdl/NFCeDownloadXML/nfceDownloadXML";

        // Namespaces dos WebServices (usados no wrapper nfeDadosMsg)
        public const string ListagemServiceNamespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFCeListagemChaves";
        public const string DownloadServiceNamespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFCeDownloadXML";

        // Padrões de Layout
        public const string VersaoLayout = "1.00";
    }
}
