namespace NavEventos
{
    partial class frmProgresso
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
            this.proBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // proBar
            // 
            this.proBar.Location = new System.Drawing.Point(12, 12);
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(466, 23);
            this.proBar.TabIndex = 0;
            // 
            // frmProgresso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 47);
            this.ControlBox = false;
            this.Controls.Add(this.proBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmProgresso";
            this.Text = "Andamento..";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar proBar;
    }
}