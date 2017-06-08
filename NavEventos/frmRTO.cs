using NavEventos.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace NavEventos
{
    public partial class frmRTO : Form
    {
        public frmRTO()
        {
            InitializeComponent();
        }

        #region EVENTO
        private void frmRTO_Load(object sender, EventArgs e)
        {
            try
            {
                inicio();

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

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = false;
                inicio();
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

        private void tsbtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                cRTO cr = new cRTO();

                if (!cGlobal.editando)
                {
                    cr.dtcomissao = dtComissao.Value;
                    cr.dtcorte = dtCorte.Value;
                    cr.numero = Convert.ToInt32(txtNumero.Text);
                    cr.grava_RTO(cr);
                    MessageBox.Show("RTO registrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Cadastro de RTO.", Environment.NewLine,
                                           "Data da Comissão: ", dtComissao.Value,
                                           "Data do Corte: ", dtCorte.Value,
                                           "Número: ", txtNumero.Text);
                    lg.form = this.Text;
                    lg.metodo = sender.ToString();
                    lg.dt = DateTime.Now;
                    lg.usersistema = cGlobal.userlogado;
                    lg.userRede = Environment.UserName;
                    lg.terminal = Environment.MachineName;
                    lg.tp_flag = true;
                    lg.grava_log(lg);
                    #endregion
                }
                else
                {
                    cr.idrto = Convert.ToInt32(txtID.Text);
                    cr.dtcomissao = dtComissao.Value;
                    cr.dtcorte = dtCorte.Value;
                    cr.numero = Convert.ToInt32(txtNumero.Text);
                    cr.atualiza_cadastro_RTO(cr);
                    MessageBox.Show("Os dados do cliente foi alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Alteração de registro.", Environment.NewLine,
                                           "Data da Comissão: ", dtComissao.Value,
                                           "Data do Corte: ", dtCorte.Value,
                                           "Número: ", txtNumero.Text);
                    lg.form = this.Text;
                    lg.metodo = sender.ToString();
                    lg.dt = DateTime.Now;
                    lg.usersistema = cGlobal.userlogado;
                    lg.userRede = Environment.UserName;
                    lg.terminal = Environment.MachineName;
                    lg.tp_flag = true;
                    lg.grava_log(lg);
                    #endregion
                }

                inicio();
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

        private void lvRTO_Click(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = true;
                txtID.Text = lvRTO.SelectedItems[0].Text;
                dtComissao.Value = Convert.ToDateTime(lvRTO.SelectedItems[0].SubItems[1].Text);
                dtCorte.Value = Convert.ToDateTime(lvRTO.SelectedItems[0].SubItems[2].Text);
                txtNumero.Text = lvRTO.SelectedItems[0].SubItems[3].Text;
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

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = false;
                inicio();
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

        private void frmRTO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                inicio();
            }
        }

        private void mnuExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvRTO.SelectedItems.Count == 0)
                {
                    tsslblMsg.Text = "Nenhum registro foi selecionado";
                    return;
                }

                cRTO cr = new cRTO();
                cr.idrto = Convert.ToInt32(lvRTO.SelectedItems[0].Text);
                cr.dtcomissao = Convert.ToDateTime(lvRTO.SelectedItems[0].SubItems[1].Text);
                cr.dtcorte = Convert.ToDateTime(lvRTO.SelectedItems[0].SubItems[2].Text);
                cr.numero = Convert.ToInt32(lvRTO.SelectedItems[0].SubItems[3].Text);

                DialogResult dlr = (MessageBox.Show(string.Concat("Deseja realmente exclui o RTO?\r\n\nData da Comissão: ",
                                                                   lvRTO.SelectedItems[0].SubItems[1].Text,
                                                                   Environment.NewLine,
                                                                   "Data do Corte: ",
                                                                   lvRTO.SelectedItems[0].SubItems[2].Text,
                                                                   Environment.NewLine,
                                                                   "Número: ",
                                                                   lvRTO.SelectedItems[0].SubItems[3].Text
                                                                   ), "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (dlr == DialogResult.Yes)
                {
                    cr.exclui_RTO(cr);

                    MessageBox.Show("Registro excluído com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Exclusão de registro.", Environment.NewLine,
                                           "Data da Comissão: ", dtComissao.Value,
                                           "Data do Corte: ", dtCorte.Value,
                                           "Número: ", txtNumero.Text);
                    lg.form = this.Text;
                    lg.metodo = sender.ToString();
                    lg.dt = DateTime.Now;
                    lg.usersistema = cGlobal.userlogado;
                    lg.userRede = Environment.UserName;
                    lg.terminal = Environment.MachineName;
                    lg.tp_flag = true;
                    lg.grava_log(lg);
                    #endregion
                    inicio();
                }
                else
                {
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
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion
            }
        }

        private void tsbtnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = false;
                txtID.Text = string.Empty;
                dtComissao.Value = DateTime.Now;
                dtCorte.Value = DateTime.Now;
                txtNumero.Text = string.Empty;
                dtComissao.Focus();
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
        #endregion

        #region METODO
        private void inicio()
        {
            try
            {

                dtComissao.Value = DateTime.Now;
                dtCorte.Value = DateTime.Now;
                txtNumero.Text = string.Empty;

                cRTO cr = new cRTO();
                using (DataSet ds = cr.preenche_lista_RTO())
                {
                    using (DataTable dt = ds.Tables["RTO"])
                    {
                        #region listview
                        lvRTO.Clear();
                        lvRTO.View = View.Details;
                        lvRTO.LabelEdit = true;
                        lvRTO.AllowColumnReorder = true;
                        lvRTO.CheckBoxes = false;
                        lvRTO.FullRowSelect = true;
                        lvRTO.GridLines = true;

                        lvRTO.Columns.Add("ID", 50);
                        lvRTO.Columns.Add("Data Comissão", 100, HorizontalAlignment.Left);
                        lvRTO.Columns.Add("Data Corte", 120, HorizontalAlignment.Left);
                        lvRTO.Columns.Add("Número", 60, HorizontalAlignment.Left);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow drw = dt.Rows[i];
                            ListViewItem lvi = new ListViewItem(drw["ID_RTO"].ToString());
                            lvi.SubItems.Add(drw["DTCOMISSAO"].ToString().Substring(0, 10));
                            lvi.SubItems.Add(drw["DTCORTE"].ToString());
                            lvi.SubItems.Add(drw["NUMERO"].ToString());
                            lvRTO.Items.Add(lvi);
                        }
                        lblTotalReg.Text = string.Concat("Total de ", lvRTO.Items.Count, " registro(s)");
                        #endregion
                    }
                }

                if (lvRTO.Items.Count == 0)
                {
                    mnuOculto.Enabled = false;
                }
                else
                {
                    mnuOculto.Enabled = true;
                }

                if (lvRTO.Items.Count > 0)
                {
                    lvRTO.Items[0].Selected = true;
                    lvRTO_Click(null, null);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
