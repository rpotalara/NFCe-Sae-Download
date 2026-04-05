# NFC-e SAE Downloader (São Paulo)

Aplicação Windows Forms desenvolvida em **.NET Framework 4.6.2** para realizar a listagem de chaves e o download de arquivos XML da Nota Fiscal de Consumidor Eletrônica (**NFC-e, modelo 65**) através do Sistema de Apoio à Escrituração (SAE) da SEFAZ-SP.

## 🚀 Funcionalidades

-   **Listagem de Chaves:** Consulta chaves de acesso emitidas por um CNPJ em um período específico.
-   **Download de XML:** Recupera o XML completo (incluindo eventos) de NFC-es autorizadas.
-   **Validação XSD Automática:** Valida todas as mensagens de saída contra os schemas oficiais da SEFAZ antes do envio.
-   **Gerenciamento de Limites (cStat 101):** Implementa lógica automática de subdivisão de períodos quando a SEFAZ retorna lista incompleta (limite de 2000 chaves).
-   **Suporte a SOAP 1.2:** Comunicação robusta seguindo os padrões modernos exigidos pela SEFAZ-SP.
-   **Filtros de Interface:** Filtragem local por número de documento e série.
-   **Sistema de Log:** Registro detalhado de operações e erros para auditoria.

## 🛠️ Requisitos Técnicos

-   **.NET Framework 4.6.2** ou superior.
-   **Certificado Digital e-CNPJ:** Obrigatório para autenticação nos WebServices (deve estar instalado no repositório do Windows).
-   **Acesso à Internet:** Para comunicação com os endereços da Fazenda SP.

## 📂 Estrutura do Projeto

-   `Infrastructure/`: Configurações centrais, constantes de namespace e repositório de estado (cursor).
-   `Services/`: Lógica de comunicação SOAP, validação de XML e serviço de certificados.
-   `Models/`: Classes de representação de dados para requisições e respostas.
-   `Schemas/`: Arquivos XSD oficiais (`nfceListagemChaves_100.xsd`, etc.) integrados ao build.
-   `Forms/`: Interface gráfica do usuário.

## ⚙️ Configuração e Uso

1.  **Certificado:** Selecione o certificado e-CNPJ correspondente ao CNPJ emissor das notas.
2.  **Período:** Defina a data inicial e final. O SAE permite consultas de até 100 dias retroativos.
3.  **Ambiente:** Escolha entre Produção ou Homologação.
4.  **Cursor:** O aplicativo salva automaticamente a data da última nota baixada, facilitando a continuidade de processos de escrituração.

## 📜 Conformidade
Esta ferramenta foi validada conforme o manual **SAE-NFC-e v1.0.0** e utiliza o namespace oficial `http://www.portalfiscal.inf.br/nfe`.

---
*Desenvolvido seguindo as melhores práticas de C# e padrões da Nota Fiscal Eletrônica.*
