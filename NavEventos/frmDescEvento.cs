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
    public partial class frmDescEvento : Form
    {
        public frmDescEvento()
        {
            InitializeComponent();
        }

        private void frmDescEvento_Load(object sender, EventArgs e)
        {
            try
            {
                if (cGlobal.acao == false)
                {
                    tsbtnSalvar.Enabled = false;
                    txtDescricaoEvento.ReadOnly = true;
                    chkRTO.Enabled = false;
                    dtpDataDemanda.Enabled = false;
                    dtpCota.Enabled = false;
                }
                else
                {
                    tsbtnSalvar.Enabled = true;
                    txtDescricaoEvento.ReadOnly = false;
                    chkRTO.Enabled = true;
                    dtpDataDemanda.Enabled = true;
                    dtpCota.Enabled = true;
                }

                inicio();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void inicio()
        {
            try
            {
                cTipoEvento ctp = new cTipoEvento();
                ctp.id_descricao_evento = cGlobal.id_desc_evento;
                using (DataSet ds = ctp.retorna_descricao_evento(ctp))
                {
                    foreach (DataRow drw in ds.Tables["DescEvento"].Rows)
                    {
                        txtID.Text = drw["ID_DESCRICAO_EVENTO"].ToString();
                        txtIDDemanda.Text = drw["SEQ_EVENTO"].ToString();
                        txtIDTPEvento.Text = drw["ID_TP_EVENTO"].ToString();
                        txtEvento.Text = drw["EVENTO"].ToString();
                        txtDescricaoEvento.Text = drw["DESCRICAO"].ToString();
                        chkRTO.Checked = Convert.ToBoolean(drw["RTO"].ToString());
                        dtpDataDemanda.Value = Convert.ToDateTime(drw["DTDEMANDA"].ToString());
                        dtpCota.Value = Convert.ToDateTime(drw["DTCOTA"].ToString());
                    }
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

        private void tsbtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                cTipoEvento ctp = new cTipoEvento();
                ctp.id_descricao_evento = int.Parse(txtID.Text);
                ctp.maskara = txtDescricaoEvento.Text;
                ctp.dtdemanda = dtpDataDemanda.Value;
                ctp.rto = chkRTO.Checked;
                ctp.dtcota = dtpCota.Value;
                ctp.atualiza_descricao_evento(ctp);
                MessageBox.Show("Registro atualizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                #region LOG
                cLog lg = new cLog();
                lg.log = string.Concat("Alteração da Registro.", Environment.NewLine,
                                       "Evento: ", txtEvento.Text, Environment.NewLine,
                                       "Descrição: ", txtDescricaoEvento.Text , Environment.NewLine,
                                       "Data da Demanda: ", dtpDataDemanda.Value , Environment.NewLine,
                                       "Data da Cota: ", dtpCota.Value
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
                Dispose();
                Close();
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
    }
}
