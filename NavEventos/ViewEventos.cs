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
    public partial class ViewEventos : Form
    {

        TreeNode NoRaiz = new TreeNode();
        TreeNode NoPrincipal = new TreeNode();
        TreeNode NoFilho = new TreeNode();
        TreeNode NoFilhoB = new TreeNode();

        string NPrincipal, NFilho;
        int NDemanda;

        public ViewEventos()
        {
            InitializeComponent();
        }

        private void ViewEventos_Load(object sender, EventArgs e)
        {
            try
            {
                limpa();
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

        private void limpa()
        {
            try
            {
                txtinfProduto.Text = string.Empty;
                txtinfCliente.Text = string.Empty;
                txtinfFundo.Text = string.Empty;
                txtinfSiglaSAC.Text = string.Empty;
                txtinfSiglaFY.Text = string.Empty;
                txtinfCNPJCPF.Text = string.Empty;
                txtDtDemanda.Text = string.Empty;
                txtDtCota.Text = string.Empty;
                txtStatus.Text = string.Empty;
                //txtApCad.Text = string.Empty;
                //txtApCadData.Text = string.Empty;
                //txtApGov.Text = string.Empty;
                //txtApGovData.Text = string.Empty;
                //txtApCap.Text = string.Empty;
                //txtApCapData.Text = string.Empty;
                //txtApRTO.Text = string.Empty;
                //txtApRTOData.Text = string.Empty;
                dgvCronograma.Columns.Clear();
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
                #region TREEVIEW
                tvwDemanda.Nodes.Clear();
                NoRaiz = tvwDemanda.Nodes.Add(key: "Root", text: "Demanda(s)", imageIndex: 0, selectedImageIndex: 0);

                cEvento ce = new cEvento();
                using (DataSet ds = ce.descricao_evento_por_demanda(false))
                {
                    if (ds.Tables["Evento"].Rows.Count == 0)
                    {
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
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tvwDemanda_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Level == 3)
                {
                    limpa();
                    NDemanda = int.Parse(e.Node.Parent.Text);
                    mostra_registros();
                }
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
                    limpa();
                }
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
                //retorna dados do evento
                cMaskara cm = new cMaskara();
                int retidevento = cm.retorna_id_tipo_evento(tvwDemanda.SelectedNode.Text);
                if (retidevento > 0)
                {
                    cEvento ce = new cEvento();
                    using (DataSet ds = ce.retorna_descricao_evento(NDemanda, int.Parse(retidevento.ToString())))
                    {
                        foreach (DataRow item in ds.Tables["RetDescEvento"].Rows)
                        {
                            txtinfProduto.Text = item["PRODUTO"].ToString();
                            txtinfCliente.Text = item["CLIENTE"].ToString();
                            txtinfFundo.Text = item["RAZAO_SOCIAL"].ToString();
                            txtinfSiglaSAC.Text = item["SIGLA_SAC"].ToString();
                            txtinfSiglaFY.Text = item["SIGLA_FY"].ToString();

                            if (item["CNPJ_CPF"].ToString().Length == 14)
                            {
                                txtinfCNPJCPF.Text = string.Concat(item["CNPJ_CPF"].ToString().Substring(0, 2), ".",
                                                                   item["CNPJ_CPF"].ToString().Substring(2, 3), ".",
                                                                   item["CNPJ_CPF"].ToString().Substring(5, 3), "/",
                                                                   item["CNPJ_CPF"].ToString().Substring(8, 4), "-",
                                                                   item["CNPJ_CPF"].ToString().Substring(12, 2)).Replace(",", ".");
                            }
                            else
                            {
                                txtinfCNPJCPF.Text = string.Concat(item["CNPJ_CPF"].ToString().Substring(0, 3), ".",
                                                               item["CNPJ_CPF"].ToString().Substring(3, 3), ".",
                                                               item["CNPJ_CPF"].ToString().Substring(6, 3), "-",
                                                               item["CNPJ_CPF"].ToString().Substring(9, 2)).Replace(",", ".");
                            }

                            txtDtDemanda.Text = item["DTDEMANDA"].ToString().Substring(0, 10);
                            txtDtCota.Text = item["DTCOTA"].ToString().Substring(0, 10);
                            txtStatus.Text = item["STATUS"].ToString();
                            //txtApCad.Text = item["USER_CAD"].ToString();
                            //txtApCadData.Text = item["DT_USER_CAD"].ToString();
                            //txtApGov.Text = item["GOV_CAD"].ToString();
                            //txtApGovData.Text = item["DT_GOV_CAD"].ToString();
                            //txtApCap.Text = item["CAPACITY_CAD"].ToString();
                            //txtApCapData.Text = item["DT_CAPACITY_CAD"].ToString();
                            //txtApRTO.Text = item["RTO_CAD"].ToString();
                            //txtApRTOData.Text = item["DT_RTO_CAD"].ToString();
                        }

                        if (ds.Tables["RetDescEvento"].Rows.Count > 0)
                        {
                            previa_Cronograma pc = new previa_Cronograma();
                            using (DataTable dt = pc.retorna_cronograma(NDemanda, int.Parse(retidevento.ToString())))
                            {
                                #region CAMPOS
                                DataGridViewTextBoxColumn campo0 = new DataGridViewTextBoxColumn();
                                campo0.Name = "Atividade";
                                campo0.HeaderText = "Atividade";
                                campo0.DataPropertyName = "ATIVIDADE";
                                campo0.Width = 200;

                                DataGridViewTextBoxColumn campo1 = new DataGridViewTextBoxColumn();
                                campo1.Name = "Esforço";
                                campo1.HeaderText = "Esforço";
                                campo1.DataPropertyName = "ESFORCO_PLAN";
                                campo1.Width = 100;

                                DataGridViewTextBoxColumn campo2 = new DataGridViewTextBoxColumn();
                                campo2.Name = "Data Execução";
                                campo2.HeaderText = "Data Execução";
                                campo2.DataPropertyName = "DT_EXEC_PLAN";
                                campo2.Width = 100;

                                DataGridViewTextBoxColumn campo3 = new DataGridViewTextBoxColumn();
                                campo3.Name = "Responsavel";
                                campo3.HeaderText = "Responsável";
                                campo3.DataPropertyName = "RESPONSAVEL";
                                campo3.Width = 100;

                                dgvCronograma.Columns.Clear();
                                dgvCronograma.AutoGenerateColumns = false;
                                dgvCronograma.Columns.AddRange(new DataGridViewColumn[] { campo0, campo1, campo2, campo3 });
                                dgvCronograma.DataSource = dt;
                                dt.Dispose();

                                cDGV modelo = new cDGV();
                                dgvCronograma = modelo.Grade(dgvCronograma);

                                #region RETORNA TOTAL DE MINUTOS CONFORME O RESPONSAVEL
                                decimal min_passivo = 0;
                                decimal min_processamento = 0;
                                decimal min_suporte = 0;

                                foreach (DataGridViewRow item in dgvCronograma.Rows)
                                {
                                    if ((string)item.Cells[3].Value == "Passivo")
                                    {
                                        min_passivo = min_passivo + Convert.ToDecimal(item.Cells[1].Value);
                                    }
                                    if ((string)item.Cells[3].Value == "Processamento")
                                    {
                                        min_processamento = min_processamento + Convert.ToDecimal(item.Cells[1].Value);
                                    }
                                    if ((string)item.Cells[3].Value == "Suporte")
                                    {
                                        min_suporte = min_suporte + Convert.ToDecimal(item.Cells[1].Value);
                                    }
                                }

                                txtPassivo.Text = Convert.ToString(min_passivo);
                                txtProcessamento.Text = Convert.ToString(min_processamento);
                                txtSuporte.Text = Convert.ToString(min_suporte);
                                #endregion


                                #endregion
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
