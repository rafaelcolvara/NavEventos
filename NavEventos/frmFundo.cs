using NavEventos.Class;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NavEventos
{
    public partial class frmFundo : Form
    {
        public frmFundo()
        {
            InitializeComponent();
        }

        #region EVENTOS
        private void frmFundo_Load(object sender, EventArgs e)
        {
            try
            {
                inicio();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void frmFundo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                inicio();
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }
        private void rbCnpj_CheckedChanged(object sender, EventArgs e)
        {
            mktCnpjCpf.Mask = "00.000.000/0000-00";
            mktCnpjCpf.ReadOnly = false;
            mktCnpjCpf.Focus();
        }
        private void rbCpf_CheckedChanged(object sender, EventArgs e)
        {
            mktCnpjCpf.Mask = "000.000.000-00";
            mktCnpjCpf.ReadOnly = false;
            mktCnpjCpf.Focus();
        }
        private void mnuExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvFundo.SelectedItems.Count == 0)
                {
                    tsslblMsg.Text = "Nenhum registro foi selecionado";
                    return;
                }

                cFundo fd = new cFundo();
                fd.id_Fundo = Convert.ToInt32(lvFundo.SelectedItems[0].Text);
                fd.razao_social = lvFundo.SelectedItems[0].SubItems[1].Text;

                DialogResult dlr = (MessageBox.Show(string.Concat("Deseja realmente exclui a Razão Social:\n", lvFundo.SelectedItems[0].SubItems[1].Text, "?"), "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (dlr == DialogResult.Yes)
                {
                    if (!fd.exclui_fundo(fd))
                    {
                        MessageBox.Show("Registro excluído com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #region LOG
                        cLog lg = new cLog();
                        lg.log = string.Concat("Exclusão de Registro.", Environment.NewLine,
                                               "Razão Social(Fundo): ", fd.razao_social.ToUpper()
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
        private void lvFundo_Click(object sender, EventArgs e)
        {
            try
            {
                string doc;

                cGlobal.editando = true;
                txtID.Text = lvFundo.SelectedItems[0].Text;
                txtRazaoSocial.Text = lvFundo.SelectedItems[0].SubItems[1].Text;
                txtSiglaSac.Text = lvFundo.SelectedItems[0].SubItems[2].Text;
                txtSiglaFy.Text = lvFundo.SelectedItems[0].SubItems[3].Text;
                doc = lvFundo.SelectedItems[0].SubItems[4].Text.Replace(",", "").Replace(".", "").Replace("/", "").Replace("-", "");

                if (doc.Length == 14)
                {
                    rbCnpj.Checked = true;
                    mktCnpjCpf.Mask = "00.000.000/0000-00";
                    mktCnpjCpf.Text = string.Concat(doc.Substring(0, 2), doc.Substring(2, 3), doc.Substring(5, 3), doc.Substring(8, 4), doc.Substring(12, 2)).Replace(",", ".");
                }
                else
                {
                    rbCpf.Checked = true;
                    mktCnpjCpf.Mask = "000.000.000-00";
                    mktCnpjCpf.Text = string.Concat(doc.Substring(0, 3), doc.Substring(3, 3), doc.Substring(6, 3), doc.Substring(9, 2)).Replace(",", ".");
                }

            }
            catch (Exception ex)
            {
                rbCnpj.Checked = true;
                mktCnpjCpf.Text = "  ,   ,   /    -";
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
                #region VALIDACAO
                if (string.IsNullOrEmpty(txtRazaoSocial.Text))
                {
                    tsslblMsg.Text = "Razão Social não informada";
                    txtRazaoSocial.Focus();
                    return;
                }
                #endregion

                cFundo fd = new cFundo();
                fd.razao_social = txtRazaoSocial.Text.ToUpper();
                fd.SiglaSAC = txtSiglaSac.Text.ToUpper();
                fd.SiglaFY = txtSiglaFy.Text.ToUpper();
                fd.CnpjCpf = mktCnpjCpf.Text.Replace(".", "").Replace(",", "").Replace("-", "").Replace("/", "");

                if (!cGlobal.editando)
                {
                    fd.grava_fundo(fd);
                    MessageBox.Show("Fundo cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Cadastro de Registro.", Environment.NewLine,
                                           "Razão Social(Fundo): ", txtRazaoSocial.Text.ToUpper(), Environment.NewLine,
                                           "Sigla SAC: ", txtSiglaSac.Text.ToUpper(), Environment.NewLine,
                                           "Sigla FY: ", txtSiglaFy.Text.ToUpper(), Environment.NewLine,
                                           "CNPJ/CPF: ", mktCnpjCpf.Text.Replace(".", "").Replace(",", "").Replace("-", "").Replace("/", "")
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
                    fd.id_Fundo = fd.retorna_id_fundo(fd);
                    fd.atualiza_cadastro_fundo(fd);
                    MessageBox.Show("Fundo alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Alteração de Registro.", Environment.NewLine,
                                           "Razão Social(Fundo): ", txtRazaoSocial.Text.ToUpper(), Environment.NewLine,
                                           "Sigla SAC: ", txtSiglaSac.Text.ToUpper(), Environment.NewLine,
                                           "Sigla FY: ", txtSiglaFy.Text.ToUpper(), Environment.NewLine,
                                           "CNPJ/CPF: ", mktCnpjCpf.Text.Replace(".", "").Replace(",", "").Replace("-", "").Replace("/", "")
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
                tsslblMsg.Text = "Erro ao cadastrar o fundo. Para mais detalhes, consulte o Log.";
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
        private void lvFundo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string doc;

                cGlobal.editando = true;
                txtID.Text = lvFundo.SelectedItems[0].Text;
                txtRazaoSocial.Text = lvFundo.SelectedItems[0].SubItems[1].Text;
                txtSiglaSac.Text = lvFundo.SelectedItems[0].SubItems[2].Text;
                txtSiglaFy.Text = lvFundo.SelectedItems[0].SubItems[3].Text;
                doc = lvFundo.SelectedItems[0].SubItems[4].Text.Replace(",", "").Replace(".", "").Replace("/", "").Replace("-", "");

                if (doc.Length == 14)
                {
                    rbCnpj.Checked = true;
                    mktCnpjCpf.Mask = "00.000.000/0000-00";
                    mktCnpjCpf.Text = string.Concat(doc.Substring(0, 2), doc.Substring(2, 3), doc.Substring(5, 3), doc.Substring(8, 4), doc.Substring(12, 2)).Replace(",", ".");
                }
                else
                {
                    rbCpf.Checked = true;
                    mktCnpjCpf.Mask = "000.000.000-00";
                    mktCnpjCpf.Text = string.Concat(doc.Substring(0, 3), doc.Substring(3, 3), doc.Substring(6, 3), doc.Substring(9, 2)).Replace(",", ".");
                }
            }
            catch (Exception ex)
            {
                rbCnpj.Checked = true;
                mktCnpjCpf.Text = "  ,   ,   /    -";
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
                txtRazaoSocial.Text = string.Empty;
                txtSiglaSac.Text = string.Empty;
                txtSiglaFy.Text = string.Empty;
                mktCnpjCpf.Text = string.Empty;
                mktCnpjCpf.ReadOnly = true;
                mktCnpjCpf.BackColor = Color.White;
                rbCnpj.Checked = false;
                rbCpf.Checked = false;
                txtRazaoSocial.Focus();

                cFundo fd = new cFundo();
                using (DataSet ds = fd.preenche_lista_fundo())
                {
                    using (DataTable dt = ds.Tables["Fundo"])
                    {
                        #region listview
                        lvFundo.Clear();
                        lvFundo.View = View.Details;
                        lvFundo.LabelEdit = false;
                        lvFundo.AllowColumnReorder = true;
                        lvFundo.CheckBoxes = false;
                        lvFundo.FullRowSelect = true;
                        lvFundo.GridLines = true;
                        lvFundo.Sorting = SortOrder.Ascending;

                        lvFundo.Columns.Add("", 0);
                        lvFundo.Columns.Add("Razão Social", 290, HorizontalAlignment.Left);
                        lvFundo.Columns.Add("Sigla SAC", 100, HorizontalAlignment.Center);
                        lvFundo.Columns.Add("Sigla FY", 100, HorizontalAlignment.Center);
                        lvFundo.Columns.Add("CNPJ/CPF", 150, HorizontalAlignment.Center);
                        //lvFundo.Columns.Add("Cadastro por", 120, HorizontalAlignment.Left);
                        //lvFundo.Columns.Add("Data Cadastro", 120, HorizontalAlignment.Left);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow drw = dt.Rows[i];
                            ListViewItem lvi = new ListViewItem(drw["ID_FUNDO"].ToString());
                            lvi.SubItems.Add(drw["RAZAO_SOCIAL"].ToString());
                            lvi.SubItems.Add(drw["SIGLA_SAC"].ToString());
                            lvi.SubItems.Add(drw["SIGLA_FY"].ToString());

                            if (drw["CNPJ_CPF"].ToString().Length == 14)
                            {
                                lvi.SubItems.Add(string.Concat(drw["CNPJ_CPF"].ToString().Substring(0, 2), ".",
                                                               drw["CNPJ_CPF"].ToString().Substring(2, 3), ".",
                                                               drw["CNPJ_CPF"].ToString().Substring(5, 3), "/",
                                                               drw["CNPJ_CPF"].ToString().Substring(8, 4), "-",
                                                               drw["CNPJ_CPF"].ToString().Substring(12, 2)).Replace(",", "."));
                            }
                            else if (drw["CNPJ_CPF"].ToString().Length == 11)
                            {
                                lvi.SubItems.Add(string.Concat(drw["CNPJ_CPF"].ToString().Substring(0, 3), ".",
                                                               drw["CNPJ_CPF"].ToString().Substring(3, 3), ".",
                                                               drw["CNPJ_CPF"].ToString().Substring(6, 3), "-",
                                                               drw["CNPJ_CPF"].ToString().Substring(9, 2)).Replace(",", "."));
                            }
                            //lvi.SubItems.Add(drw["USERCAD"].ToString());
                            //lvi.SubItems.Add(drw["DTCAD"].ToString());

                            lvFundo.Items.Add(lvi);
                        }
                        lblTotalReg.Text = string.Concat("Total de ", lvFundo.Items.Count, " registro(s)");
                        #endregion
                    }
                }

                if (lvFundo.Items.Count == 0)
                {
                    mnuOculto.Enabled = false;
                }
                else
                {
                    mnuOculto.Enabled = true;
                }

                if (lvFundo.Items.Count > 0)
                {
                    lvFundo.Items[0].Selected = true;
                    lvFundo_Click(null, null);
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

        #endregion

        private void tsbtnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                cGlobal.editando = false;
                txtID.Text = string.Empty;
                txtRazaoSocial.Text = string.Empty;
                txtSiglaSac.Text = string.Empty;
                txtSiglaFy.Text = string.Empty;
                rbCnpj.Checked = true;
                //mktCnpjCpf.Mask = "00.000.000/0000-00";
                mktCnpjCpf.Text = string.Empty;
                txtRazaoSocial.Focus();
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

        private void tsbtnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Title = "Importar Xlsx";
                ofd.InitialDirectory = @"C:\";
                //odo.Filter = "Excel (*.xlsx)|*.xlsx|" + "All files (*.*)|*.*";
                ofd.Filter = "Excel (*.xls)|*.xls";
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = true;
                ofd.ReadOnlyChecked = true;
                ofd.ShowReadOnly = true;
                ofd.Title = "Selecione o Arquivo";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.AppStarting;
                    cFundo cf = new cFundo();
                    using (DataSet ds = cf.retorna_planilha_fundos(ofd.FileName))
                    {
                        tsprbProgress.Visible = true;
                        tsprbProgress.Value = 0;
                        tsprbProgress.Maximum = ds.Tables[0].Rows.Count;
                        int count = 1;

                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            cf.razao_social = item[1].ToString();
                            cf.SiglaSAC = item[0].ToString();
                            cf.SiglaFY = item[3].ToString();
                            cf.CnpjCpf = item[2].ToString();
                            if (!cf.verifica_fundo_existe(cf))
                            {
                                cf.grava_fundo(cf);
                            }
                            else
                            {
                                cf.id_Fundo = cf.retorna_id_fundo(cf);
                                cf.atualiza_cadastro_fundo(cf);
                            }
                            count++;
                            tsprbProgress.Value++;
                        }
                    }
                    inicio();
                    tsprbProgress.Visible = false;
                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
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
