using NavEventos.Class;
using System;
using System.Data;
using System.Windows.Forms;


namespace NavEventos
{
    public partial class frmClientes : Form
    {

        public frmClientes()
        {
            InitializeComponent();
        }

        #region EVENTOS
        private void frmClientes_Load(object sender, EventArgs e)
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
        private void frmClientes_KeyDown(object sender, KeyEventArgs e)
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
        private void mnuExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvClientes.SelectedItems.Count == 0)
                {
                    tsslblMsg.Text = "Nenhum registro foi selecionado";
                    return;
                }

                cCliente cli = new cCliente();
                cli.id_cliente = Convert.ToInt32(lvClientes.SelectedItems[0].Text);
                cli.cliente = lvClientes.SelectedItems[0].SubItems[1].Text;

                DialogResult dlr = (MessageBox.Show(string.Concat("Deseja realmente exclui o cliente:\n", lvClientes.SelectedItems[0].SubItems[1].Text, "?"), "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (dlr == DialogResult.Yes)
                {
                    if (!cli.exclui_cliente(cli))
                    {
                        MessageBox.Show("Registro excluído com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #region LOG
                        cLog lg = new cLog();
                        lg.log = string.Concat("Exclusão de Registro.", Environment.NewLine,
                                               "Cliente: ", cli.cliente.ToUpper());
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
        private void lvClientes_Click(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = true;
                txtID.Text = lvClientes.SelectedItems[0].Text;
                txtNome.Text = lvClientes.SelectedItems[0].SubItems[1].Text;
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
        private void lvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = true;
                txtID.Text = lvClientes.SelectedItems[0].Text;
                txtNome.Text = lvClientes.SelectedItems[0].SubItems[1].Text;
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
                cCliente cli = new cCliente();

                #region VALIDAÇÃO
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    tsslblMsg.Text = "Nome do cliente não informado";
                    txtNome.Focus();
                    return;
                }
                #endregion

                if (!cGlobal.editando)
                {
                    cli.cliente = txtNome.Text.ToUpper();
                    cli.grava_cliente(cli);
                    MessageBox.Show("Cliente registrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Cadastro de Registro.", Environment.NewLine,
                                           "Cliente: ", txtNome.Text.ToUpper());
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
                    cli.id_cliente = Convert.ToInt32(txtID.Text);
                    cli.cliente = txtNome.Text.ToUpper();
                    cli.atualiza_cadastro_cliente(cli);
                    MessageBox.Show("Os dados do cliente foi alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Alteração de Registro.", Environment.NewLine,
                                           "Cliente: ", txtNome.Text.ToUpper());
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
        private void tsbtnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = false;
                txtID.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtNome.Focus();
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
                txtNome.Text = string.Empty;

                cCliente cli = new cCliente();
                using (DataSet ds = cli.preenche_lista_cliente())
                {
                    using (DataTable dt = ds.Tables["Clientes"])
                    {
                        #region listview
                        lvClientes.Clear();
                        lvClientes.View = View.Details;
                        lvClientes.LabelEdit = true;
                        lvClientes.AllowColumnReorder = true;
                        lvClientes.CheckBoxes = false;
                        lvClientes.FullRowSelect = true;
                        lvClientes.GridLines = true;
                        // lvClientes.Sorting = SortOrder.Ascending;

                        lvClientes.Columns.Add("ID", 50);
                        lvClientes.Columns.Add("Nome", 320, HorizontalAlignment.Left);
                        //lvClientes.Columns.Add("Cadastro por", 120, HorizontalAlignment.Left);
                        //lvClientes.Columns.Add("Data Cadastro", 120, HorizontalAlignment.Left);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow drw = dt.Rows[i];
                            ListViewItem lvi = new ListViewItem(drw["ID_CLIENTE"].ToString());
                            lvi.SubItems.Add(drw["CLIENTE"].ToString().ToUpper());
                            //lvi.SubItems.Add(drw["USERCAD"].ToString());
                            //lvi.SubItems.Add(drw["DTCAD"].ToString().Substring(0, 10));

                            lvClientes.Items.Add(lvi);
                        }
                        lblTotalReg.Text = string.Concat("Total de ", lvClientes.Items.Count, " registro(s)");
                        #endregion
                    }
                }

                if (lvClientes.Items.Count == 0)
                {
                    mnuOculto.Enabled = false;
                }
                else
                {
                    mnuOculto.Enabled = true;
                }

                if (lvClientes.Items.Count > 0)
                {
                    lvClientes.Items[0].Selected = true;
                    lvClientes_Click(null, null);
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
