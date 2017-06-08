namespace NavEventos
{
    partial class frmSetor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetor));
            this.gpxStatus = new System.Windows.Forms.GroupBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSetor = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lvSetor = new System.Windows.Forms.ListView();
            this.mnuOculto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExcluir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalReg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.gpxStatus.SuspendLayout();
            this.mnuOculto.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpxStatus
            // 
            this.gpxStatus.Controls.Add(this.txtID);
            this.gpxStatus.Controls.Add(this.label1);
            this.gpxStatus.Controls.Add(this.txtSetor);
            this.gpxStatus.Controls.Add(this.lblID);
            this.gpxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpxStatus.Location = new System.Drawing.Point(12, 57);
            this.gpxStatus.Name = "gpxStatus";
            this.gpxStatus.Size = new System.Drawing.Size(405, 84);
            this.gpxStatus.TabIndex = 1;
            this.gpxStatus.TabStop = false;
            this.gpxStatus.Text = "Informações do Setor";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(53, 30);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(115, 20);
            this.txtID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Setor:";
            // 
            // txtSetor
            // 
            this.txtSetor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetor.Location = new System.Drawing.Point(53, 56);
            this.txtSetor.Name = "txtSetor";
            this.txtSetor.Size = new System.Drawing.Size(346, 20);
            this.txtSetor.TabIndex = 0;
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
            // lvSetor
            // 
            this.lvSetor.ContextMenuStrip = this.mnuOculto;
            this.lvSetor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvSetor.Location = new System.Drawing.Point(12, 147);
            this.lvSetor.Name = "lvSetor";
            this.lvSetor.Size = new System.Drawing.Size(405, 236);
            this.lvSetor.TabIndex = 0;
            this.lvSetor.UseCompatibleStateImageBehavior = false;
            this.lvSetor.SelectedIndexChanged += new System.EventHandler(this.lvSetor_SelectedIndexChanged);
            this.lvSetor.Click += new System.EventHandler(this.lvSetor_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 409);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(425, 22);
            this.statusStrip1.TabIndex = 38;
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
            this.lblTotalReg.Location = new System.Drawing.Point(12, 386);
            this.lblTotalReg.Name = "lblTotalReg";
            this.lblTotalReg.Size = new System.Drawing.Size(0, 13);
            this.lblTotalReg.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(217, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Pressione [F5] para atualizar o Formulário";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNovo,
            this.toolStripSeparator2,
            this.tsbtnSalvar,
            this.toolStripSeparator3,
            this.tsbtnRefresh,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(425, 54);
            this.toolStrip1.TabIndex = 42;
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 54);
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
            // frmSetor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 431);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalReg);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gpxStatus);
            this.Controls.Add(this.lvSetor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setor";
            this.Load += new System.EventHandler(this.frmSetor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSetor_KeyDown);
            this.gpxStatus.ResumeLayout(false);
            this.gpxStatus.PerformLayout();
            this.mnuOculto.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpxStatus;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSetor;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ListView lvSetor;
        private System.Windows.Forms.ContextMenuStrip mnuOculto;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblMsg;
        private System.Windows.Forms.Label lblTotalReg;
        private System.Windows.Forms.ToolStripMenuItem mnuExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnSalvar;
        private System.Windows.Forms.ToolStripButton tsbtnNovo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}