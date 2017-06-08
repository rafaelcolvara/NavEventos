using NavEventos.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace NavEventos
{
    public partial class frmStatus : Form
    {
        public frmStatus()
        {
            InitializeComponent();
        }

        #region EVENTO
        private void frmStatus_Load(object sender, EventArgs e)
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
        private void lvStatus_Click(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = true;
                txtID.Text = lvStatus.SelectedItems[0].Text;
                txtStatus.Text = lvStatus.SelectedItems[0].SubItems[1].Text;
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

        }
        private void mnuExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvStatus.SelectedItems.Count == 0)
                {
                    tsslblMsg.Text = "Nenhum registro foi selecionado";
                    return;
                }

                cStatus cs = new cStatus();
                cs.id_status = Convert.ToInt32(lvStatus.SelectedItems[0].Text);
                cs.status = lvStatus.SelectedItems[0].SubItems[1].Text;

                DialogResult dlr = (MessageBox.Show(string.Concat("Deseja realmente exclui o status:\n", lvStatus.SelectedItems[0].SubItems[1].Text, "?"), "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (dlr == DialogResult.Yes)
                {
                    if (!cs.exclui_status(cs))
                    {
                        MessageBox.Show("Registro excluído com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #region LOG
                        cLog lg = new cLog();
                        lg.log = string.Concat("Exclusão de Registro.", Environment.NewLine,
                                               "Status: ", cs.status.ToUpper()
                                               );
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
                        MessageBox.Show("O registro não pode ser excluído,\npois contém EVENTOS vínculados a ele.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        inicio();
                    }
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
        private void tsbtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                cStatus cs = new cStatus();

                #region VALIDAÇÃO
                if (string.IsNullOrEmpty(txtStatus.Text))
                {
                    tsslblMsg.Text = "Nome do status não informado";
                    txtStatus.Focus();
                    return;
                }
                #endregion

                if (!cGlobal.editando)
                {
                    cs.status = txtStatus.Text.ToUpper();
                    cs.grava_status(cs);
                    MessageBox.Show("Status registrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Cadastro de Registro.", Environment.NewLine,
                                           "Status: ", txtStatus.Text.ToUpper()
                                           );
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
                    cs.id_status = Convert.ToInt32(txtID.Text);
                    cs.status = txtStatus.Text.ToUpper();
                    cs.atualiza_cadastro_status(cs);
                    MessageBox.Show("O Status foi alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Alteração de Registro.", Environment.NewLine,
                                           "Status: ", txtStatus.Text.ToUpper()
                                           );
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
        private void tsbtnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = false;
                txtID.Text = string.Empty;
                txtStatus.Text = string.Empty;
                txtStatus.Focus();
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
        private void lvStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = true;
                txtID.Text = lvStatus.SelectedItems[0].Text;
                txtStatus.Text = lvStatus.SelectedItems[0].SubItems[1].Text;
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
                txtID.Text = string.Empty;
                txtStatus.Text = string.Empty;
                txtStatus.Focus();

                cStatus cs = new cStatus();
                using (DataSet ds = cs.preenche_lista_status())
                {
                    using (DataTable dt = ds.Tables["Status"])
                    {
                        #region listview
                        lvStatus.Clear();
                        lvStatus.View = View.Details;
                        lvStatus.LabelEdit = true;
                        lvStatus.AllowColumnReorder = true;
                        lvStatus.CheckBoxes = false;
                        lvStatus.FullRowSelect = true;
                        lvStatus.GridLines = true;
                        //lvStatus.Sorting = SortOrder.Ascending;

                        lvStatus.Columns.Add("ID", 50);
                        lvStatus.Columns.Add("Status", 430, HorizontalAlignment.Left);
                        //lvStatus.Columns.Add("Cadastro por", 120, HorizontalAlignment.Left);
                        //lvStatus.Columns.Add("Data Cadastro", 120, HorizontalAlignment.Left);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow drw = dt.Rows[i];
                            ListViewItem lvi = new ListViewItem(drw["ID_STATUS"].ToString());
                            lvi.SubItems.Add(drw["STATUS"].ToString());
                            //lvi.SubItems.Add(drw["USERCAD"].ToString());
                            //lvi.SubItems.Add(drw["DTCAD"].ToString());
                            lvStatus.Items.Add(lvi);
                        }

                        lblTotalReg.Text = string.Concat("Total de ", lvStatus.Items.Count, " registro(s)");
                        #endregion
                    }
                }

                if (lvStatus.Items.Count == 0)
                {
                    mnuOculto.Enabled = false;
                }
                else
                {
                    mnuOculto.Enabled = true;
                }

                if (lvStatus.Items.Count > 0)
                {
                    lvStatus.Items[0].Selected = true;
                    lvStatus_Click(null, null);
                }


            }
            catch (Exception ex)
            {
                #region LOG ERRO
                cLog lg = new cLog();
                lg.log = ex.Message.Replace("'", "");
                lg.form = this.Text;
                lg.metodo = "Inicio";
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
    }
}
