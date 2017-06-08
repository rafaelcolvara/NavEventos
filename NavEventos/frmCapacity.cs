using NavEventos.Class;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace NavEventos
{
    public partial class frmCapacity : Form
    {
        Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();

        #region EVENTOS
        public frmCapacity()
        {
            InitializeComponent();
        }
        private void frmCapacity_Load(object sender, EventArgs e)
        {
            try
            {
                cCapacity cp = new cCapacity();
                dtpData.Value = DateTime.Now;
                inicio(DateTime.Now);
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
        private void frmCapacity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    dtpData.Value = DateTime.Now;
                    inicio(dtpData.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                inicio(dtpData.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                dtpData.Value = dtpData.Value.AddDays(-1);
                int cont = 0;
                do
                {
                    if (!verifica_dia_util(dtpData.Value))
                    {
                        dtpData.Value = dtpData.Value.AddDays(-1);
                    }
                    else
                    {
                        break;
                    }
                    cont++;
                } while (cont < 7);
                inicio(dtpData.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                dtpData.Value = dtpData.Value.AddDays(1);
                int cont = 0;
                do
                {
                    if (!verifica_dia_util(dtpData.Value))
                    {
                        dtpData.Value = dtpData.Value.AddDays(1);
                    }
                    else
                    {
                        break;
                    }
                    cont++;
                } while (cont < 7);

                inicio(dtpData.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool verifica_dia_util(DateTime dt)
        {
            try
            {
                string diasemana;
                diasemana = Convert.ToString(dt.DayOfWeek);

                if (diasemana.Equals("Saturday") || diasemana.Equals("Sunday"))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void dgvCapacity_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    DataGridViewColumn dgvc = dgvCapacity.Columns[e.ColumnIndex];
                    dgvc.DefaultCellStyle.BackColor = Color.DodgerBlue;
                    dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (e.ColumnIndex == 2)
                {
                    DataGridViewColumn dgvc = dgvCapacity.Columns[e.ColumnIndex];
                    dgvc.DefaultCellStyle.BackColor = Color.MediumSeaGreen;
                    dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (e.ColumnIndex == 3)
                {
                    DataGridViewColumn dgvc = dgvCapacity.Columns[e.ColumnIndex];
                    dgvc.DefaultCellStyle.BackColor = Color.Yellow;
                    dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (e.ColumnIndex == 4)
                {
                    DataGridViewColumn dgvc = dgvCapacity.Columns[e.ColumnIndex];
                    dgvc.DefaultCellStyle.BackColor = Color.Red;
                    dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    DataGridViewColumn dgvc = dgvCapacity.Columns[e.ColumnIndex];
                    dgvc.DefaultCellStyle.BackColor = Color.White;
                    //dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                #region EXPORTAR EXCEL

                #region EXPORTAR COM GRÁFICO (ERRO NO WINDOWS 7)
                //SaveFileDialog salvar = new SaveFileDialog();

                //Excel.Application App; // Aplicação Excel 
                //Excel.Workbook WorkBook; // Pasta 
                //Excel.Worksheet WorkSheet; // Planilha 
                //object misValue = System.Reflection.Missing.Value;

                //App = new Excel.Application();
                //WorkBook = App.Workbooks.Add(misValue);
                //WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);
                //int i = 0;
                //int j = 0;

                //for (int c = 1; c < dgvCapacity.Columns.Count + 1; c++)
                //{
                //    WorkSheet.Cells[1, c] = dgvCapacity.Columns[c - 1].HeaderText;
                //}

                //// passa as celulas do DataGridView para a Pasta do Excel 
                //for (i = 0; i <= dgvCapacity.RowCount - 1; i++)
                //{
                //    for (j = 0; j <= dgvCapacity.ColumnCount - 1; j++)
                //    {
                //        DataGridViewCell cell = dgvCapacity[j, i];
                //        WorkSheet.Cells[i + 2, j + 1] = cell.Value;
                //    }
                //}

                //Excel.Range chartRange;

                //Excel.ChartObjects xlCharts = (Excel.ChartObjects)WorkSheet.ChartObjects(Type.Missing);
                //Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
                //Excel.Chart chartPage = myChart.Chart;

                //chartRange = WorkSheet.get_Range("A1", "E4");
                //chartPage.SetSourceData(chartRange, misValue);
                //chartPage.ChartType = Excel.XlChartType.xl3DColumnClustered;

                //// Chart exportação como arquivo de imagem
                ////chartPage.Export(@"C:\Temp\excel_chart_export.bmp", "BMP", misValue);
                //chartPage.Export(string.Concat(Application.StartupPath, @"\excel_chart_export.bmp", "BMP", misValue));

                //// define algumas propriedades da caixa salvar 
                //salvar.Title = "Exportação de Arquivo";
                //salvar.Filter = "Arquivo do Excel *.xls | *.xls";
                //salvar.FileName = string.Concat("Capacity_", dtpData.Value.ToString().Replace("/", "").Replace(":", "").Replace(" ", "_"));
                //salvar.ShowDialog(); // mostra 

                //// salva o arquivo 
                //WorkBook.SaveAs(salvar.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,

                //Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                //WorkBook.Close(true, misValue, misValue);
                //App.Quit(); // encerra o excel 

                //liberarObjetos(WorkBook);
                //liberarObjetos(WorkSheet);
                //liberarObjetos(App);
                #endregion

                this.Cursor = Cursors.AppStarting;
                if (dgvCapacity.Rows.Count > 0)
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 1; i < dgvCapacity.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dgvCapacity.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < dgvCapacity.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvCapacity.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dgvCapacity.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    //
                    XcelApp.Columns.AutoFit();
                    //
                    XcelApp.Visible = true;

                }

                this.Cursor = Cursors.Arrow;

                #endregion

                #region LOG
                cLog lg = new cLog();
                lg.log = string.Concat("Exportação, Capacity.", Environment.NewLine,
                                        "Data ", dtpData.Value.ToShortDateString());
                lg.form = this.Text;
                lg.metodo = sender.ToString();
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = true;
                lg.grava_log(lg);
                #endregion

                //MessageBox.Show("Exportação executada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        //private void liberarObjetos(object obj)
        //{
        //    try
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        //        obj = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        obj = null;
        //        MessageBox.Show("Ocorreu um erro durante a liberação do objeto " + ex.ToString());
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }
        //}



        #endregion

        #region METODOS
        private void inicio(DateTime data)
        {
            #region CAMPOS
            DataGridViewTextBoxColumn campo0 = new DataGridViewTextBoxColumn();
            campo0.Name = "Responsavel";
            campo0.HeaderText = "RESPONSÁVEL";
            campo0.DataPropertyName = "RESPONSAVEL";
            campo0.Width = 130;

            DataGridViewTextBoxColumn campo1 = new DataGridViewTextBoxColumn();
            campo1.Name = "MINUTOS";
            campo1.HeaderText = "MINUTOS";
            campo1.DataPropertyName = "MINUTOS";
            campo1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn campo2 = new DataGridViewTextBoxColumn();
            campo2.Name = "DISPONIVEL";
            campo2.HeaderText = "DISPONÍVEL";
            campo2.DataPropertyName = "DISPONIVEL";
            campo2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn campo3 = new DataGridViewTextBoxColumn();
            campo3.Name = "Comprometido";
            campo3.HeaderText = "COMPROMETIDO";
            campo3.DataPropertyName = "COMPROMETIDO";
            campo3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn campo4 = new DataGridViewTextBoxColumn();
            campo4.Name = "Reservado";
            campo4.HeaderText = "RESERVADO";
            campo4.DataPropertyName = "RESERVA";
            campo4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            #endregion

            cCapacity cc = new cCapacity();
            using (DataSet ds = cc.retorna_capacity_dia(data))
            {
                using (DataTable dt = ds.Tables["Capacity"])
                {
                    dgvCapacity.Columns.Clear();
                    dgvCapacity.AutoGenerateColumns = false;
                    dgvCapacity.Columns.AddRange(new DataGridViewColumn[] { campo0, campo1, campo2, campo3, campo4 });
                    dgvCapacity.DataSource = dt;

                    dgvCapacity.Columns["RESPONSAVEL"].Frozen = true;

                    cDGV modelo = new cDGV();
                    dgvCapacity = modelo.Grade(dgvCapacity);

                    #region GRAFICO
                    chtGrafico.DataSource = null;
                    chtGrafico.DataBind();

                    chtGrafico.DataSource = dt;
                    chtGrafico.Series["Minutos"].XValueMember = Convert.ToString(dt.Columns[2].ToString());
                    chtGrafico.Series["Minutos"].YValueMembers = Convert.ToString(dt.Columns[3].ToString());
                    chtGrafico.Series["Disponivel"].XValueMember = Convert.ToString(dt.Columns[2].ToString());
                    chtGrafico.Series["Disponivel"].YValueMembers = Convert.ToString(dt.Columns[4].ToString());
                    chtGrafico.Series["Comprometido"].XValueMember = Convert.ToString(dt.Columns[2].ToString());
                    chtGrafico.Series["Comprometido"].YValueMembers = Convert.ToString(dt.Columns[5].ToString());
                    chtGrafico.Series["Reservado"].XValueMember = Convert.ToString(dt.Columns[2].ToString());
                    chtGrafico.Series["Reservado"].YValueMembers = Convert.ToString(dt.Columns[6].ToString());

                    chtGrafico.DataBind();
                    #endregion
                }
            }
        }

        private void btnGerarCapacity_Click(object sender, EventArgs e)
        {
            try
            {
                string param = cGlobal.InputBox("Digite o ano", "Capacity", "");
                if (!string.IsNullOrEmpty(param))
                {

                    cCapacity cc = new cCapacity();
                    cc.ano = param;

                    if (!cc.verifica_capacity_ano(cc))
                    {
                        if (cc.gera_capacity(cc) > 1) { 
                            MessageBox.Show("Capacity gerado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Problemas ao gerar Capacity.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        #region LOG
                        cLog lg = new cLog();
                        lg.log = string.Concat("Geração de Capacity para o ano  ", param, Environment.NewLine);
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
                        MessageBox.Show(string.Format("Já consta capacity gerado para o ano de {0}.", param), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
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

        #endregion


        // private void releaseObject(object obj)
        //{
        //    try
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject (obj);
        //        obj = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        obj = null;
        //        MessageBox.Show ( "Exceção ocorreu ao liberar objeto" + ex.ToString ());
        //    }
        //    finally
        //    {
        //        GC.Collect ();
        //    }
        //}
    }
}
