using NavEventos.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;


namespace NavEventos
{
    public partial class frmInicial : Form
    {
        #region VARIAVEIS
        ArrayList countsetorcheck = new ArrayList();
        ArrayList countitemcheck = new ArrayList();
        DataSet dsRegEvento = new DataSet();
        bool navegando = false;
        bool flgAlterouMascara = false;

        string v_monta_nova_proposta = string.Empty;

        string descricao_log = string.Empty;

        DateTime v_dt_exec_plan, v_dt_cota;
        int v_esforco_plan, v_id_tp_evento;
        string v_responsavel, v_atividade;

        #endregion

        #region EVENTOS

        #region FORM
        public frmInicial()
        {
            InitializeComponent();
        }
        private void frmInicial_Load(object sender, EventArgs e)
        {
            try
            {
                #region RETORNA USUÁRIO LOGADO 
                string userlog = Environment.UserName;
                string name_machine = Environment.MachineName;

                tsslblUsuario.Text = string.Concat("Login Sistema: ", cGlobal.userlogado);
                tsslblUsuarioDtHr.Text = string.Concat("Data/Hora: ", DateTime.Now);
                tsslblUsuarioRede.Text = string.Concat("Usuário Rede: ", userlog);
                tsslblUsuarioRedeDNS.Text = string.Concat("Terminal: ", name_machine);
                #endregion

                //timer1.Start();
                inicio();


                tstxtLocalizar.Focus();
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
        private void frmInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Alt && e.KeyCode == Keys.F4)
            {
                Dispose();
                Close();
            }
            //atualiza o formulário inteiro
            if (e.KeyCode == Keys.F5)
            {
                inicio();
            }
            if (e.KeyCode == Keys.Enter)
            {
                tsbLocalizar_Click(null, null);
            }
        }
        private void frmInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (navegando)
                {
                    e.Cancel = true;
                }
                else
                {
                    //e.Cancel = false;
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = "Finalizou o acesso ao Sistema.";
                    lg.form = this.Text;
                    lg.metodo = sender.ToString();
                    lg.dt = DateTime.Now;
                    lg.usersistema = cGlobal.userlogado;
                    lg.userRede = Environment.UserName;
                    lg.terminal = Environment.MachineName;
                    lg.tp_flag = true;
                    lg.grava_log(lg);
                    #endregion
                    dsRegEvento.Dispose();
                    Dispose();
                    Close();
                    Application.Exit();
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

        #endregion

        #region MENUS
        private void mnuSair_Click(object sender, EventArgs e)
        {
            try
            {
                navegando = false;
                #region LOG
                cLog lg = new cLog();
                lg.log = "Finalizou o acesso ao Sistema.";
                lg.form = this.Text;
                lg.metodo = sender.ToString();
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = true;
                lg.grava_log(lg);
                #endregion
                dsRegEvento.Dispose();
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
        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmUsuario frm = new frmUsuario())
                {
                    frm.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuClientes_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmClientes frm = new frmClientes())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuTipoEvento_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmTiposEventos frm = new frmTiposEventos())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuStatusEvento_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmStatus frm = new frmStatus())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuSetor_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmSetor frm = new frmSetor())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cGlobal.novo)
                {
                    inicio();
                }
                else
                {
                    carrega_combos_checklistbox();
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
        private void mnuAtividade_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmCronograma frm = new frmCronograma())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuSobre_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmAbout frm = new frmAbout())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuFundo_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmFundo frm = new frmFundo())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuCapacity_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmCapacity frm = new frmCapacity())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuLog_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmLog frm = new frmLog())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuDemandaAtiv_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmAtividade frm = new frmAtividade())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuLogoff_Click(object sender, EventArgs e)
        {
            try
            {
                #region LOG
                cLog lg = new cLog();
                lg.log = "Efetuado Logoff no Sistema";
                lg.form = this.Text;
                lg.metodo = sender.ToString();
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = true;
                lg.grava_log(lg);
                #endregion
                using (frmLogin frm = new frmLogin())
                {
                    this.Hide();
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
        private void mnuBackup_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmBackup frm = new frmBackup())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuRestore_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmRestore frm = new frmRestore())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuReportAtividade_Click(object sender, EventArgs e)
        {
            try
            {
                using (Report.frmReportAtividade frm = new Report.frmReportAtividade())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuReportPeriodo_Click(object sender, EventArgs e)
        {
            try
            {
                using (Report.frmRerportPeriodo frm = new Report.frmRerportPeriodo())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuProduto_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmProduto frm = new frmProduto())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mnuDesbloquear_Click(object sender, EventArgs e)
        {
            try
            {
                //retorna quem está bloqueando o capacity
                cUsuario user = new cUsuario();
                using (DataSet ds = user.retorna_usuario_bloqueado())
                {
                    foreach (DataRow item in ds.Tables["Bloqueio"].Rows)
                    {
                        cGlobal.user_bloq = item["USERCAD"].ToString();
                        cGlobal.dt_blog = Convert.ToDateTime(item["DTCAD"].ToString());
                    }
                }

                if (string.IsNullOrEmpty(cGlobal.user_bloq))
                {
                    MessageBox.Show("O Capacity não encontra-se bloqueado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DialogResult dlr = (MessageBox.Show(string.Format("O Capacity encontra-se bloqueado. Último acesso:\r\n\nUsuário: {0}\r\nData: {1}.\r\n\nDeseja desbloquear o Capacity para os outros usuários?", cGlobal.user_bloq, cGlobal.dt_blog), "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                    if (dlr == DialogResult.Yes)
                    {
                        user.login = cGlobal.userlogado;
                        user.bloqueia_usuario_capacity(user, false);
                        MessageBox.Show("Debloqueio realizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        return;
                    }
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
        private void mnuVisaoEventos_Click(object sender, EventArgs e)
        {
            try
            {
                using (ViewEventos frm = new ViewEventos())
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

        #region CHECKLISTBOX
        private void chklbSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cSetor cst = new cSetor();

                int selected = chklbSetor.SelectedIndex;
                if (selected != -1)
                {
                    var ret = cst.retorna_id_setor(chklbSetor.Items[selected].ToString());
                    cst.id_setor = int.Parse(ret[0].ToString());
                    cst.id_seq_evento = Convert.ToInt32(txtIDSeq.Text);

                    if (!countsetorcheck.Contains(chklbSetor.Items[selected].ToString()))
                    {
                        #region SE O ITEM NÃO CONTER NO ARRAY ELE ADICIONA PARA FAZER A VERIFICAÇÃO DEPOIS
                        countsetorcheck.Add(chklbSetor.Items[selected].ToString());
                        cst.grava_relacao_evento_setor(cst);
                        #endregion
                    }
                    else
                    {
                        #region SE O ITEM EXISTIR NO ARRAY E O ITEM FOR CHECKED FALSO, REMOVE DO ARRAY E DA TABELA DESCRICAO_EVENTO_TB
                        countsetorcheck.Remove(chklbSetor.Items[selected].ToString());
                        cst.remove_relacao_evento_setor(cst);
                        #endregion
                    }
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
        private void chklbTpEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cMaskara cm = new cMaskara();

                int selected = chklbTpEvento.SelectedIndex;
                if (selected != -1)
                {
                    string textoMascara = cm.retorna_maskara_evento(chklbTpEvento.Items[selected].ToString(), Convert.ToInt32(txtIDSeq.Text));
                    int retid = cm.retorna_id_tipo_evento(chklbTpEvento.Items[selected].ToString());
                    var retNomeEvento = cm.retorna_nome_evento(chklbTpEvento.Items[selected].ToString());
                    var retRTO = cm.retorna_RTO(chklbTpEvento.Items[selected].ToString());
                    cm.seq_evento = Convert.ToInt32(txtIDSeq.Text);
                    cm.id_tpevento = Convert.ToInt32(retid.ToString());
                    cm.nome_evento = retNomeEvento[0].ToString();
                    cm.maskara = textoMascara.ToString();
                    cm.parecer_rto = retRTO.ToString();
                    txtMascara.Text = textoMascara;

                    if (!countitemcheck.Contains(chklbTpEvento.Items[selected].ToString()))
                    {
                        #region SE O ITEM NÃO CONTER NO ARRAY ELE ADICIONA PARA FAZER A VERIFICAÇÃO DEPOIS
                        countitemcheck.Add(chklbTpEvento.Items[selected].ToString());
                        cm.grava_descricao(cm);
                        retorna_grid_tipo_eventos(int.Parse(txtIDSeq.Text));
                        cm.grava_temp_mascara(cm);

                        #endregion
                    }
                    else
                    {
                        #region SE O ITEM EXISTIR NO ARRAY E O ITEM FOR CHECKED FALSO, REMOVE DO ARRAY E DA TABELA DESCRICAO_EVENTO_TB
                        countitemcheck.Remove(chklbTpEvento.Items[selected].ToString());
                        cm.remove_descricao(cm);
                        retorna_grid_tipo_eventos(int.Parse(txtIDSeq.Text));
                        #endregion
                    }
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

        #endregion

        #region CONTROLE TOOLSTRIP
        private void tsbtnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                BindingContext[dsRegEvento, "Eventoreg"].Position = 0;
                tslStatus.Text = string.Concat(BindingContext[dsRegEvento, "Eventoreg"].Position + 1, "/", BindingContext[dsRegEvento, "Eventoreg"].Count);
                retorna_setores(int.Parse(txtIDSeq.Text));
                retorna_tipos_eventos(int.Parse(txtIDSeq.Text));
                trata_flag(lblFlag.Text);
                retorna_dados_fundo(int.Parse(txtIDSeq.Text));
                retorna_grid_tipo_eventos(int.Parse(txtIDSeq.Text));
                this.Cursor = Cursors.Arrow;
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
        private void tsbtnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                BindingContext[dsRegEvento, "Eventoreg"].Position -= 1;
                tslStatus.Text = string.Concat(BindingContext[dsRegEvento, "Eventoreg"].Position + 1, "/", BindingContext[dsRegEvento, "Eventoreg"].Count);
                retorna_setores(int.Parse(txtIDSeq.Text));
                retorna_tipos_eventos(int.Parse(txtIDSeq.Text));
                trata_flag(lblFlag.Text);
                retorna_dados_fundo(int.Parse(txtIDSeq.Text));
                retorna_grid_tipo_eventos(int.Parse(txtIDSeq.Text));
                this.Cursor = Cursors.Arrow;
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
        private void tsbtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                BindingContext[dsRegEvento, "Eventoreg"].Position += 1;
                tslStatus.Text = string.Concat(BindingContext[dsRegEvento, "Eventoreg"].Position + 1, "/", BindingContext[dsRegEvento, "Eventoreg"].Count);
                retorna_setores(int.Parse(txtIDSeq.Text));
                retorna_tipos_eventos(int.Parse(txtIDSeq.Text));
                trata_flag(lblFlag.Text);
                retorna_dados_fundo(int.Parse(txtIDSeq.Text));
                retorna_grid_tipo_eventos(int.Parse(txtIDSeq.Text));
                this.Cursor = Cursors.Arrow;
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
        private void tsbtnLast_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                BindingContext[dsRegEvento, "Eventoreg"].Position = BindingContext[dsRegEvento, "Eventoreg"].Count - 1;
                tslStatus.Text = string.Concat(BindingContext[dsRegEvento, "Eventoreg"].Count, "/", BindingContext[dsRegEvento, "Eventoreg"].Count);
                retorna_setores(int.Parse(txtIDSeq.Text));
                retorna_tipos_eventos(int.Parse(txtIDSeq.Text));
                trata_flag(lblFlag.Text);
                retorna_dados_fundo(int.Parse(txtIDSeq.Text));
                retorna_grid_tipo_eventos(int.Parse(txtIDSeq.Text));
                this.Cursor = Cursors.Arrow;
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
        private void tsbNovo_Click(object sender, EventArgs e)
        {
            try
            {
                cGlobal.novo = true;
                navegando = true;
                Limpa_Campos();

                #region RETORNA O PRÓXIMO NUMERO DA SEQUENCIA DO EVENTO
                cEvento ce = new cEvento();
                ce.insert_sequencia_evento();
                var ret_nseq = ce.select_sequencia_evento(cGlobal.userlogado);
                #endregion  

                txtIDSeq.Text = ret_nseq[0].ToString();

                Bloqueio(true);
                cboStatus.Enabled = false;
                tsbtnFirst.Enabled = false;
                tsbtnPrevious.Enabled = false;
                tsbtnNext.Enabled = false;
                tsbtnLast.Enabled = false;
                tsbNovo.Enabled = false;
                tsbSalvar.Enabled = true;
                tsbCancelar.Enabled = true;
                tsbLocalizar.Enabled = false;
                tstxtLocalizar.Enabled = false;
                tsbRefresh.Enabled = false;
                btnSalvaComentario.Enabled = false;

                //quando incluindo, não sair
                mnuLogoff.Enabled = false;
                mnuSair.Enabled = false;

                mnuReport.Enabled = false;
                mnuRefresh.Enabled = false;
                MenuFerramentas.Visible = false;

                btnRefCboProduto.Enabled = true;
                btnRefCboCliente.Enabled = true;
                btnRefCboFundoOrigem.Enabled = true;

                tsbAprovacoes.Enabled = false;

                //Ricardo 15/05
                //Somente leitura desativado
                dgvDescEvento.ReadOnly = false;
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
        private void tsbCancelar_Click(object sender, EventArgs e)
        {

            int id_seq = int.Parse(txtIDSeq.Text);

            try
            {
                #region REMOVE A SEQ. DA TABELA SEQ_EVENTO_TB
                cEvento ce = new cEvento();
                ce.remove_sequencia_evento(id_seq, cGlobal.userlogado);
                #endregion

                cMaskara cm = new cMaskara();
                cm.seq_evento = id_seq;
                cm.remove_toda_descricao(cm);

                cSetor cst = new cSetor();
                cst.id_seq_evento = id_seq;
                cst.remove_toda_relacao_evento_setor(cst);

                #region LOG
                cLog lg = new cLog();
                lg.log = string.Concat("Cancelamento da Demanda nº ", id_seq);
                lg.form = this.Text;
                lg.metodo = sender.ToString();
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = true;
                lg.grava_log(lg);
                #endregion

                Limpa_Campos();

                //Ricardo 15/05
                //Somente leitura ativado
                dgvDescEvento.ReadOnly = true;

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
        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            cEvento cv = new cEvento();

            try
            {
                #region VALIDAÇÃO
                if (string.IsNullOrEmpty(cboCliente.Text))
                {
                    MessageBox.Show("Cliente não informado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboCliente.Focus();
                    return;
                }

                //DEPARTAMENTO
                if (countsetorcheck.Count == 0)
                {
                    MessageBox.Show("Nenhum Setor foi selecionado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chklbSetor.Focus();
                    return;
                }

                //TIPO DE EVENTO
                if (countitemcheck.Count == 0)
                {
                    MessageBox.Show("Nenhum Tipo de Evento foi selecionado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chklbTpEvento.Focus();
                    return;
                }

                //if (string.IsNullOrEmpty(cboProduto.Text))
                //{
                //    MessageBox.Show("Produto não informado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cboProduto.Focus();
                //    return;
                //}

                //FUNDO
                if (string.IsNullOrEmpty(cboFundoOrigem.Text))
                {
                    MessageBox.Show("Fundo não informado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboFundoOrigem.Focus();
                    return;
                }

                #region PERCORRE DATAGRIDVIEW PARA VER SE CONSTA A DATA DO EVENTO (COTA)
                int sem_data = 0;
                int qtdfds = 0; 
                foreach (DataGridViewRow linha in dgvDescEvento.Rows)
                {
                    foreach (DataGridViewCell item in linha.Cells)
                    {
                        if (item.ColumnIndex == 4)
                        {
                            if (item.Value.ToString() == "")
                            {
                                sem_data++;                                
                            }
                            else
                            {
                                int fds  = Convert.ToDateTime(item.Value.ToString()).DayOfWeek.GetHashCode();
                                if (fds == 6 || fds == 0)
                                {
                                    qtdfds++;
                                }
                            }
                        }
                    }
                }

                if (sem_data != 0)
                {
                    MessageBox.Show("Data dos Eventos não informada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDescEvento.Focus();
                    return;
                }

                if (qtdfds != 0)
                {
                    MessageBox.Show("Evento não pode iniciar em um final de semana", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDescEvento.Focus();
                    return;

                }
                #endregion

                #region PERCORRE DATAGRIDVIEW PARA VALIDAR RTO 
                int rto_true = 0;
                foreach (DataGridViewRow linha in dgvDescEvento.Rows)
                {
                    foreach (DataGridViewCell item in linha.Cells)
                    {
                        if (item.ColumnIndex == 6)
                        {
                            if (!string.IsNullOrEmpty(linha.Cells[item.ColumnIndex].Value.ToString()))
                            {
                                if (Convert.ToBoolean(linha.Cells[item.ColumnIndex].Value))
                                {
                                    rto_true++;
                                }
                            }
                        }
                    }
                }

                if (rto_true != 0 && (string.IsNullOrEmpty(txtRTO.Text)))
                {
                    MessageBox.Show("Número do RTO deve ser informado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRTO.Focus();
                    return;
                }
                #endregion

                #endregion

                cv.id_seq_evento = int.Parse(txtIDSeq.Text);
                cv.status = 2; //VALIDAÇÃO GOVERNANÇA
                cv.id_cliente = !string.IsNullOrEmpty(cboCliente.Text) ? cv.id_cliente = int.Parse(cboCliente.SelectedValue.ToString()) : 1;
                cv.rtxtHistorico = txtHistorico.Text;
                cv.rtxtComentario = txtComentario.Text;
                cv.ApCad = cGlobal.userlogado;
                cv.id_fundoOrigem = !string.IsNullOrEmpty(cboFundoOrigem.Text) ?  int.Parse(cboFundoOrigem.SelectedValue.ToString()) : 1;
                cv.id_fundoDestino = !string.IsNullOrEmpty(cboFundoDestino.Text) ? cv.id_fundoDestino = int.Parse(cboFundoDestino.SelectedValue.ToString()) : 1;
                cv.id_produto = !string.IsNullOrEmpty(cboProduto.Text) ? cv.id_produto = int.Parse(cboProduto.SelectedValue.ToString()) : 1;
                cv.extra_pauta = chkExtraPauta.Checked;
                cv.excecao = chkExcecao.Checked;
                cv.nrRTO = txtRTO.Text.ToString();


                #region RADIONBUTTON
                if (rbNaoPadrao.Checked == true)
                {
                    cv.flag = rbNaoPadrao.Text;
                }
                else if (rbFlagPadrao.Checked == true)
                {
                    cv.flag = rbFlagPadrao.Text;
                }
                else if (rbPadraoCiencia.Checked == true)
                {
                    cv.flag = rbPadraoCiencia.Text;
                }
                if (chkReservaCapacity.Checked)
                {
                    cv.flagCapacity = true;
                }
                else
                {
                    cv.flagCapacity = false;
                }

                #endregion

                DialogResult dr = (MessageBox.Show(string.Format("Deseja realmente salvar este registro\nDemanda nº: {0}?", int.Parse(txtIDSeq.Text)), "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (dr == DialogResult.Yes)
                {

                    #region GRAVA DATA DA COTA
                    cTipoEvento ctp = new cTipoEvento();
                    foreach (DataGridViewRow linha in dgvDescEvento.Rows)
                    {
                        foreach (DataGridViewCell item in linha.Cells)
                        {
                            if (item.ColumnIndex == 0)
                            {
                                ctp.id_descricao_evento = int.Parse(item.Value.ToString());
                            }
                            if (item.ColumnIndex == 4)
                            {
                                ctp.dtcota = Convert.ToDateTime(item.Value.ToString());
                                 
                            }
                            if (item.ColumnIndex == 7) // Passivo
                            {
                                ctp.codPassivo = Convert.ToInt32(item.Value.ToString());
                            }
                            if (item.ColumnIndex == 8) // Ativo
                            {
                                ctp.codAtivo = Convert.ToInt32(item.Value.ToString());
                            }
                        }
                        ctp.atualiza_descricao_evento(ctp);
                    }
                    #endregion

                    cv.grava_evento(cv);

                    MessageBox.Show(string.Format("A Demanda nº {0},\nfoi registrada e encaminhada com sucesso.", int.Parse(txtIDSeq.Text)), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSalvaComentario.Enabled = true;

                    cGlobal.infotxt = string.Empty;

                    #region MOSTRA RESULTADO NO BLOCO DE NOTAS
                    //abre bloco de notas para mostrar as informações do evento
                    //verifica antes se o arquivo existe
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    using (StringWriter sw = new StringWriter(sb))
                    {
                        string evento = string.Empty;
                        string status = "VALIDAÇÃO GOVERNANÇA"; //cboStatus.Text;
                        string siglasac = string.Empty;
                        string cnpjcpf = string.Empty;
                        string nomeFundo = string.Empty;
                        int id = Convert.ToInt32(txtIDSeq.Text);
                        //DateTime dtcota = Convert.ToDateTime(dtpCota.Value);
                        string setor = chklbSetor.Items[chklbSetor.SelectedIndex].ToString();

                        #region RETORNA DADOS FUNDO
                        using (DataSet dsfd = cv.retorna_dados_fundo_origem(cv))
                        {
                            foreach (DataRow drw in dsfd.Tables["DadosFundoOrigem"].Rows)
                            {
                                siglasac = drw["SIGLA_SAC"].ToString();
                                nomeFundo = drw["RAZAO_SOCIAL"].ToString();
                                if (drw["CNPJ_CPF"].ToString().Length == 14)
                                {
                                    cnpjcpf = (string.Concat(drw["CNPJ_CPF"].ToString().Substring(0, 2), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(2, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(5, 3), "/",
                                                                     drw["CNPJ_CPF"].ToString().Substring(8, 4), "-",
                                                                     drw["CNPJ_CPF"].ToString().Substring(12, 2)).Replace(",", "."));
                                }
                                else
                                {
                                    cnpjcpf = (string.Concat(drw["CNPJ_CPF"].ToString().Substring(0, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(3, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(6, 3), "-",
                                                                     drw["CNPJ_CPF"].ToString().Substring(9, 2)).Replace(",", "."));
                                }
                            }
                        }
                        #endregion

                        sw.WriteLine("Informações salvas da Demanda:");
                        sw.Write(Environment.NewLine);
                        sw.Write(string.Format("ID Demanda: {0}", id));
                        sw.Write(Environment.NewLine);
                        sw.Write(string.Format("Status: {0}", status));
                        sw.Write(Environment.NewLine);
                        sw.Write(string.Format("Razão Social: {0}", nomeFundo));
                        sw.Write(Environment.NewLine);
                        sw.Write(string.Format("Sigla SAC: {0}", siglasac));
                        sw.Write(Environment.NewLine);
                        sw.Write(string.Format("CNPJ/CPF: {0}", cnpjcpf));
                        sw.Write(Environment.NewLine);
                        sw.Write(Environment.NewLine);
                        sw.Write("EVENTO(S):");

                        #region RETORNA TIPOS DE EVENTOS
                        using (DataSet dstp = cv.retorna_tipo_evento(cv))
                        {
                            string tituloEmail = string.Empty;

                            for (int i = 0; i < chklbTpEvento.Items.Count; i++)
                            {
                                foreach (DataRow drw in dstp.Tables["TipoEvento"].Rows)
                                {

                                    if (drw["EVENTO"].ToString() == chklbTpEvento.Items[i].ToString())
                                    {
                                        chklbTpEvento.SetItemChecked(i, true);
                                        //sw.WriteLine(Environment.NewLine);
                                        evento = string.Concat("ID - ", drw["ID_DESCRICAO_EVENTO"].ToString(), " | Evento: ", drw["EVENTO"].ToString(), " | Data Demanda: ", drw["DTDEMANDA"].ToString(), " | Data do Evento: ", drw["DTCOTA"].ToString().Substring(0, 10));
                                        sw.Write(Environment.NewLine);
                                        sw.Write(evento);
                                        if (string.Compare(setor, "INTRAG") == 0)
                                            tituloEmail = setor + "-" + evento;
                                        else
                                            tituloEmail = evento;
                                        
                                    }
                                }
                            }
                        }
                        
                        #endregion
                    }
                    
                    using (StringReader sr = new StringReader(Application.StartupPath + @"\Info.txt"))
                    {
                        string linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            cGlobal.infotxt = string.Concat(cGlobal.infotxt,
                                                            Environment.NewLine,
                                                            linha);
                        }
                    }
                    #endregion
                    #region Monta Titulo Email

                    #endregion
                    cv.enviaEmailOutlook("NavEventos - Novo Evento Cadastrado", cGlobal.infotxt);
                    grava_comentario(cGlobal.infotxt, "HISTORICO");
                    grava_comentario("Registro encaminhado", "HISTORICO");

                    #region REMOVE A SEQ. DA TABELA SEQ_EVENTO_TB
                    cEvento ce = new cEvento();
                    ce.remove_sequencia_evento(Convert.ToInt32(txtIDSeq.Text), cGlobal.userlogado);
                    #endregion

                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Cadastro da Demanda nº ", txtIDSeq.Text);
                    lg.form = this.Text;
                    lg.metodo = sender.ToString();
                    lg.dt = DateTime.Now;
                    lg.usersistema = cGlobal.userlogado;
                    lg.userRede = Environment.UserName;
                    lg.terminal = Environment.MachineName;
                    lg.tp_flag = true;
                    lg.grava_log(lg);
                    #endregion


                    //Ricardo 15/05
                    //Somente leitura ativado
                    dgvDescEvento.ReadOnly = true;

                    inicio();
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
                MessageBox.Show(lg.log);
            }
        }
        private void tsbLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (string.IsNullOrEmpty(tstxtLocalizar.Text))
                //{
                //    MessageBox.Show("Identificação do Evento não informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //    return;
                //}

                //using (frmFind frm = new frmFind())
                //{
                #region LOG
                //cLog lg = new cLog();
                //lg.log = string.Concat("Localização de Registro.", Environment.NewLine,
                //                       "Registro: ", tstxtLocalizar.Text
                //                       );
                //lg.form = this.Text;
                //lg.metodo = sender.ToString();
                //lg.dt = DateTime.Now;
                //lg.usersistema = cGlobal.userlogado;
                //lg.userRede = Environment.UserName;
                //lg.terminal = Environment.MachineName;
                //lg.tp_flag = true;
                //lg.grava_log(lg);
                #endregion
                //cGlobal.reg_pesquisa = tstxtLocalizar.Text;
                //frm.ShowDialog();
                // if (cGlobal.pesquisando == 1)
                // {
                carrega_registros(true);
                // }
                //}

                //carrega_registros(true);

                tsbRefresh.Enabled = true;


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
        private void tstxtLocalizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            //    {
            //        e.Handled = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                tstxtLocalizar.Text = string.Empty;
                inicio();
                mnuRefresh.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                Process.Start(Application.StartupPath + @"\Manual_NavEventos.pdf");
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region OUTROS COMPONENTES
        private void btnSalvarComentario_Click(object sender, EventArgs e)
        {
            try
            {
                string coment = cGlobal.InputBox("Digite seu comentário", "Comentário", "");
                if (!string.IsNullOrEmpty(coment) && !string.IsNullOrEmpty(txtIDSeq.Text))
                {
                    grava_comentario(coment, "COMENTARIO");
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Inclusão de comentário na Demanda nº ", txtIDSeq.Text, Environment.NewLine,
                                           "Comentário: ", coment);
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
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void cboFundo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //retorna dados do Fundo
                cFundo fd = new cFundo();
                if (Convert.ToInt32(cboFundoOrigem.SelectedValue) == 1)
                {
                    txtSiglaSACOrigem.Text = "";
                    txtSiglaFYOrigem.Text = "";
                    txtCNPJCPFOrigem.Text = "";
                }
                else
                {
                    fd.id_Fundo = Convert.ToInt32(cboFundoOrigem.SelectedValue);

                    using (DataSet ds = fd.retorna_dados_fundo(fd))
                    {
                        if (ds.Tables.Count > 0)
                        {
                            foreach (DataRow drw in ds.Tables["RetFundo"].Rows)
                            {
                                txtSiglaSACOrigem.Text = drw["SIGLA_SAC"].ToString();
                                txtSiglaFYOrigem.Text = drw["SIGLA_FY"].ToString();

                                if (drw["CNPJ_CPF"].ToString().Length == 14)
                                {
                                    txtCNPJCPFOrigem.Text = (string.Concat(drw["CNPJ_CPF"].ToString().Substring(0, 2), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(2, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(5, 3), "/",
                                                                     drw["CNPJ_CPF"].ToString().Substring(8, 4), "-",
                                                                     drw["CNPJ_CPF"].ToString().Substring(12, 2)).Replace(",", "."));
                                }
                                else
                                {
                                    txtCNPJCPFOrigem.Text = (string.Concat(drw["CNPJ_CPF"].ToString().Substring(0, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(3, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(6, 3), "-",
                                                                     drw["CNPJ_CPF"].ToString().Substring(9, 2)).Replace(",", "."));
                                }
                            }
                        }
                        else
                        {
                            txtSiglaSACOrigem.Text = string.Empty;
                            txtSiglaFYOrigem.Text = string.Empty;
                            txtCNPJCPFOrigem.Text = string.Empty;
                        }
                    }
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
                //lg.grava_log(lg);
                #endregion
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tsslblTime.Text = string.Concat(DateTime.Now.ToLongDateString(), " - ", DateTime.Now.ToLongTimeString()); //.ToString("dd/MM/yyyy HH:MM:SS");
        }

        private void btnRefCboProduto_Click(object sender, EventArgs e)
        {
            try
            {
                carrega_combo_produto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnRefCboCliente_Click(object sender, EventArgs e)
        {
            try
            {
                carrega_combo_cliente();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnRefCboFundo_Click(object sender, EventArgs e)
        {
            try
            {
                carrega_combo_fundo((ComboBox)sender);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void mnuConfiguracao_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmConfiguracao frm = new frmConfiguracao())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void mnuRTO_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmRTO form = new frmRTO())
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DATAGRIDVIEW
        private void dgvDescEvento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                var senderGrid = (DataGridView)sender;
               
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    this.Cursor = Cursors.AppStarting;
                    #region VIEW
                    if (e.ColumnIndex == 9)
                    {
                        using (frmDescEvento frm = new frmDescEvento())
                        {
                            cGlobal.acao = false;
                            cGlobal.id_desc_evento = int.Parse(dgvDescEvento.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                            frm.ShowDialog();
                        }
                    }
                    #endregion

                    #region EDITAR
                    if (e.ColumnIndex == 10)
                    {
                        using (frmDescEvento frm = new frmDescEvento())
                        {
                            cGlobal.acao = true;
                            cGlobal.id_desc_evento = int.Parse(dgvDescEvento.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                            #region LOG
                            cLog lg = new cLog();
                            lg.log = string.Concat("Alteração de Registro.", Environment.NewLine,
                                                   "Evento nº ", cGlobal.id_desc_evento, Environment.NewLine,
                                                   "Demanda nº ", txtIDSeq.Text);
                            lg.form = this.Text;
                            lg.metodo = sender.ToString();
                            lg.dt = DateTime.Now;
                            lg.usersistema = cGlobal.userlogado;
                            lg.userRede = Environment.UserName;
                            lg.terminal = Environment.MachineName;
                            lg.tp_flag = true;
                            lg.grava_log(lg);
                            #endregion
                            frm.ShowDialog();
                        }
                        retorna_grid_tipo_eventos(int.Parse(txtIDSeq.Text));
                    }
                    #endregion

                    #region DELETE
                    if (e.ColumnIndex == 11)
                    {
                        cMaskara cm = new cMaskara();
                        cm.id_descricao_evento = int.Parse(dgvDescEvento.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        cm.remove_descricao_grid(cm);
                        #region LOG
                        cLog lg = new cLog();
                        lg.log = string.Concat("Exclusão de Registro.", Environment.NewLine,
                                               "Evento nº ", cGlobal.id_desc_evento, Environment.NewLine,
                                               "Demanda nº ", txtIDSeq.Text);
                        lg.form = this.Text;
                        lg.metodo = sender.ToString();
                        lg.dt = DateTime.Now;
                        lg.usersistema = cGlobal.userlogado;
                        lg.userRede = Environment.UserName;
                        lg.terminal = Environment.MachineName;
                        lg.tp_flag = true;
                        lg.grava_log(lg);
                        #endregion
                        retorna_grid_tipo_eventos(int.Parse(txtIDSeq.Text));
                    }
                    #endregion

                    #region DUPLICAR
                    if (e.ColumnIndex == 12)
                    {
                        cMaskara cm = new cMaskara();
                        //cGlobal.id_desc_evento = int.Parse(dgvDescEvento.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        string txtMask = cm.retorna_maskara_evento(dgvDescEvento.Rows[e.RowIndex].Cells["EVENTO"].Value.ToString(), Convert.ToInt32(txtIDSeq.Text));
                        var retid = cm.retorna_id_tipo_evento(dgvDescEvento.Rows[e.RowIndex].Cells["EVENTO"].Value.ToString());
                        var retNomeEvento = dgvDescEvento.Rows[e.RowIndex].Cells["EVENTO"].Value.ToString();
                        var retRTO = cm.retorna_RTO(dgvDescEvento.Rows[e.RowIndex].Cells["EVENTO"].Value.ToString());
                        txtMascara.Text = txtMask;
                        cm.seq_evento = Convert.ToInt32(txtIDSeq.Text);
                        cm.id_tpevento = Convert.ToInt32(retid.ToString());
                        cm.nome_evento = retNomeEvento[0].ToString();
                        cm.maskara = txtMask.ToString();
                        cm.parecer_rto = retRTO.ToString();
                        cm.grava_descricao(cm);
                        #region LOG
                        cLog lg = new cLog();
                        lg.log = string.Concat("Duplicação de Registro.", Environment.NewLine,
                                               "Evento nº ", cGlobal.id_desc_evento, Environment.NewLine,
                                               "Demanda nº ", txtIDSeq.Text);
                        lg.form = this.Text;
                        lg.metodo = sender.ToString();
                        lg.dt = DateTime.Now;
                        lg.usersistema = cGlobal.userlogado;
                        lg.userRede = Environment.UserName;
                        lg.terminal = Environment.MachineName;
                        lg.tp_flag = true;
                        lg.grava_log(lg);
                        #endregion
                        retorna_grid_tipo_eventos(int.Parse(txtIDSeq.Text));
                    }
                    #endregion

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvDescEvento_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            this.Cursor = Cursors.AppStarting;
            // If any cell is clicked on the Second column which is our date Column  
            if (e.ColumnIndex == 4)
            {
                //Initialized a new DateTimePicker Control  
                oDateTimePicker = new DateTimePicker();
                //Adding DateTimePicker control into DataGridView   
                dgvDescEvento.Controls.Add(oDateTimePicker);
                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker.Format = DateTimePickerFormat.Short;
                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dgvDescEvento.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                //Setting area for DateTimePicker Control  
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);
                // Setting Location  
                oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);
                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);
                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

                // Now make it visible  
                if (!navegando)
                {
                    oDateTimePicker.Visible = false;
                }
                else
                {
                    oDateTimePicker.Visible = true;
                }

            }

            //if (e.ColumnIndex == 6)
            //{
            //    dgvDescEvento.Columns[e.ColumnIndex].DataGridView.Enabled = true;
            //}
            this.Cursor = Cursors.Arrow;


        }
        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            /*
            DateTime dt = new DateTime();
            dt = oDateTimePicker.Value;

            if (dt.DayOfWeek.GetHashCode() >= DayOfWeek.Monday.GetHashCode() && dt.DayOfWeek.GetHashCode() <= DayOfWeek.Friday.GetHashCode())
            {
                */
                dgvDescEvento.CurrentCell.Value = oDateTimePicker.Text.ToString();
            /*
              }
            else
            {
                dgvDescEvento.CurrentCell.Value = string.Empty;
            }
            */    
               
        }
        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker.Visible = false;
        }

        private void dgvDescEvento_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                this.Cursor = Cursors.AppStarting;
                if (flgAlterouMascara)
                {
                    cMaskara mc = new cMaskara();
                    string tipoevento = string.Empty;
                    DataGridViewRow row = dgvDescEvento.CurrentRow;
                    int indice = row.Index;
                    tipoevento = dgvDescEvento.Rows[indice].Cells[2].Value.ToString();
                    mc.id_tpevento = mc.retorna_id_tipo_evento(tipoevento);
                    mc.seq_evento = Convert.ToInt32(txtIDSeq.Text);
                    mc.maskara = txtMascara.Text;
                    mc.grava_temp_mascara(mc);
                }
                flgAlterouMascara = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }


        }

        private void dgvDescEvento_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridView dg = (DataGridView)sender;
                cMaskara mc = new cMaskara();
                int indice = 0;
                string tipoevento = string.Empty;
                DataGridViewRow row = dg.CurrentRow;
                int qtdLinhas = dg.Rows.Count;
                if (row == null && qtdLinhas == 0) return;
                if (qtdLinhas == 1 && row == null)
                {
                    indice = 0;
                }
                else
                {
                    indice = e.RowIndex;
                }
                if (string.IsNullOrEmpty(txtIDSeq.Text)) return;
                tipoevento = dgvDescEvento.Rows[indice].Cells[2].Value.ToString();
                mc.id_tpevento = mc.retorna_id_tipo_evento(tipoevento);
                mc.seq_evento = Convert.ToInt32(txtIDSeq.Text);
                txtMascara.Text = mc.retorna_maskara_evento(tipoevento, mc.seq_evento);
                flgAlterouMascara = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #endregion

        #region METODOS
        private void inicio()
        {
            try
            {
                this.Cursor = Cursors.AppStarting;

                cGlobal.novo = false;
                navegando = false;
                flgAlterouMascara = false;

                carrega_combos_checklistbox();
                carrega_combo_produto();
                carrega_combo_cliente();
                carrega_combo_fundo(cboFundoDestino);
                carrega_combo_fundo(cboFundoOrigem);

                carrega_registros(false);

                Bloqueio(false);
                tsbNovo.Enabled = true;
                tsbSalvar.Enabled = false;
                tsbCancelar.Enabled = false;
                tsbRefresh.Enabled = false;

                mnuLogoff.Enabled = true;
                mnuSair.Enabled = true;

                mnuReport.Enabled = true;
                mnuRefresh.Enabled = true;
                MenuFerramentas.Visible = true;

                btnRefCboProduto.Enabled = false;
                btnRefCboCliente.Enabled = false;
                btnRefCboFundoOrigem.Enabled = false;

                btnSalvaComentario.Focus();
                trata_permissoes();
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
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

        private void carrega_combo_fundo(ComboBox cmb)
        {
            try
            {
                cmb.DataSource = null;
                cmb.Items.Clear();

                #region FUNDO
                cFundo fd = new cFundo();
                using (DataSet dsFu = fd.carrega_combo_fundo())
                {
                    cmb.DataSource = dsFu.Tables["TipoFundo"];
                    cmb.DisplayMember = "RAZAO_SOCIAL";
                    cmb.ValueMember = "ID_FUNDO";
                    cmb.SelectedValue = 1;
                    cmb.Text = string.Empty;
                }
                #endregion
            }
            catch (Exception ex)
            {
                #region LOG ERRO
                cLog lg = new cLog();
                lg.log = ex.Message.Replace("'", "");
                lg.form = this.Text;
                lg.metodo = "carrega_combo_fundo";
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion
            }
        }
        private void carrega_combo_cliente()
        {
            try
            {
                cboCliente.DataSource = null;
                cboCliente.Items.Clear();

                #region CLIENTE
                cCliente cli = new cCliente();
                using (DataSet dscli = cli.preenche_lista_cliente())
                {
                    cboCliente.DataSource = dscli.Tables["Clientes"];
                    cboCliente.DisplayMember = "CLIENTE";
                    cboCliente.ValueMember = "ID_CLIENTE";
                    cboCliente.SelectedValue = 1;
                    cboCliente.Text = string.Empty;
                }
                #endregion
            }
            catch (Exception ex)
            {
                #region LOG ERRO
                cLog lg = new cLog();
                lg.log = ex.Message.Replace("'", "");
                lg.form = this.Text;
                lg.metodo = "carrega_combo_cliente";
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion

            }
        }
        private void carrega_combo_produto()
        {
            try
            {
                cboProduto.DataSource = null;
                cboProduto.Items.Clear();

                #region PRODUTO
                cProduto cprod = new cProduto();
                using (DataSet dsProd = cprod.preenche_lista_produto())
                {
                    cboProduto.DataSource = dsProd.Tables["Produto"];
                    cboProduto.DisplayMember = "PRODUTO";
                    cboProduto.ValueMember = "ID_PRODUTO";
                    cboProduto.SelectedValue = 1;
                    cboProduto.Text = string.Empty;
                }
                #endregion
            }
            catch (Exception ex)
            {
                #region LOG ERRO
                cLog lg = new cLog();
                lg.log = ex.Message.Replace("'", "");
                lg.form = this.Text;
                lg.metodo = "carrega_combo_produto";
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion
            }
        }
        private void carrega_registros(bool pesquisa)
        {
            try
            {
                cEvento ce = new cEvento();
                dsRegEvento.Clear();

                if (!pesquisa)
                {
                    dsRegEvento = ce.eventos(null, false);
                }
                else
                {
                    //dsRegEvento = ce.eventos(cGlobal.id_fundo_pesquisa, true);
                    dsRegEvento = ce.eventos(tstxtLocalizar.Text, true);
                    if (dsRegEvento.Tables["Eventoreg"].Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum registro foi localizado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tsbLocalizar.Text = string.Empty;
                        carrega_registros(false);
                    }
                }

                #region LIMPA DATABINDINGS
                txtIDSeq.DataBindings.Clear();
                cboStatus.DataBindings.Clear();
                cboCliente.DataBindings.Clear();
                txtHistorico.DataBindings.Clear();
                txtComentario.DataBindings.Clear();
                txtApCad.DataBindings.Clear();
                txtApCadData.DataBindings.Clear();
                txtApGov.DataBindings.Clear();
                txtApGovData.DataBindings.Clear();
                txtApCap.DataBindings.Clear();
                txtApCapData.DataBindings.Clear();
                txtApRTO.DataBindings.Clear();
                txtApRTOData.DataBindings.Clear();
                lblFlag.DataBindings.Clear();
                cboFundoOrigem.DataBindings.Clear();
                cboFundoDestino.DataBindings.Clear();
                chkExtraPauta.DataBindings.Clear();
                chkExcecao.DataBindings.Clear();
                cboProduto.DataBindings.Clear();
                chkReservaCapacity.DataBindings.Clear();
                txtRTO.DataBindings.Clear();
                #endregion

                #region CAMPOS
                txtIDSeq.DataBindings.Add("Text", dsRegEvento, "Eventoreg.SEQ_EVENTO");
                txtHistorico.DataBindings.Add("Text", dsRegEvento, "Eventoreg.HISTORICO");
                txtComentario.DataBindings.Add("Text", dsRegEvento, "Eventoreg.COMENTARIOS");
                txtApCad.DataBindings.Add("Text", dsRegEvento, "Eventoreg.USER_CAD");
                txtApCadData.DataBindings.Add("Text", dsRegEvento, "Eventoreg.DT_USER_CAD");
                txtApGov.DataBindings.Add("Text", dsRegEvento, "Eventoreg.GOV_CAD");
                txtApGovData.DataBindings.Add("Text", dsRegEvento, "Eventoreg.DT_GOV_CAD");
                txtApCap.DataBindings.Add("Text", dsRegEvento, "Eventoreg.CAPACITY_CAD");
                txtApCapData.DataBindings.Add("Text", dsRegEvento, "Eventoreg.DT_CAPACITY_CAD");
                txtApRTO.DataBindings.Add("Text", dsRegEvento, "Eventoreg.RTO_CAD");
                txtApRTOData.DataBindings.Add("Text", dsRegEvento, "Eventoreg.DT_RTO_CAD");
                txtRTO.DataBindings.Add("Text", dsRegEvento, "Eventoreg.NRO_RTO");
                lblFlag.DataBindings.Add("Text", dsRegEvento, "Eventoreg.FLAG");
                chkExtraPauta.DataBindings.Add("Checked", dsRegEvento, "Eventoreg.EXTRAPAUTA");
                chkExcecao.DataBindings.Add("Checked", dsRegEvento, "Eventoreg.EXCECAO");
                chkReservaCapacity.DataBindings.Add("Checked", dsRegEvento, "Eventoreg.FLAG_CAPACITY");


                cboStatus.DataSource = dsRegEvento.Tables["Statusreg"];
                cboStatus.DisplayMember = "STATUS";
                cboStatus.ValueMember = "ID_STATUS";
                cboStatus.DataBindings.Add("SelectedValue", dsRegEvento, "Eventoreg.ID_STATUS");

                cboCliente.DataSource = dsRegEvento.Tables["Clientereg"];
                cboCliente.DisplayMember = "CLIENTE";
                cboCliente.ValueMember = "ID_CLIENTE";
                cboCliente.DataBindings.Add("SelectedValue", dsRegEvento, "Eventoreg.ID_CLIENTE");

                cboFundoOrigem.DataSource = dsRegEvento.Tables["FundoOrigemreg"];
                cboFundoOrigem.DisplayMember = "RAZAO_SOCIAL";
                cboFundoOrigem.ValueMember = "ID_FUNDO";
                cboFundoOrigem.DataBindings.Add("SelectedValue", dsRegEvento, "Eventoreg.ID_FUNDO_ORIGEM");

                cboFundoDestino.DataSource = dsRegEvento.Tables["FundoDestinoreg"];
                cboFundoDestino.DisplayMember = "RAZAO_SOCIAL";
                cboFundoDestino.ValueMember = "ID_FUNDO";
                cboFundoDestino.DataBindings.Add("SelectedValue", dsRegEvento, "Eventoreg.ID_FUNDO_DESTINO");

                cboProduto.DataSource = dsRegEvento.Tables["Produtoreg"];
                cboProduto.DisplayMember = "PRODUTO";
                cboProduto.ValueMember = "ID_PRODUTO";
                cboProduto.DataBindings.Add("SelectedValue", dsRegEvento, "Eventoreg.ID_PRODUTO");

                #endregion

                if (BindingContext[dsRegEvento, "Eventoreg"].Count > 0)
                {

                    tslStatus.Text = string.Concat(BindingContext[dsRegEvento, "Eventoreg"].Position + 1, "/", BindingContext[dsRegEvento, "Eventoreg"].Count);

                    trata_flag(lblFlag.Text);
                    retorna_setores(int.Parse(txtIDSeq.Text));
                    retorna_tipos_eventos(int.Parse(txtIDSeq.Text));
                    retorna_dados_fundo(int.Parse(txtIDSeq.Text));
                    retorna_grid_tipo_eventos(int.Parse(txtIDSeq.Text));
                    tsbtnFirst.Enabled = true;
                    tsbtnPrevious.Enabled = true;
                    tsbtnNext.Enabled = true;
                    tsbtnLast.Enabled = true;
                    tsbLocalizar.Enabled = true;
                    tstxtLocalizar.Enabled = true;
                    btnSalvaComentario.Enabled = true;
                    tsbAprovacoes.Enabled = true;
                    cboFundoDestino.Enabled = true;
                    cboFundoOrigem.Enabled = true;
                }
                else
                {
                    tsbtnFirst.Enabled = false;
                    tsbtnPrevious.Enabled = false;
                    tsbtnNext.Enabled = false;
                    tsbtnLast.Enabled = false;
                    btnSalvaComentario.Enabled = false;
                    tsbLocalizar.Enabled = false;
                    tstxtLocalizar.Enabled = false;
                    tsbAprovacoes.Enabled = false;
                    cboStatus.SelectedValue = 1;
                    cboProduto.SelectedValue = 1;
                    cboFundoDestino.SelectedValue = 1;
                    cboFundoOrigem.SelectedValue = 1;
                }

                dsRegEvento.Dispose();

            }
            catch (Exception ex)
            {
                #region LOG ERRO
                cLog lg = new cLog();
                lg.log = ex.Message.Replace("'", "");
                lg.form = this.Text;
                lg.metodo = "carrega_registros";
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);

                #endregion
            }
        }
        private void carrega_combos_checklistbox()
        {
            try
            {
                #region LIMPA CONTROLES
                cboStatus.DataSource = null;
                cboStatus.Items.Clear();
                chklbSetor.Items.Clear();
                chklbTpEvento.Items.Clear();


                #endregion

                #region STATUS
                cStatus cs = new cStatus();
                using (DataSet dsStatus = cs.preenche_lista_status())
                {
                    cboStatus.DataSource = dsStatus.Tables["Status"];
                    cboStatus.DisplayMember = "STAUTS";
                    cboStatus.ValueMember = "ID_STATUS";
                    cboStatus.SelectedValue = 1;
                    cboStatus.Enabled = false;
                }
                #endregion

                #region SETOR
                cSetor cst = new cSetor();
                using (DataSet dsSetor = cst.preenche_lista_setor())
                {
                    foreach (DataRow dr in dsSetor.Tables["Setor"].Rows)
                    {
                        chklbSetor.Items.Add(dr["Setor"].ToString());
                    }
                }
                #endregion

                #region TIPO EVENTO
                cTipoEvento cte = new cTipoEvento();
                using (DataSet dstpevento = cte.preenche_lista_tpeventos())
                {
                    foreach (DataRow dr in dstpevento.Tables["TpEventos"].Rows)
                    {
                        chklbTpEvento.Items.Add(dr["EVENTO"].ToString());
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                #region LOG ERRO
                cLog lg = new cLog();
                lg.log = ex.Message.Replace("'", "");
                lg.form = this.Text;
                lg.metodo = "carrega_combos_checklistbox";
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion
            }
        }
        private void Bloqueio(bool flag)
        {
            txtIDSeq.Enabled = flag;
            cboStatus.Enabled = flag;
            chklbSetor.Enabled = flag;
            cboProduto.Enabled = flag;
            cboCliente.Enabled = flag;
            txtRTO.Enabled = flag;
            txtMascara.Enabled = flag;
            chklbTpEvento.Enabled = flag;
            cboFundoOrigem.Enabled = flag;
            cboFundoDestino.Enabled = flag;
            rbFlagPadrao.Enabled = flag;
            rbNaoPadrao.Enabled = flag;
            rbPadraoCiencia.Enabled = flag;
            chkReservaCapacity.Enabled = flag;
            chkExtraPauta.Enabled = flag;
            chkExcecao.Enabled = flag;

        }
        private void Limpa_Campos()
        {
            try
            {
                txtIDSeq.Text = string.Empty;
                flgAlterouMascara = false;
                cboStatus.SelectedValue = 1;
                cboProduto.SelectedValue = 1;
                for (int i = 0; i < chklbSetor.Items.Count; i++)
                {
                    chklbSetor.SetItemChecked(i, false);
                }
                cboCliente.SelectedValue = 1;
                for (int i = 0; i < chklbTpEvento.Items.Count; i++)
                {
                    chklbTpEvento.SetItemChecked(i, false);
                }
                cboFundoOrigem.Text = string.Empty;
                cboFundoDestino.Text = string.Empty;
                txtHistorico.Text = string.Empty;
                txtComentario.Text = string.Empty;
                txtApCad.Text = string.Empty;
                txtApCadData.Text = string.Empty;
                txtApGov.Text = string.Empty;
                txtApGovData.Text = string.Empty;
                txtApCap.Text = string.Empty;
                txtApCapData.Text = string.Empty;
                txtApRTO.Text = string.Empty;
                txtRTO.Text = string.Empty;
                txtApRTOData.Text = string.Empty;
                txtMascara.Text = string.Empty;

                //limpa arrays
                countsetorcheck.Clear();
                countitemcheck.Clear();

                //lvRelFundo.Items.Clear();
                tstxtLocalizar.Text = string.Empty;

                rbFlagPadrao.Checked = true;
                rbNaoPadrao.Checked = false;
                rbPadraoCiencia.Checked = false;

                chkExtraPauta.Checked = false;
                chkExcecao.Checked = false;

                txtSiglaSACOrigem.Text = string.Empty;
                txtSiglaFYOrigem.Text = string.Empty;
                txtCNPJCPFOrigem.Text = string.Empty;
                txtSiglaSACDestino.Text = string.Empty;
                txtSiglaFYDestino.Text = string.Empty;
                txtCNPJCPFDestino.Text = string.Empty;


                //limpa datagridview
                dgvDescEvento.Columns.Clear();
                //gvDescEvento.Rows.Clear();

            }
            catch (Exception ex)
            {
                #region LOG ERRO
                cLog lg = new cLog();
                lg.log = ex.Message.Replace("'", "");
                lg.form = this.Text;
                lg.metodo = "Limpa_Campos";
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion
            }
        }
        private void retorna_tipos_eventos(int id)
        {
            try
            {
                cEvento ce = new cEvento();
                ce.id_seq_evento = id;

                #region RETORNA TIPOS DE EVENTOS
                //TIRA A SELEÇÃO DOS CAMPOS
                for (int i = 0; i < chklbTpEvento.Items.Count; i++)
                {
                    chklbTpEvento.SetItemChecked(i, false);
                }
                using (DataSet dstp = ce.retorna_tipo_evento(ce))
                {
                    for (int i = 0; i < chklbTpEvento.Items.Count; i++)
                    {
                        foreach (DataRow dr in dstp.Tables["TipoEvento"].Rows)
                        {
                            if (dr["EVENTO"].ToString() == chklbTpEvento.Items[i].ToString())
                            {
                                chklbTpEvento.SetItemChecked(i, true);

                                //txtDescEvento.Text = txtDescEvento.Text + dr["DESCRICAO"].ToString() + Environment.NewLine + "===========================================" + Environment.NewLine + Environment.NewLine;
                            }
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                #region LOG ERRO
                cLog lg = new cLog();
                lg.log = ex.Message.Replace("'", "");
                lg.form = this.Text;
                lg.metodo = "retorna_tipos_eventos";
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion
            }
        }
        private void retorna_setores(int id)
        {
            try
            {
                cEvento ce = new cEvento();
                ce.id_seq_evento = id;

                #region RETORNA SETOR

                //TIRA A SELEÇÃO DOS CAMPOS
                for (int i = 0; i < chklbSetor.Items.Count; i++)
                {
                    chklbSetor.SetItemChecked(i, false);
                }

                using (DataSet dsse = ce.retorna_setor_evento(ce))
                {
                    for (int i = 0; i < chklbSetor.Items.Count; i++)
                    {
                        foreach (DataRow dre in dsse.Tables["SetorEvento"].Rows)
                        {
                            if (dre["SETOR"].ToString() == chklbSetor.Items[i].ToString())
                            {
                                chklbSetor.SetItemChecked(i, true);
                            }
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void retorna_dados_fundo(int id)
        {
            try
            {
                cFundo fd = new cFundo();
                //retorna dados
                fd.id_seq_evento = id;
                using (DataSet ds = fd.retorna_dados_fundo_evento(fd))
                {
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow drw in ds.Tables["RetFundo"].Rows)
                        {
                            if (drw["FONTE"].ToString() == "ORIGEM")
                            {
                                txtSiglaSACOrigem.Text = drw["SIGLA_SAC"].ToString();
                                txtSiglaFYOrigem.Text = drw["SIGLA_FY"].ToString();


                                if (drw["CNPJ_CPF"].ToString().Length == 14)
                                {
                                    txtCNPJCPFOrigem.Text = (string.Concat(drw["CNPJ_CPF"].ToString().Substring(0, 2), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(2, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(5, 3), "/",
                                                                     drw["CNPJ_CPF"].ToString().Substring(8, 4), "-",
                                                                     drw["CNPJ_CPF"].ToString().Substring(12, 2)).Replace(",", "."));
                                }
                                else
                                {
                                    txtCNPJCPFOrigem.Text = (string.Concat(drw["CNPJ_CPF"].ToString().Substring(0, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(3, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(6, 3), "-",
                                                                     drw["CNPJ_CPF"].ToString().Substring(9, 2)).Replace(",", "."));
                                }
                            }
                            else
                            {
                                txtSiglaSACDestino.Text = drw["SIGLA_SAC"].ToString();
                                txtSiglaFYDestino.Text = drw["SIGLA_FY"].ToString();


                                if (drw["CNPJ_CPF"].ToString().Length == 14)
                                {
                                    txtCNPJCPFDestino.Text = (string.Concat(drw["CNPJ_CPF"].ToString().Substring(0, 2), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(2, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(5, 3), "/",
                                                                     drw["CNPJ_CPF"].ToString().Substring(8, 4), "-",
                                                                     drw["CNPJ_CPF"].ToString().Substring(12, 2)).Replace(",", "."));
                                }
                                else if (drw["CNPJ_CPF"].ToString().Length > 0)
                                {
                                    txtCNPJCPFDestino.Text = (string.Concat(drw["CNPJ_CPF"].ToString().Substring(0, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(3, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(6, 3), "-",
                                                                     drw["CNPJ_CPF"].ToString().Substring(9, 2)).Replace(",", "."));
                                }
                            }
                        }
                    }
                    else
                    {
                        txtSiglaSACOrigem.Text = string.Empty;
                        txtSiglaFYOrigem.Text = string.Empty;
                        txtCNPJCPFOrigem.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        enum ePassivoAtivo
        {
            Passivo = 1,
            Ativo = 2
        }
        private void retorna_grid_tipo_eventos(int id)
        {

            try
            {

                cEvento ce = new cEvento();
                ce.id_seq_evento = id;
                DataTable dtview = ce.tipo_evento(ce);

                #region DATAGRIDVIEW
                DataGridViewTextBoxColumn campo0 = new DataGridViewTextBoxColumn();
                campo0.Name = "ID";
                campo0.HeaderText = "ID";
                campo0.DataPropertyName = "ID_DESCRICAO_EVENTO";
                campo0.ToolTipText = "id do registro";
                campo0.Width = 50;

                DataGridViewTextBoxColumn campo1 = new DataGridViewTextBoxColumn();
                campo1.Name = "ID_TP_EVENTO";
                campo1.HeaderText = "";
                campo1.DataPropertyName = "ID_TP_EVENTO";
                campo1.ToolTipText = "id do registro";
                campo1.Width = 0;

                DataGridViewTextBoxColumn campo2 = new DataGridViewTextBoxColumn();
                campo2.Name = "Evento";
                campo2.HeaderText = "Evento";
                campo2.DataPropertyName = "EVENTO";
                campo2.ToolTipText = "evento";
                campo2.Width = 185;

                DataGridViewTextBoxColumn campo3 = new DataGridViewTextBoxColumn();
                campo3.Name = "Demanda";
                campo3.HeaderText = "Data da Demanda";
                campo3.DataPropertyName = "DTDEMANDA";
                campo3.ToolTipText = "data da demanda";
                campo3.Width = 105;

                DataGridViewTextBoxColumn campo4 = new DataGridViewTextBoxColumn();
                campo4.Name = "Cota";
                campo4.HeaderText = "Data Evento";
                campo4.DataPropertyName = "DTCOTA";
                campo4.ToolTipText = "data cota";
                campo4.Width = 100;

                DataGridViewTextBoxColumn campo5 = new DataGridViewTextBoxColumn();
                campo5.Name = "HoraCota";
                campo5.HeaderText = "Hora do Evento";
                campo5.DataPropertyName = "HRCOTA";
                campo5.ToolTipText = "Hora cota";
                campo5.Width = 50;

                DataGridViewCheckBoxColumn campo6 = new DataGridViewCheckBoxColumn();
                campo6.Name = "RTO";
                campo6.HeaderText = "RTO";
                campo6.DataPropertyName = "RTO";
                campo6.ToolTipText = "rto";
                campo6.Width = 35;

                DataTable dtAtivo = new DataTable();
                DataTable dtPassivo = new DataTable();

                dtAtivo.Columns.Add(new DataColumn("CDATIVO", System.Type.GetType("System.Int32")));
                dtAtivo.Columns.Add(new DataColumn("DESCRICAO_ATIVO", System.Type.GetType("System.String")));

                dtPassivo.Columns.Add(new DataColumn("CDPASSIVO", System.Type.GetType("System.Int32")));
                dtPassivo.Columns.Add(new DataColumn("DESCRICAO_PASSIVO", System.Type.GetType("System.String")));

                dtAtivo.Clear();
                dtPassivo.Clear();

                DataRow dr = dtAtivo.NewRow();
                dr["CDATIVO"] = 0;
                dr["DESCRICAO_ATIVO"] = "N/A";
                dtAtivo.Rows.Add(dr);

                dr = dtAtivo.NewRow();
                dr["CDATIVO"] = 1;
                dr["DESCRICAO_ATIVO"] = "P";
                dtAtivo.Rows.Add(dr);

                dr = dtAtivo.NewRow();
                dr["CDATIVO"] = 2;
                dr["DESCRICAO_ATIVO"] = "M";
                dtAtivo.Rows.Add(dr);

                dr = dtAtivo.NewRow();
                dr["CDATIVO"] = 3;
                dr["DESCRICAO_ATIVO"] = "G";
                dtAtivo.Rows.Add(dr);

                DataRow drPassivo = dtPassivo.NewRow();
                drPassivo["CDPASSIVO"] = 0;
                drPassivo["DESCRICAO_PASSIVO"] = "N/A";
                dtPassivo.Rows.Add(drPassivo);
                drPassivo = dtPassivo.NewRow();
                drPassivo["CDPASSIVO"] = 1;
                drPassivo["DESCRICAO_PASSIVO"] = "P";
                dtPassivo.Rows.Add(drPassivo);
                drPassivo = dtPassivo.NewRow();
                drPassivo["CDPASSIVO"] = 2;
                drPassivo["DESCRICAO_PASSIVO"] = "M";
                dtPassivo.Rows.Add(drPassivo);
                drPassivo = dtPassivo.NewRow();
                drPassivo["CDPASSIVO"] = 3;
                drPassivo["DESCRICAO_PASSIVO"] = "G";
                dtPassivo.Rows.Add(drPassivo);
                
                //Ricardo 15/05
                var campo7 = new DataGridViewComboBoxColumn();
                campo7.Name = "PASSIVO";
                campo7.DataPropertyName = "CDPASSIVO";
                campo7.HeaderText = "Passivo";
                campo7.DataSource = dtPassivo;
                campo7.DisplayMember = "DESCRICAO_PASSIVO";
                campo7.ValueMember = "CDPASSIVO"; 
                campo7.ToolTipText = "passivo";
                campo7.Width = 50;
                campo7.DefaultCellStyle.NullValue = "N/A";


                var campo8 = new DataGridViewComboBoxColumn();
                campo8.Name = "ATIVO";
                campo8.DataPropertyName = "CDATIVO";
                campo8.HeaderText = "Ativo";
                campo8.DataSource = dtAtivo;
                campo8.DisplayMember = "DESCRICAO_ATIVO";
                campo8.ValueMember = "CDATIVO";
                campo8.ToolTipText = "ativo";
                campo8.Width = 50;
                campo8.DefaultCellStyle.NullValue = "N/A";


                //DataGridViewComboBoxColumn campo7 = new DataGridViewComboBoxColumn();
                //campo7.Name = "PASSIVO";
                //campo7.HeaderText = "Passivo";
                //campo7.ValueMember = "Value";
                //campo7.DisplayMember = "Display";
                //campo7.DataSource = new DataView(dt)
                //                         .ToTable(true, new string[] { "Value", "Display" });
                //campo7.ToolTipText = "passivo";
                //campo7.DataPropertyName = "Display";
                //campo7.Width = 41;

                //DataGridViewComboBoxColumn campo8 = new DataGridViewComboBoxColumn();
                //campo8.Name = "ATIVO";
                //campo8.HeaderText = "Ativo";
                //campo8.Width = 41;
                //campo8.DataSource = new DataView(dt)
                //                         .ToTable(true, new string[] { "Value", "Display"});
                //campo8.DataPropertyName = "Display";
                //campo8.ToolTipText = "ativo";
                //dgvDescEvento.Columns.Add(campo7);
                /*
                campo8.DataSource = dt;
                campo8.ValueMember = "Value";
                campo8.DisplayMember = "Display";
                */
                // campos abaixo anterado de campo7, campo8 , campo9 e campo10 para campo9, campo10, campo11 e  campo12
                //                           campo7  = campo9
                //                           campo8  = campo10
                //                           campo9  = campo11
                //                           campo10 = campo12

                DataGridViewImageColumn campo9 = new DataGridViewImageColumn();
                campo9.ValuesAreIcons = false;
                Image img1 = Image.FromFile(string.Concat(Application.StartupPath, @"\icone1.ico"));
                campo9.Image = img1;
                campo9.HeaderText = "";
                campo9.Name = "View";
                campo9.ToolTipText = "visualiza registro";
                campo9.Width = 20;

                DataGridViewImageColumn campo10 = new DataGridViewImageColumn();
                campo10.ValuesAreIcons = false;
                Image img2 = Image.FromFile(string.Concat(Application.StartupPath, @"\icone2.ico"));
                campo10.Image = img2;
                campo10.HeaderText = "";
                campo10.Name = "Edit";
                campo10.ToolTipText = "edita registro";
                campo10.Width = 20;

                DataGridViewImageColumn campo11 = new DataGridViewImageColumn();
                campo11.ValuesAreIcons = false;
                Image img3 = Image.FromFile(string.Concat(Application.StartupPath, @"\icone3.ico"));
                campo11.Image = img3;
                campo11.HeaderText = "";
                campo11.Name = "Delete";
                campo11.Width = 20;

                DataGridViewImageColumn campo12 = new DataGridViewImageColumn();
                campo12.ValuesAreIcons = false;
                Image img4 = Image.FromFile(string.Concat(Application.StartupPath, @"\icone4.ico"));
                campo12.Image = img4;
                campo12.HeaderText = "";
                campo12.Name = "duplicate";
                campo12.ToolTipText = "duplica registro";
                campo12.Width = 20;


                dgvDescEvento.Columns.Clear();
                dgvDescEvento.AutoGenerateColumns = false;
                dgvDescEvento.Columns.AddRange(new DataGridViewColumn[] { campo0, campo1, campo2, campo3, campo4, campo5, campo6, campo7, campo8, campo9, campo10, campo11, campo12 });


                #endregion

                #region VISIBILIDADE DOS BOTÕES DUPLICAR E EXCLUIR DA GRID
                if (!navegando)
                {
                    campo9.Visible = true;
                    campo10.Visible = false;
                    campo11.Visible = false;
                    campo12.Visible = false;
                }
                else
                {
                    campo9.Visible = false;
                    campo10.Visible = false;
                    campo11.Visible = true;
                    campo12.Visible = true;
                }
                #endregion

                dgvDescEvento.DataSource = dtview;
               
                
                dgvDescEvento.Columns["ID"].Visible = true;
                dgvDescEvento.Columns["ID_TP_EVENTO"].Visible = false;
                dgvDescEvento.Columns["EVENTO"].Frozen = true;
                dgvDescEvento.Columns["HoraCota"].Visible = false;


                //Ricardo 15/05
                //Deixe comentado este metodo, ele serve para mudar a datagrid, frescura que achei na web kkkkk
                //mas se você descomentar não vai funcionar a combobox na datagridview ok
                //cDGV modelo = new cDGV();
                //dgvDescEvento = modelo.Grade(dgvDescEvento);
/*
                foreach (DataGridViewRow row in dgvDescEvento.Rows)
                {
                    DataGridViewComboBoxCell cboAtivo = (DataGridViewComboBoxCell)
                                                                 (row.Cells["ATIVO"]);
                    cboAtivo.DataSource = dtAtivo;//Get the contact details of a person,
                                             //using his Name or Id field (row.Cells["Name"]);
                    cboAtivo.DisplayMember = "DESCRICAO_ATIVO"; //Name column of contact datasource
                    cboAtivo.ValueMember = "CDATIVO";//Value column of contact datasource
                    
                    DataGridViewComboBoxCell cboPassivo = (DataGridViewComboBoxCell)
                                                                 (row.Cells["PASSIVO"]);
                    cboPassivo.DataSource = dtPassivo;//Get the contact details of a person,
                                               //using his Name or Id field (row.Cells["Name"]);
                    cboPassivo.DisplayMember = "DESCRICAO_PASSIVO"; //Name column of contact datasource
                    cboPassivo.ValueMember = "CDPASSIVO";//Value column of contact datasource
                   
                }
                */


                dtview.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        private void trata_flag(string flag)
        {
            try
            {
                if (flag.Equals("Padrão"))
                {
                    rbFlagPadrao.Checked = true;
                }
                else if (flag.Equals("Não Padrão"))
                {
                    rbNaoPadrao.Checked = true;
                }
                else if (flag.Equals("Padrão Ciência"))
                {
                    rbPadraoCiencia.Checked = true;
                }
                else
                {
                    chkReservaCapacity.Checked = true;
                    rbFlagPadrao.Checked = false;
                    rbNaoPadrao.Checked = false;
                    rbPadraoCiencia.Checked = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void trata_permissoes()
        {
            try
            {
                cUsuario cuser = new cUsuario();
                cuser.login = cGlobal.userlogado;
                #region ADMINISTRADOR
                var ret_perm = cuser.retorna_permissoes(cuser);
                if (ret_perm[0].per_cad_evento == true &&
                    ret_perm[0].per_aprova_evento == true &&
                    ret_perm[0].per_cad_cliente == true &&
                    ret_perm[0].per_cronograma == true &&
                    ret_perm[0].per_produto == true &&
                    ret_perm[0].per_suporte == true)
                {
                    mnuVisaoEventos.Visible = true;
                    mnuDesbloquear.Visible = true;
                    tssBarra1.Visible = true;
                    tsbAprovacoes.Enabled = true;
                    MenuEditar.Enabled = true;
                    MenuFerramentas.Enabled = true;
                    mnuLog.Visible = true;
                    barraLog.Visible = true;

                }
                #endregion

                #region SOMENTE CADASTRAR DEMANDA(EVENTO)
                if (ret_perm[0].per_cad_evento == true &&
                         ret_perm[0].per_aprova_evento == false &&
                         ret_perm[0].per_cad_cliente == false &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == false &&
                         ret_perm[0].per_suporte == false)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tssBarra1.Visible = false;
                    tsbNovo.Enabled = true;
                    tsbAprovacoes.Enabled = false;
                    MenuEditar.Enabled = false;
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;

                }
                #endregion

                #region SOMENTE CADASTRAR DEMANDA(EVENTO) + GOVERNANCA
                if (ret_perm[0].per_cad_evento == true &&
                         ret_perm[0].per_aprova_evento == true &&
                         ret_perm[0].per_cad_cliente == false &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == false &&
                         ret_perm[0].per_suporte == false)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tssBarra1.Visible = false;
                    tsbNovo.Enabled = true;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Enabled = true;
                    tsmnuApCapacity.Visible = false;
                    tsmnuApSuporte.Visible = false;
                    MenuEditar.Enabled = false;
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;

                }
                #endregion

                #region SOMENTE CADASTRAR DEMANDA(EVENTO) + GOVERNANCA + CAPACITY
                if (ret_perm[0].per_cad_evento == true &&
                         ret_perm[0].per_aprova_evento == true &&
                         ret_perm[0].per_cad_cliente == false &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == true &&
                         ret_perm[0].per_suporte == false)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tssBarra1.Visible = false;
                    tsbNovo.Enabled = true;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Enabled = true;
                    tsmnuApCapacity.Enabled = true;
                    tsmnuApSuporte.Visible = false;
                    MenuEditar.Enabled = false;
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;

                }
                #endregion

                #region SOMENTE CADASTRAR DEMANDA(EVENTO) + GOVERNANCA + CAPACITY + SUPORTE
                if (ret_perm[0].per_cad_evento == true &&
                         ret_perm[0].per_aprova_evento == true &&
                         ret_perm[0].per_cad_cliente == false &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == true &&
                         ret_perm[0].per_suporte == true)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tssBarra1.Visible = false;
                    tsbNovo.Enabled = true;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Enabled = true;
                    tsmnuApCapacity.Enabled = true;
                    tsmnuApSuporte.Enabled = true;
                    MenuEditar.Enabled = false;
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;

                }
                #endregion

                #region SOMENTE CADASTRAR DEMANDA(EVENTO) + CAPACITY
                if (ret_perm[0].per_cad_evento == true &&
                         ret_perm[0].per_aprova_evento == false &&
                         ret_perm[0].per_cad_cliente == false &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == true &&
                         ret_perm[0].per_suporte == false)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tssBarra1.Visible = false;
                    tsbNovo.Enabled = true;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Visible = false;
                    tsmnuApCapacity.Visible = true;
                    tsmnuApSuporte.Visible = false;
                    MenuEditar.Enabled = false;
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;

                }
                #endregion

                #region SOMENTE CADASTRAR DEMANDA(EVENTO) + SUPORTE
                if (ret_perm[0].per_cad_evento == true &&
                         ret_perm[0].per_aprova_evento == false &&
                         ret_perm[0].per_cad_cliente == false &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == false &&
                         ret_perm[0].per_suporte == true)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tssBarra1.Visible = false;
                    tsbNovo.Enabled = true;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Visible = false;
                    tsmnuApCapacity.Visible = false;
                    tsmnuApSuporte.Visible = true;
                    MenuEditar.Enabled = false;
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;

                }
                #endregion

                #region SOMENTE CADASTRAR DEMANDA(EVENTO) + SUPORTE + GOVERNANCA
                if (ret_perm[0].per_cad_evento == true &&
                         ret_perm[0].per_aprova_evento == true &&
                         ret_perm[0].per_cad_cliente == false &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == false &&
                         ret_perm[0].per_suporte == true)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tssBarra1.Visible = false;
                    tsbNovo.Enabled = true;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Visible = true;
                    tsmnuApCapacity.Visible = false;
                    tsmnuApSuporte.Visible = true;
                    MenuEditar.Enabled = false;
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;

                }
                #endregion

                #region SOMENTE CADASTRAR DEMANDA(EVENTO) + CADASTRAR CLIENTES
                if (ret_perm[0].per_cad_evento == true &&
                         ret_perm[0].per_aprova_evento == false &&
                         ret_perm[0].per_cad_cliente == true &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == false &&
                         ret_perm[0].per_suporte == false)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tssBarra1.Visible = false;
                    tsbNovo.Enabled = true;
                    tsbAprovacoes.Enabled = false;
                    tsmnuApGovernanca.Visible = false;
                    tsmnuApCapacity.Visible = false;
                    tsmnuApSuporte.Visible = false;
                    #region MENU EDITAR
                    MenuEditar.Enabled = true;
                    mnuDemandaAtiv.Visible = false;
                    mnuCapacity.Visible = false;
                    mnuClientes.Visible = true;
                    mnuAtividade.Visible = false;
                    mnuFundo.Visible = false;
                    mnuProduto.Visible = false;
                    mnuStatusEvento.Visible = false;
                    mnuSetor.Visible = false;
                    mnuTipoEvento.Visible = false;
                    #endregion
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;
                }
                #endregion

                #region SOMENTE CADASTRAR DEMANDA(EVENTO) + CADASTRAR CLIENTES + GOVERNACA
                if (ret_perm[0].per_cad_evento == true &&
                         ret_perm[0].per_aprova_evento == true &&
                         ret_perm[0].per_cad_cliente == true &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == false &&
                         ret_perm[0].per_suporte == false)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tssBarra1.Visible = false;
                    tsbNovo.Enabled = true;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Visible = true;
                    tsmnuApCapacity.Visible = false;
                    tsmnuApSuporte.Visible = false;
                    #region MENU EDITAR
                    MenuEditar.Enabled = true;
                    mnuDemandaAtiv.Visible = false;
                    mnuCapacity.Visible = false;
                    mnuClientes.Visible = true;
                    mnuAtividade.Visible = false;
                    mnuFundo.Visible = false;
                    mnuProduto.Visible = false;
                    mnuStatusEvento.Visible = false;
                    mnuSetor.Visible = false;
                    mnuTipoEvento.Visible = false;
                    #endregion
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;
                }
                #endregion

                #region SOMENTE CADASTRAR DEMANDA(EVENTO) + CADASTRAR CLIENTES + GOVERNACA + CAPACITY
                if (ret_perm[0].per_cad_evento == true &&
                         ret_perm[0].per_aprova_evento == true &&
                         ret_perm[0].per_cad_cliente == true &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == true &&
                         ret_perm[0].per_suporte == false)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tssBarra1.Visible = false;
                    tsbNovo.Enabled = true;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Visible = true;
                    tsmnuApCapacity.Visible = true;
                    tsmnuApSuporte.Visible = false;
                    #region MENU EDITAR
                    MenuEditar.Enabled = true;
                    mnuDemandaAtiv.Visible = false;
                    mnuCapacity.Visible = false;
                    mnuClientes.Visible = true;
                    mnuAtividade.Visible = false;
                    mnuFundo.Visible = false;
                    mnuProduto.Visible = false;
                    mnuStatusEvento.Visible = false;
                    mnuSetor.Visible = false;
                    mnuTipoEvento.Visible = false;
                    #endregion
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;
                }
                #endregion

                #region SOMENTE CADASTRAR DEMANDA(EVENTO) + CADASTRAR CLIENTES + GOVERNACA + CAPACITY + SUPORTE
                if (ret_perm[0].per_cad_evento == true &&
                         ret_perm[0].per_aprova_evento == true &&
                         ret_perm[0].per_cad_cliente == true &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == true &&
                         ret_perm[0].per_suporte == true)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tssBarra1.Visible = false;
                    tsbNovo.Enabled = true;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Visible = true;
                    tsmnuApCapacity.Visible = true;
                    tsmnuApSuporte.Visible = true;
                    #region MENU EDITAR
                    MenuEditar.Enabled = true;
                    mnuDemandaAtiv.Visible = false;
                    mnuCapacity.Visible = false;
                    mnuClientes.Visible = true;
                    mnuAtividade.Visible = false;
                    mnuFundo.Visible = false;
                    mnuProduto.Visible = false;
                    mnuStatusEvento.Visible = false;
                    mnuSetor.Visible = false;
                    mnuTipoEvento.Visible = false;
                    #endregion
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;
                }
                #endregion

                #region APROVAR GOVERNANÇA
                if (ret_perm[0].per_cad_evento == false &&
                         ret_perm[0].per_aprova_evento == true &&
                         ret_perm[0].per_cad_cliente == false &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == false &&
                         ret_perm[0].per_suporte == false)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tsbNovo.Enabled = false;
                    tssBarra1.Visible = false;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Visible = true;
                    tsmnuApCapacity.Visible = false;
                    tsmnuApSuporte.Visible = false;
                    MenuEditar.Enabled = false;
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;

                }
                #endregion

                #region APROVAR GOVERNANÇA + CAPACITY
                if (ret_perm[0].per_cad_evento == false &&
                         ret_perm[0].per_aprova_evento == true &&
                         ret_perm[0].per_cad_cliente == false &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == true &&
                         ret_perm[0].per_suporte == false)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tsbNovo.Enabled = false;
                    tssBarra1.Visible = false;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Visible = true;
                    tsmnuApCapacity.Visible = true;
                    tsmnuApSuporte.Visible = false;
                    MenuEditar.Enabled = false;
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;

                }
                #endregion

                #region APROVAR GOVERNANÇA + CAPACITY + SUPORTE
                if (ret_perm[0].per_cad_evento == false &&
                         ret_perm[0].per_aprova_evento == true &&
                         ret_perm[0].per_cad_cliente == false &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == true &&
                         ret_perm[0].per_suporte == true)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tsbNovo.Enabled = false;
                    tssBarra1.Visible = false;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Visible = true;
                    tsmnuApCapacity.Visible = true;
                    tsmnuApSuporte.Visible = true;
                    MenuEditar.Enabled = false;
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;

                }
                #endregion

                #region APROVAR CAPACITY
                if (ret_perm[0].per_cad_evento == false &&
                         ret_perm[0].per_aprova_evento == false &&
                         ret_perm[0].per_cad_cliente == false &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == true &&
                         ret_perm[0].per_suporte == false)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tsbNovo.Enabled = false;
                    tssBarra1.Visible = false;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Visible = false;
                    tsmnuApCapacity.Visible = true;
                    tsmnuApSuporte.Visible = false;
                    MenuEditar.Enabled = false;
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;

                }
                #endregion

                #region APROVAR CAPACITY + SUPORTE
                if (ret_perm[0].per_cad_evento == false &&
                         ret_perm[0].per_aprova_evento == false &&
                         ret_perm[0].per_cad_cliente == false &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == true &&
                         ret_perm[0].per_suporte == true)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tsbNovo.Enabled = false;
                    tssBarra1.Visible = false;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Visible = false;
                    tsmnuApCapacity.Visible = true;
                    tsmnuApSuporte.Visible = true;
                    MenuEditar.Enabled = false;
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;

                }
                #endregion

                #region SUPORTE
                if (ret_perm[0].per_cad_evento == false &&
                         ret_perm[0].per_aprova_evento == false &&
                         ret_perm[0].per_cad_cliente == false &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == false &&
                         ret_perm[0].per_suporte == true)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tsbNovo.Enabled = false;
                    tssBarra1.Visible = false;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Visible = false;
                    tsmnuApCapacity.Visible = false;
                    tsmnuApSuporte.Visible = true;
                    MenuEditar.Enabled = false;
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;

                }
                #endregion

                #region SUPORTE + GOVERNANCA
                if (ret_perm[0].per_cad_evento == false &&
                         ret_perm[0].per_aprova_evento == true &&
                         ret_perm[0].per_cad_cliente == false &&
                         ret_perm[0].per_cronograma == false &&
                         ret_perm[0].per_produto == false &&
                         ret_perm[0].per_suporte == true)
                {
                    mnuVisaoEventos.Visible = false;
                    mnuDesbloquear.Visible = false;
                    tsbNovo.Enabled = false;
                    tssBarra1.Visible = false;
                    tsbAprovacoes.Enabled = true;
                    tsmnuApGovernanca.Visible = true;
                    tsmnuApCapacity.Visible = false;
                    tsmnuApSuporte.Visible = true;
                    MenuEditar.Enabled = false;
                    MenuFerramentas.Enabled = false;
                    mnuLog.Visible = false;
                    barraLog.Visible = false;

                }
                #endregion
            }
            catch (Exception ex)
            {
                #region LOG ERRO
                cLog lg = new cLog();
                lg.log = ex.Message.Replace("'", "");
                lg.form = this.Text;
                lg.metodo = "trata_permissoes";
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion

            }
        }
        private void grava_comentario(string comentario, string tipo)
        {
            // tipo: HISTORICO ou COMENTARIO
            if (tipo == "COMENTARIO")
            {
                string guardamsgant = txtComentario.Text;
                try
                {

                    txtComentario.Text = string.Concat(comentario,
                                                      Environment.NewLine,
                                                      Environment.NewLine,
                                                      cGlobal.userlogado,
                                                      "  |  ",
                                                      DateTime.Now,
                                                      Environment.NewLine,
                                                      "----------------------------------------------------------------------------------------------------------------------------------------------------",
                                                      Environment.NewLine,
                                                      Environment.NewLine,
                                                      guardamsgant
                                                      );


                    cEvento ce = new cEvento();
                    if (!txtIDSeq.Text.Equals(string.Empty))
                        ce.id_seq_evento = int.Parse(txtIDSeq.Text);
                    else
                        return;

                    ce.comentario = txtComentario.Text;
                    ce.atualiza_comentario(ce, "COMENTARIOS");
                }
                catch (Exception ex)
                {
                    txtComentario.Text = string.Empty;
                    throw ex;
                }
            }
            else if (tipo == "HISTORICO")
            {
                string guardamsgant = txtHistorico.Text;
                try
                {

                    txtHistorico.Text = string.Concat(comentario,
                                                      Environment.NewLine,
                                                      Environment.NewLine,
                                                      cGlobal.userlogado,
                                                      "  |  ",
                                                      DateTime.Now,
                                                      Environment.NewLine,
                                                      "----------------------------------------------------------------------------------------------------------------------------------------------------",
                                                      Environment.NewLine,
                                                      Environment.NewLine,
                                                      guardamsgant
                                                      );


                    cEvento ce = new cEvento();
                    ce.id_seq_evento = int.Parse(txtIDSeq.Text);
                    ce.comentario = txtHistorico.Text;
                    ce.atualiza_comentario(ce, "HISTORICO");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        private void txtMascara_KeyPress(object sender, KeyPressEventArgs e)
        {
            flgAlterouMascara = true;

        }

        private void txtMascara_Leave(object sender, EventArgs e)
        {
            cMaskara mc = new cMaskara();
            string tipoevento = string.Empty;
            DataGridViewRow row = dgvDescEvento.CurrentRow;
            int indice = row.Index;
            tipoevento = dgvDescEvento.Rows[indice].Cells[2].Value.ToString();
            mc.id_tpevento = mc.retorna_id_tipo_evento(tipoevento);
            mc.seq_evento = Convert.ToInt32(txtIDSeq.Text);
            mc.maskara = txtMascara.Text;
            mc.grava_temp_mascara(mc);

        }

        private void dgvDescEvento_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            {

                MessageBox.Show("Erro Ocorrido " + e.Context.ToString());

                if (e.Context == DataGridViewDataErrorContexts.Commit)
                {
                    MessageBox.Show("Erro de Commit");
                }
                if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
                {
                    MessageBox.Show("Erro ao mudar a celula");
                }
                if (e.Context == DataGridViewDataErrorContexts.Parsing)
                {
                    MessageBox.Show("Erro de Parse");
                }
                if (e.Context == DataGridViewDataErrorContexts.LeaveControl)
                {
                    MessageBox.Show("Erro ao deixar o controle");
                }

                if ((e.Exception) is ConstraintException)
                {
                    DataGridView view = (DataGridView)sender;
                    view.Rows[e.RowIndex].ErrorText = "um erro";
                    view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "um erro";

                    e.ThrowException = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int atualizado = 1;
            DateTime cdata = new DateTime(2017, 01, 01);
            for (int i=0; i< 15794; i++)
            {
                if (!(cdata.DayOfWeek == DayOfWeek.Sunday || cdata.DayOfWeek == DayOfWeek.Saturday))
                {
                    cGlobal.query = "update calendario_tb set datas = '" + cdata.ToShortDateString() + "', " +
                                   " dia_semana = " + cdata.DayOfYear.ToString() +
                                   " where id = " + atualizado++;
                    using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cConexao.fecha_conexao();
                    }

                }       
                cdata = cdata.AddDays(1);        
            }

            

        }

        private void btnRefCboFundoDestino_Click(object sender, EventArgs e)
        {
            try
            {
                carrega_combo_fundo((ComboBox)sender);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cboFundoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //retorna dados do Fundo
                cFundo fd = new cFundo();
                if (Convert.ToInt32(cboFundoDestino.SelectedValue) == 1)
                {
                    txtSiglaSACDestino.Text = "";
                    txtSiglaFYDestino.Text = "";
                    txtCNPJCPFDestino.Text = "";
                }
                else
                {
                    fd.id_Fundo = Convert.ToInt32(cboFundoDestino.SelectedValue);

                    using (DataSet ds = fd.retorna_dados_fundo(fd))
                    {
                        if (ds.Tables.Count > 0)
                        {
                            foreach (DataRow drw in ds.Tables["RetFundo"].Rows)
                            {
                                txtSiglaSACDestino.Text = drw["SIGLA_SAC"].ToString();
                                txtSiglaFYDestino.Text = drw["SIGLA_FY"].ToString();

                                if (drw["CNPJ_CPF"].ToString().Length == 14)
                                {
                                    txtCNPJCPFDestino.Text = (string.Concat(drw["CNPJ_CPF"].ToString().Substring(0, 2), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(2, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(5, 3), "/",
                                                                     drw["CNPJ_CPF"].ToString().Substring(8, 4), "-",
                                                                     drw["CNPJ_CPF"].ToString().Substring(12, 2)).Replace(",", "."));
                                }
                                else
                                {
                                    txtCNPJCPFDestino.Text = (string.Concat(drw["CNPJ_CPF"].ToString().Substring(0, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(3, 3), ".",
                                                                     drw["CNPJ_CPF"].ToString().Substring(6, 3), "-",
                                                                     drw["CNPJ_CPF"].ToString().Substring(9, 2)).Replace(",", "."));
                                }
                            }
                        }
                        else
                        {
                            txtSiglaSACDestino.Text = string.Empty;
                            txtSiglaFYDestino.Text = string.Empty;
                            txtCNPJCPFDestino.Text = string.Empty;
                        }
                    }
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
                //lg.grava_log(lg);
                #endregion
            }
        }

        #endregion

        #region APROVACOES

        #region GOVERNANÇA
        private void tsmnuApGovernanca_Click(object sender, EventArgs e)
        {
            DateTime dtevento;
            List<status_evento> se = new List<status_evento>();
            se.Clear();
            try
            {
                this.Cursor = Cursors.AppStarting;

                #region VERIFICA SE JÁ FOI APROVADO A GOVERNANCA
                cEvento ce = new cEvento();
                int ret = ce.verifica_aprov_governanca(int.Parse(txtIDSeq.Text));
                if (ret > 0)
                {
                    MessageBox.Show("A Demanda já está aprovada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Arrow;
                    return;
                }
                #endregion

                #region VERIFICA DATA DO EVENTO DOS REGISTROS DA GRID
                foreach (DataGridViewRow linha in dgvDescEvento.Rows)
                {
                    foreach (DataGridViewCell item in linha.Cells)
                    {
                        #region DATA DO EVENTO
                        if (item.ColumnIndex == 4)
                        {
                            dtevento = Convert.ToDateTime(item.Value.ToString().Substring(0, 10));

                            if (dtevento.Date < DateTime.Now.Date)
                            {
                                se.Add(new status_evento(Convert.ToInt32(linha.Cells[0].Value),
                                                         Convert.ToInt32(linha.Cells[1].Value),
                                                         Convert.ToString(linha.Cells[2].Value),
                                                         Convert.ToDateTime(linha.Cells[4].Value),
                                                         false
                                                         )
                                      );
                            }
                            else
                            {
                                se.Add(new status_evento(Convert.ToInt32(linha.Cells[0].Value),
                                                         Convert.ToInt32(linha.Cells[1].Value),
                                                         Convert.ToString(linha.Cells[2].Value),
                                                         Convert.ToDateTime(linha.Cells[4].Value),
                                                         true
                                                         )
                                      );
                            }
                        }
                        #endregion
                    }
                }
                #endregion

                #region RESUMO
                string newstringA = string.Empty;
                string newstringB = string.Empty;
                for (int i = 0; i < se.Count; i++)
                {
                    if (se[i].flag == false)
                    {
                        newstringA += string.Concat("Evento: ", se[i].ideven, "-", se[i].neven, " | Data Evento: ", se[i].dteven.ToShortDateString(), "\r\n");
                    }
                }

                for (int j = 0; j < se.Count; j++)
                {
                    if (se[j].flag == true)
                    {
                        newstringB += string.Concat("Evento: ", se[j].ideven, "-", se[j].neven, " | Data Evento: ", se[j].dteven.ToShortDateString(), "\r\n");
                    }
                }

                string msgA = string.Concat("Evento(s) em data retroativa.", "\r\n", "Será necessário enviar o de acordo de exceção para execução na data informada.", "\r\n\n");
                if (!string.IsNullOrEmpty(newstringA))
                {
                    newstringA = string.Concat(msgA, newstringA);
                }

                string msgB = string.Concat("Evento validado pela governança, confirmar se há disponibilidade de capacity.", "\r\n\n");
                if (!string.IsNullOrEmpty(newstringB))
                {
                    newstringB = string.Concat(msgB, newstringB);
                }

                if (string.IsNullOrEmpty(newstringA) && !string.IsNullOrEmpty(newstringB))
                {
                    grava_comentario(newstringB, "HISTORICO");
                    MessageBox.Show(string.Concat(newstringB));
                }
                else if (!string.IsNullOrEmpty(newstringA) && string.IsNullOrEmpty(newstringB))
                {
                    grava_comentario(newstringA, "HISTORICO");
                    MessageBox.Show(string.Concat(newstringA));
                }
                else
                {
                    grava_comentario(newstringA, "HISTORICO");
                    grava_comentario(newstringB, "HISTORICO");
                    MessageBox.Show(string.Concat(newstringA,
                                                  Environment.NewLine,
                                                  "--------------------------------------------------------------------------------------",
                                                  newstringB));
                }
                #endregion

                ce.id_seq_evento = int.Parse(txtIDSeq.Text);
                ce.atualiza_status_evento(ce, 0);

                grava_comentario("Registro executado pela Governança", "HISTORICO");

                MessageBox.Show("Registro executado pela Governança", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #region LOG
                cLog lg = new cLog();
                lg.log = string.Concat("Registro executado pela Governança.", Environment.NewLine,
                                        "Demanda nº ", txtIDSeq.Text);
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
                this.Cursor = Cursors.Arrow;
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
        #endregion

        #region CAPACITY
        private void tsmnuApCapacity_Click(object sender, EventArgs e)
        {
            try
            {
                int qtd_cron = 0;
                bool mostrar_msg = false;

                //verifica se já foi aprovado pela governanca
                if (string.IsNullOrEmpty(txtApGov.Text))
                {
                    MessageBox.Show("A Demanda ainda não foi aprovada pela Governança.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                #region VERIFICA SE JÁ FOI APROVADO O CAPACITY
                cEvento ce = new cEvento();
                int ret = ce.verifica_aprov_capacity(int.Parse(txtIDSeq.Text));
                if (ret > 0)
                {
                    MessageBox.Show("Já foi aprovado o Capacity para esta Demanda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Arrow;
                    return;
                }
                #endregion

                #region VERIFICA SE USUÁRIO ESTÁ BLOQUEADO
                cUsuario user = new cUsuario();
                if (user.verifica_bloqueio_usuario())
                {
                    var retuserblock = user.retorna_usuario_bloqueio();
                    MessageBox.Show(string.Concat("Aguarde...",
                                                   Environment.NewLine,
                                                   "Já consta uma aprovação de Capacity em andamento.",
                                                   Environment.NewLine,
                                                   "Usuário: ",
                                                   retuserblock[0].ToString()
                                                   ), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                #endregion
                else
                {
                    this.Cursor = Cursors.AppStarting;

                    #region INICIA PROCESSO - MONTA CRONOGRAMA

                    user.login = cGlobal.userlogado;
                    cGlobal.msg_monta = string.Empty;

                    #region BLOQUEIA GERAÇÃO DE CAPACITY
                    user.bloqueia_usuario_capacity(user, true);
                    #endregion

                    previa_Cronograma pc = new previa_Cronograma();

                    #region REMOVE CRONOGRAMA GERADO CONFORME A DEMANDA
                    pc.remove_cronograma(int.Parse(txtIDSeq.Text));
                    #endregion

                    #region LIMPA TABELA MENSAGEM
                    pc.limpa_mensagem();

                    #endregion

                    #region LIMPA TABELA PREVIA CRONOGRAMA
                    pc.limpa_previa_cronograma();
                    #endregion

                    #region PROGRESSBAR
                    tsprb.Value = 0;
                    tsprb.Step = 1;
                    tsprb.Minimum = 0;
                    tsprb.Maximum = dgvDescEvento.Rows.Count;
                    #endregion

                    #region PERCORRE O DATAGRIDVIEW
                    foreach (DataGridViewRow linha in dgvDescEvento.Rows)
                    {
                        foreach (DataGridViewCell item in linha.Cells)
                        {
                            if (item.ColumnIndex == 0)
                            {
                                cGlobal.id_desc_evento = int.Parse(item.Value.ToString());
                            }

                            //id evento
                            if (item.ColumnIndex == 1)
                            {
                                pc.monta_previa_cronograma(int.Parse(txtIDSeq.Text), int.Parse(item.Value.ToString()));

                                #region  FAZ A RESERVA DO CAPACITY
                                if (pc.verifica_reserva_capacity(int.Parse(txtIDSeq.Text)))
                                {
                                    using (DataSet ds = pc.retorna_data_responsavel_esforco(int.Parse(txtIDSeq.Text), int.Parse(item.Value.ToString())))
                                    {
                                        foreach (DataRow dr in ds.Tables["RetDtRespEsf"].Rows)
                                        {
                                            #region LÊ LINHA POR LINHA E SUBTRAI NA TABELA CAPACITY(CAMPO DISPONÍVEL)
                                            v_dt_exec_plan = Convert.ToDateTime(dr["DT_EXEC_PLAN"].ToString());
                                            v_esforco_plan = int.Parse(dr["ESFORCO_PLAN"].ToString());
                                            v_responsavel = dr["RESPONSAVEL"].ToString();
                                            v_id_tp_evento = int.Parse(dr["ID_TP_EVENTO"].ToString());
                                            v_atividade = dr["ATIVIDADE"].ToString();
                                            v_dt_cota = Convert.ToDateTime(dr["DTCOTA"].ToString());
                                            #endregion

                                            #region RETORNA OS DADOS DO CAPACITY CONFORME A DATA
                                            int v_min_antes = 0;
                                            int v_disp_antes = 0;
                                            int v_compr_antes = 0;
                                            int v_compr_novo = 0;
                                            int v_reserva_antes = 0;
                                            int v_reserva = 0;
                                            DataSet ds_cap_ant = pc.retorna_dados_tabela_capacity(v_dt_exec_plan, v_responsavel);
                                            foreach (DataRow dr_cap_ant in ds_cap_ant.Tables["InfoCapacity"].Rows)
                                            {
                                                v_min_antes = int.Parse(dr_cap_ant["MINUTOS"].ToString());
                                                v_disp_antes = int.Parse(dr_cap_ant["DISPONIVEL"].ToString());
                                                v_compr_antes = int.Parse(dr_cap_ant["COMPROMETIDO"].ToString());
                                                v_reserva_antes = int.Parse(dr_cap_ant["RESERVA"].ToString());
                                                v_reserva = (v_esforco_plan + v_reserva_antes);
                                                v_compr_novo = (v_compr_antes + v_esforco_plan);
                                            }
                                            ds_cap_ant.Dispose();
                                            #endregion

                                            #region ATUALIZA OS MINUTOS DA TABELA CAPACITY_TB
                                            pc.atualiza_minutos(v_dt_exec_plan, v_esforco_plan, v_compr_novo, v_reserva, v_responsavel);
                                            #endregion
                                        }
                                        ce.id_seq_evento = int.Parse(txtIDSeq.Text);
                                        ce.atualiza_status_evento(ce, 3);
                                        //ATUALIZA STATUS DA TABELA DESCRICAO_EVENTO_TB
                                        ce.atualiza_descricao_evento(true, "Reserva de Capacity.\r\n Necessário enviar para a RTO quando aprovado.", 0, int.Parse(txtIDSeq.Text), 0);

                                        pc.grava_tabela_cronograma(int.Parse(item.Value.ToString()), int.Parse(txtIDSeq.Text.ToString()));
                                        grava_comentario("Reserva de Capacity Gerada. Necessário enviar para a RTO quando aprovado", "HISTORICO");
                                        //MessageBox.Show("Reserva de Capacity Gerada. Necessário enviar para a RTO quando aprovado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                #endregion
                                else
                                {
                                    #region APLICA AS REGRAS PARA CADA EVENTO INFORMADO
                                    var retdtmin = pc.retorna_dt_minima(int.Parse(txtIDSeq.Text), int.Parse(item.Value.ToString()));
                                    if (retdtmin.Count > 0)
                                    {
                                        DateTime dtmin = Convert.ToDateTime(retdtmin[0].ToString());
                                        //1-REGRA DE VALIDAÇÃO - DENTRO DO PRAZO PARA EXECUÇÃO DO EVENTO
                                        if (dtmin.Date < DateTime.Now.Date)
                                        {
                                            var retNome = pc.retorna_nome_do_evento(int.Parse(item.Value.ToString()));
                                            #region GUARDA LOG
                                            descricao_log = string.Concat("Evento: ",
                                                                          retNome[0].ToString(),
                                                                          Environment.NewLine,
                                                                          "Sem Capacity",
                                                                          Environment.NewLine,
                                                                          "Não há tempo habil para execução do evento pois existem atividades para execução retroativa: ",
                                                                          retdtmin[0].ToString().Substring(0, 10)
                                                                         );

                                            pc.grava_mensagem_capacity(int.Parse(txtIDSeq.Text),
                                                                       int.Parse(item.Value.ToString()),
                                                                       "Não há tempo habil",
                                                                       descricao_log);

                                            //ATUALIZA STATUS DA TABELA DESCRICAO_EVENTO_TB
                                            ce.atualiza_descricao_evento(false, string.Concat("Sem Capacity",
                                                                                              Environment.NewLine,
                                                                                              "Não há tempo habil para execução do evento pois existem atividades para execução retroativa: ",
                                                                                              retdtmin[0].ToString().Substring(0, 10)
                                                                                             ),
                                                                                              cGlobal.id_desc_evento,
                                                                                              int.Parse(txtIDSeq.Text),
                                                                                              int.Parse(item.Value.ToString())
                                                                        );

                                            grava_comentario(string.Concat(descricao_log), "HISTORICO");

                                            tsprb.Value = 0;

                                            mostrar_msg = true;

                                            #endregion
                                        }
                                        else
                                        {
                                            #region 2-REGRA DE VALIDAÇÃO - VERIFICA SE HÁ CAPACITY NO DIA   
                                            using (DataSet ds = pc.retorna_data_responsavel_esforco(int.Parse(txtIDSeq.Text), int.Parse(item.Value.ToString())))
                                            {
                                                foreach (DataRow dr in ds.Tables["RetDtRespEsf"].Rows)
                                                {
                                                    var ret_min_disp = pc.retorna_minutos_disponiveis_capacity(Convert.ToDateTime(dr["DT_EXEC_PLAN"].ToString()), dr["RESPONSAVEL"].ToString());

                                                    if (ret_min_disp.Count == 0)
                                                        break;

                                                    int minT = ret_min_disp[0].min;
                                                    int dispT = ret_min_disp[0].disp;
                                                    int compT = ret_min_disp[0].compr;
                                                    //VERIFICA SE HÁ CAPACITY
                                                    if (dispT < int.Parse(dr["ESFORCO_PLAN"].ToString()))
                                                    {
                                                        #region GUARDA LOG
                                                        #region MENSAGEM 1
                                                        DateTime retnextdt = pc.retorna_proxima_data(Convert.ToDateTime(dr["DT_EXEC_PLAN"].ToString().Substring(0, 10)), int.Parse(dr["ESFORCO_PLAN"].ToString()), dr["RESPONSAVEL"].ToString());
                                                        descricao_log = string.Concat("Proposta de Cronograma: ",
                                                                                      retnextdt.ToShortDateString());
                                                        #endregion

                                                        #region Mensagem 2
                                                        descricao_log = string.Concat("Não há capacity em: ",
                                                                                      Convert.ToDateTime(dr["DT_EXEC_PLAN"].ToString()).ToShortDateString(),
                                                                                      " para ",
                                                                                      dr["RESPONSAVEL"].ToString().ToUpper(),
                                                                                      Environment.NewLine,
                                                                                      "Motivo: Minutos: ",
                                                                                      minT,
                                                                                      " | Comprometido: ",
                                                                                      compT,
                                                                                      " | Disponível: ",
                                                                                      dispT,
                                                                                      " | Necessário: ",
                                                                                      int.Parse(dr["ESFORCO_PLAN"].ToString())
                                                                                      );
                                                        #endregion

                                                        #region VERIFICA PRÓXIMA DATA PARA O CRONOGRAMA
                                                        var retevento = pc.retorna_nome_do_evento(int.Parse(item.Value.ToString()));
                                                        grava_comentario(string.Concat("Proposta Cronograma: ", retnextdt.ToShortDateString(),
                                                                                       Environment.NewLine,
                                                                                       "Evento: ", retevento[0].ToString(),
                                                                                       Environment.NewLine,
                                                                                       descricao_log
                                                                                       ), "HISTORICO");
                                                        #endregion

                                                        pc.grava_mensagem_capacity(int.Parse(txtIDSeq.Text),
                                                                                   int.Parse(item.Value.ToString()),
                                                                                   "Não há capacity",
                                                                                   string.Concat("Proposta Cronograma: ", retnextdt.ToShortDateString(),
                                                                                                  Environment.NewLine,
                                                                                                 "Evento: ", retevento[0].ToString(),
                                                                                                  Environment.NewLine,
                                                                                                  descricao_log,
                                                                                                  Environment.NewLine
                                                                                                 )
                                                                                   );

                                                        //ATUALIZA STATUS DA TABELA DESCRICAO_EVENTO_TB
                                                        ce.atualiza_descricao_evento(false, string.Concat("Proposta Cronograma: ",
                                                                                            retnextdt.ToShortDateString(),
                                                                                            Environment.NewLine,
                                                                                            descricao_log,
                                                                                            Environment.NewLine),
                                                                                            cGlobal.id_desc_evento,
                                                                                            int.Parse(txtIDSeq.Text),
                                                                                            int.Parse(item.Value.ToString()));

                                                        #endregion
                                                    }
                                                    else
                                                    {
                                                        #region GERA CRONOGRAMA
                                                        #region LÊ LINHA POR LINHA E SUBTRAI NA TABELA CAPACITY(CAMPO DISPONÍVEL)
                                                        v_dt_exec_plan = Convert.ToDateTime(dr["DT_EXEC_PLAN"].ToString());
                                                        v_esforco_plan = int.Parse(dr["ESFORCO_PLAN"].ToString());
                                                        v_responsavel = dr["RESPONSAVEL"].ToString();
                                                        v_id_tp_evento = int.Parse(dr["ID_TP_EVENTO"].ToString());
                                                        v_atividade = dr["ATIVIDADE"].ToString();
                                                        v_dt_cota = Convert.ToDateTime(dr["DTCOTA"].ToString());
                                                        #endregion

                                                        #region RETORNA OS DADOS DO CAPACITY CONFORME A DATA
                                                        int v_min_antes = 0;
                                                        int v_disp_antes = 0;
                                                        int v_compr_antes = 0;
                                                        int v_compr_novo = 0;
                                                        DataSet ds_cap_ant = pc.retorna_dados_tabela_capacity(v_dt_exec_plan, v_responsavel);
                                                        foreach (DataRow dr_cap_ant in ds_cap_ant.Tables["InfoCapacity"].Rows)
                                                        {
                                                            v_min_antes = int.Parse(dr_cap_ant["MINUTOS"].ToString());
                                                            v_disp_antes = int.Parse(dr_cap_ant["DISPONIVEL"].ToString());
                                                            v_compr_antes = int.Parse(dr_cap_ant["COMPROMETIDO"].ToString());
                                                            v_compr_novo = (v_compr_antes + v_esforco_plan);
                                                        }
                                                        ds_cap_ant.Dispose();
                                                        #endregion

                                                        #region ATUALIZA OS MINUTOS DA TABELA CAPACITY_TB
                                                        pc.atualiza_minutos(v_dt_exec_plan, v_esforco_plan, v_compr_novo, 0, v_responsavel);
                                                        #endregion

                                                        ce.id_seq_evento = int.Parse(txtIDSeq.Text);
                                                        ce.atualiza_status_evento(ce, 1);
                                                        #endregion
                                                    }
                                                }
                                                #region GRAVA TABELA CRONOGRAMA_TB
                                                pc.grava_tabela_cronograma(int.Parse(item.Value.ToString()), int.Parse(txtIDSeq.Text.ToString()));
                                                var retnevento = pc.retorna_nome_do_evento(int.Parse(item.Value.ToString()));
                                                grava_comentario(string.Concat("Cronograma Gerado",
                                                                               Environment.NewLine,
                                                                               "Evento: ",
                                                                               retnevento[0].ToString()), "HISTORICO");

                                                //ATUALIZA STATUS DA TABELA DESCRICAO_EVENTO_TB
                                                ce.atualiza_descricao_evento(false,
                                                                             string.Concat("Cronograma Gerado"),
                                                                             cGlobal.id_desc_evento,
                                                                             int.Parse(txtIDSeq.Text),
                                                                             int.Parse(item.Value.ToString()));

                                                #endregion
                                            }
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }

                                //verifica se foi gerado cronograma
                                using (DataTable dt = pc.retorna_cronograma(int.Parse(txtIDSeq.Text), int.Parse(item.Value.ToString())))
                                {
                                    qtd_cron = dt.Rows.Count;
                                }

                            }
                        }
                        if (tsprb.Value <= dgvDescEvento.Rows.Count)
                        {
                            tsprb.Value = tsprb.Value + 1;
                        }
                        else
                        {
                            break;
                        }
                    }

                    #endregion

                    #region ABRE OUTLOOK
                    //MOSTRA STATUS NO OUTLOOK PARA OS EVENTOS QUE NÃO FORAM GERADOS CRONOGRAMA
                    int OpenOutlook = 0;
                    using (DataSet ds = pc.retorna_status(int.Parse(txtIDSeq.Text)))
                    {
                        foreach (DataRow dw in ds.Tables["MontMsg"].Rows)
                        {
                            if (dw["STATUS"].ToString() != "Cronograma Gerado")
                            {
                                OpenOutlook = OpenOutlook + 1;
                            }
                        }
                    }
                    if (OpenOutlook > 0)
                    {
                        Outlook.Application outlookApp = new Outlook.Application();
                        Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                        Outlook.Inspector oInspector = oMailItem.GetInspector;

                        Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;

                        #region MONTA ASSUNTO
                        using (DataSet ds = pc.retorna_info_demanda(int.Parse(txtIDSeq.Text)))
                        {
                            string cnpjcpf;
                            foreach (DataRow dr in ds.Tables["RetInfDem"].Rows)
                            {
                                if (dr["CNPJ_CPF"].ToString().Length == 14)
                                {
                                    cnpjcpf = (string.Concat(dr["CNPJ_CPF"].ToString().Substring(0, 2), ".",
                                                             dr["CNPJ_CPF"].ToString().Substring(2, 3), ".",
                                                             dr["CNPJ_CPF"].ToString().Substring(5, 3), "/",
                                                             dr["CNPJ_CPF"].ToString().Substring(8, 4), "-",
                                                             dr["CNPJ_CPF"].ToString().Substring(12, 2)).Replace(",", "."));
                                }
                                else
                                {
                                    cnpjcpf = (string.Concat(dr["CNPJ_CPF"].ToString().Substring(0, 3), ".",
                                                             dr["CNPJ_CPF"].ToString().Substring(3, 3), ".",
                                                             dr["CNPJ_CPF"].ToString().Substring(6, 3), "-",
                                                             dr["CNPJ_CPF"].ToString().Substring(9, 2)).Replace(",", "."));
                                }

                                oMailItem.Subject = string.Format("Status: {0} | ID DEMANDA: {1} | Sigla SAC: {2} | CNPJ/CPF: {3} ", dr["STATUS"].ToString(), dr["SEQ_EVENTO"].ToString(), dr["SIGLA_SAC"].ToString(), cnpjcpf);
                            }
                        }
                        #endregion

                        #region MONTA CORPO DO E-MAIL
                        using (DataSet ds = pc.monta_msg_outlook(int.Parse(txtIDSeq.Text)))
                        {
                            foreach (DataRow dr in ds.Tables["MontMsg"].Rows)
                            {
                                var retevento = pc.retorna_nome_do_evento(int.Parse(dr["ID_EVENTO"].ToString()));
                                cGlobal.msg_monta = string.Concat(cGlobal.msg_monta,
                                                                  dr["DESCRICAO"].ToString(),
                                                                  "\r\n"
                                                                 );
                            }
                        }
                        #endregion

                        oMailItem.Body = cGlobal.msg_monta;

                        oMailItem.Display(false);
                    }
                    tsprb.Value = 0;
                    #endregion
                    #endregion

                    #region LIBERA TABELA CAPACITY_TB
                    user.bloqueia_usuario_capacity(user, false);
                    #endregion


                    if (qtd_cron == 0 && !mostrar_msg)
                    {
                        MessageBox.Show("Não foi possível gerar o cronograma.\nVerifique a data do Evento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Arrow;
                        return;
                    }
                    else
                    {
                        #region ATUALIZA STATUS
                        ce.id_seq_evento = int.Parse(txtIDSeq.Text);
                        ce.atualiza_status_evento(ce, 1);
                        #endregion

                        MessageBox.Show("Capacity executado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    inicio();

                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Geração de Cronograma, Capacity.", Environment.NewLine,
                                            "Demanda nº ", txtIDSeq.Text);
                    lg.form = this.Text;
                    lg.metodo = sender.ToString();
                    lg.dt = DateTime.Now;
                    lg.usersistema = cGlobal.userlogado;
                    lg.userRede = Environment.UserName;
                    lg.terminal = Environment.MachineName;
                    lg.tp_flag = true;
                    lg.grava_log(lg);
                    #endregion

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                tsprb.Value = 0;
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
                MessageBox.Show(lg.log);
                #endregion
            }
        }
        #endregion

        #region SUPORTE
        private void tsmnuApSuporte_Click(object sender, EventArgs e)
        {
            try
            {
                //verifica se já foi aprovado pela governanca e capacity
                if (string.IsNullOrEmpty(txtApGov.Text) && string.IsNullOrEmpty(txtApCap.Text))
                {
                    MessageBox.Show("A Demanda ainda não foi aprovada pela Governança e nem foi gerado o Capacity.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(txtApCap.Text))
                {
                    MessageBox.Show("Não foi gerado o Capacity da Demanda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                this.Cursor = Cursors.AppStarting;
                #region VERIFICA SE JÁ FOI APROVADA PELO SUPORTE
                cEvento ce = new cEvento();
                int ret = ce.verifica_aprov_suporte(int.Parse(txtIDSeq.Text));
                if (ret > 0)
                {
                    MessageBox.Show("A Demanda já está aprovada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Arrow;
                    return;
                }
                #endregion

                ce.id_seq_evento = int.Parse(txtIDSeq.Text);
                ce.atualiza_status_evento(ce, 4);

                grava_comentario("Agendado.", "HISTORICO");

                MessageBox.Show("Registro agendado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #region LOG
                cLog lg = new cLog();
                lg.log = string.Concat("Registro executado pelo Suporte.", Environment.NewLine,
                                        "Demanda nº ", txtIDSeq.Text);
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
                this.Cursor = Cursors.Arrow;
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
        #endregion

        #endregion

    }
}