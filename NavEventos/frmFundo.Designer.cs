namespace NavEventos
{
    partial class frmFundo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFundo));
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mktCnpjCpf = new System.Windows.Forms.MaskedTextBox();
            this.rbCpf = new System.Windows.Forms.RadioButton();
            this.rbCnpj = new System.Windows.Forms.RadioButton();
            this.txtSiglaFy = new System.Windows.Forms.TextBox();
            this.lblSiglaFY = new System.Windows.Forms.Label();
            this.txtSiglaSac = new System.Windows.Forms.TextBox();
            this.lblSiglaSAC = new System.Windows.Forms.Label();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.lblRazaoSocial = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvFundo = new System.Windows.Forms.ListView();
            this.mnuOculto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExcluir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotalReg = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnImportar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsprbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.mnuOculto.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(465, 420);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 13);
            this.label3.TabIndex = 82;
            this.label3.Text = "Pressione [F5] para atualizar o Formulário";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mktCnpjCpf);
            this.groupBox1.Controls.Add(this.rbCpf);
            this.groupBox1.Controls.Add(this.rbCnpj);
            this.groupBox1.Controls.Add(this.txtSiglaFy);
            this.groupBox1.Controls.Add(this.lblSiglaFY);
            this.groupBox1.Controls.Add(this.txtSiglaSac);
            this.groupBox1.Controls.Add(this.lblSiglaSAC);
            this.groupBox1.Controls.Add(this.txtRazaoSocial);
            this.groupBox1.Controls.Add(this.lblRazaoSocial);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 145);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações do Fundo";
            // 
            // mktCnpjCpf
            // 
            this.mktCnpjCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mktCnpjCpf.Location = new System.Drawing.Point(98, 118);
            this.mktCnpjCpf.Name = "mktCnpjCpf";
            this.mktCnpjCpf.Size = new System.Drawing.Size(125, 20);
            this.mktCnpjCpf.TabIndex = 6;
            // 
            // rbCpf
            // 
            this.rbCpf.AutoSize = true;
            this.rbCpf.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbCpf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCpf.Location = new System.Drawing.Point(55, 108);
            this.rbCpf.Name = "rbCpf";
            this.rbCpf.Size = new System.Drawing.Size(31, 30);
            this.rbCpf.TabIndex = 5;
            this.rbCpf.TabStop = true;
            this.rbCpf.Text = "CPF";
            this.rbCpf.UseVisualStyleBackColor = true;
            this.rbCpf.CheckedChanged += new System.EventHandler(this.rbCpf_CheckedChanged);
            // 
            // rbCnpj
            // 
            this.rbCnpj.AutoSize = true;
            this.rbCnpj.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbCnpj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbCnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCnpj.Location = new System.Drawing.Point(12, 108);
            this.rbCnpj.Name = "rbCnpj";
            this.rbCnpj.Size = new System.Drawing.Size(38, 30);
            this.rbCnpj.TabIndex = 4;
            this.rbCnpj.TabStop = true;
            this.rbCnpj.Text = "CNPJ";
            this.rbCnpj.UseVisualStyleBackColor = true;
            this.rbCnpj.CheckedChanged += new System.EventHandler(this.rbCnpj_CheckedChanged);
            // 
            // txtSiglaFy
            // 
            this.txtSiglaFy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSiglaFy.Location = new System.Drawing.Point(98, 81);
            this.txtSiglaFy.Name = "txtSiglaFy";
            this.txtSiglaFy.Size = new System.Drawing.Size(125, 20);
            this.txtSiglaFy.TabIndex = 3;
            // 
            // lblSiglaFY
            // 
            this.lblSiglaFY.AutoSize = true;
            this.lblSiglaFY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiglaFY.Location = new System.Drawing.Point(13, 84);
            this.lblSiglaFY.Name = "lblSiglaFY";
            this.lblSiglaFY.Size = new System.Drawing.Size(49, 13);
            this.lblSiglaFY.TabIndex = 87;
            this.lblSiglaFY.Text = "Sigla FY:";
            // 
            // txtSiglaSac
            // 
            this.txtSiglaSac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSiglaSac.Location = new System.Drawing.Point(98, 55);
            this.txtSiglaSac.Name = "txtSiglaSac";
            this.txtSiglaSac.Size = new System.Drawing.Size(125, 20);
            this.txtSiglaSac.TabIndex = 2;
            // 
            // lblSiglaSAC
            // 
            this.lblSiglaSAC.AutoSize = true;
            this.lblSiglaSAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiglaSAC.Location = new System.Drawing.Point(13, 58);
            this.lblSiglaSAC.Name = "lblSiglaSAC";
            this.lblSiglaSAC.Size = new System.Drawing.Size(57, 13);
            this.lblSiglaSAC.TabIndex = 85;
            this.lblSiglaSAC.Text = "Sigla SAC:";
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazaoSocial.Location = new System.Drawing.Point(98, 29);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(488, 20);
            this.txtRazaoSocial.TabIndex = 1;
            // 
            // lblRazaoSocial
            // 
            this.lblRazaoSocial.AutoSize = true;
            this.lblRazaoSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazaoSocial.Location = new System.Drawing.Point(13, 32);
            this.lblRazaoSocial.Name = "lblRazaoSocial";
            this.lblRazaoSocial.Size = new System.Drawing.Size(73, 13);
            this.lblRazaoSocial.TabIndex = 80;
            this.lblRazaoSocial.Text = "Razão Social:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(676, 22);
            this.statusStrip1.TabIndex = 84;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblMsg
            // 
            this.tsslblMsg.AutoSize = false;
            this.tsslblMsg.ForeColor = System.Drawing.Color.Red;
            this.tsslblMsg.Name = "tsslblMsg";
            this.tsslblMsg.Size = new System.Drawing.Size(600, 17);
            this.tsslblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvFundo
            // 
            this.lvFundo.ContextMenuStrip = this.mnuOculto;
            this.lvFundo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvFundo.Location = new System.Drawing.Point(12, 210);
            this.lvFundo.Name = "lvFundo";
            this.lvFundo.Size = new System.Drawing.Size(653, 207);
            this.lvFundo.TabIndex = 0;
            this.lvFundo.UseCompatibleStateImageBehavior = false;
            this.lvFundo.SelectedIndexChanged += new System.EventHandler(this.lvFundo_SelectedIndexChanged);
            this.lvFundo.Click += new System.EventHandler(this.lvFundo_Click);
            // 
            // mnuOculto
            // 
            this.mnuOculto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExcluir,
            this.toolStripSeparator1,
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(110, 6);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuRefresh.Image")));
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(113, 22);
            this.mnuRefresh.Text = "Refresh";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // lblTotalReg
            // 
            this.lblTotalReg.AutoSize = true;
            this.lblTotalReg.Location = new System.Drawing.Point(16, 420);
            this.lblTotalReg.Name = "lblTotalReg";
            this.lblTotalReg.Size = new System.Drawing.Size(0, 13);
            this.lblTotalReg.TabIndex = 86;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(461, 269);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(49, 20);
            this.txtID.TabIndex = 88;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNovo,
            this.toolStripSeparator3,
            this.tsbtnSalvar,
            this.toolStripSeparator2,
            this.tsbtnRefresh,
            this.toolStripSeparator4,
            this.tsbtnImportar,
            this.toolStripSeparator5,
            this.tsprbProgress});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(676, 54);
            this.toolStrip1.TabIndex = 89;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnNovo
            // 
            this.tsbtnNovo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNovo.Image")));
            this.tsbtnNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNovo.Name = "tsbtnNovo";
            this.tsbtnNovo.Size = new System.Drawing.Size(40, 51);
            this.tsbtnNovo.Text = "Novo";
            this.tsbtnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnNovo.Click += new System.EventHandler(this.tsbtnNovo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 54);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefresh.Image")));
            this.tsbtnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(50, 51);
            this.tsbtnRefresh.Text = "Refresh";
            this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 54);
            // 
            // tsbtnImportar
            // 
            this.tsbtnImportar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnImportar.Image")));
            this.tsbtnImportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnImportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnImportar.Name = "tsbtnImportar";
            this.tsbtnImportar.Size = new System.Drawing.Size(57, 51);
            this.tsbtnImportar.Text = "Importar";
            this.tsbtnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnImportar.Click += new System.EventHandler(this.tsbtnImportar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 54);
            // 
            // tsprbProgress
            // 
            this.tsprbProgress.Name = "tsprbProgress";
            this.tsprbProgress.Size = new System.Drawing.Size(100, 51);
            this.tsprbProgress.Visible = false;
            // 
            // frmFundo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 461);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblTotalReg);
            this.Controls.Add(this.lvFundo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFundo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fundo";
            this.Load += new System.EventHandler(this.frmFundo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFundo_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mnuOculto.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox mktCnpjCpf;
        private System.Windows.Forms.RadioButton rbCpf;
        private System.Windows.Forms.RadioButton rbCnpj;
        private System.Windows.Forms.TextBox txtSiglaFy;
        private System.Windows.Forms.Label lblSiglaFY;
        private System.Windows.Forms.TextBox txtSiglaSac;
        private System.Windows.Forms.Label lblSiglaSAC;
        private System.Windows.Forms.TextBox txtRazaoSocial;
        private System.Windows.Forms.Label lblRazaoSocial;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblMsg;
        private System.Windows.Forms.ListView lvFundo;
        private System.Windows.Forms.Label lblTotalReg;
        private System.Windows.Forms.ContextMenuStrip mnuOculto;
        private System.Windows.Forms.ToolStripMenuItem mnuExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnSalvar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripButton tsbtnNovo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtnImportar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripProgressBar tsprbProgress;
    }
}