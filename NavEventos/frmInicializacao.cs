using System;
using System.Windows.Forms;

namespace NavEventos
{
    public partial class frmInicializacao : Form
    {
        public frmInicializacao()
        {
            InitializeComponent();
        }

        private void frmInicializacao_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            timer1.Enabled = true;
            timer1.Interval = 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 2;
                if (progressBar1.Value <= 20)
                {
                    lblPorcento.Text = string.Concat("Aguarde... ", string.Format("{0}", progressBar1.Value), "%");
                }
                else if (progressBar1.Value > 20 && progressBar1.Value <= 76)
                {
                    lblPorcento.Text = string.Concat("Carregando registros... ", string.Format("{0}", progressBar1.Value), "%");
                }
                else
                {
                    lblPorcento.Text = string.Concat("Iniciando... ", string.Format("{0}", progressBar1.Value), "%");
                }
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                timer1.Enabled = false;
                this.Visible = false;
                
                using (frmLogin frm = new frmLogin())
                {
                    frm.ShowDialog();
                }
                
          

            }
        }
    }
}
