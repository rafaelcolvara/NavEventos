using NavEventos.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace NavEventos
{
    public partial class frmTiposEventos : Form
    {

        public frmTiposEventos()
        {
            InitializeComponent();
        }

        #region EVENTOS
        private void frmTiposEventos_Load(object sender, EventArgs e)
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

        private void frmTiposEventos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                cGlobal.editando = false;
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
                if (lvTpEventos.SelectedItems.Count == 0)
                {
                    tsslblMsg.Text = "Nenhum registro foi selecionado";
                    return;
                }

                cTipoEvento ctp = new cTipoEvento();
                ctp.id_tpevento = Convert.ToInt32(lvTpEventos.SelectedItems[0].Text);
                ctp.tpevento = lvTpEventos.SelectedItems[0].SubItems[1].Text;

                DialogResult dlr = (MessageBox.Show(string.Concat("Deseja realmente exclui o tipo de evento:\n", lvTpEventos.SelectedItems[0].SubItems[1].Text, "?"), "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (dlr == DialogResult.Yes)
                {
                    if (!ctp.exclui_tpevento(ctp))
                    {
                        MessageBox.Show("Registro excluído com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #region LOG
                        cLog lg = new cLog();
                        lg.log = string.Concat("Exclusão de Registro.", Environment.NewLine,
                                               "Evento: ", ctp.tpevento.ToUpper()
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
                        MessageBox.Show("O registro não pode ser excluído,\npois contém EVENTOS vínculados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void lvTpEventos_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvTpEventos.SelectedItems.Count == 0)
                {
                    tsslblMsg.Text = "Nenhum registro foi selecionado";
                    return;
                }

                cGlobal.editando = true;
                txtID.Text = lvTpEventos.SelectedItems[0].Text;
                txtEvento.Text = // lvTpEventos.SelectedItems[0].SubItems[1].Text;
                txtMaskara.Text = lvTpEventos.SelectedItems[0].SubItems[2].Text;
                txtRecomendacoes.Text = lvTpEventos.SelectedItems[0].SubItems[3].Text;
                chkRTO.Checked = Convert.ToBoolean(lvTpEventos.SelectedItems[0].SubItems[4].Text) == true ? true : false;
                chkExcecao.Checked = Convert.ToBoolean(lvTpEventos.SelectedItems[0].SubItems[5].Text) == true ? true : false;
                chkHabilitado.Checked = Convert.ToBoolean(lvTpEventos.SelectedItems[0].SubItems[6].Text) == true ? true : false;

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

        private void lvTpEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (lvTpEventos.SelectedItems.Count == 0)
                //{
                //    tsslblMsg.Text = "Nenhum registro foi selecionado";
                //    return;
                //}

                cGlobal.editando = true;
                txtID.Text = lvTpEventos.SelectedItems[0].Text;
                txtEvento.Text = lvTpEventos.SelectedItems[0].SubItems[1].Text;
                txtMaskara.Text = lvTpEventos.SelectedItems[0].SubItems[2].Text;
                txtRecomendacoes.Text = lvTpEventos.SelectedItems[0].SubItems[3].Text;
                chkRTO.Checked = Convert.ToBoolean(lvTpEventos.SelectedItems[0].SubItems[4].Text) == true ? true : false;
                chkExcecao.Checked = Convert.ToBoolean(lvTpEventos.SelectedItems[0].SubItems[5].Text) == true ? true : false;
                chkHabilitado.Checked = Convert.ToBoolean(lvTpEventos.SelectedItems[0].SubItems[6].Text) == true ? true : false;
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
                #region VALIDAÇÃO
                if (string.IsNullOrEmpty(txtEvento.Text))
                {
                    tsslblMsg.Text = "Tipo de Evento não informado";
                    txtEvento.Focus();
                    return;
                }
                #endregion

                cTipoEvento ctp = new cTipoEvento();
                if (!cGlobal.editando)
                {
                    ctp.tpevento = txtEvento.Text.ToUpper();
                    ctp.maskara = txtMaskara.Text;
                    ctp.recomendacoes = txtRecomendacoes.Text;
                    ctp.rto = chkRTO.Checked == true ? true : false;
                    ctp.flag_excecao = chkExcecao.Checked == true ? true : false;
                    ctp.flgHabilitado = chkHabilitado.Checked == true ? true : false;
                    ctp.grava_tipo_evento(ctp);
                    MessageBox.Show("Tipo de Evento cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Inclusão de Registro.", Environment.NewLine,
                                           "Evento: ", txtEvento.Text, Environment.NewLine,
                                           "Mascara: ", txtMaskara.Text, Environment.NewLine,
                                           "recomendacoes: ", txtRecomendacoes.Text
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
                    ctp.id_tpevento = Convert.ToInt32(txtID.Text);
                    ctp.tpevento = txtEvento.Text.ToUpper();
                    ctp.maskara = txtMaskara.Text;
                    ctp.recomendacoes = txtRecomendacoes.Text;
                    ctp.rto = chkRTO.Checked == true ? true : false;
                    ctp.flag_excecao = chkExcecao.Checked == true ? true : false;
                    ctp.flgHabilitado = chkHabilitado.Checked == true ? true : false;
                    ctp.atualiza_cadastro_tpevento(ctp);
                    MessageBox.Show("O Evento foi alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Alteração de Registro.", Environment.NewLine,
                                           "Evento: ", txtEvento.Text, Environment.NewLine,
                                           "Mascara: ", txtMaskara.Text, Environment.NewLine,
                                           "recomendacoes: ", txtRecomendacoes.Text
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
                limpa_campos();
                txtEvento.Focus();
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

        #region METODOS
        private void inicio()
        {
            try
            {
                limpa_campos();
                txtEvento.Focus();
                cTipoEvento tpe = new cTipoEvento();
                using (DataSet ds = tpe.preenche_lista_tpeventos())
                {
                    using (DataTable dt = ds.Tables["TpEventos"])
                    {
                        #region listview
                        lvTpEventos.Clear();
                        lvTpEventos.View = View.Details;
                        lvTpEventos.LabelEdit = true;
                        lvTpEventos.AllowColumnReorder = true;
                        lvTpEventos.CheckBoxes = false;
                        lvTpEventos.FullRowSelect = true;
                        lvTpEventos.GridLines = true;
                        //lvTpEventos.Sorting = SortOrder.Ascending;

                        lvTpEventos.Columns.Add("ID", 50);
                        lvTpEventos.Columns.Add("Evento", 490, HorizontalAlignment.Left);
                        //lvTpEventos.Columns.Add("Cadastro por", 120, HorizontalAlignment.Left);
                        //lvTpEventos.Columns.Add("Data Cadastro", 120, HorizontalAlignment.Left);
                        lvTpEventos.Columns.Add("", 0);
                        lvTpEventos.Columns.Add("", 0);
                        lvTpEventos.Columns.Add("", 0);
                        lvTpEventos.Columns.Add("", 0);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow drw = dt.Rows[i];
                            ListViewItem lvi = new ListViewItem(drw["ID_TP_EVENTO"].ToString());
                            lvi.SubItems.Add(drw["EVENTO"].ToString());
                            //lvi.SubItems.Add(drw["USERCAD"].ToString());
                            //lvi.SubItems.Add(drw["DTCAD"].ToString());
                            lvi.SubItems.Add(drw["MASCARA"].ToString());
                            lvi.SubItems.Add(drw["RECOMENDACOES"].ToString());
                            lvi.SubItems.Add(drw["RTO"].ToString());
                            lvi.SubItems.Add(drw["FLAG"].ToString());
                            lvi.SubItems.Add(drw["flgHabilitado"].ToString());

                            lvTpEventos.Items.Add(lvi);
                        }
                        lblTotalReg.Text = string.Concat("Total de ", lvTpEventos.Items.Count, " registro(s)");
                        #endregion
                    }
                }

                if (lvTpEventos.Items.Count == 0)
                {
                    mnuOculto.Enabled = false;
                }
                else
                {
                    mnuOculto.Enabled = true;
                }

                if (lvTpEventos.Items.Count > 0)
                {
                    lvTpEventos.Items[0].Selected = true;
                    lvTpEventos_Click(null, null);
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

        private void limpa_campos()
        {
            txtID.Text = string.Empty;
            txtEvento.Text = string.Empty;
            txtMaskara.Text = string.Empty;
            txtRecomendacoes.Text = string.Empty;
            chkRTO.Checked = false;
            chkExcecao.Checked = false;
            chkHabilitado.Checked = false;
        }


        #endregion


    }
}
