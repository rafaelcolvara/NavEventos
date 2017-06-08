using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavEventos.Report
{
    public partial class frmReportRTO : Form
    {
        public frmReportRTO()
        {
            InitializeComponent();
        }

        private void frmReportRTO_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_Nav_E_ventosDataSet1.Rel_RTO' table. You can move, or remove it, as needed.
         //   this.rel_RTOTableAdapter1.Fill(this._Nav_E_ventosDataSet1.Rel_RTO);
          //  this.reportViewer1.RefreshReport();
            
        }
        public void filtraRTO(int rto)
        {
            this.rel_RTOTableAdapter1.FillByNumeroRTO(this._Nav_E_ventosDataSet1.Rel_RTO, rto);
            this.reportViewer1.RefreshReport();
        }
        
    }
}
