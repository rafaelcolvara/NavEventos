namespace NavEventos
{
    partial class ViewEventos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewEventos));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tvwDemanda = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtinfCNPJCPF = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtinfSiglaFY = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtinfSiglaSAC = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtinfFundo = new System.Windows.Forms.TextBox();
            this.txtinfCliente = new System.Windows.Forms.TextBox();
            this.txtinfProduto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDtCota = new System.Windows.Forms.TextBox();
            this.txtDtDemanda = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblCota = new System.Windows.Forms.Label();
            this.lblDtDemanda = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSuporte = new System.Windows.Forms.TextBox();
            this.txtProcessamento = new System.Windows.Forms.TextBox();
            this.txtPassivo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCronograma = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCronograma)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "002.ICO");
            this.imageList1.Images.SetKeyName(1, "041.ICO");
            this.imageList1.Images.SetKeyName(2, "CRDFLE08.ICO");
            this.imageList1.Images.SetKeyName(3, "CALENDAR.ICO");
            // 
            // tvwDemanda
            // 
            this.tvwDemanda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvwDemanda.ImageIndex = 0;
            this.tvwDemanda.ImageList = this.imageList1;
            this.tvwDemanda.Location = new System.Drawing.Point(3, 3);
            this.tvwDemanda.Name = "tvwDemanda";
            this.tvwDemanda.SelectedImageIndex = 0;
            this.tvwDemanda.Size = new System.Drawing.Size(304, 546);
            this.tvwDemanda.TabIndex = 132;
            this.tvwDemanda.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvwDemanda_AfterExpand);
            this.tvwDemanda.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDemanda_AfterSelect);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtinfCNPJCPF);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtinfSiglaFY);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtinfSiglaSAC);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtinfFundo);
            this.groupBox3.Controls.Add(this.txtinfCliente);
            this.groupBox3.Controls.Add(this.txtinfProduto);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(316, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(587, 177);
            this.groupBox3.TabIndex = 142;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informações da Demanda";
            // 
            // txtinfCNPJCPF
            // 
            this.txtinfCNPJCPF.BackColor = System.Drawing.Color.White;
            this.txtinfCNPJCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinfCNPJCPF.Location = new System.Drawing.Point(94, 148);
            this.txtinfCNPJCPF.Name = "txtinfCNPJCPF";
            this.txtinfCNPJCPF.ReadOnly = true;
            this.txtinfCNPJCPF.Size = new System.Drawing.Size(484, 20);
            this.txtinfCNPJCPF.TabIndex = 108;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 107;
            this.label13.Text = "CNPJ/CPF:";
            // 
            // txtinfSiglaFY
            // 
            this.txtinfSiglaFY.BackColor = System.Drawing.Color.White;
            this.txtinfSiglaFY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinfSiglaFY.Location = new System.Drawing.Point(94, 122);
            this.txtinfSiglaFY.Name = "txtinfSiglaFY";
            this.txtinfSiglaFY.ReadOnly = true;
            this.txtinfSiglaFY.Size = new System.Drawing.Size(484, 20);
            this.txtinfSiglaFY.TabIndex = 106;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 105;
            this.label12.Text = "Sigla FY:";
            // 
            // txtinfSiglaSAC
            // 
            this.txtinfSiglaSAC.BackColor = System.Drawing.Color.White;
            this.txtinfSiglaSAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinfSiglaSAC.Location = new System.Drawing.Point(94, 96);
            this.txtinfSiglaSAC.Name = "txtinfSiglaSAC";
            this.txtinfSiglaSAC.ReadOnly = true;
            this.txtinfSiglaSAC.Size = new System.Drawing.Size(484, 20);
            this.txtinfSiglaSAC.TabIndex = 104;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 103;
            this.label11.Text = "Sigla SAC:";
            // 
            // txtinfFundo
            // 
            this.txtinfFundo.BackColor = System.Drawing.Color.White;
            this.txtinfFundo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinfFundo.Location = new System.Drawing.Point(94, 71);
            this.txtinfFundo.Name = "txtinfFundo";
            this.txtinfFundo.ReadOnly = true;
            this.txtinfFundo.Size = new System.Drawing.Size(484, 20);
            this.txtinfFundo.TabIndex = 102;
            // 
            // txtinfCliente
            // 
            this.txtinfCliente.BackColor = System.Drawing.Color.White;
            this.txtinfCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinfCliente.Location = new System.Drawing.Point(94, 45);
            this.txtinfCliente.Name = "txtinfCliente";
            this.txtinfCliente.ReadOnly = true;
            this.txtinfCliente.Size = new System.Drawing.Size(484, 20);
            this.txtinfCliente.TabIndex = 101;
            // 
            // txtinfProduto
            // 
            this.txtinfProduto.BackColor = System.Drawing.Color.White;
            this.txtinfProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinfProduto.Location = new System.Drawing.Point(94, 19);
            this.txtinfProduto.Name = "txtinfProduto";
            this.txtinfProduto.ReadOnly = true;
            this.txtinfProduto.Size = new System.Drawing.Size(484, 20);
            this.txtinfProduto.TabIndex = 100;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 97;
            this.label9.Text = "Fundo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "Cliente:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 95;
            this.label6.Text = "Produto:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDtCota);
            this.groupBox1.Controls.Add(this.txtDtDemanda);
            this.groupBox1.Controls.Add(this.lblDescricao);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.lblCota);
            this.groupBox1.Controls.Add(this.lblDtDemanda);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(316, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 141);
            this.groupBox1.TabIndex = 143;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações do Evento";
            // 
            // txtDtCota
            // 
            this.txtDtCota.BackColor = System.Drawing.Color.White;
            this.txtDtCota.Enabled = false;
            this.txtDtCota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtCota.Location = new System.Drawing.Point(288, 19);
            this.txtDtCota.Name = "txtDtCota";
            this.txtDtCota.Size = new System.Drawing.Size(100, 20);
            this.txtDtCota.TabIndex = 144;
            // 
            // txtDtDemanda
            // 
            this.txtDtDemanda.BackColor = System.Drawing.Color.White;
            this.txtDtDemanda.Enabled = false;
            this.txtDtDemanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtDemanda.Location = new System.Drawing.Point(94, 19);
            this.txtDtDemanda.Name = "txtDtDemanda";
            this.txtDtDemanda.Size = new System.Drawing.Size(100, 20);
            this.txtDtDemanda.TabIndex = 145;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.Location = new System.Drawing.Point(6, 45);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(51, 13);
            this.lblDescricao.TabIndex = 143;
            this.lblDescricao.Text = "Histórico:";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.White;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(94, 45);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(484, 90);
            this.txtStatus.TabIndex = 140;
            // 
            // lblCota
            // 
            this.lblCota.AutoSize = true;
            this.lblCota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCota.Location = new System.Drawing.Point(200, 22);
            this.lblCota.Name = "lblCota";
            this.lblCota.Size = new System.Drawing.Size(85, 13);
            this.lblCota.TabIndex = 142;
            this.lblCota.Text = "Data do Evento:";
            // 
            // lblDtDemanda
            // 
            this.lblDtDemanda.AutoSize = true;
            this.lblDtDemanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDtDemanda.Location = new System.Drawing.Point(6, 22);
            this.lblDtDemanda.Name = "lblDtDemanda";
            this.lblDtDemanda.Size = new System.Drawing.Size(82, 13);
            this.lblDtDemanda.TabIndex = 141;
            this.lblDtDemanda.Text = "Data Demanda:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSuporte);
            this.groupBox2.Controls.Add(this.txtProcessamento);
            this.groupBox2.Controls.Add(this.txtPassivo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dgvCronograma);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(316, 333);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 216);
            this.groupBox2.TabIndex = 144;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cronograma";
            // 
            // txtSuporte
            // 
            this.txtSuporte.BackColor = System.Drawing.Color.White;
            this.txtSuporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuporte.Location = new System.Drawing.Point(385, 187);
            this.txtSuporte.Name = "txtSuporte";
            this.txtSuporte.ReadOnly = true;
            this.txtSuporte.Size = new System.Drawing.Size(54, 20);
            this.txtSuporte.TabIndex = 147;
            this.txtSuporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProcessamento
            // 
            this.txtProcessamento.BackColor = System.Drawing.Color.White;
            this.txtProcessamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcessamento.Location = new System.Drawing.Point(248, 187);
            this.txtProcessamento.Name = "txtProcessamento";
            this.txtProcessamento.ReadOnly = true;
            this.txtProcessamento.Size = new System.Drawing.Size(54, 20);
            this.txtProcessamento.TabIndex = 146;
            this.txtProcessamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPassivo
            // 
            this.txtPassivo.BackColor = System.Drawing.Color.White;
            this.txtPassivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassivo.Location = new System.Drawing.Point(76, 187);
            this.txtPassivo.Name = "txtPassivo";
            this.txtPassivo.ReadOnly = true;
            this.txtPassivo.Size = new System.Drawing.Size(54, 20);
            this.txtPassivo.TabIndex = 145;
            this.txtPassivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(324, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 144;
            this.label4.Text = "Suporte:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(145, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 143;
            this.label3.Text = "Processamento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 142;
            this.label2.Text = "Passivo:";
            // 
            // dgvCronograma
            // 
            this.dgvCronograma.AllowUserToAddRows = false;
            this.dgvCronograma.AllowUserToDeleteRows = false;
            this.dgvCronograma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCronograma.Location = new System.Drawing.Point(14, 19);
            this.dgvCronograma.Name = "dgvCronograma";
            this.dgvCronograma.ReadOnly = true;
            this.dgvCronograma.Size = new System.Drawing.Size(564, 164);
            this.dgvCronograma.TabIndex = 141;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 555);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(910, 22);
            this.statusStrip1.TabIndex = 145;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssMsg
            // 
            this.tssMsg.AutoSize = false;
            this.tssMsg.ForeColor = System.Drawing.Color.Black;
            this.tssMsg.Name = "tssMsg";
            this.tssMsg.Size = new System.Drawing.Size(880, 17);
            this.tssMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ViewEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 577);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tvwDemanda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewEventos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visão Geral dos Eventos";
            this.Load += new System.EventHandler(this.ViewEventos_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCronograma)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView tvwDemanda;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDtCota;
        private System.Windows.Forms.TextBox txtDtDemanda;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblCota;
        private System.Windows.Forms.Label lblDtDemanda;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCronograma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtinfCNPJCPF;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtinfSiglaFY;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtinfSiglaSAC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtinfFundo;
        private System.Windows.Forms.TextBox txtinfCliente;
        private System.Windows.Forms.TextBox txtinfProduto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSuporte;
        private System.Windows.Forms.TextBox txtProcessamento;
        private System.Windows.Forms.TextBox txtPassivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssMsg;
    }
}