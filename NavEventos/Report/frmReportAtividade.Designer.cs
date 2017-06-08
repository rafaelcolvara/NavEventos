namespace NavEventos.Report
{
    partial class frmReportAtividade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportAtividade));
            this.dgvReportAtiv = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnExportar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgresso = new System.Windows.Forms.ToolStripProgressBar();
            this.dtIni = new System.Windows.Forms.DateTimePicker();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportAtiv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReportAtiv
            // 
            this.dgvReportAtiv.AllowUserToAddRows = false;
            this.dgvReportAtiv.AllowUserToDeleteRows = false;
            this.dgvReportAtiv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportAtiv.Location = new System.Drawing.Point(1, 42);
            this.dgvReportAtiv.Name = "dgvReportAtiv";
            this.dgvReportAtiv.ReadOnly = true;
            this.dgvReportAtiv.Size = new System.Drawing.Size(1298, 537);
            this.dgvReportAtiv.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnExportar,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1301, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnExportar
            // 
            this.tsbtnExportar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnExportar.Image")));
            this.tsbtnExportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExportar.Name = "tsbtnExportar";
            this.tsbtnExportar.Size = new System.Drawing.Size(89, 36);
            this.tsbtnExportar.Text = "Exportar ";
            this.tsbtnExportar.Click += new System.EventHandler(this.tsbtnExportar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblStatus,
            this.toolStripStatusLabel2,
            this.tsProgresso});
            this.statusStrip1.Location = new System.Drawing.Point(0, 582);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1301, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslblStatus
            // 
            this.tslblStatus.AutoSize = false;
            this.tslblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tslblStatus.Name = "tslblStatus";
            this.tslblStatus.Size = new System.Drawing.Size(300, 17);
            this.tslblStatus.Text = "Total de 0 registro(s) localizado(s)";
            this.tslblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(880, 17);
            // 
            // tsProgresso
            // 
            this.tsProgresso.Name = "tsProgresso";
            this.tsProgresso.Size = new System.Drawing.Size(100, 16);
            // 
            // dtIni
            // 
            this.dtIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtIni.Location = new System.Drawing.Point(142, 12);
            this.dtIni.Name = "dtIni";
            this.dtIni.Size = new System.Drawing.Size(100, 20);
            this.dtIni.TabIndex = 4;
            // 
            // dtFim
            // 
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFim.Location = new System.Drawing.Point(267, 12);
            this.dtFim.Name = "dtFim";
            this.dtFim.Size = new System.Drawing.Size(100, 20);
            this.dtFim.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "De";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "a";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(382, 12);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 21);
            this.btnFiltrar.TabIndex = 8;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // frmReportAtividade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 604);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFim);
            this.Controls.Add(this.dtIni);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvReportAtiv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportAtividade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório - Atividade";
            this.Load += new System.EventHandler(this.frmReportAtividade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportAtiv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReportAtiv;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnExportar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tsProgresso;
        private System.Windows.Forms.ToolStripStatusLabel tslblStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.DateTimePicker dtIni;
        private System.Windows.Forms.DateTimePicker dtFim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFiltrar;
    }
}