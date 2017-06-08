namespace NavEventos
{
    partial class frmCapacity
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapacity));
            this.chtGrafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.dgvCapacity = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnGerarCapacity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chtGrafico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // chtGrafico
            // 
            this.chtGrafico.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Sunken;
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.Area3DStyle.Inclination = 25;
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.Area3DStyle.IsRightAngleAxes = false;
            chartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea2.Area3DStyle.PointGapDepth = 200;
            chartArea2.Area3DStyle.WallWidth = 5;
            chartArea2.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisX.Title = "Áreas";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.Title = "Minutos";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 84.41898F;
            chartArea2.Position.Width = 75.74576F;
            chartArea2.Position.X = 4.112288F;
            chartArea2.Position.Y = 10.69592F;
            this.chtGrafico.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chtGrafico.Legends.Add(legend2);
            this.chtGrafico.Location = new System.Drawing.Point(12, 38);
            this.chtGrafico.Name = "chtGrafico";
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.DodgerBlue;
            series5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            series5.Label = "#VAL";
            series5.Legend = "Legend1";
            series5.Name = "Minutos";
            series6.ChartArea = "ChartArea1";
            series6.Color = System.Drawing.Color.MediumSeaGreen;
            series6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            series6.Label = "#VAL";
            series6.Legend = "Legend1";
            series6.Name = "Disponivel";
            series7.ChartArea = "ChartArea1";
            series7.Color = System.Drawing.Color.Yellow;
            series7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            series7.Label = "#VAL";
            series7.Legend = "Legend1";
            series7.Name = "Comprometido";
            series8.ChartArea = "ChartArea1";
            series8.Color = System.Drawing.Color.Red;
            series8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            series8.Label = "#VAL";
            series8.Legend = "Legend1";
            series8.Name = "Reservado";
            this.chtGrafico.Series.Add(series5);
            this.chtGrafico.Series.Add(series6);
            this.chtGrafico.Series.Add(series7);
            this.chtGrafico.Series.Add(series8);
            this.chtGrafico.Size = new System.Drawing.Size(1003, 475);
            this.chtGrafico.TabIndex = 31;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            title2.Name = "Title1";
            title2.Text = "Gráfico de Capacity (Diário)";
            this.chtGrafico.Titles.Add(title2);
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(70, 12);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(100, 20);
            this.dtpData.TabIndex = 32;
            this.dtpData.ValueChanged += new System.EventHandler(this.dtpData_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Localizar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(812, 593);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Pressione [F5] para atualizar o Formulário";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.Location = new System.Drawing.Point(176, 11);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(24, 23);
            this.btnPrevious.TabIndex = 35;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Location = new System.Drawing.Point(202, 11);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 23);
            this.btnNext.TabIndex = 36;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // dgvCapacity
            // 
            this.dgvCapacity.AllowUserToAddRows = false;
            this.dgvCapacity.AllowUserToDeleteRows = false;
            this.dgvCapacity.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCapacity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCapacity.Location = new System.Drawing.Point(12, 520);
            this.dgvCapacity.Name = "dgvCapacity";
            this.dgvCapacity.ReadOnly = true;
            this.dgvCapacity.Size = new System.Drawing.Size(590, 91);
            this.dgvCapacity.TabIndex = 37;
            this.dgvCapacity.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCapacity_CellFormatting);
            // 
            // btnExportar
            // 
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnExportar.Location = new System.Drawing.Point(626, 542);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(96, 44);
            this.btnExportar.TabIndex = 38;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnGerarCapacity
            // 
            this.btnGerarCapacity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerarCapacity.Image = ((System.Drawing.Image)(resources.GetObject("btnGerarCapacity.Image")));
            this.btnGerarCapacity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerarCapacity.Location = new System.Drawing.Point(893, 520);
            this.btnGerarCapacity.Name = "btnGerarCapacity";
            this.btnGerarCapacity.Size = new System.Drawing.Size(122, 44);
            this.btnGerarCapacity.TabIndex = 39;
            this.btnGerarCapacity.Text = "Gerar Capacity\r\n";
            this.btnGerarCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGerarCapacity.UseVisualStyleBackColor = true;
            this.btnGerarCapacity.Click += new System.EventHandler(this.btnGerarCapacity_Click);
            // 
            // frmCapacity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1024, 615);
            this.Controls.Add(this.btnGerarCapacity);
            this.Controls.Add(this.chtGrafico);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvCapacity);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCapacity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capacity";
            this.Load += new System.EventHandler(this.frmCapacity_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCapacity_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.chtGrafico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chtGrafico;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.DataGridView dgvCapacity;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnGerarCapacity;
    }
}