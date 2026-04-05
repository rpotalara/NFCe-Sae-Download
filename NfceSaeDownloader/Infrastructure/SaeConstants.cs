namespace NfceSaeDownloader.Infrastructure
{
    public static class SaeConstants
    {
        // Namespace oficial do manual SAE e XSDs
        public const string SaeNamespace = "http://www.portalfiscal.inf.br/nfe";

        // SOAP Actions (normalmente é o namespace + o nome do método)
        public const string ListagemSoapAction = "http://www.portalfiscal.inf.br/nfe/NFCeListagemChaves";
        public const string DownloadSoapAction = "http://www.portalfiscal.inf.br/nfe/NFCeDownloadXML";

        // Padrões de Layout
        public const string VersaoLayout = "1.00";
    }
}
