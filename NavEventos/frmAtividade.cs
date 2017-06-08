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
    public partial class frmAtividade : Form
    {

        DataSet dsdem = new DataSet();

        #region FORM
        public frmAtividade()
        {
            InitializeComponent();
        }
        private void frmAtividade_Load(object sender, EventArgs e)
        {
            try
            {
                inicio(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmAtividade_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    tsbtnRefresh_Click(null, null);
                }

                if (e.KeyCode == Keys.Enter)
                {
                    btnLocalizar_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void frmAtividade_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                dsdem.Dispose();
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
        private void inicio(bool pesquisa)
        {
            try
            {
                Bloqueio(true);
                tssMsg.Text = string.Empty;

                #region TIPO EVENTO
                cTipoEvento cte = new cTipoEvento();
                using (DataSet dstpevento = cte.preenche_lista_tpeventos())
                {
                    cboTPEvento.DataSource = dstpevento.Tables["TpEventos"];
                    cboTPEvento.DisplayMember = "EVENTO";
                    cboTPEvento.ValueMember = "ID_TP_EVENTO";
                    cboTPEvento.Text = string.Empty;
                }
                #endregion

                cDemanda cdem = new cDemanda();
                if (!pesquisa)
                {
                    dsdem = cdem.retorna_demanda(null);
                }
                else
                {
                    dsdem = cdem.retorna_demanda(txtLocalizar.Text.ToUpper());
                }

                if (dsdem.Tables["Demanda"].Rows.Count == 0)
                {
                    txtLocalizar.Text = string.Empty;
                    inicio(false);
                }
                
                #region DATASET
                txtIdDemanda.DataBindings.Clear();
                cboTPEvento.DataBindings.Clear();
                txtAtividade.DataBindings.Clear();
                txtEsforco.DataBindings.Clear();
                cboResponsavel.DataBindings.Clear();
                txtSequencia.DataBindings.Clear();
                txtUsuario.DataBindings.Clear();
                txtDataCad.DataBindings.Clear();

                txtIdDemanda.DataBindings.Add("Text", dsdem, "Demanda.ID_ATIVIDADE");
                txtAtividade.DataBindings.Add("Text", dsdem, "Demanda.ATIVIDADE");
                txtEsforco.DataBindings.Add("Text", dsdem, "Demanda.ESFORCO");
                cboResponsavel.DataBindings.Add("Text", dsdem, "Demanda.RESPONSAVEL");
                txtSequencia.DataBindings.Add("Text", dsdem, "Demanda.SEQUENCIA");
                txtUsuario.DataBindings.Add("Text", dsdem, "Demanda.USERCAD");
                txtDataCad.DataBindings.Add("Text", dsdem, "Demanda.DTCAD");

                cboTPEvento.DataSource = dsdem.Tables["TpEvento"];
                cboTPEvento.DisplayMember = "EVENTO";
                cboTPEvento.ValueMember = "ID_TP_EVENTO";
                cboTPEvento.DataBindings.Add("SelectedValue", dsdem, "Demanda.ID_TP_EVENTO");

                tslStatus.Text = string.Concat(BindingContext[dsdem, "Demanda"].Position + 1, "/", BindingContext[dsdem, "Demanda"].Count);

                if (BindingContext[dsdem, "Demanda"].Count > 0)
                {
                    tsbtnNovo.Enabled = true;
                    tsbtnEditar.Enabled = true;
                    tsbtnCancelar.Enabled = false;
                    tsbtnDeletar.Enabled = true;
                    tsbtnSalvar.Enabled = false;
                }
                else
                {
                    tsbtnNovo.Enabled = true;
                    tsbtnEditar.Enabled = false;
                    tsbtnCancelar.Enabled = false;
                    tsbtnDeletar.Enabled = false;
                    tsbtnSalvar.Enabled = false;
                    Limpa_campos();
                }
                #endregion

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

        private void Limpa_campos()
        {
            try
            {
                cboTPEvento.Text = string.Empty;
                txtAtividade.Text = string.Empty;
                txtEsforco.Text = "0";
                cboResponsavel.Text = string.Empty;
                txtSequencia.Text = "0";
                txtUsuario.Text = string.Empty;
                txtDataCad.Text = string.Empty;
                tssMsg.Text = string.Empty;
                txtLocalizar.Text = string.Empty;

                Bloqueio(false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Bloqueio(bool flag)
        {
            try
            {
                if (flag)
                {
                    cboTPEvento.Enabled = false;
                    cboResponsavel.Enabled = false;
                }
                else
                {
                    cboTPEvento.Enabled = true;
                    cboResponsavel.Enabled = true;
                }
                
                txtAtividade.ReadOnly = flag;
                txtEsforco.ReadOnly = flag;
                txtSequencia.ReadOnly = flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region NAVEGACAO
        private void tsbFirst_Click(object sender, EventArgs e)
        {
            try
            {
                BindingContext[dsdem, "Demanda"].Position = 0;
                tslStatus.Text = string.Concat(BindingContext[dsdem, "Demanda"].Position + 1, "/", BindingContext[dsdem, "Demanda"].Count);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tsbPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                BindingContext[dsdem, "Demanda"].Position -= 1;
                tslStatus.Text = string.Concat(BindingContext[dsdem, "Demanda"].Position + 1, "/", BindingContext[dsdem, "Demanda"].Count);
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
                BindingContext[dsdem, "Demanda"].Position += 1;
                tslStatus.Text = string.Concat(BindingContext[dsdem, "Demanda"].Position + 1, "/", BindingContext[dsdem, "Demanda"].Count);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tsbLast_Click(object sender, EventArgs e)
        {
            try
            {
                BindingContext[dsdem, "Demanda"].Position = BindingContext[dsdem, "Demanda"].Count - 1;
                tslStatus.Text = string.Concat(BindingContext[dsdem, "Demanda"].Count, "/", BindingContext[dsdem, "Demanda"].Count);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion

        #region COMANDOS
        private void tsbtnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                inicio(false);
                cGlobal.editando = false;
                Limpa_campos();
                Bloqueio(false);
                tsbtnNovo.Enabled = false;
                tsbtnEditar.Enabled = false;
                tsbtnCancelar.Enabled = true;
                tsbtnDeletar.Enabled = false;
                tsbtnSalvar.Enabled = true;
                txtLocalizar.Enabled = false;
                btnLocalizar.Enabled = false;
                cboTPEvento.Focus();
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

        private void tsbtnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Bloqueio(true);
                tsbtnNovo.Enabled = true;
                tsbtnEditar.Enabled = false;
                tsbtnCancelar.Enabled = false;
                tsbtnDeletar.Enabled = false;
                tsbtnSalvar.Enabled = false;
                txtLocalizar.Enabled = true;
                btnLocalizar.Enabled = true;
                inicio(false);
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
                if (string.IsNullOrEmpty(cboTPEvento.Text))
                {
                    tssMsg.Text = "Tipo de Evento não informado";
                    cboTPEvento.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtAtividade.Text))
                {
                    tssMsg.Text = "Atividade não informada";
                    txtAtividade.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(cboResponsavel.Text))
                {
                    tssMsg.Text = "Responsável não informado";
                    cboResponsavel.Focus();
                    return;
                }
                #endregion

                cDemanda cdem = new cDemanda();
                var retid = cdem.retorna_id_tp_evento(cboTPEvento.Text);
                cdem.id_tpevento = int.Parse(retid[0].ToString());
                cdem.atividade = txtAtividade.Text;
                cdem.esforco = Convert.ToInt32(txtEsforco.Text);
                cdem.responsavel = cboResponsavel.Text;
                cdem.sequencia = Convert.ToInt32(txtSequencia.Text);

                if (cGlobal.editando == false)
                {
                    //insert
                    cdem.grava_demanda(cdem);
                    MessageBox.Show("Registro cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Cadastro de Registro.", Environment.NewLine,
                                           "Evento: ", cboTPEvento.Text, Environment.NewLine,
                                           "Atividade: ", txtAtividade.Text, Environment.NewLine,
                                           "Esforço: ", txtEsforco.Text, Environment.NewLine,
                                           "Responsável: ", cboResponsavel.Text, Environment.NewLine,
                                           "Sequência: ", txtSequencia.Text, Environment.NewLine
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
                    cdem.id_demanda = int.Parse(txtIdDemanda.Text);
                    cdem.altera_demanda(cdem);
                    MessageBox.Show("Registro alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Alteração de Registro.", Environment.NewLine,
                                           "Evento: ", cboTPEvento.Text, Environment.NewLine,
                                           "Atividade: ", txtAtividade.Text, Environment.NewLine,
                                           "Esforço: ", txtEsforco.Text, Environment.NewLine,
                                           "Responsável: ", cboResponsavel.Text, Environment.NewLine,
                                           "Sequência: ", txtSequencia.Text, Environment.NewLine
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

                Limpa_campos();
                txtLocalizar.Enabled = true;
                btnLocalizar.Enabled = true;
                inicio(false);


            }
            catch (Exception ex)
            {
                tssMsg.Text = "Ocorreu um erro ao Salvar o registro. Consulte o Log.";
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
                cGlobal.editando = true;
                Bloqueio(false);
                tsbtnNovo.Enabled = false;
                tsbtnEditar.Enabled = false;
                tsbtnCancelar.Enabled = true;
                tsbtnDeletar.Enabled = false;
                tsbtnSalvar.Enabled = true;
                txtLocalizar.Enabled = false;
                btnLocalizar.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tsbtnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                cDemanda cdem = new cDemanda();
                cdem.id_demanda = Convert.ToInt32(txtIdDemanda.Text);

                DialogResult dlr = (MessageBox.Show("Deseja realmente excluir esta Demanda?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (dlr == DialogResult.Yes)
                {
                    cdem.deleta_demanda(cdem);
                    MessageBox.Show("Registro excluído com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Exclusão de Registro.", Environment.NewLine,
                                           "Demanda nº : ", cdem.id_demanda
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

                    inicio(false);
                    txtLocalizar.Text = string.Empty;
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

        #endregion

        private void txtEsforco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtSequencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && !(e.KeyChar == '-'))
            {
                e.Handled = true;
            }
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                inicio(false);
                txtLocalizar.Enabled = true;
                btnLocalizar.Enabled = true;
                txtLocalizar.Text = string.Empty;
                txtLocalizar.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void btnTpEvento_Click(object sender, EventArgs e)
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

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLocalizar.Text))
                {
                    #region LOG
                    cLog lg = new cLog();
                    lg.log = string.Concat("Localização de Demanda(Atividade)", Environment.NewLine,
                                           "Evento localizado: ", txtLocalizar.Text
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
                    inicio(false);
                }
                else
                {
                    inicio(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
