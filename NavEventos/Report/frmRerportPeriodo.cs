using NavEventos.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace NavEventos.Report
{
    public partial class frmRerportPeriodo : Form
    {

        Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();

        public frmRerportPeriodo()
        {
            InitializeComponent();
        }

        private void frmRerportPeriodo_Load(object sender, EventArgs e)
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

        private void inicio()
        {
            try
            {
                cRelatorio report = new cRelatorio();
                using (DataTable dt = report.report_periodo())
                {
                    #region COLUNAS
                    //DataGridViewTextBoxColumn campo0 = new DataGridViewTextBoxColumn();
                    //campo0.Name = "ID";
                    //campo0.HeaderText = "ID";
                    //campo0.Width = 100;
                    //campo0.DataPropertyName = "ID";

                    DataGridViewTextBoxColumn campo1 = new DataGridViewTextBoxColumn();
                    campo1.Name = "DATA_DEMANDA";
                    campo1.HeaderText = "Data da Demanda";
                    campo1.Width = 100;
                    campo1.DataPropertyName = "DATA_DEMANDA";

                    DataGridViewTextBoxColumn campo2 = new DataGridViewTextBoxColumn();
                    campo2.Name = "REGISTRADO_POR";
                    campo2.HeaderText = "Registrado Por";
                    campo2.Width = 100;
                    campo2.DataPropertyName = "REGISTRADO_POR";

                    DataGridViewTextBoxColumn campo3 = new DataGridViewTextBoxColumn();
                    campo3.Name = "SETOR";
                    campo3.HeaderText = "Setor";
                    campo2.Width = 100;
                    campo3.DataPropertyName = "SETOR";

                    DataGridViewTextBoxColumn campo4 = new DataGridViewTextBoxColumn();
                    campo4.Name = "CLIENTE";
                    campo4.HeaderText = "Cliente";
                    campo4.Width = 100;
                    campo4.DataPropertyName = "CLIENTE";

                    DataGridViewTextBoxColumn campo5 = new DataGridViewTextBoxColumn();
                    campo5.Name = "TIPO_EVENTO";
                    campo5.HeaderText = "Tipo de Evento";
                    campo5.Width = 100;
                    campo5.DataPropertyName = "TIPO_EVENTO";

                    DataGridViewTextBoxColumn campo6 = new DataGridViewTextBoxColumn();
                    campo6.Name = "STATUS";
                    campo6.HeaderText = "Status";
                    campo6.Width = 100;
                    campo6.DataPropertyName = "STATUS";

                    DataGridViewTextBoxColumn campo7 = new DataGridViewTextBoxColumn();
                    campo7.Name = "SIGLA_SAC";
                    campo7.HeaderText = "Sigla SAC";
                    campo7.Width = 100;
                    campo7.DataPropertyName = "SIGLA_SAC";

                    DataGridViewTextBoxColumn campo8 = new DataGridViewTextBoxColumn();
                    campo8.Name = "SIGLA_FY";
                    campo8.HeaderText = "Sigla FY";
                    campo8.Width = 100;
                    campo8.DataPropertyName = "SIGLA_FY";

                    DataGridViewTextBoxColumn campo9 = new DataGridViewTextBoxColumn();
                    campo9.Name = "CNPJ_CPF";
                    campo9.HeaderText = "CNPJ/CPF";
                    campo9.Width = 100;
                    campo9.DataPropertyName = "CNPJ_CPF";

                    DataGridViewTextBoxColumn campo10 = new DataGridViewTextBoxColumn();
                    campo10.Name = "RAZAO_SOCIAL";
                    campo10.HeaderText = "Razão Social";
                    campo10.Width = 100;
                    campo10.DataPropertyName = "RAZAO_SOCIAL";

                    DataGridViewTextBoxColumn campo11 = new DataGridViewTextBoxColumn();
                    campo11.Name = "DATA_COTA";
                    campo11.HeaderText = "Data da Cota";
                    campo11.Width = 100;
                    campo11.DataPropertyName = "DATA_COTA";

                    DataGridViewTextBoxColumn campo12 = new DataGridViewTextBoxColumn();
                    campo12.Name = "COMISSAO";
                    campo12.HeaderText = "Comissão";
                    campo12.Width = 100;
                    campo12.DataPropertyName = "COMISSAO";

                    DataGridViewTextBoxColumn campo13 = new DataGridViewTextBoxColumn();
                    campo13.Name = "TIPO";
                    campo13.HeaderText = "Tipo";
                    campo13.Width = 100;
                    campo13.DataPropertyName = "TIPO";

                    DataGridViewTextBoxColumn campo14 = new DataGridViewTextBoxColumn();
                    campo14.Name = "PRODUTO";
                    campo14.HeaderText = "Produto";
                    campo14.Width = 100;
                    campo14.DataPropertyName = "PRODUTO";

                    //DataGridViewTextBoxColumn campo15 = new DataGridViewTextBoxColumn();
                    DataGridViewCheckBoxColumn campo15 = new DataGridViewCheckBoxColumn();
                    campo15.Name = "PARECER_RTO";
                    campo15.HeaderText = "Parecer RTO";
                    campo15.Width = 100;
                    campo15.DataPropertyName = "PARECER_RTO";

                    //DataGridViewTextBoxColumn campo16 = new DataGridViewTextBoxColumn();
                    DataGridViewCheckBoxColumn campo16 = new DataGridViewCheckBoxColumn();
                    campo16.Name = "EXTRAPAUTA";
                    campo16.HeaderText = "Extrapauta";
                    campo16.Width = 100;
                    campo16.DataPropertyName = "EXTRAPAUTA";

                    //DataGridViewTextBoxColumn campo17 = new DataGridViewTextBoxColumn();
                    DataGridViewCheckBoxColumn campo17 = new DataGridViewCheckBoxColumn();
                    campo17.Name = "EXCECAO";
                    campo17.HeaderText = "Exceção";
                    campo17.Width = 100;
                    campo17.DataPropertyName = "EXCECAO";

                    dgvReportPeriodo.Columns.Clear();
                    dgvReportPeriodo.AutoGenerateColumns = false;
                    dgvReportPeriodo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvReportPeriodo.Columns.AddRange(new DataGridViewColumn[] { campo1, campo2, campo3, campo4, campo5, campo6, campo7, campo8, campo9, campo10, campo11, campo12, campo13, campo14, campo15, campo16, campo17 });

                    #endregion

                    tslblStatus.Text = string.Concat("Total de: ", dt.Rows.Count, " registro(s) localizado(s)");
                    dgvReportPeriodo.DataSource = dt;
                    cDGV modelo = new cDGV();
                    dgvReportPeriodo = modelo.Grade(dgvReportPeriodo);

                    if (dt.Rows.Count == 0)
                    {
                        tsbtnExportar.Enabled = false;
                    }
                    else
                    {
                        tsbtnExportar.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tsbtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                if (dgvReportPeriodo.Rows.Count > 0)
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);

                    tsProgresso.Value = 0;
                    tsProgresso.Step = 1;
                    tsProgresso.Minimum = 0;
                    tsProgresso.Maximum = dgvReportPeriodo.Rows.Count;

                    for (int i = 1; i < dgvReportPeriodo.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dgvReportPeriodo.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < dgvReportPeriodo.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvReportPeriodo.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dgvReportPeriodo.Rows[i].Cells[j].Value.ToString();
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
    }
}
