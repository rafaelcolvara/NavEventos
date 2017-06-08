namespace NavEventos
{
    partial class frmRestore
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
            this.btnIniciarRestore = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tspBarraProgresso = new System.Windows.Forms.ToolStripProgressBar();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtPathBD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerRestore = new System.Windows.Forms.Timer(this.components);
            this.lblAviso = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIniciarRestore
            // 
            this.btnIniciarRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciarRestore.Location = new System.Drawing.Point(200, 116);
            this.btnIniciarRestore.Name = "btnIniciarRestore";
            this.btnIniciarRestore.Size = new System.Drawing.Size(119, 52);
            this.btnIniciarRestore.TabIndex = 17;
            this.btnIniciarRestore.Text = "Iniciar\r\nRestore";
            this.btnIniciarRestore.UseVisualStyleBackColor = true;
            this.btnIniciarRestore.Click += new System.EventHandler(this.btnIniciarRestore_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspBarraProgresso});
            this.statusStrip1.Location = new System.Drawing.Point(0, 205);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(517, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tspBarraProgresso
            // 
            this.tspBarraProgresso.Name = "tspBarraProgresso";
            this.tspBarraProgresso.Size = new System.Drawing.Size(500, 16);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrir.Location = new System.Drawing.Point(447, 71);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(60, 23);
            this.btnAbrir.TabIndex = 15;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // txtDestino
            // 
            this.txtDestino.BackColor = System.Drawing.Color.White;
            this.txtDestino.Location = new System.Drawing.Point(10, 73);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.ReadOnly = true;
            this.txtDestino.Size = new System.Drawing.Size(431, 20);
            this.txtDestino.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Destino:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Location = new System.Drawing.Point(447, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(60, 23);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Localizar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtPathBD
            // 
            this.txtPathBD.BackColor = System.Drawing.Color.White;
            this.txtPathBD.Location = new System.Drawing.Point(10, 25);
            this.txtPathBD.Name = "txtPathBD";
            this.txtPathBD.ReadOnly = true;
            this.txtPathBD.Size = new System.Drawing.Size(431, 20);
            this.txtPathBD.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Arquivo Backup:";
            // 
            // timerRestore
            // 
            this.timerRestore.Tick += new System.EventHandler(this.timerRestore_Tick);
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.Blue;
            this.lblAviso.Location = new System.Drawing.Point(1, 192);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(0, 13);
            this.lblAviso.TabIndex = 18;
            // 
            // frmRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 227);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.btnIniciarRestore);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtPathBD);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRestore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restore";
            this.Load += new System.EventHandler(this.frmRestore_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciarRestore;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tspBarraProgresso;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtPathBD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerRestore;
        private System.Windows.Forms.Label lblAviso;
    }
}