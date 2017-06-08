namespace NavEventos.Report
{
    partial class frmReportRTO
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportRTO));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.relRTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._Nav_E_ventosDataSet1 = new NavEventos._Nav_E_ventosDataSet();
            this.rel_RTOTableAdapter1 = new NavEventos._Nav_E_ventosDataSetTableAdapters.Rel_RTOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.relRTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Nav_E_ventosDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsRTO";
            reportDataSource1.Value = this.relRTOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NavEventos.Report.rptRTO.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(635, 432);
            this.reportViewer1.TabIndex = 0;
            // 
            // relRTOBindingSource
            // 
            this.relRTOBindingSource.DataMember = "Rel_RTO";
            this.relRTOBindingSource.DataSource = this._Nav_E_ventosDataSet1;
            // 
            // _Nav_E_ventosDataSet1
            // 
            this._Nav_E_ventosDataSet1.DataSetName = "_Nav_E_ventosDataSet";
            this._Nav_E_ventosDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rel_RTOTableAdapter1
            // 
            this.rel_RTOTableAdapter1.ClearBeforeFill = true;
            // 
            // frmReportRTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 432);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportRTO";
            this.Text = "Relatório de RTO ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportRTO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.relRTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Nav_E_ventosDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private _Nav_E_ventosDataSet _Nav_E_ventosDataSet1;
        private System.Windows.Forms.BindingSource relRTOBindingSource;
        private _Nav_E_ventosDataSetTableAdapters.Rel_RTOTableAdapter rel_RTOTableAdapter1;
    }
}