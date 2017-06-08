using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Security.Principal;
using NavEventos.Class;

namespace NavEventos
{
    public partial class frmLoginCadastro : Form
    {
        public frmLoginCadastro()
        {
            InitializeComponent();
        }

        private void frmLoginCadastro_Load(object sender, EventArgs e)
        {
            try
            {
                txtLogin.Text = Environment.UserName.ToUpper();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                #region VALIDAÇÕES
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    tsslblMsg.Text = "Informe o nome completo";
                    txtNome.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    tsslblMsg.Text = "Informe o email";
                    txtEmail.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtSenha.Text))
                {
                    tsslblMsg.Text = "Informe a senha";
                    txtSenha.Focus();
                    return;
                }

                if (txtSenha.Text.Length < 4)
                {
                    tsslblMsg.Text = "A senha tem que de 4 à 10 caractéres";
                    txtSenha.Focus();
                    return;
                }

                if (txtSenha.Text != txtConfirmaSenha.Text)
                {
                    tsslblMsg.Text = "Confirmação de senha inválida";
                    txtConfirmaSenha.Text = string.Empty;
                    txtConfirmaSenha.Focus();
                    return;
                }
                #endregion

                cUsuario user = new cUsuario();
                user.usuario = txtNome.Text.ToUpper();
                user.email = txtEmail.Text.ToLower();
                user.login = txtLogin.Text;
                user.senha = Criptografia.Criptografia.executa_cript(txtSenha.Text);
                user.dtcad = DateTime.Now;

                if (!user.verifica_usuario_existe(user))
                {
                    user.grava_acesso(user);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Cadastro de Acesso.", Environment.NewLine, 
                                           "Usuário nº ", txtNome.Text.ToUpper(), Environment.NewLine, 
                                           "E-mail: ", txtEmail.Text.ToLower(), Environment.NewLine, 
                                           "Login: ", txtLogin.Text);
                    lg.form = this.Text;
                    lg.metodo = sender.ToString();
                    lg.dt = DateTime.Now;
                    lg.usersistema = "";
                    lg.userRede = Environment.UserName;
                    lg.terminal = Environment.MachineName;
                    lg.tp_flag = true;
                    lg.grava_log(lg);
                    #endregion
                    MessageBox.Show("Usuário cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dispose();
                    Close();
                }
                else
                {
                    MessageBox.Show("Usuário já cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
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
                lg.usersistema = "";
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Dispose();
                Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
