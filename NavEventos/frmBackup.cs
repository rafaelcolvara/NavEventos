using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NavEventos.Class;

namespace NavEventos
{
    public partial class frmBackup : Form
    {
        StreamReader rdr = null;
        string linha = string.Empty;

        public frmBackup()
        {
            InitializeComponent();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            try
            {
                inicio();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void inicio()
        {
            try
            {
                if (File.Exists(string.Concat(Application.StartupPath, @"\Backup.txt")))
                {
                    rdr = new StreamReader(string.Concat(Application.StartupPath, @"\Backup.txt"));
                    while ((linha = rdr.ReadLine()) != null)
                    {
                        if (linha.Substring(0,1) == "1")
                        {
                            txtPathBD.Text = linha.ToString().Substring(2, linha.Length - 2);
                        }
                        else if (linha.Substring(0, 1) == "2")
                        {
                            txtDestino.Text = linha.ToString().Substring(2, linha.Length - 2);
                        }
                        else
                        {
                            lblAviso.Text = string.Concat("Último Backup realizado em: ", linha.ToString().Substring(2, linha.Length - 2));
                        }
                    }
                    rdr.Dispose();
                    rdr.Close();
                }
                else
                {
                    lblAviso.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                #region LOG ERRO
                cLog lg = new cLog();
                lg.log = ex.Message.Replace("'", "");
                lg.form = this.Text;
                lg.metodo = "inicio";
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Microsoft Access Database(2002 - 2003)(*.mdb) | *.mdb";
                ofd.InitialDirectory = @"C:\";
                ofd.FilterIndex = 1;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtPathBD.Text = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtDestino.Text = fbd.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnIniciarBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPathBD.Text))
                {
                    MessageBox.Show("Banco de Dados não informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnBuscar.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtDestino.Text))
                {
                    MessageBox.Show("Informe o caminho onde será realizado\no backup do Banco de Dados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnAbrir.Focus();
                    return;
                }

                this.Cursor = Cursors.AppStarting;
                controle(false);
                timerBackup.Enabled = true;
                timerBackup.Interval = 100;

                if (File.Exists(string.Concat(txtDestino.Text, @"\Nav[E]ventos.mdb")))
                {
                    File.Delete(string.Concat(txtDestino.Text, @"\Nav[E]ventos.mdb"));
                    File.Copy(txtPathBD.Text, txtDestino.Text + @"\Nav[E]ventos.mdb");
                }
                else
                {
                    File.Copy(txtPathBD.Text, txtDestino.Text + @"\Nav[E]ventos.mdb");
                }
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


        private void grava_log()
        {
            try
            {
                if (File.Exists(string.Concat(Application.StartupPath, @"\Backup.txt")))
                {
                    File.Delete(string.Concat(Application.StartupPath, @"\Backup.txt"));
                }

                using (StreamWriter sw = new StreamWriter(string.Concat(Application.StartupPath, @"\Backup.txt")))
                {
                    sw.Write(string.Format("{0}-{1}","1", txtPathBD.Text));
                    sw.Write(Environment.NewLine);
                    sw.Write(string.Format("{0}-{1}", "2", txtDestino.Text));
                    sw.Write(Environment.NewLine);
                    sw.Write(string.Format("{0}-{1} - Usuário: {2}", "3", DateTime.Now, cGlobal.userlogado));
                    
                }
            }
            catch (Exception ex)
            {
                #region LOG ERRO
                cLog lg = new cLog();
                lg.log = ex.Message.Replace("'", "");
                lg.form = this.Text;
                lg.metodo = "grava_log";
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion
            }
        }

        private void controle(bool flag)
        {
            btnAbrir.Enabled = flag;
            btnBuscar.Enabled = flag;
            btnIniciarBackup.Enabled = flag;
        }

        private void timerBackup_Tick(object sender, EventArgs e)
        {
            if (tspBarraProgresso.Value < 100)
            {
                tspBarraProgresso.Value = tspBarraProgresso.Value + 5;

                if (tspBarraProgresso.Value == 100)
                {
                    MessageBox.Show("Backup realizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Backup realizado em: ", DateTime.Now, Environment.NewLine);
                    lg.form = this.Text;
                    lg.metodo = sender.ToString();
                    lg.dt = DateTime.Now;
                    lg.usersistema = cGlobal.userlogado;
                    lg.userRede = Environment.UserName;
                    lg.terminal = Environment.MachineName;
                    lg.tp_flag = true;
                    lg.grava_log(lg);
                    #endregion
                    grava_log();
                    tspBarraProgresso.Value = 0;
                    this.Cursor = Cursors.Arrow;
                    timerBackup.Enabled = false;
                    controle(true);
                    inicio();
                }
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                timerBackup.Enabled = false;
            }
        }

    }
}
