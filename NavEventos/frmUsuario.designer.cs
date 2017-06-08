namespace NavEventos
{
    partial class frmUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuario));
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.gbxPermissoes = new System.Windows.Forms.GroupBox();
            this.chkAdm = new System.Windows.Forms.CheckBox();
            this.chkGovernanca = new System.Windows.Forms.CheckBox();
            this.chkCronograma = new System.Windows.Forms.CheckBox();
            this.chkSuporte = new System.Windows.Forms.CheckBox();
            this.chkCadCliente = new System.Windows.Forms.CheckBox();
            this.chkProduto = new System.Windows.Forms.CheckBox();
            this.chkAprovEventos = new System.Windows.Forms.CheckBox();
            this.lvUsuarios = new System.Windows.Forms.ListView();
            this.mnuOculto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExcluir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.chkResetaSenha = new System.Windows.Forms.CheckBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.gpxDados = new System.Windows.Forms.GroupBox();
            this.cboArea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkInativar = new System.Windows.Forms.CheckBox();
            this.lblTotalReg = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gbxPermissoes.SuspendLayout();
            this.mnuOculto.SuspendLayout();
            this.gpxDados.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(9, 57);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(53, 54);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(382, 20);
            this.txtNome.TabIndex = 0;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(53, 80);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(382, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(9, 83);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.White;
            this.txtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.Location = new System.Drawing.Point(53, 106);
            this.txtLogin.MaxLength = 10;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.ReadOnly = true;
            this.txtLogin.Size = new System.Drawing.Size(115, 20);
            this.txtLogin.TabIndex = 2;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(9, 109);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(36, 13);
            this.lblLogin.TabIndex = 6;
            this.lblLogin.Text = "Login:";
            // 
            // gbxPermissoes
            // 
            this.gbxPermissoes.Controls.Add(this.chkAdm);
            this.gbxPermissoes.Controls.Add(this.chkGovernanca);
            this.gbxPermissoes.Controls.Add(this.chkCronograma);
            this.gbxPermissoes.Controls.Add(this.chkSuporte);
            this.gbxPermissoes.Controls.Add(this.chkCadCliente);
            this.gbxPermissoes.Controls.Add(this.chkProduto);
            this.gbxPermissoes.Controls.Add(this.chkAprovEventos);
            this.gbxPermissoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPermissoes.Location = new System.Drawing.Point(453, 57);
            this.gbxPermissoes.Name = "gbxPermissoes";
            this.gbxPermissoes.Size = new System.Drawing.Size(139, 208);
            this.gbxPermissoes.TabIndex = 1;
            this.gbxPermissoes.TabStop = false;
            this.gbxPermissoes.Text = "Permissões";
            // 
            // chkAdm
            // 
            this.chkAdm.AutoSize = true;
            this.chkAdm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdm.Location = new System.Drawing.Point(6, 27);
            this.chkAdm.Name = "chkAdm";
            this.chkAdm.Size = new System.Drawing.Size(89, 17);
            this.chkAdm.TabIndex = 8;
            this.chkAdm.Text = "Administrador";
            this.chkAdm.UseVisualStyleBackColor = true;
            this.chkAdm.CheckedChanged += new System.EventHandler(this.chkAdm_CheckedChanged);
            // 
            // chkGovernanca
            // 
            this.chkGovernanca.AutoSize = true;
            this.chkGovernanca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkGovernanca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGovernanca.Location = new System.Drawing.Point(6, 120);
            this.chkGovernanca.Name = "chkGovernanca";
            this.chkGovernanca.Size = new System.Drawing.Size(85, 17);
            this.chkGovernanca.TabIndex = 7;
            this.chkGovernanca.Text = "Governança";
            this.chkGovernanca.UseVisualStyleBackColor = true;
            // 
            // chkCronograma
            // 
            this.chkCronograma.AutoSize = true;
            this.chkCronograma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkCronograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCronograma.Location = new System.Drawing.Point(6, 97);
            this.chkCronograma.Name = "chkCronograma";
            this.chkCronograma.Size = new System.Drawing.Size(123, 17);
            this.chkCronograma.TabIndex = 4;
            this.chkCronograma.Text = "Atualiza Cronograma";
            this.chkCronograma.UseVisualStyleBackColor = true;
            // 
            // chkSuporte
            // 
            this.chkSuporte.AutoSize = true;
            this.chkSuporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSuporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSuporte.Location = new System.Drawing.Point(6, 167);
            this.chkSuporte.Name = "chkSuporte";
            this.chkSuporte.Size = new System.Drawing.Size(63, 17);
            this.chkSuporte.TabIndex = 6;
            this.chkSuporte.Text = "Suporte";
            this.chkSuporte.UseVisualStyleBackColor = true;
            // 
            // chkCadCliente
            // 
            this.chkCadCliente.AutoSize = true;
            this.chkCadCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkCadCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCadCliente.Location = new System.Drawing.Point(6, 74);
            this.chkCadCliente.Name = "chkCadCliente";
            this.chkCadCliente.Size = new System.Drawing.Size(111, 17);
            this.chkCadCliente.TabIndex = 3;
            this.chkCadCliente.Text = "Cadastrar Clientes";
            this.chkCadCliente.UseVisualStyleBackColor = true;
            // 
            // chkProduto
            // 
            this.chkProduto.AutoSize = true;
            this.chkProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProduto.Location = new System.Drawing.Point(6, 144);
            this.chkProduto.Name = "chkProduto";
            this.chkProduto.Size = new System.Drawing.Size(67, 17);
            this.chkProduto.TabIndex = 5;
            this.chkProduto.Text = "Capacity";
            this.chkProduto.UseVisualStyleBackColor = true;
            // 
            // chkAprovEventos
            // 
            this.chkAprovEventos.AutoSize = true;
            this.chkAprovEventos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAprovEventos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAprovEventos.Location = new System.Drawing.Point(6, 50);
            this.chkAprovEventos.Name = "chkAprovEventos";
            this.chkAprovEventos.Size = new System.Drawing.Size(110, 17);
            this.chkAprovEventos.TabIndex = 1;
            this.chkAprovEventos.Text = "Cadastra Eventos";
            this.chkAprovEventos.UseVisualStyleBackColor = true;
            // 
            // lvUsuarios
            // 
            this.lvUsuarios.ContextMenuStrip = this.mnuOculto;
            this.lvUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvUsuarios.Location = new System.Drawing.Point(6, 271);
            this.lvUsuarios.Name = "lvUsuarios";
            this.lvUsuarios.Size = new System.Drawing.Size(586, 173);
            this.lvUsuarios.TabIndex = 0;
            this.lvUsuarios.UseCompatibleStateImageBehavior = false;
            this.lvUsuarios.SelectedIndexChanged += new System.EventHandler(this.lvUsuarios_SelectedIndexChanged);
            this.lvUsuarios.Click += new System.EventHandler(this.lvwUsuarios_Click);
            // 
            // mnuOculto
            // 
            this.mnuOculto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExcluir,
            this.toolStripSeparator2,
            this.mnuRefresh});
            this.mnuOculto.Name = "mnuOculto";
            this.mnuOculto.Size = new System.Drawing.Size(114, 54);
            // 
            // mnuExcluir
            // 
            this.mnuExcluir.Image = ((System.Drawing.Image)(resources.GetObject("mnuExcluir.Image")));
            this.mnuExcluir.Name = "mnuExcluir";
            this.mnuExcluir.Size = new System.Drawing.Size(113, 22);
            this.mnuExcluir.Text = "Excluir";
            this.mnuExcluir.Click += new System.EventHandler(this.mnuExcluir_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(110, 6);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuRefresh.Image")));
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(113, 22);
            this.mnuRefresh.Text = "Refresh";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // chkResetaSenha
            // 
            this.chkResetaSenha.AutoSize = true;
            this.chkResetaSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkResetaSenha.Location = new System.Drawing.Point(53, 132);
            this.chkResetaSenha.Name = "chkResetaSenha";
            this.chkResetaSenha.Size = new System.Drawing.Size(167, 17);
            this.chkResetaSenha.TabIndex = 3;
            this.chkResetaSenha.Text = "Resetar Senha (Default 1234)";
            this.chkResetaSenha.UseVisualStyleBackColor = true;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(53, 28);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(115, 20);
            this.txtID.TabIndex = 10;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(9, 31);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 11;
            this.lblID.Text = "ID:";
            // 
            // gpxDados
            // 
            this.gpxDados.Controls.Add(this.cboArea);
            this.gpxDados.Controls.Add(this.label1);
            this.gpxDados.Controls.Add(this.chkInativar);
            this.gpxDados.Controls.Add(this.txtID);
            this.gpxDados.Controls.Add(this.lblNome);
            this.gpxDados.Controls.Add(this.lblID);
            this.gpxDados.Controls.Add(this.txtNome);
            this.gpxDados.Controls.Add(this.chkResetaSenha);
            this.gpxDados.Controls.Add(this.lblEmail);
            this.gpxDados.Controls.Add(this.txtEmail);
            this.gpxDados.Controls.Add(this.lblLogin);
            this.gpxDados.Controls.Add(this.txtLogin);
            this.gpxDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpxDados.Location = new System.Drawing.Point(6, 57);
            this.gpxDados.Name = "gpxDados";
            this.gpxDados.Size = new System.Drawing.Size(441, 208);
            this.gpxDados.TabIndex = 1;
            this.gpxDados.TabStop = false;
            this.gpxDados.Text = "Informações do Usuário";
            // 
            // cboArea
            // 
            this.cboArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboArea.FormattingEnabled = true;
            this.cboArea.Location = new System.Drawing.Point(53, 178);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(181, 21);
            this.cboArea.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Área:";
            // 
            // chkInativar
            // 
            this.chkInativar.AutoSize = true;
            this.chkInativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInativar.Location = new System.Drawing.Point(53, 155);
            this.chkInativar.Name = "chkInativar";
            this.chkInativar.Size = new System.Drawing.Size(50, 17);
            this.chkInativar.TabIndex = 12;
            this.chkInativar.Text = "Ativo";
            this.chkInativar.UseVisualStyleBackColor = true;
            // 
            // lblTotalReg
            // 
            this.lblTotalReg.AutoSize = true;
            this.lblTotalReg.Location = new System.Drawing.Point(12, 447);
            this.lblTotalReg.Name = "lblTotalReg";
            this.lblTotalReg.Size = new System.Drawing.Size(0, 13);
            this.lblTotalReg.TabIndex = 13;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSalvar,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(602, 54);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnSalvar
            // 
            this.tsbtnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSalvar.Image")));
            this.tsbtnSalvar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSalvar.Name = "tsbtnSalvar";
            this.tsbtnSalvar.Size = new System.Drawing.Size(42, 51);
            this.tsbtnSalvar.Text = "Salvar";
            this.tsbtnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSalvar.Click += new System.EventHandler(this.tsbtnSalvar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 466);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblTotalReg);
            this.Controls.Add(this.gpxDados);
            this.Controls.Add(this.lvUsuarios);
            this.Controls.Add(this.gbxPermissoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuários";
            this.Load += new System.EventHandler(this.frmUsuario_Load);
            this.gbxPermissoes.ResumeLayout(false);
            this.gbxPermissoes.PerformLayout();
            this.mnuOculto.ResumeLayout(false);
            this.gpxDados.ResumeLayout(false);
            this.gpxDados.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.GroupBox gbxPermissoes;
        private System.Windows.Forms.CheckBox chkCronograma;
        private System.Windows.Forms.CheckBox chkSuporte;
        private System.Windows.Forms.CheckBox chkCadCliente;
        private System.Windows.Forms.CheckBox chkProduto;
        private System.Windows.Forms.CheckBox chkAprovEventos;
        private System.Windows.Forms.ListView lvUsuarios;
        private System.Windows.Forms.CheckBox chkResetaSenha;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.GroupBox gpxDados;
        private System.Windows.Forms.Label lblTotalReg;
        private System.Windows.Forms.ContextMenuStrip mnuOculto;
        private System.Windows.Forms.ToolStripMenuItem mnuExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnSalvar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckBox chkGovernanca;
        private System.Windows.Forms.CheckBox chkAdm;
        private System.Windows.Forms.CheckBox chkInativar;
        private System.Windows.Forms.ComboBox cboArea;
        private System.Windows.Forms.Label label1;
    }
}