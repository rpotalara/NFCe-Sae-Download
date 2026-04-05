namespace NfceSaeDownloader.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAmbiente = new System.Windows.Forms.Label();
            this.cboAmbiente = new System.Windows.Forms.ComboBox();
            this.lblStoreLocation = new System.Windows.Forms.Label();
            this.cboStoreLocation = new System.Windows.Forms.ComboBox();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.cboStoreName = new System.Windows.Forms.ComboBox();
            this.lblCertificados = new System.Windows.Forms.Label();
            this.cboCertificados = new System.Windows.Forms.ComboBox();
            this.btnAtualizarCertificados = new System.Windows.Forms.Button();
            this.lblDataInicial = new System.Windows.Forms.Label();
            this.dtIni = new System.Windows.Forms.DateTimePicker();
            this.lblDataFinal = new System.Windows.Forms.Label();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.chkAutoDividir = new System.Windows.Forms.CheckBox();
            this.lblVersao = new System.Windows.Forms.Label();
            this.txtVersao = new System.Windows.Forms.TextBox();
            this.lblUrlListagem = new System.Windows.Forms.Label();
            this.txtUrlListagem = new System.Windows.Forms.TextBox();
            this.lblUrlDownload = new System.Windows.Forms.Label();
            this.txtUrlDownload = new System.Windows.Forms.TextBox();
            this.lblOutputDir = new System.Windows.Forms.Label();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.btnPastaSaida = new System.Windows.Forms.Button();
            this.lblDelay = new System.Windows.Forms.Label();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnBaixarSelecionados = new System.Windows.Forms.Button();
            this.btnBaixarTodos = new System.Windows.Forms.Button();
            this.lblCursor = new System.Windows.Forms.Label();
            this.txtCursor = new System.Windows.Forms.TextBox();
            this.btnUsarCursor = new System.Windows.Forms.Button();
            this.gridResultados = new System.Windows.Forms.DataGridView();
            this.colSelecionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDhEmissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados)).BeginInit();
            this.SuspendLayout();
            //
            // lblAmbiente
            //
            this.lblAmbiente.AutoSize = true;
            this.lblAmbiente.Location = new System.Drawing.Point(12, 15);
            this.lblAmbiente.Name = "lblAmbiente";
            this.lblAmbiente.Size = new System.Drawing.Size(58, 13);
            this.lblAmbiente.TabIndex = 0;
            this.lblAmbiente.Text = "Ambiente:";
            //
            // cboAmbiente
            //
            this.cboAmbiente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAmbiente.FormattingEnabled = true;
            this.cboAmbiente.Location = new System.Drawing.Point(76, 12);
            this.cboAmbiente.Name = "cboAmbiente";
            this.cboAmbiente.Size = new System.Drawing.Size(135, 21);
            this.cboAmbiente.TabIndex = 1;
            this.cboAmbiente.SelectedIndexChanged += new System.EventHandler(this.cboAmbiente_SelectedIndexChanged);
            //
            // lblStoreLocation
            //
            this.lblStoreLocation.AutoSize = true;
            this.lblStoreLocation.Location = new System.Drawing.Point(227, 15);
            this.lblStoreLocation.Name = "lblStoreLocation";
            this.lblStoreLocation.Size = new System.Drawing.Size(76, 13);
            this.lblStoreLocation.TabIndex = 2;
            this.lblStoreLocation.Text = "StoreLocation:";
            //
            // cboStoreLocation
            //
            this.cboStoreLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStoreLocation.FormattingEnabled = true;
            this.cboStoreLocation.Location = new System.Drawing.Point(309, 12);
            this.cboStoreLocation.Name = "cboStoreLocation";
            this.cboStoreLocation.Size = new System.Drawing.Size(121, 21);
            this.cboStoreLocation.TabIndex = 3;
            //
            // lblStoreName
            //
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.Location = new System.Drawing.Point(446, 15);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(64, 13);
            this.lblStoreName.TabIndex = 4;
            this.lblStoreName.Text = "StoreName:";
            //
            // cboStoreName
            //
            this.cboStoreName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStoreName.FormattingEnabled = true;
            this.cboStoreName.Location = new System.Drawing.Point(516, 12);
            this.cboStoreName.Name = "cboStoreName";
            this.cboStoreName.Size = new System.Drawing.Size(121, 21);
            this.cboStoreName.TabIndex = 5;
            //
            // lblCertificados
            //
            this.lblCertificados.AutoSize = true;
            this.lblCertificados.Location = new System.Drawing.Point(12, 45);
            this.lblCertificados.Name = "lblCertificados";
            this.lblCertificados.Size = new System.Drawing.Size(60, 13);
            this.lblCertificados.TabIndex = 6;
            this.lblCertificados.Text = "Certificado:";
            //
            // cboCertificados
            //
            this.cboCertificados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCertificados.FormattingEnabled = true;
            this.cboCertificados.Location = new System.Drawing.Point(76, 42);
            this.cboCertificados.Name = "cboCertificados";
            this.cboCertificados.Size = new System.Drawing.Size(792, 21);
            this.cboCertificados.TabIndex = 7;
            //
            // btnAtualizarCertificados
            //
            this.btnAtualizarCertificados.Location = new System.Drawing.Point(874, 40);
            this.btnAtualizarCertificados.Name = "btnAtualizarCertificados";
            this.btnAtualizarCertificados.Size = new System.Drawing.Size(102, 23);
            this.btnAtualizarCertificados.TabIndex = 8;
            this.btnAtualizarCertificados.Text = "Atualizar";
            this.btnAtualizarCertificados.UseVisualStyleBackColor = true;
            this.btnAtualizarCertificados.Click += new System.EventHandler(this.btnAtualizarCertificados_Click);
            //
            // lblDataInicial
            //
            this.lblDataInicial.AutoSize = true;
            this.lblDataInicial.Location = new System.Drawing.Point(12, 78);
            this.lblDataInicial.Name = "lblDataInicial";
            this.lblDataInicial.Size = new System.Drawing.Size(63, 13);
            this.lblDataInicial.TabIndex = 9;
            this.lblDataInicial.Text = "Data inicial:";
            //
            // dtIni
            //
            this.dtIni.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIni.Location = new System.Drawing.Point(76, 72);
            this.dtIni.Name = "dtIni";
            this.dtIni.Size = new System.Drawing.Size(165, 20);
            this.dtIni.TabIndex = 10;
            //
            // lblDataFinal
            //
            this.lblDataFinal.AutoSize = true;
            this.lblDataFinal.Location = new System.Drawing.Point(258, 78);
            this.lblDataFinal.Name = "lblDataFinal";
            this.lblDataFinal.Size = new System.Drawing.Size(58, 13);
            this.lblDataFinal.TabIndex = 11;
            this.lblDataFinal.Text = "Data final:";
            //
            // dtFim
            //
            this.dtFim.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFim.Location = new System.Drawing.Point(322, 72);
            this.dtFim.Name = "dtFim";
            this.dtFim.Size = new System.Drawing.Size(165, 20);
            this.dtFim.TabIndex = 12;
            //
            // lblNumero
            //
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(505, 78);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(47, 13);
            this.lblNumero.TabIndex = 13;
            this.lblNumero.Text = "Número:";
            //
            // txtNumero
            //
            this.txtNumero.Location = new System.Drawing.Point(558, 72);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(111, 20);
            this.txtNumero.TabIndex = 14;
            //
            // lblSerie
            //
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(684, 78);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(34, 13);
            this.lblSerie.TabIndex = 15;
            this.lblSerie.Text = "Série:";
            //
            // txtSerie
            //
            this.txtSerie.Location = new System.Drawing.Point(724, 72);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(74, 20);
            this.txtSerie.TabIndex = 16;
            //
            // chkAutoDividir
            //
            this.chkAutoDividir.AutoSize = true;
            this.chkAutoDividir.Location = new System.Drawing.Point(816, 74);
            this.chkAutoDividir.Name = "chkAutoDividir";
            this.chkAutoDividir.Size = new System.Drawing.Size(160, 17);
            this.chkAutoDividir.TabIndex = 17;
            this.chkAutoDividir.Text = "Auto dividir se cStat = 101";
            this.chkAutoDividir.UseVisualStyleBackColor = true;
            //
            // lblVersao
            //
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(12, 107);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(46, 13);
            this.lblVersao.TabIndex = 18;
            this.lblVersao.Text = "Versão:";
            //
            // txtVersao
            //
            this.txtVersao.Location = new System.Drawing.Point(76, 104);
            this.txtVersao.Name = "txtVersao";
            this.txtVersao.Size = new System.Drawing.Size(80, 20);
            this.txtVersao.TabIndex = 19;
            //
            // lblUrlListagem
            //
            this.lblUrlListagem.AutoSize = true;
            this.lblUrlListagem.Location = new System.Drawing.Point(172, 107);
            this.lblUrlListagem.Name = "lblUrlListagem";
            this.lblUrlListagem.Size = new System.Drawing.Size(77, 13);
            this.lblUrlListagem.TabIndex = 20;
            this.lblUrlListagem.Text = "URL Listagem:";
            //
            // txtUrlListagem
            //
            this.txtUrlListagem.Location = new System.Drawing.Point(255, 104);
            this.txtUrlListagem.Name = "txtUrlListagem";
            this.txtUrlListagem.Size = new System.Drawing.Size(721, 20);
            this.txtUrlListagem.TabIndex = 21;
            //
            // lblUrlDownload
            //
            this.lblUrlDownload.AutoSize = true;
            this.lblUrlDownload.Location = new System.Drawing.Point(12, 137);
            this.lblUrlDownload.Name = "lblUrlDownload";
            this.lblUrlDownload.Size = new System.Drawing.Size(80, 13);
            this.lblUrlDownload.TabIndex = 22;
            this.lblUrlDownload.Text = "URL Download:";
            //
            // txtUrlDownload
            //
            this.txtUrlDownload.Location = new System.Drawing.Point(98, 134);
            this.txtUrlDownload.Name = "txtUrlDownload";
            this.txtUrlDownload.Size = new System.Drawing.Size(878, 20);
            this.txtUrlDownload.TabIndex = 23;
            //
            // lblOutputDir
            //
            this.lblOutputDir.AutoSize = true;
            this.lblOutputDir.Location = new System.Drawing.Point(12, 167);
            this.lblOutputDir.Name = "lblOutputDir";
            this.lblOutputDir.Size = new System.Drawing.Size(93, 13);
            this.lblOutputDir.TabIndex = 24;
            this.lblOutputDir.Text = "Diretório de saída:";
            //
            // txtOutputDir
            //
            this.txtOutputDir.Location = new System.Drawing.Point(111, 164);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(757, 20);
            this.txtOutputDir.TabIndex = 25;
            //
            // btnPastaSaida
            //
            this.btnPastaSaida.Location = new System.Drawing.Point(874, 162);
            this.btnPastaSaida.Name = "btnPastaSaida";
            this.btnPastaSaida.Size = new System.Drawing.Size(102, 23);
            this.btnPastaSaida.TabIndex = 26;
            this.btnPastaSaida.Text = "Selecionar...";
            this.btnPastaSaida.UseVisualStyleBackColor = true;
            this.btnPastaSaida.Click += new System.EventHandler(this.btnPastaSaida_Click);
            //
            // lblDelay
            //
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(12, 197);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(81, 13);
            this.lblDelay.TabIndex = 27;
            this.lblDelay.Text = "Delay (ms):";
            //
            // txtDelay
            //
            this.txtDelay.Location = new System.Drawing.Point(99, 194);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(85, 20);
            this.txtDelay.TabIndex = 28;
            //
            // lblTimeout
            //
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Location = new System.Drawing.Point(209, 197);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(74, 13);
            this.lblTimeout.TabIndex = 29;
            this.lblTimeout.Text = "Timeout (ms):";
            //
            // txtTimeout
            //
            this.txtTimeout.Location = new System.Drawing.Point(289, 194);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(102, 20);
            this.txtTimeout.TabIndex = 30;
            //
            // btnConsultar
            //
            this.btnConsultar.Location = new System.Drawing.Point(412, 191);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(122, 24);
            this.btnConsultar.TabIndex = 31;
            this.btnConsultar.Text = "1. Consultar chaves";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            //
            // btnBaixarSelecionados
            //
            this.btnBaixarSelecionados.Location = new System.Drawing.Point(540, 191);
            this.btnBaixarSelecionados.Name = "btnBaixarSelecionados";
            this.btnBaixarSelecionados.Size = new System.Drawing.Size(147, 24);
            this.btnBaixarSelecionados.TabIndex = 32;
            this.btnBaixarSelecionados.Text = "2. Baixar selecionados";
            this.btnBaixarSelecionados.UseVisualStyleBackColor = true;
            this.btnBaixarSelecionados.Click += new System.EventHandler(this.btnBaixarSelecionados_Click);
            //
            // btnBaixarTodos
            //
            this.btnBaixarTodos.Location = new System.Drawing.Point(693, 191);
            this.btnBaixarTodos.Name = "btnBaixarTodos";
            this.btnBaixarTodos.Size = new System.Drawing.Size(126, 24);
            this.btnBaixarTodos.TabIndex = 33;
            this.btnBaixarTodos.Text = "3. Baixar todos";
            this.btnBaixarTodos.UseVisualStyleBackColor = true;
            this.btnBaixarTodos.Click += new System.EventHandler(this.btnBaixarTodos_Click);
            //
            // lblCursor
            //
            this.lblCursor.AutoSize = true;
            this.lblCursor.Location = new System.Drawing.Point(12, 228);
            this.lblCursor.Name = "lblCursor";
            this.lblCursor.Size = new System.Drawing.Size(95, 13);
            this.lblCursor.TabIndex = 34;
            this.lblCursor.Text = "Cursor incremental:";
            //
            // txtCursor
            //
            this.txtCursor.Location = new System.Drawing.Point(111, 225);
            this.txtCursor.Name = "txtCursor";
            this.txtCursor.Size = new System.Drawing.Size(219, 20);
            this.txtCursor.TabIndex = 35;
            //
            // btnUsarCursor
            //
            this.btnUsarCursor.Location = new System.Drawing.Point(336, 223);
            this.btnUsarCursor.Name = "btnUsarCursor";
            this.btnUsarCursor.Size = new System.Drawing.Size(125, 23);
            this.btnUsarCursor.TabIndex = 36;
            this.btnUsarCursor.Text = "Usar como data inicial";
            this.btnUsarCursor.UseVisualStyleBackColor = true;
            this.btnUsarCursor.Click += new System.EventHandler(this.btnUsarCursor_Click);
            //
            // gridResultados
            //
            this.gridResultados.AllowUserToAddRows = false;
            this.gridResultados.AllowUserToDeleteRows = false;
            this.gridResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelecionar,
            this.colNumero,
            this.colSerie,
            this.colChave,
            this.colDhEmissao,
            this.colStatus,
            this.colResultado});
            this.gridResultados.Location = new System.Drawing.Point(15, 258);
            this.gridResultados.Name = "gridResultados";
            this.gridResultados.Size = new System.Drawing.Size(961, 289);
            this.gridResultados.TabIndex = 37;
            //
            // colSelecionar
            //
            this.colSelecionar.HeaderText = "Sel.";
            this.colSelecionar.Name = "colSelecionar";
            this.colSelecionar.Width = 40;
            //
            // colNumero
            //
            this.colNumero.HeaderText = "Número";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 80;
            //
            // colSerie
            //
            this.colSerie.HeaderText = "Série";
            this.colSerie.Name = "colSerie";
            this.colSerie.ReadOnly = true;
            this.colSerie.Width = 60;
            //
            // colChave
            //
            this.colChave.HeaderText = "Chave";
            this.colChave.Name = "colChave";
            this.colChave.ReadOnly = true;
            this.colChave.Width = 280;
            //
            // colDhEmissao
            //
            this.colDhEmissao.HeaderText = "Dh emissão";
            this.colDhEmissao.Name = "colDhEmissao";
            this.colDhEmissao.ReadOnly = true;
            this.colDhEmissao.Width = 120;
            //
            // colStatus
            //
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 70;
            //
            // colResultado
            //
            this.colResultado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colResultado.HeaderText = "Arquivo / Mensagem";
            this.colResultado.Name = "colResultado";
            this.colResultado.ReadOnly = true;
            //
            // txtLog
            //
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(15, 553);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(961, 115);
            this.txtLog.TabIndex = 38;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 680);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.gridResultados);
            this.Controls.Add(this.btnUsarCursor);
            this.Controls.Add(this.txtCursor);
            this.Controls.Add(this.lblCursor);
            this.Controls.Add(this.btnBaixarTodos);
            this.Controls.Add(this.btnBaixarSelecionados);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.txtTimeout);
            this.Controls.Add(this.lblTimeout);
            this.Controls.Add(this.txtDelay);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.btnPastaSaida);
            this.Controls.Add(this.txtOutputDir);
            this.Controls.Add(this.lblOutputDir);
            this.Controls.Add(this.txtUrlDownload);
            this.Controls.Add(this.lblUrlDownload);
            this.Controls.Add(this.txtUrlListagem);
            this.Controls.Add(this.lblUrlListagem);
            this.Controls.Add(this.txtVersao);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.chkAutoDividir);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.lblSerie);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.dtFim);
            this.Controls.Add(this.lblDataFinal);
            this.Controls.Add(this.dtIni);
            this.Controls.Add(this.lblDataInicial);
            this.Controls.Add(this.btnAtualizarCertificados);
            this.Controls.Add(this.cboCertificados);
            this.Controls.Add(this.lblCertificados);
            this.Controls.Add(this.cboStoreName);
            this.Controls.Add(this.lblStoreName);
            this.Controls.Add(this.cboStoreLocation);
            this.Controls.Add(this.lblStoreLocation);
            this.Controls.Add(this.cboAmbiente);
            this.Controls.Add(this.lblAmbiente);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAE-NFC-e Downloader - SEFAZ/SP";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblAmbiente;
        private System.Windows.Forms.ComboBox cboAmbiente;
        private System.Windows.Forms.Label lblStoreLocation;
        private System.Windows.Forms.ComboBox cboStoreLocation;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.ComboBox cboStoreName;
        private System.Windows.Forms.Label lblCertificados;
        private System.Windows.Forms.ComboBox cboCertificados;
        private System.Windows.Forms.Button btnAtualizarCertificados;
        private System.Windows.Forms.Label lblDataInicial;
        private System.Windows.Forms.DateTimePicker dtIni;
        private System.Windows.Forms.Label lblDataFinal;
        private System.Windows.Forms.DateTimePicker dtFim;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.CheckBox chkAutoDividir;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.TextBox txtVersao;
        private System.Windows.Forms.Label lblUrlListagem;
        private System.Windows.Forms.TextBox txtUrlListagem;
        private System.Windows.Forms.Label lblUrlDownload;
        private System.Windows.Forms.TextBox txtUrlDownload;
        private System.Windows.Forms.Label lblOutputDir;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Button btnPastaSaida;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.TextBox txtDelay;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnBaixarSelecionados;
        private System.Windows.Forms.Button btnBaixarTodos;
        private System.Windows.Forms.Label lblCursor;
        private System.Windows.Forms.TextBox txtCursor;
        private System.Windows.Forms.Button btnUsarCursor;
        private System.Windows.Forms.DataGridView gridResultados;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelecionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDhEmissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultado;
    }
}
