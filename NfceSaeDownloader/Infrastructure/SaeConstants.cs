namespace NfceSaeDownloader.Infrastructure
{
    /// <summary>
    /// Centraliza as constantes de configuração, namespaces e SOAP Actions para o serviço SAE-NFC-e.
    /// </summary>
    public static class SaeConstants
    {
        /// <summary>
        /// Namespace oficial para as tags de dados da NFC-e conforme Manual SAE v1.0.0.
        /// </summary>
        public const string SaeNamespace = "http://www.portalfiscal.inf.br/nfe";

        /// <summary>
        /// SOAP Action para o serviço de listagem de chaves (utilizado no Header ou Content-Type action).
        /// </summary>
        public const string ListagemSoapAction = "http://www.portalfiscal.inf.br/nfe/wsdl/NFCeListagemChaves/nfceListagemChaves";

        /// <summary>
        /// SOAP Action para o serviço de download de XML.
        /// </summary>
        public const string DownloadSoapAction = "http://www.portalfiscal.inf.br/nfe/wsdl/NFCeDownloadXML/nfceDownloadXML";

        /// <summary>
        /// Namespace do serviço de listagem para uso na tag wrapper <c>nfeDadosMsg</c>.
        /// </summary>
        public const string ListagemServiceNamespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFCeListagemChaves";

        /// <summary>
        /// Namespace do serviço de download para uso na tag wrapper <c>nfeDadosMsg</c>.
        /// </summary>
        public const string DownloadServiceNamespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFCeDownloadXML";

        /// <summary>
        /// Versão atual do layout do serviço SAE.
        /// </summary>
        public const string VersaoLayout = "1.00";
    }
}
