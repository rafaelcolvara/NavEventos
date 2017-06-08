namespace NavEventos
{
    partial class frmFiltroRTO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltroRTO));
            this.cmdCancela = new System.Windows.Forms.Button();
            this.txtNrRto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancela
            // 
            this.cmdCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancela.Location = new System.Drawing.Point(132, 86);
            this.cmdCancela.Name = "cmdCancela";
            this.cmdCancela.Size = new System.Drawing.Size(75, 23);
            this.cmdCancela.TabIndex = 3;
            this.cmdCancela.Text = "Cancela";
            this.cmdCancela.UseVisualStyleBackColor = true;
            this.cmdCancela.Click += new System.EventHandler(this.cmdCancela_Click);
            // 
            // txtNrRto
            // 
            this.txtNrRto.Location = new System.Drawing.Point(148, 29);
            this.txtNrRto.Name = "txtNrRto";
            this.txtNrRto.Size = new System.Drawing.Size(100, 20);
            this.txtNrRto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numero RTO";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(213, 86);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNrRto);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 68);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // frmFiltroRTO
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancela;
            this.ClientSize = new System.Drawing.Size(300, 121);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancela);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFiltroRTO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filtro para relatório - RTO";
            this.Load += new System.EventHandler(this.frmFiltroRTO_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCancela;
        private System.Windows.Forms.TextBox txtNrRto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}