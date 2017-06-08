namespace NavEventos
{
    partial class frmClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientes));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvClientes = new System.Windows.Forms.ListView();
            this.mnuOculto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExcluir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalReg = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.ttpBalon = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOculto.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(53, 56);
            this.txtNome.Multiline = true;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(346, 50);
            this.txtNome.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nome:";
            // 
            // lvClientes
            // 
            this.lvClientes.ContextMenuStrip = this.mnuOculto;
            this.lvClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvClientes.Location = new System.Drawing.Point(14, 210);
            this.lvClientes.Name = "lvClientes";
            this.lvClientes.Size = new System.Drawing.Size(405, 243);
            this.lvClientes.TabIndex = 0;
            this.ttpBalon.SetToolTip(this.lvClientes, "clique com o botão direito do mouse\r\n");
            this.lvClientes.UseCompatibleStateImageBehavior = false;
            this.lvClientes.SelectedIndexChanged += new System.EventHandler(this.lvClientes_SelectedIndexChanged);
            this.lvClientes.Click += new System.EventHandler(this.lvClientes_Click);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 479);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(425, 22);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblMsg
            // 
            this.tsslblMsg.AutoSize = false;
            this.tsslblMsg.ForeColor = System.Drawing.Color.Red;
            this.tsslblMsg.Name = "tsslblMsg";
            this.tsslblMsg.Size = new System.Drawing.Size(400, 17);
            this.tsslblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalReg
            // 
            this.lblTotalReg.AutoSize = true;
            this.lblTotalReg.Location = new System.Drawing.Point(11, 456);
            this.lblTotalReg.Name = "lblTotalReg";
            this.lblTotalReg.Size = new System.Drawing.Size(0, 13);
            this.lblTotalReg.TabIndex = 26;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(53, 30);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(115, 20);
            this.txtID.TabIndex = 28;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(9, 33);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 29;
            this.lblID.Text = "ID:";
            // 
            // ttpBalon
            // 
            this.ttpBalon.ForeColor = System.Drawing.Color.Blue;
            this.ttpBalon.IsBalloon = true;
            this.ttpBalon.ToolTipTitle = "Sistema";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 114);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações do Cliente";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(12, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(401, 33);
            this.label2.TabIndex = 32;
            this.label2.Text = "O Nome do cliente deverá seguir o padrão da manifestação de clientes. Em caso de " +
    "duvida alinhar com o atendimento.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(217, 456);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Pressione [F5] para atualizar o Formulário";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNovo,
            this.toolStripSeparator3,
            this.tsbtnSalvar,
            this.toolStripSeparator2,
            this.tsbtnRefresh,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(425, 54);
            this.toolStrip1.TabIndex = 35;
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 54);
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 501);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotalReg);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.frmClientes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmClientes_KeyDown);
            this.mnuOculto.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvClientes;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblMsg;
        private System.Windows.Forms.Label lblTotalReg;
        private System.Windows.Forms.ContextMenuStrip mnuOculto;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ToolTip ttpBalon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuExcluir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnSalvar;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnNovo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}