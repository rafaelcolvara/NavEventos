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
    public partial class frmProgresso : Form
    {
        public frmProgresso()
        {
            InitializeComponent();
        }
        public void atualiza_ProgressBar(int val)
        {
            this.proBar.Value = val;
        }
        public void set_Max_progressBar(int max)
        {
            this.proBar.Maximum = max;
        }
    }
}
