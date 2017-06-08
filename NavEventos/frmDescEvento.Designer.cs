namespace NavEventos
{
    partial class frmDescEvento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDescEvento));
            this.dtpCota = new System.Windows.Forms.DateTimePicker();
            this.lblCota = new System.Windows.Forms.Label();
            this.dtpDataDemanda = new System.Windows.Forms.DateTimePicker();
            this.lblDtDemanda = new System.Windows.Forms.Label();
            this.lblIDDemanda = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtIDDemanda = new System.Windows.Forms.TextBox();
            this.txtEvento = new System.Windows.Forms.TextBox();
            this.lblEvento = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricaoEvento = new System.Windows.Forms.TextBox();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbtnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtIDTPEvento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkRTO = new System.Windows.Forms.CheckBox();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpCota
            // 
            this.dtpCota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCota.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCota.Location = new System.Drawing.Point(98, 343);
            this.dtpCota.Name = "dtpCota";
            this.dtpCota.Size = new System.Drawing.Size(105, 20);
            this.dtpCota.TabIndex = 3;
            // 
            // lblCota
            // 
            this.lblCota.AutoSize = true;
            this.lblCota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCota.Location = new System.Drawing.Point(7, 349);
            this.lblCota.Name = "lblCota";
            this.lblCota.Size = new System.Drawing.Size(85, 13);
            this.lblCota.TabIndex = 113;
            this.lblCota.Text = "Data do Evento:";
            // 
            // dtpDataDemanda
            // 
            this.dtpDataDemanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataDemanda.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataDemanda.Location = new System.Drawing.Point(98, 317);
            this.dtpDataDemanda.Name = "dtpDataDemanda";
            this.dtpDataDemanda.Size = new System.Drawing.Size(105, 20);
            this.dtpDataDemanda.TabIndex = 2;
            // 
            // lblDtDemanda
            // 
            this.lblDtDemanda.AutoSize = true;
            this.lblDtDemanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDtDemanda.Location = new System.Drawing.Point(7, 322);
            this.lblDtDemanda.Name = "lblDtDemanda";
            this.lblDtDemanda.Size = new System.Drawing.Size(82, 13);
            this.lblDtDemanda.TabIndex = 112;
            this.lblDtDemanda.Text = "Data Demanda:";
            // 
            // lblIDDemanda
            // 
            this.lblIDDemanda.AutoSize = true;
            this.lblIDDemanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDDemanda.Location = new System.Drawing.Point(7, 60);
            this.lblIDDemanda.Name = "lblIDDemanda";
            this.lblIDDemanda.Size = new System.Drawing.Size(70, 13);
            this.lblIDDemanda.TabIndex = 115;
            this.lblIDDemanda.Text = "ID Demanda:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(236, 179);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 116;
            // 
            // txtIDDemanda
            // 
            this.txtIDDemanda.BackColor = System.Drawing.Color.White;
            this.txtIDDemanda.Enabled = false;
            this.txtIDDemanda.Location = new System.Drawing.Point(98, 57);
            this.txtIDDemanda.Name = "txtIDDemanda";
            this.txtIDDemanda.Size = new System.Drawing.Size(100, 20);
            this.txtIDDemanda.TabIndex = 117;
            // 
            // txtEvento
            // 
            this.txtEvento.BackColor = System.Drawing.Color.White;
            this.txtEvento.Enabled = false;
            this.txtEvento.Location = new System.Drawing.Point(98, 109);
            this.txtEvento.Name = "txtEvento";
            this.txtEvento.Size = new System.Drawing.Size(365, 20);
            this.txtEvento.TabIndex = 118;
            // 
            // lblEvento
            // 
            this.lblEvento.AutoSize = true;
            this.lblEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvento.Location = new System.Drawing.Point(7, 112);
            this.lblEvento.Name = "lblEvento";
            this.lblEvento.Size = new System.Drawing.Size(44, 13);
            this.lblEvento.TabIndex = 119;
            this.lblEvento.Text = "Evento:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.Location = new System.Drawing.Point(7, 138);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 121;
            this.lblDescricao.Text = "Descrição:";
            // 
            // txtDescricaoEvento
            // 
            this.txtDescricaoEvento.BackColor = System.Drawing.Color.White;
            this.txtDescricaoEvento.Location = new System.Drawing.Point(98, 135);
            this.txtDescricaoEvento.Multiline = true;
            this.txtDescricaoEvento.Name = "txtDescricaoEvento";
            this.txtDescricaoEvento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricaoEvento.Size = new System.Drawing.Size(365, 153);
            this.txtDescricaoEvento.TabIndex = 0;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSalvar,
            this.toolStripSeparator1});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(471, 54);
            this.tsMenu.TabIndex = 122;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbtnSalvar
            // 
            this.tsbtnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSalvar.Image")));
            this.tsbtnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnSalvar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSalvar.Name = "tsbtnSalvar";
            this.tsbtnSalvar.Size = new System.Drawing.Size(42, 51);
            this.tsbtnSalvar.Text = "Salvar";
            this.tsbtnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbtnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSalvar.Click += new System.EventHandler(this.tsbtnSalvar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // txtIDTPEvento
            // 
            this.txtIDTPEvento.BackColor = System.Drawing.Color.White;
            this.txtIDTPEvento.Enabled = false;
            this.txtIDTPEvento.Location = new System.Drawing.Point(98, 83);
            this.txtIDTPEvento.Name = "txtIDTPEvento";
            this.txtIDTPEvento.Size = new System.Drawing.Size(100, 20);
            this.txtIDTPEvento.TabIndex = 124;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 123;
            this.label1.Text = "ID Evento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "RTO:";
            // 
            // chkRTO
            // 
            this.chkRTO.AutoSize = true;
            this.chkRTO.Location = new System.Drawing.Point(98, 296);
            this.chkRTO.Name = "chkRTO";
            this.chkRTO.Size = new System.Drawing.Size(15, 14);
            this.chkRTO.TabIndex = 1;
            this.chkRTO.UseVisualStyleBackColor = true;
            // 
            // frmDescEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 369);
            this.Controls.Add(this.chkRTO);
            this.Controls.Add(this.txtIDTPEvento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricaoEvento);
            this.Controls.Add(this.lblEvento);
            this.Controls.Add(this.txtEvento);
            this.Controls.Add(this.txtIDDemanda);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblIDDemanda);
            this.Controls.Add(this.dtpCota);
            this.Controls.Add(this.lblCota);
            this.Controls.Add(this.dtpDataDemanda);
            this.Controls.Add(this.lblDtDemanda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDescEvento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descrição do Tipo de Evento";
            this.Load += new System.EventHandler(this.frmDescEvento_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpCota;
        private System.Windows.Forms.Label lblCota;
        private System.Windows.Forms.DateTimePicker dtpDataDemanda;
        private System.Windows.Forms.Label lblDtDemanda;
        private System.Windows.Forms.Label lblIDDemanda;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtIDDemanda;
        private System.Windows.Forms.TextBox txtEvento;
        private System.Windows.Forms.Label lblEvento;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricaoEvento;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbtnSalvar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox txtIDTPEvento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkRTO;
    }
}