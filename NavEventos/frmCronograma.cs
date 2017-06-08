using NavEventos.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace NavEventos
{
    public partial class frmCronograma : Form
    {
        #region VARIAVEIS
        TreeNode NoRaiz = new TreeNode();
        TreeNode NoPrincipal = new TreeNode();
        TreeNode NoFilho = new TreeNode();
        TreeNode NoFilhoB = new TreeNode();
        string NPrincipal, NFilho;
        int NDemanda;
        bool b_reserva = false;
        DataSet ds = new DataSet();
        #endregion

        public frmCronograma()
        {
            InitializeComponent();
        }

        #region EVENTOS

        #region FORM
        private void frmCronograma_Load(object sender, EventArgs e)
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
        private void frmCronograma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                mostra_registros();
            }
        }
        private void frmCronograma_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ds.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BOTOES
        private void tsbPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                BindingContext[ds, "Cronograma"].Position -= 1;
                tslStatus.Text = string.Concat(BindingContext[ds, "Cronograma"].Position + 1, "/", BindingContext[ds, "Cronograma"].Count);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void tsbNext_Click(object sender, EventArgs e)
        {
            try
            {
                BindingContext[ds, "Cronograma"].Position += 1;
                tslStatus.Text = string.Concat(BindingContext[ds, "Cronograma"].Position + 1, "/", BindingContext[ds, "Cronograma"].Count);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void tsbtnCancelarEvento_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlr = (MessageBox.Show("Deseja realmente cancelar este Evento?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (dlr == DialogResult.Yes)
                {
                    if (cboStatus.Text == "Cancelado")
                    {
                        MessageBox.Show("Este evento já está cancelado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //RETORNA O STATUS DO EVENTO
                    cEvento ce = new cEvento();
                    b_reserva = ce.retorna_status_capacity_do_evento(NDemanda);
                    
                    previa_Cronograma pc = new previa_Cronograma();
                    using (DataTable dt = pc.retorna_cronograma(NDemanda, cGlobal.id_tp_evento))
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            //int disponivel = int.Parse(item["DISPONIVEL"].ToString());
                            //int comprometido = int.Parse(item["COMPROMETIDO"].ToString());
                            //int reservado = int.Parse(item["RESERVA"].ToString());
                            int esforco = int.Parse(item["ESFORCO_PLAN"].ToString());
                            DateTime dt_esforco = Convert.ToDateTime(item["DT_EXEC_PLAN"].ToString());
                            string resp = item["RESPONSAVEL"].ToString();

                            pc.cancela_minutos_reservados(esforco, dt_esforco, resp, b_reserva);
                        } 
                    }

                    //remove cronograma
                    //pc.remove_cronograma(NDemanda);

                    //atualiza status do cronograma para Cancelado
                    pc.atualiza_status_cronograma(NDemanda, cGlobal.id_tp_evento);

                    MessageBox.Show("O evento foi cancelado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Cancelamento de Evento(s)", Environment.NewLine, "Demanda nº ", NDemanda);
                    lg.form = this.Text;
                    lg.metodo = sender.ToString();
                    lg.dt = DateTime.Now;
                    lg.usersistema = cGlobal.userlogado;
                    lg.userRede = Environment.UserName;
                    lg.terminal = Environment.MachineName;
                    lg.tp_flag = true;
                    lg.grava_log(lg);
                    #endregion

                    mostra_registros();
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
        private void tsbtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Avaliacao();
                Status();
                cboAvaliacao.Enabled = true;
                cboStatus.Enabled = true;
                txtHistorico.ReadOnly = false;                
                tsbtnEditar.Enabled = false;
                tsbtnCancelar.Enabled = true;
                tsbtnSalvar.Enabled = true;
                tsbtnCancelarEvento.Enabled = false;
                cboStatus.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void tsbtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                previa_Cronograma pc = new previa_Cronograma();
                pc.id_cronograma = int.Parse(txtID.Text);
                pc.pc_status = cboStatus.Text;
                pc.pc_historico = txtHistorico.Text;
                pc.pc_avaliacao = cboAvaliacao.Text;
                pc.pc_cadastro_atraso = chkAtrCadastro.Checked;
                pc.pc_cadastro_falha = chkFalCadastro.Checked;
                pc.pc_passivo_atraso = chkAtrPassivo.Checked;
                pc.pc_passivo_falha = chkFalPassivo.Checked;
                pc.pc_relac_atraso = chkAtrRelacionamento.Checked;
                pc.pc_relac_falha = chkFalRelacionamento.Checked;
                pc.pc_produto_atraso = chkAtrProduto.Checked;
                pc.pc_produto_falha = chkFalProduto.Checked;
                pc.pc_liquid_atraso = chkAtrLiquid.Checked;
                pc.pc_liquid_falha = chkFalLiquid.Checked;
                pc.pc_precif_atraso = chkAtrPrecif.Checked;
                pc.pc_precif_falha = chkFalPrecif.Checked;
                pc.pc_cad_ativo_atraso = chkAtrCadAtivos.Checked;
                pc.pc_cad_ativo_falha = chkFalCadAtivos.Checked;
                pc.pc_suporte_atend_atraso = chkAtrSupAtend.Checked;
                pc.pc_suporte_atend_falha = chkFalSupAtend.Checked;
                pc.pc_suporte_proc_atraso = chkAtrSupProc.Checked;
                pc.pc_suporte_proc_falha = chkFalSupProc.Checked;
                pc.pc_conciliacao_atraso = chkAtrConc.Checked;
                pc.pc_conciliacao_falha = chkFalConc.Checked;
                pc.pc_cliente_atraso = chkAtrCliente.Checked;
                pc.pc_cliente_falha = chkFalCliente.Checked;
                pc.pc_despesa_atraso = chkAtrDespesa.Checked;
                pc.pc_despesa_falha = chkFalDespesa.Checked;
                pc.pc_taxas_atraso = chkAtrTaxas.Checked;
                pc.pc_taxas_falha = chkFalTaxas.Checked;
                pc.atualiza_cronograma(pc);
                mostra_registros();

                tsbtnCancelar_Click(null, null);

                MessageBox.Show("O registro foi atualizado com sucesso.");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void tsbtnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                cboAvaliacao.Enabled = false;
                cboStatus.Enabled = false;
                txtHistorico.ReadOnly = true;
                tsbtnEditar.Enabled = true;
                tsbtnCancelar.Enabled = false;
                tsbtnSalvar.Enabled = false;
                tsbtnCancelarEvento.Enabled = true;

                mostra_registros();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region OUTROS
        private void tstxtLocalizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void txtEsfPlan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void txtEsfReal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void txtEvento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        #endregion

        #endregion

        #region METODOS
        private void inicio()
        {
            try
            {
                #region TREEVIEW
                tvwDemanda.Nodes.Clear();
                NoRaiz = tvwDemanda.Nodes.Add(key: "Root", text: "Cronograma(s)", imageIndex: 0, selectedImageIndex: 0);

                cEvento ce = new cEvento();
                using (DataSet ds = ce.descricao_evento_por_demanda(true))
                {
                    if (ds.Tables["Evento"].Rows.Count == 0)
                    {
                        tsbPrevious.Enabled = false;
                        tsbNext.Enabled = false;
                        tsbtnEditar.Enabled = false;
                        tsbtnCancelar.Enabled = false;
                        tsbtnSalvar.Enabled = false;
                        tsbtnCancelarEvento.Enabled = false;
                        tssMsg.Text = "Total de registro(s): 0";
                    }
                    else
                    {
                        tssMsg.Text = string.Concat("Total de registro(s): ", ds.Tables["Evento"].Rows.Count);
                        int Contador = 0;
                        foreach (DataRow item in ds.Tables["Evento"].Rows)
                        {
                            if (NPrincipal != item["ANO"].ToString())
                            {
                                NoPrincipal = NoRaiz.Nodes.Add(key: "Demanda", text: item["ANO"].ToString(), imageIndex: 3, selectedImageIndex: 3);
                                NPrincipal = item["ANO"].ToString();
                                Contador++;
                            }
                            foreach (DataRow itemchild in item.GetChildRows("A"))
                            {
                                int aponta = 0;
                                foreach (DataRow itemsubcchild in itemchild.GetChildRows("B"))
                                {
                                    if (NFilho != item["SEQ_EVENTO"].ToString())
                                    {
                                        NoFilho = NoPrincipal.Nodes.Add(key: "Evento", text: item["SEQ_EVENTO"].ToString(), imageIndex: 1, selectedImageIndex: 1);
                                        NFilho = item["SEQ_EVENTO"].ToString();
                                        aponta++;
                                    }

                                    foreach (var itemsubchidB in itemchild.GetChildRows("B"))
                                    {
                                        NoFilhoB = NoFilho.Nodes.Add(key: "Eventos", text: itemsubchidB["EVENTO"].ToString(), imageIndex: 2, selectedImageIndex: 2);
                                    }

                                }
                            }
                        }
                        tvwDemanda.Nodes[0].EnsureVisible();
                        tvwDemanda.Nodes[0].Expand();

                        tsbtnEditar.Enabled = true;
                        tsbtnCancelar.Enabled = false;
                        tsbtnSalvar.Enabled = false;
                        tsbtnCancelar.Enabled = false;

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
                lg.metodo = "Inicial";
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = false;
                lg.grava_log(lg);
                #endregion
            }
        }
        private void Status()
        {
            try
            {
                cboStatus.Items.Clear();
                cboStatus.Items.Add("Planejado");
                cboStatus.Items.Add("Em Execução");
                cboStatus.Items.Add("Concluído");
                cboStatus.Items.Add("Cancelado");
                cboStatus.Items.Add("Não se aplica");
                cboStatus.Items.Add("Em atraso - Cliente");
                cboStatus.Items.Add("Em atraso - Contraparte");
                cboStatus.Items.Add("Em atraso - Itaú");
                cboStatus.Sorted = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Avaliacao()
        {
            try
            {
                cboAvaliacao.Items.Clear();
                cboAvaliacao.Items.Add("Executado sem falhas");
                cboAvaliacao.Items.Add("Executado com falhas - Cliente");
                cboAvaliacao.Items.Add("Executado com falhas - Itaú");
                cboAvaliacao.Items.Add("Executado com falhas - Contraparte");
                cboAvaliacao.Items.Add("Executado sem falhas - Itau mitigou problemas");
                cboAvaliacao.Sorted = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Limpa_campos()
        {
            try
            {
                txtID.Text = string.Empty;
                //txtEvento.Text = string.Empty;
                cboStatus.Text = string.Empty;
                txtAtividade.Text = string.Empty;
                txtEsfPlan.Text = string.Empty;
                dtpEsforcoPlan.Value = DateTime.Now;
                dtpDataReal.Value = DateTime.Now;
                txtEsfReal.Text = string.Empty;
                txtResp.Text = string.Empty;
                txtHistorico.Text = string.Empty;
                cboAvaliacao.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void mostra_registros()
        {
            try
            {
                this.Width = 912;
                //retorna dados do evento
                cMaskara cm = new cMaskara();
                int retidevento = cm.retorna_id_tipo_evento(tvwDemanda.SelectedNode.Text);
                cGlobal.id_tp_evento = int.Parse(retidevento.ToString());

                cTarefa ativ = new cTarefa();
                Status();
                Avaliacao();

                ds.Clear();
                ds = ativ.retorna_cronograma(NDemanda, int.Parse(retidevento.ToString()));

                #region DATASET

                #region CLEAR
                txtID.DataBindings.Clear();
                cboStatus.DataBindings.Clear();
                txtAtividade.DataBindings.Clear();
                txtEsfPlan.DataBindings.Clear();
                txtEsfReal.DataBindings.Clear();
                dtpEsforcoPlan.DataBindings.Clear();
                dtpDataReal.DataBindings.Clear();
                txtResp.DataBindings.Clear();
                txtHistorico.DataBindings.Clear();
                cboAvaliacao.DataBindings.Clear();
                chkAtrCadastro.DataBindings.Clear();
                chkFalCadastro.DataBindings.Clear();
                chkAtrPassivo.DataBindings.Clear();
                chkFalPassivo.DataBindings.Clear();
                chkAtrRelacionamento.DataBindings.Clear();
                chkFalRelacionamento.DataBindings.Clear();
                chkAtrProduto.DataBindings.Clear();
                chkFalProduto.DataBindings.Clear();
                chkAtrLiquid.DataBindings.Clear();
                chkFalLiquid.DataBindings.Clear();
                chkAtrPrecif.DataBindings.Clear();
                chkFalPrecif.DataBindings.Clear();
                chkAtrCadAtivos.DataBindings.Clear();
                chkFalCadAtivos.DataBindings.Clear();
                chkAtrSupAtend.DataBindings.Clear();
                chkFalSupAtend.DataBindings.Clear();
                chkAtrSupProc.DataBindings.Clear();
                chkFalSupProc.DataBindings.Clear();
                chkAtrConc.DataBindings.Clear();
                chkFalConc.DataBindings.Clear();
                chkAtrCliente.DataBindings.Clear();
                chkFalCliente.DataBindings.Clear();
                chkAtrDespesa.DataBindings.Clear();
                chkFalDespesa.DataBindings.Clear();
                chkAtrTaxas.DataBindings.Clear();
                chkFalTaxas.DataBindings.Clear();
                #endregion

                #region VINCULA DATASET
                txtID.DataBindings.Add("Text", ds, "Cronograma.ID_CRONOGRAMA");
                cboStatus.DataBindings.Add("Text", ds, "Cronograma.STATUS");
                txtAtividade.DataBindings.Add("Text", ds, "Cronograma.ATIVIDADE");
                txtEsfPlan.DataBindings.Add("Text", ds, "Cronograma.ESFORCO_PLAN");
                txtEsfReal.DataBindings.Add("Text", ds, "Cronograma.ESFORCO_REAL");
                dtpEsforcoPlan.DataBindings.Add("Text", ds, "Cronograma.DT_EXEC_PLAN");
                dtpDataReal.DataBindings.Add("Text", ds, "Cronograma.DT_EXEC_REAL");
                txtResp.DataBindings.Add("Text", ds, "Cronograma.RESPONSAVEL");
                txtHistorico.DataBindings.Add("Text", ds, "Cronograma.HISTORICO");
                cboAvaliacao.DataBindings.Add("Text", ds, "Cronograma.AVALIACAO");
                chkAtrCadastro.DataBindings.Add("Checked", ds, "Cronograma.CADASTRO_ATRASO");
                chkFalCadastro.DataBindings.Add("Checked", ds, "Cronograma.CADASTRO_FALHA");
                chkAtrPassivo.DataBindings.Add("Checked", ds, "Cronograma.PASSIVO_ATRASO");
                chkFalPassivo.DataBindings.Add("Checked", ds, "Cronograma.PASSIVO_FALHA");
                chkAtrRelacionamento.DataBindings.Add("Checked", ds, "Cronograma.RELAC_ATRASO");
                chkFalRelacionamento.DataBindings.Add("Checked", ds, "Cronograma.RELAC_FALHA");
                chkAtrProduto.DataBindings.Add("Checked", ds, "Cronograma.PRODUTO_ATRASO");
                chkFalProduto.DataBindings.Add("Checked", ds, "Cronograma.PRODUTO_FALHA");
                chkAtrLiquid.DataBindings.Add("Checked", ds, "Cronograma.LIQUID_ATRASO");
                chkFalLiquid.DataBindings.Add("Checked", ds, "Cronograma.LIQUID_FALHA");
                chkAtrPrecif.DataBindings.Add("Checked", ds, "Cronograma.PRECIF_ATRASO");
                chkFalPrecif.DataBindings.Add("Checked", ds, "Cronograma.PRECIF_FALHA");
                chkAtrCadAtivos.DataBindings.Add("Checked", ds, "Cronograma.CAD_ATIVO_ATRASO");
                chkFalCadAtivos.DataBindings.Add("Checked", ds, "Cronograma.CAD_ATIVO_FALHA");
                chkAtrSupAtend.DataBindings.Add("Checked", ds, "Cronograma.SUPORTE_ATEND_ATRASO");
                chkFalSupAtend.DataBindings.Add("Checked", ds, "Cronograma.SUPORTE_ATEND_FALHA");
                chkAtrSupProc.DataBindings.Add("Checked", ds, "Cronograma.SUPORTE_PROC_ATRASO");
                chkFalSupProc.DataBindings.Add("Checked", ds, "Cronograma.SUPORTE_PROC_FALHA");
                chkAtrConc.DataBindings.Add("Checked", ds, "Cronograma.CONCILIACAO_ATRASO");
                chkFalConc.DataBindings.Add("Checked", ds, "Cronograma.CONCILIACAO_FALHA");
                chkAtrCliente.DataBindings.Add("Checked", ds, "Cronograma.CLIENTE_ATRASO");
                chkFalCliente.DataBindings.Add("Checked", ds, "Cronograma.CLIENTE_FALHA");
                chkAtrDespesa.DataBindings.Add("Checked", ds, "Cronograma.DESPESA_ATRASO");
                chkFalDespesa.DataBindings.Add("Checked", ds, "Cronograma.DESPESA_FALHA");
                chkAtrTaxas.DataBindings.Add("Checked", ds, "Cronograma.TAXAS_ATRASO");
                chkFalTaxas.DataBindings.Add("Checked", ds, "Cronograma.TAXAS_FALHA");
                #endregion

                tslStatus.Text = string.Concat(BindingContext[ds, "Cronograma"].Position + 1, "/", BindingContext[ds, "Cronograma"].Count);

                if (BindingContext[ds, "Cronograma"].Count > 0)
                {
                    tspSuperior.Enabled = true;
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                }
                else
                {
                    tspSuperior.Enabled = false;
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    Limpa_campos();
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region TREEVIEW
        private void tvwDemanda_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Level == 3)
                {
                    Limpa_campos();
                    NDemanda = int.Parse(e.Node.Parent.Text);
                    mostra_registros();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnForcarCronograma_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tvwDemanda_AfterExpand(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Level == 2)
                {
                    NDemanda = int.Parse(e.Node.Text);
                    Limpa_campos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion
    }
}
