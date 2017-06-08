using NavEventos.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace NavEventos
{
    public partial class frmProduto : Form
    {
        public frmProduto()
        {
            InitializeComponent();
        }

        #region EVENTO
        private void frmProduto_Load(object sender, EventArgs e)
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
        private void tsbtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                cProduto prod = new cProduto();

                #region VALIDAÇÃO
                if (string.IsNullOrEmpty(txtProduto.Text))
                {
                    tsslblMsg.Text = "Nome do Produto não informado";
                    txtProduto.Focus();
                    return;
                }
                #endregion

                if (!cGlobal.editando)
                {
                    prod.produto = txtProduto.Text.ToUpper();
                    prod.grava_produto(prod);
                    MessageBox.Show("Produto registrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Cadastro de Registro.", Environment.NewLine,
                                           "Produto: ", txtProduto.Text.ToUpper()
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
                    prod.idproduto = Convert.ToInt32(txtID.Text);
                    prod.produto = txtProduto.Text.ToUpper();
                    prod.atualiza_cadastro_produto(prod);
                    MessageBox.Show("O Produto foi alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Alteração de Registro.", Environment.NewLine,
                                           "Status: ", txtProduto.Text.ToUpper()
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
        private void lvProduto_Click(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = true;
                txtID.Text = lvProduto.SelectedItems[0].Text;
                txtProduto.Text = lvProduto.SelectedItems[0].SubItems[1].Text;
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
                if (lvProduto.SelectedItems.Count == 0)
                {
                    tsslblMsg.Text = "Nenhum registro foi selecionado";
                    return;
                }

                cProduto prod = new cProduto();
                prod.idproduto = Convert.ToInt32(lvProduto.SelectedItems[0].Text);
                prod.produto = lvProduto.SelectedItems[0].SubItems[1].Text;

                DialogResult dlr = (MessageBox.Show(string.Concat("Deseja realmente exclui o produto:\n", lvProduto.SelectedItems[0].SubItems[1].Text, "?"), "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (dlr == DialogResult.Yes)
                {
                    if (!prod.exclui_produto(prod))
                    {
                        MessageBox.Show("Registro excluído com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #region LOG
                        cLog lg = new cLog();
                        lg.log = string.Concat("Exclusão de Registro.", Environment.NewLine,
                                               "Produto: ", prod.produto.ToUpper()
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
        private void lvProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = true;
                txtID.Text = lvProduto.SelectedItems[0].Text;
                txtProduto.Text = lvProduto.SelectedItems[0].SubItems[1].Text;
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
                txtProduto.Text = string.Empty;
                txtProduto.Focus();
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

        #endregion

        #region METODO
        private void inicio()
        {
            try
            {
                txtID.Text = string.Empty;
                txtProduto.Text = string.Empty;
                txtProduto.Focus();

                cProduto cprod = new cProduto();
                using (DataSet ds = cprod.preenche_lista_produto())
                {
                    using (DataTable dt = ds.Tables["Produto"])
                    {
                        #region listview
                        lvProduto.Clear();
                        lvProduto.View = View.Details;
                        lvProduto.LabelEdit = true;
                        lvProduto.AllowColumnReorder = true;
                        lvProduto.CheckBoxes = false;
                        lvProduto.FullRowSelect = true;
                        lvProduto.GridLines = true;
                        lvProduto.Sorting = SortOrder.Ascending;

                        lvProduto.Columns.Add("ID", 50);
                        lvProduto.Columns.Add("Produto", 340, HorizontalAlignment.Left);
                        //lvProduto.Columns.Add("Cadastro por", 120, HorizontalAlignment.Left);
                        //lvProduto.Columns.Add("Data Cadastro", 120, HorizontalAlignment.Left);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow drw = dt.Rows[i];
                            ListViewItem lvi = new ListViewItem(drw["ID_PRODUTO"].ToString());
                            lvi.SubItems.Add(drw["PRODUTO"].ToString());
                            //lvi.SubItems.Add(drw["USERCAD"].ToString());
                            //lvi.SubItems.Add(drw["DTCAD"].ToString());

                            if (lvi.Text != "1")
                            {
                                lvProduto.Items.Add(lvi);
                            }
                        }
                        lblTotalReg.Text = string.Concat("Total de ", lvProduto.Items.Count, " registro(s)");
                        #endregion
                    }
                }

                if (lvProduto.Items.Count == 0)
                {
                    mnuOculto.Enabled = false;
                }
                else
                {
                    mnuOculto.Enabled = true;
                }

                if (lvProduto.Items.Count > 0)
                {
                    lvProduto.Items[0].Selected = true;
                    lvProduto_Click(null, null);
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
