using NavEventos.Class;
using System;
using System.Data;
using System.Windows.Forms;


namespace NavEventos.Report
{
    public partial class frmReportAtividade : Form
    {

        Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();

        public frmReportAtividade()
        {
            InitializeComponent();
        }

        private void frmReportAtividade_Load(object sender, EventArgs e)
        {
            try
            {
                dtIni.Value = DateTime.Now.AddDays(-1);
                dtFim.Value = DateTime.Now.AddDays(+5);
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

        private void inicio()
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                cRelatorio report = new cRelatorio();
                using (DataTable dt = report.report_atividade(dtIni.Value, dtFim.Value))
                {
                    #region COLUNAS
                    DataGridViewTextBoxColumn campo0 = new DataGridViewTextBoxColumn();
                    campo0.Name = "ID";
                    campo0.HeaderText = "ID Cronograma";
                    campo0.Width = 100;
                    campo0.DataPropertyName = "ID_CRONOGRAMA";

                    DataGridViewTextBoxColumn campo1 = new DataGridViewTextBoxColumn();
                    campo1.Name = "DATA_EXECUCAO_PLANEJADO";
                    campo1.HeaderText = "Data Exec Plan";
                    campo1.Width = 100;
                    campo1.DataPropertyName = "DATA_EXECUCAO_PLANEJADO";

                    DataGridViewTextBoxColumn campo2 = new DataGridViewTextBoxColumn();
                    campo2.Name = "ESFORCO_PLANEJADO";
                    campo2.HeaderText = "Esforço Planejado";
                    campo2.Width = 100;
                    campo2.DataPropertyName = "ESFORCO_PLANEJADO";

                    DataGridViewTextBoxColumn campo3 = new DataGridViewTextBoxColumn();
                    campo3.Name = "EVENTO";
                    campo3.HeaderText = "Evento";
                    campo2.Width = 100;
                    campo3.DataPropertyName = "EVENTO";

                    DataGridViewTextBoxColumn campo4 = new DataGridViewTextBoxColumn();
                    campo4.Name = "CLIENTE";
                    campo4.HeaderText = "Cliente";
                    campo4.Width = 100;
                    campo4.DataPropertyName = "CLIENTE";

                    DataGridViewTextBoxColumn campo5 = new DataGridViewTextBoxColumn();
                    campo5.Name = "INTRAG";
                    campo5.HeaderText = "Intrag";
                    campo5.Width = 100;
                    campo5.DataPropertyName = "INTRAG";

                    DataGridViewTextBoxColumn campo6 = new DataGridViewTextBoxColumn();
                    campo6.Name = "SIGLA_SAC";
                    campo6.HeaderText = "Sigla SAC";
                    campo6.Width = 100;
                    campo6.DataPropertyName = "SIGLA_SAC";

                    DataGridViewTextBoxColumn campo7 = new DataGridViewTextBoxColumn();
                    campo7.Name = "SIGLA_FY";
                    campo7.HeaderText = "Sigla FY";
                    campo7.Width = 100;
                    campo7.DataPropertyName = "SIGLA_FY";

                    DataGridViewTextBoxColumn campo8 = new DataGridViewTextBoxColumn();
                    campo8.Name = "CNPJ_CPF";
                    campo8.HeaderText = "CNPJ/CPF";
                    campo8.Width = 100;
                    campo8.DataPropertyName = "CNPJ_CPF";

                    DataGridViewTextBoxColumn campo9 = new DataGridViewTextBoxColumn();
                    campo9.Name = "DATA_DEMANDA";
                    campo9.HeaderText = "Data Demanda";
                    campo9.Width = 100;
                    campo9.DataPropertyName = "DATA_DEMANDA";

                    DataGridViewTextBoxColumn campo10 = new DataGridViewTextBoxColumn();
                    campo10.Name = "RESPONSAVEL";
                    campo10.HeaderText = "Responsável";
                    campo10.Width = 100;
                    campo10.DataPropertyName = "RESPONSAVEL";

                    DataGridViewTextBoxColumn campo11 = new DataGridViewTextBoxColumn();
                    campo11.Name = "RAZAO_SOCIAL";
                    campo11.HeaderText = "Razão Social";
                    campo11.Width = 100;
                    campo11.DataPropertyName = "RAZAO_SOCIAL";

                    DataGridViewTextBoxColumn campo12 = new DataGridViewTextBoxColumn();
                    campo12.Name = "ID_DEMANDA";
                    campo12.HeaderText = "ID Demanda";
                    campo12.Width = 100;
                    campo12.DataPropertyName = "ID_DEMANDA";

                    DataGridViewTextBoxColumn campo13 = new DataGridViewTextBoxColumn();
                    campo13.Name = "ATIVIDADE";
                    campo13.HeaderText = "Atividade";
                    campo13.Width = 100;
                    campo13.DataPropertyName = "ATIVIDADE";

                    DataGridViewTextBoxColumn campo14 = new DataGridViewTextBoxColumn();
                    campo14.Name = "AVALIACAO";
                    campo14.HeaderText = "Avaliação";
                    campo14.Width = 100;
                    campo14.DataPropertyName = "AVALIACAO";

                    DataGridViewTextBoxColumn campo15 = new DataGridViewTextBoxColumn();
                    campo15.Name = "STATUS";
                    campo15.HeaderText = "Status";
                    campo15.Width = 100;
                    campo15.DataPropertyName = "STATUS";

                    dgvReportAtiv.Columns.Clear();
                    dgvReportAtiv.AutoGenerateColumns = false;
                    dgvReportAtiv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvReportAtiv.Columns.AddRange(new DataGridViewColumn[] { campo0, campo1, campo2, campo3, campo4, campo5, campo6, campo7, campo8, campo9, campo10, campo11, campo12, campo13, campo14, campo15 });

                    //dgvPonto.Columns["DT"].Frozen = true;
                    //dgvPonto.Columns["DT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    //dgvPonto.Columns["HRINICIO"].DefaultCellStyle.Format = "hh:mm";
                    //dgvPonto.Columns["HRINICIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    //dgvPonto.Columns["INTERVALO"].DefaultCellStyle.Format = "hh:mm";
                    //dgvPonto.Columns["INTERVALO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    //dgvPonto.Columns["HR_FIM"].DefaultCellStyle.Format = "hh:mm";
                    //dgvPonto.Columns["HR_FIM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    //dgvPonto.Columns["TOTAL"].DefaultCellStyle.Format = "hh:mm";
                    //dgvPonto.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    //dgvPonto.Columns["HR_CUMPRIR"].DefaultCellStyle.Format = "hh:mm";
                    //dgvPonto.Columns["HR_CUMPRIR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    //dgvPonto.Columns["HR_EXTRAS"].DefaultCellStyle.Format = "hh:mm";
                    //dgvPonto.Columns["HR_EXTRAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    //dgvPonto.Columns["HR_PEND"].DefaultCellStyle.Format = "hh:mm";
                    //dgvPonto.Columns["HR_PEND"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    #endregion

                    tslblStatus.Text = string.Concat("Total de: ", dt.Rows.Count, " registro(s) localizado(s)");
                    dgvReportAtiv.DataSource = dt;
                    cDGV modelo = new cDGV();
                    dgvReportAtiv = modelo.Grade(dgvReportAtiv);

                    if (dt.Rows.Count == 0)
                    {
                        tsbtnExportar.Enabled = false;
                    }
                    else
                    {
                        tsbtnExportar.Enabled = true;
                    }

                }
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                throw ex;
            }
        }

        private void tsbtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                if (dgvReportAtiv.Rows.Count > 0)
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);

                    tsProgresso.Value = 0;
                    tsProgresso.Step = 1;
                    tsProgresso.Minimum = 0;
                    tsProgresso.Maximum = dgvReportAtiv.Rows.Count;

                    for (int i = 1; i < dgvReportAtiv.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dgvReportAtiv.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < dgvReportAtiv.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvReportAtiv.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dgvReportAtiv.Rows[i].Cells[j].Value.ToString();
                        }
                        tsProgresso.Value++;
                    }

                    tsProgresso.Value = 0;
                    //
                    XcelApp.Columns.AutoFit();
                    //
                    XcelApp.Visible = true;
                    XcelApp.Quit();
                }

                #region LOG
                cLog lg = new cLog();
                lg.log = "Exportação para Excel do relatório de Atividades.";
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
                this.Cursor = Cursors.Arrow;
                XcelApp.Quit();
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            inicio();
        }
    }
}
