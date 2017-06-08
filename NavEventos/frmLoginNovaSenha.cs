using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NavEventos.Class;

namespace NavEventos
{
    public partial class frmLoginNovaSenha : Form
    {
        public frmLoginNovaSenha()
        {
            InitializeComponent();
        }

        private void frmLoginNovaSenha_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Dispose();
                Close();
                using (frmLogin frm = new frmLogin())
                {
                    frm.ShowDialog();
                }
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
                #region VALIDAÇÃO
                if (string.IsNullOrEmpty(txtSenha.Text))
                {
                    tsslblMsg.Text = "Informe a senha";
                    txtSenha.Focus();
                    return;
                }

                if (txtSenha.Text.Length < 4)
                {
                    tsslblMsg.Text = "Senha muito pequena";
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
                user.id_usuario = cGlobal.iduserlogado;
                user.senha = Criptografia.Criptografia.executa_cript(txtSenha.Text);
                user.grava_alteracao_senha(user);
                #region LOG
                cLog lg = new cLog();
                lg.log = string.Concat("Alteração de Senha de Acesso.", Environment.NewLine, 
                                       "Usuário nº ", cGlobal.iduserlogado);
                lg.form = this.Text;
                lg.metodo = sender.ToString();
                lg.dt = DateTime.Now;
                lg.usersistema = "";
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = true;
                lg.grava_log(lg);
                #endregion

                using (frmInicial frm = new frmInicial())
                {
                    Dispose();
                    Close();
                    frm.ShowDialog();
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

    }
}
