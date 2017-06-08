using NavEventos.Class;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace NavEventos
{
    public partial class frmConfiguracao : Form
    {
        string monta_caminho = string.Empty;

        public frmConfiguracao()
        {
            InitializeComponent();
        }

        private void frmConfiguracao_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(string.Concat(Application.StartupPath, @"\Config.txt")))
                {
                    StreamReader rdr = null;
                    string linha = string.Empty;

                    rdr = new StreamReader(string.Concat(Application.StartupPath, @"\Config.txt"));
                    while ((linha = rdr.ReadLine()) != null)
                    {
                        txtDiretorio.Text = linha.ToString();
                    }
                    rdr.Dispose();
                    rdr.Close();
                }

                #region RETORNA O TAMANHO DO ARQUIVO EM DISCO
                FileInfo fi = new FileInfo(string.Concat(Application.StartupPath, @"\Nav[E]ventos.mdb"));
                lbltamanho.Text = string.Concat("Tamanho do Banco de Dados em Disco: ", cGlobal.TamanhoAmigavel(fi.Length));
                #endregion

                //int qtdcaracter = (ConfigurationManager.ConnectionStrings["cnn"].ToString().Length - 45 - txtNomeBanco.Text.Length);
                //txtDiretorio.Text = ConfigurationManager.ConnectionStrings["cnn"].ToString().Substring(45, qtdcaracter);
            }
            catch (Exception ex)
            {
                #region LOG ERRO
                cLog lg = new cLog();
                lg.log = ex.Message.Replace("'", "");
                lg.form = this.Text;
                lg.metodo = sender.ToString();
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //Jet OLEDB:Database Password = gr@w*16
                monta_caminho = string.Format(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source ={0}\{1};", txtDiretorio.Text, txtNomeBanco.Text);
                Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                conf.ConnectionStrings.ConnectionStrings["cnn"].ConnectionString = monta_caminho;
                conf.Save();
                grava_log();
                MessageBox.Show("Configuração alterada com sucesso.\r\nÉ necessário fechar e iniciar novamente o sistema,\r\npara que a alteração tenha efeito.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Dispose();
                Close();

                //Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                //conf.ConnectionStrings.ConnectionStrings["cnn"].ConnectionString = string.Concat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", txtDiretorio.Text);
                //conf.Save();

                #region LOG
                cLog lg = new cLog();
                lg.log = string.Concat("Configuração de Conexão", Environment.NewLine, string.Concat(txtDiretorio.Text, txtNomeBanco.Text));
                lg.form = this.Text;
                lg.metodo = sender.ToString();
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = true;
                lg.grava_log(lg);
                #endregion

                Dispose();
                Close();
            }
            catch (Exception ex)
            {
                #region LOG ERRO
                cLog lg = new cLog();
                lg.log = ex.Message.Replace("'", "");
                lg.form = this.Text;
                lg.metodo = sender.ToString();
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();

                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtDiretorio.Text = fbd.SelectedPath;
                }
                //OpenFileDialog ofd = new OpenFileDialog();
                //ofd.Filter = "Microsoft Access Database(2002 - 2003)(*.mdb) | *.mdb";
                //ofd.InitialDirectory = @"C:\";
                //ofd.FilterIndex = 1;
                //if (ofd.ShowDialog() == DialogResult.OK)
                //{
                //    txtDiretorio.Text = ofd.FileName;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void grava_log()
        {
            try
            {
                if (File.Exists(string.Concat(Application.StartupPath, @"\Config.txt")))
                {
                    File.Delete(string.Concat(Application.StartupPath, @"\Config.txt"));
                }

                using (StreamWriter sw = new StreamWriter(string.Concat(Application.StartupPath, @"\Config.txt")))
                {
                    sw.Write(txtDiretorio.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
