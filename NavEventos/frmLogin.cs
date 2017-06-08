using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using NavEventos.Class;
using System.Security;
using System.Security.Principal;

namespace NavEventos
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        #region EVENTOS
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                //já mostra no campo login o usuário da rede
                txtLogin.Text = Environment.UserName.ToUpper(); //descomentar

                if (!string.IsNullOrEmpty(txtLogin.Text))
                {
                    txtSenha.TabIndex = 0;
                    btnLogin.TabIndex = 1;
                    btnCancelar.TabIndex = 2;
                    lklblCadastraSenha.TabIndex = 3;
                    txtLogin.TabIndex = 4;
                }
                
                //txtLogin.Text = "ADMINISTRADOR";
                //txtSenha.Text = "1310"; //"#itau"; //teste
            }
            catch (Exception ex)
            {
                #region LOG ERRO
                cLog lg = new cLog();
                lg.log = ex.Message.Replace("'", "");
                lg.form = this.Text;
                lg.metodo = sender.ToString();
                lg.dt = DateTime.Now;
                lg.usersistema = "";
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion
            }
        }
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

               
                    #region VALIDAÇÕES
                    if (string.IsNullOrEmpty(txtLogin.Text))
                    {
                        tsslblMsg.Text = "Login não informado";
                        txtLogin.Focus();
                        return;
                    }

                if (string.IsNullOrEmpty(txtSenha.Text))
                {
                    tsslblMsg.Text = "Senha não informada";
                    txtSenha.Focus();
                    return;
                }
                #endregion

                cUsuario usuario = new cUsuario();
                usuario.usuario = txtLogin.Text.ToUpper();
                usuario.senha = Criptografia.Criptografia.executa_cript(txtSenha.Text);
                
                #region VERIFICA SE LOGIN DO USUÁRIO ESTÁ ATIVO
                if (usuario.verifica_login_ativo(usuario))
                {
                    MessageBox.Show("Não foi possível fazer login no sistema.\n\rO acesso do usuário está inativo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                #region VERIFICAR SE SENHA PRECISA SER ALTERADA
                if (usuario.verifica_reset_senha(usuario))
                {
                    using (frmLoginNovaSenha frm = new frmLoginNovaSenha())
                    {
                        cGlobal.userlogado = txtLogin.Text.ToUpper();
                        cGlobal.iduserlogado = usuario.retorna_id_usuario(usuario);
                        Dispose();
                        Close();
                        frm.ShowDialog();
                    }
                    return;
                }
                #endregion

                if (usuario.valida_login(usuario))
                {
                    Dispose();
                    Close();
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = "Efetuado Login no Sistema";
                    lg.form = this.Text;
                    lg.metodo = sender.ToString();
                    lg.dt = DateTime.Now;
                    lg.usersistema = cGlobal.userlogado;
                    lg.userRede = Environment.UserName;
                    lg.terminal = Environment.MachineName;
                    lg.tp_flag = true;
                    lg.grava_log(lg);
                    #endregion
                    using (frmInicial frm = new frmInicial())
                    {
                         frm.ShowDialog();
                    }
                }
                else
                {
                    tsslblMsg.Text = "Usuário e/ou senha inválido";
                    txtLogin.Text = Environment.UserName.ToUpper();
                    txtSenha.Text = string.Empty;
                    txtLogin.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Provedor OLE DB não foi especificado em ConnectionString. Por exemplo, 'Provider=SQLOLEDB;'."))
                {
                    MessageBox.Show("Não foi possível localizar o Banco de Dados.\r\nEntre em contato com o Administrador.","Mensagem",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Dispose();
                    Close();
                    Application.Exit();
                }
                else
                {
                    #region LOG ERRO
                    cLog lg = new cLog();
                    lg.log = ex.Message.Replace("'", "");
                    lg.form = this.Text;
                    lg.metodo = sender.ToString();
                    lg.dt = DateTime.Now;
                    lg.usersistema = "";
                    lg.userRede = Environment.UserName;
                    lg.terminal = Environment.MachineName;
                    lg.tp_flag = false;
                    lg.grava_log(lg);
                    #endregion
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Dispose();
                Close();
                Application.Exit();
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
        private void lklblCadastraSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                tsslblMsg.Text = string.Empty;
                using (frmLoginCadastro frm = new frmLoginCadastro())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
