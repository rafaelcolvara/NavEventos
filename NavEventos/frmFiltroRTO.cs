using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavEventos
{
    public partial class frmFiltroRTO : Form
    {
        public frmFiltroRTO()
        {
            InitializeComponent();
           
        }

        private void cmdCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            
            using (Report.frmReportRTO frm = new Report.frmReportRTO())
            {
                int nrRto = Convert.ToInt32(txtNrRto.Text.ToString());
                frm.filtraRTO(nrRto);
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void frmFiltroRTO_Load(object sender, EventArgs e)
        {
            txtNrRto.Focus();
        }
    }
}
