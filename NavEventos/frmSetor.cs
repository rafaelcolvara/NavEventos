using NavEventos.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace NavEventos
{
    public partial class frmSetor : Form
    {
        public frmSetor()
        {
            InitializeComponent();
        }

        #region EVENTO
        private void frmSetor_Load(object sender, EventArgs e)
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
        private void frmSetor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                inicio();
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
        private void lvSetor_Click(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = true;
                txtID.Text = lvSetor.SelectedItems[0].Text;
                txtSetor.Text = lvSetor.SelectedItems[0].SubItems[1].Text;
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
        private void mnuExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvSetor.SelectedItems.Count == 0)
                {
                    tsslblMsg.Text = "Nenhum registro foi selecionado";
                    return;
                }

                cSetor cst = new cSetor();
                cst.id_setor = Convert.ToInt32(lvSetor.SelectedItems[0].Text);
                cst.setor = lvSetor.SelectedItems[0].SubItems[1].Text;

                DialogResult dlr = (MessageBox.Show(string.Concat("Deseja realmente exclui o setor:\n", lvSetor.SelectedItems[0].SubItems[1].Text, "?"), "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (dlr == DialogResult.Yes)
                {
                    if (!cst.exclui_setor(cst))
                    {
                        MessageBox.Show("Registro excluído com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #region LOG
                        cLog lg = new cLog();
                        lg.log = string.Concat("Exclusão de Registro.", Environment.NewLine,
                                               "Setor: ", cst.setor.ToUpper()
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
                        MessageBox.Show(string.Concat("O registro não pode ser excluído,", Environment.NewLine, "pois contém EVENTO(S) vínculados a ele."), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                cSetor cst = new cSetor();

                #region VALIDAÇÃO
                if (string.IsNullOrEmpty(txtSetor.Text))
                {
                    tsslblMsg.Text = "Nome do setor não informado";
                    txtSetor.Focus();
                    return;
                }
                #endregion

                if (!cGlobal.editando)
                {
                    cst.setor = txtSetor.Text.ToUpper();
                    cst.grava_setor(cst);
                    MessageBox.Show("Setor registrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Cadastro de Registro.", Environment.NewLine,
                                           "Setor: ", txtSetor.Text.ToUpper()
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
                    cst.id_setor = Convert.ToInt32(txtID.Text);
                    cst.setor = txtSetor.Text.ToUpper();
                    cst.atualiza_cadastro_setor(cst);
                    MessageBox.Show("O Setor foi alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Alteração de Registro.", Environment.NewLine,
                                           "Setor: ", txtSetor.Text.ToUpper()
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
                txtSetor.Text = string.Empty;
                txtSetor.Focus();
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
        private void lvSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = true;
                txtID.Text = lvSetor.SelectedItems[0].Text;
                txtSetor.Text = lvSetor.SelectedItems[0].SubItems[1].Text;
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
                txtSetor.Text = string.Empty;
                txtSetor.Focus();

                cSetor cst = new cSetor();
                using (DataSet ds = cst.preenche_lista_setor())
                {
                    using (DataTable dt = ds.Tables["Setor"])
                    {
                        #region listview
                        lvSetor.Clear();
                        lvSetor.View = View.Details;
                        lvSetor.LabelEdit = true;
                        lvSetor.AllowColumnReorder = true;
                        lvSetor.CheckBoxes = false;
                        lvSetor.FullRowSelect = true;
                        lvSetor.GridLines = true;
                        lvSetor.Sorting = SortOrder.Ascending;

                        lvSetor.Columns.Add("ID", 50);
                        lvSetor.Columns.Add("Setor", 330, HorizontalAlignment.Left);
                        //lvSetor.Columns.Add("Cadastro por", 120, HorizontalAlignment.Left);
                        //lvSetor.Columns.Add("Data Cadastro", 120, HorizontalAlignment.Left);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow drw = dt.Rows[i];
                            ListViewItem lvi = new ListViewItem(drw["ID_SETOR"].ToString());
                            lvi.SubItems.Add(drw["SETOR"].ToString());
                            //lvi.SubItems.Add(drw["USERCAD"].ToString());
                            //lvi.SubItems.Add(drw["DTCAD"].ToString());

                            lvSetor.Items.Add(lvi);
                        }
                        lblTotalReg.Text = string.Concat("Total de ", lvSetor.Items.Count, " registro(s)");
                        #endregion
                    }
                }

                if (lvSetor.Items.Count == 0)
                {
                    mnuOculto.Enabled = false;
                }
                else
                {
                    mnuOculto.Enabled = true;
                }

                if (lvSetor.Items.Count > 0)
                {
                    lvSetor.Items[0].Selected = true;
                    lvSetor_Click(null, null);
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
