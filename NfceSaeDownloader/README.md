# SAE-NFC-e Downloader - SEFAZ/SP

Projeto WinForms (.NET Framework 4.6.2) para consultar chaves e baixar XMLs de NFC-e modelo 65 por meio do SAE-NFC-e da SEFAZ/SP.

## O que o projeto faz

- consulta o serviço `NFCeListagemChaves` por período;
- filtra localmente por número e série extraídos da chave de acesso;
- baixa os XMLs pelo serviço `NFCeDownloadXML`;
- salva os arquivos em disco;
- grava cursor incremental em `sae-state.xml`;
- auto divide o período quando a SEFAZ retornar `cStat=101` (lista incompleta);
- grava log em `logs\sae-nfce.log`.

## Observações importantes

1. O serviço exige certificado digital e-CNPJ do próprio contribuinte.
2. O SAE trabalha com consulta de chaves por período e download por chave, não por número direto.
3. O projeto usa envelopes SOAP montados manualmente. Caso a SEFAZ altere namespace ou SOAPAction, ajuste no `App.config`.
4. O cursor incremental foi implementado por `dhUltimaEmissao`, pois a especificação do SAE publicada pela SEFAZ/SP expõe `dhEmisUltNfce` e não NSU.

## Como usar

1. Abra `NfceSaeDownloader.sln` no Visual Studio 2022.
2. Compile em .NET Framework 4.6.2.
3. Selecione ambiente, store, certificado e período.
4. Clique em **Consultar chaves**.
5. Marque as linhas desejadas ou use **Baixar todos**.

## Estrutura

- `Forms\MainForm.*`: interface gráfica.
- `Services\SefazSaeSoapClient.cs`: consumo SOAP direto dos webservices.
- `Services\SaeNfceDownloader.cs`: regra de negócio de consulta, partição automática e download.
- `Infrastructure\StateRepository.cs`: cursor incremental local.
- `Services\CertificateService.cs`: leitura de certificados do Windows.

