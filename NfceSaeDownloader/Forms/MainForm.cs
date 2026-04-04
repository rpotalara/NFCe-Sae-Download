using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using NfceSaeDownloader.Infrastructure;
using NfceSaeDownloader.Models;
using NfceSaeDownloader.Services;

namespace NfceSaeDownloader.Forms
{
    public partial class MainForm : Form
    {
        private readonly List<NfceChaveInfo> _ultimasChaves = new List<NfceChaveInfo>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cboAmbiente.DataSource = Enum.GetValues(typeof(SaeAmbiente));
            cboStoreLocation.DataSource = Enum.GetValues(typeof(StoreLocation));
            cboStoreName.DataSource = Enum.GetValues(typeof(StoreName));
            cboAmbiente.SelectedItem = SaeAmbiente.Producao;
            cboStoreLocation.SelectedItem = StoreLocation.CurrentUser;
            cboStoreName.SelectedItem = StoreName.My;
            txtVersao.Text = AppSettingsStore.GetString("SaeVersaoLayout", "1.00");
            txtOutputDir.Text = AppSettingsStore.GetString("DiretorioSaidaPadrao", @"C:\NFCE\SAE\XML");
            txtDelay.Text = AppSettingsStore.GetInt("DelayEntreChamadasMs", 600).ToString();
            txtTimeout.Text = AppSettingsStore.GetInt("SoapTimeoutMs", 120000).ToString();
            dtIni.Value = DateTime.Now.Date;
            dtFim.Value = DateTime.Now;
            chkAutoDividir.Checked = true;
            RefreshUrls();
            LoadCertificates();
        }

        private void cboAmbiente_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshUrls();
        }

        private void btnAtualizarCertificados_Click(object sender, EventArgs e)
        {
            LoadCertificates();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                gridResultados.Rows.Clear();
                _ultimasChaves.Clear();

                var config = BuildConfig();
                var log = new LogService(config.DiretorioSaida);
                var service = new SaeNfceDownloader(config, log);
                var cnpj = CertificateService.ExtractCnpj(config.Certificado);

                var chaves = service.ConsultarChaves(
                    dtIni.Value,
                    dtFim.Value,
                    chkAutoDividir.Checked,
                    txtNumero.Text.Trim(),
                    txtSerie.Text.Trim(),
                    cnpj);

                _ultimasChaves.AddRange(chaves);

                foreach (var item in chaves)
                {
                    gridResultados.Rows.Add(false, item.NumeroDocumento, item.Serie, item.Chave, item.DhEmissao.HasValue ? item.DhEmissao.Value.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty, string.Empty, string.Empty);
                }

                var cursor = service.LoadLastCursor(cnpj);
                txtCursor.Text = cursor.HasValue ? cursor.Value.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
                AppendLog(string.Format("Consulta concluída. {0} chave(s) localizada(s).", chaves.Count));
            }
            catch (Exception ex)
            {
                AppendLog("Erro na consulta: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaixarSelecionados_Click(object sender, EventArgs e)
        {
            try
            {
                var selecionadas = new List<NfceChaveInfo>();
                for (int i = 0; i < gridResultados.Rows.Count; i++)
                {
                    var isChecked = Convert.ToBoolean(gridResultados.Rows[i].Cells[0].Value ?? false);
                    if (!isChecked)
                    {
                        continue;
                    }

                    var chave = Convert.ToString(gridResultados.Rows[i].Cells[3].Value);
                    var item = _ultimasChaves.FirstOrDefault(x => x.Chave == chave);
                    if (item != null)
                    {
                        selecionadas.Add(item);
                    }
                }

                if (selecionadas.Count == 0)
                {
                    MessageBox.Show(this, "Selecione ao menos uma chave para download.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var config = BuildConfig();
                var log = new LogService(config.DiretorioSaida);
                var service = new SaeNfceDownloader(config, log);
                var result = service.BaixarXmls(selecionadas);
                RenderDownloadResult(result);
            }
            catch (Exception ex)
            {
                AppendLog("Erro no download: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaixarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridResultados.Rows)
            {
                row.Cells[0].Value = true;
            }
            btnBaixarSelecionados_Click(sender, e);
        }

        private void btnUsarCursor_Click(object sender, EventArgs e)
        {
            DateTime parsed;
            if (DateTime.TryParse(txtCursor.Text, out parsed))
            {
                dtIni.Value = parsed;
            }
        }

        private void btnPastaSaida_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.SelectedPath = txtOutputDir.Text;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    txtOutputDir.Text = dialog.SelectedPath;
                }
            }
        }

        private void LoadCertificates()
        {
            cboCertificados.Items.Clear();
            var location = (StoreLocation)cboStoreLocation.SelectedItem;
            var storeName = (StoreName)cboStoreName.SelectedItem;

            var certificates = CertificateService.GetAvailableCertificates(location, storeName);
            foreach (var certificate in certificates)
            {
                cboCertificados.Items.Add(new CertificateComboItem(certificate));
            }

            if (cboCertificados.Items.Count > 0)
            {
                cboCertificados.SelectedIndex = 0;
            }
        }

        private void RefreshUrls()
        {
            var ambiente = (SaeAmbiente)cboAmbiente.SelectedItem;
            if (ambiente == SaeAmbiente.Homologacao)
            {
                txtUrlListagem.Text = "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFCeListagemChaves.asmx";
                txtUrlDownload.Text = "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFCeDownloadXML.asmx";
            }
            else
            {
                txtUrlListagem.Text = "https://nfce.fazenda.sp.gov.br/ws/NFCeListagemChaves.asmx";
                txtUrlDownload.Text = "https://nfce.fazenda.sp.gov.br/ws/NFCeDownloadXML.asmx";
            }
        }

        private SaeConfig BuildConfig()
        {
            if (cboCertificados.SelectedItem == null)
            {
                throw new ApplicationException("Selecione um certificado digital e-CNPJ com chave privada.");
            }

            int timeout;
            if (!int.TryParse(txtTimeout.Text, out timeout) || timeout <= 0)
            {
                throw new ApplicationException("Timeout inválido.");
            }

            int delay;
            if (!int.TryParse(txtDelay.Text, out delay) || delay < 0)
            {
                throw new ApplicationException("Delay inválido.");
            }

            return new SaeConfig
            {
                Ambiente = (SaeAmbiente)cboAmbiente.SelectedItem,
                VersaoLayout = txtVersao.Text.Trim(),
                UrlListagem = txtUrlListagem.Text.Trim(),
                UrlDownload = txtUrlDownload.Text.Trim(),
                TimeoutMs = timeout,
                DelayEntreChamadasMs = delay,
                Certificado = ((CertificateComboItem)cboCertificados.SelectedItem).Certificate,
                DiretorioSaida = txtOutputDir.Text.Trim(),
                ListagemNamespace = AppSettingsStore.GetString("ListagemNamespace", "http://www.portalfiscal.inf.br/nfce/sae/listagem"),
                DownloadNamespace = AppSettingsStore.GetString("DownloadNamespace", "http://www.portalfiscal.inf.br/nfce/sae/download"),
                ListagemSoapAction = AppSettingsStore.GetString("ListagemSoapAction", "http://www.portalfiscal.inf.br/nfce/sae/listagem/NFCeListagemChaves"),
                DownloadSoapAction = AppSettingsStore.GetString("DownloadSoapAction", "http://www.portalfiscal.inf.br/nfce/sae/download/NFCeDownloadXML")
            };
        }

        private void RenderDownloadResult(IEnumerable<DownloadResult> results)
        {
            foreach (var item in results)
            {
                foreach (DataGridViewRow row in gridResultados.Rows)
                {
                    var chave = Convert.ToString(row.Cells[3].Value);
                    if (string.Equals(chave, item.Chave, StringComparison.OrdinalIgnoreCase))
                    {
                        row.Cells[5].Value = item.Sucesso ? "OK" : "ERRO";
                        row.Cells[6].Value = item.Sucesso ? item.ArquivoSalvo : item.Mensagem;
                        break;
                    }
                }

                AppendLog(string.Format("{0} | {1} | {2}", item.Chave, item.Sucesso ? "OK" : "ERRO", item.Sucesso ? item.ArquivoSalvo : item.Mensagem));
            }
        }

        private void AppendLog(string text)
        {
            txtLog.AppendText(string.Format("{0:HH:mm:ss} - {1}{2}", DateTime.Now, text, Environment.NewLine));
        }

        private sealed class CertificateComboItem
        {
            public X509Certificate2 Certificate { get; private set; }

            public CertificateComboItem(X509Certificate2 certificate)
            {
                Certificate = certificate;
            }

            public override string ToString()
            {
                return string.Format("{0} | Válido até {1:dd/MM/yyyy} | Thumbprint {2}", Certificate.Subject, Certificate.NotAfter, Certificate.Thumbprint);
            }
        }
    }
}
