namespace NavEventos
{
    partial class frmAtividade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAtividade));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsMenuLateral = new System.Windows.Forms.ToolStrip();
            this.tsbFirst = new System.Windows.Forms.ToolStripButton();
            this.tsbPrevious = new System.Windows.Forms.ToolStripButton();
            this.tslStatus = new System.Windows.Forms.ToolStripLabel();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnDeletar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtDataCad = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSequencia = new System.Windows.Forms.TextBox();
            this.cboResponsavel = new System.Windows.Forms.ComboBox();
            this.txtEsforco = new System.Windows.Forms.TextBox();
            this.txtAtividade = new System.Windows.Forms.TextBox();
            this.cboTPEvento = new System.Windows.Forms.ComboBox();
            this.txtIdDemanda = new System.Windows.Forms.TextBox();
            this.btnTpEvento = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCadPor = new System.Windows.Forms.Label();
            this.lblSequencia = new System.Windows.Forms.Label();
            this.lblResponsavel = new System.Windows.Forms.Label();
            this.lblEsforco = new System.Windows.Forms.Label();
            this.lblAtividade = new System.Windows.Forms.Label();
            this.lblTpEvento = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtLocalizar = new System.Windows.Forms.TextBox();
            this.btnLocalizar = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tsMenuLateral.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 409);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(665, 22);
            this.statusStrip1.TabIndex = 51;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssMsg
            // 
            this.tssMsg.AutoSize = false;
            this.tssMsg.ForeColor = System.Drawing.Color.Red;
            this.tssMsg.Name = "tssMsg";
            this.tssMsg.Size = new System.Drawing.Size(650, 17);
            this.tssMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsMenuLateral
            // 
            this.tsMenuLateral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFirst,
            this.tsbPrevious,
            this.tslStatus,
            this.tsbNext,
            this.tsbLast,
            this.toolStripSeparator7,
            this.tsbtnNovo,
            this.toolStripSeparator2,
            this.tsbtnEditar,
            this.toolStripSeparator3,
            this.tsbtnCancelar,
            this.toolStripSeparator4,
            this.tsbtnDeletar,
            this.toolStripSeparator5,
            this.tsbtnSalvar,
            this.toolStripSeparator8,
            this.tsbtnRefresh,
            this.toolStripSeparator1});
            this.tsMenuLateral.Location = new System.Drawing.Point(0, 0);
            this.tsMenuLateral.Name = "tsMenuLateral";
            this.tsMenuLateral.Size = new System.Drawing.Size(665, 54);
            this.tsMenuLateral.TabIndex = 85;
            this.tsMenuLateral.Text = "toolStrip1";
            // 
            // tsbFirst
            // 
            this.tsbFirst.Image = ((System.Drawing.Image)(resources.GetObject("tsbFirst.Image")));
            this.tsbFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirst.Name = "tsbFirst";
            this.tsbFirst.Size = new System.Drawing.Size(56, 51);
            this.tsbFirst.Text = "Primeiro";
            this.tsbFirst.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbFirst.Click += new System.EventHandler(this.tsbFirst_Click);
            // 
            // tsbPrevious
            // 
            this.tsbPrevious.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrevious.Image")));
            this.tsbPrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrevious.Name = "tsbPrevious";
            this.tsbPrevious.Size = new System.Drawing.Size(54, 51);
            this.tsbPrevious.Text = "Anterior";
            this.tsbPrevious.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbPrevious.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrevious.Click += new System.EventHandler(this.tsbPrevious_Click);
            // 
            // tslStatus
            // 
            this.tslStatus.AutoSize = false;
            this.tslStatus.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(110, 50);
            this.tslStatus.Text = "10000/10000";
            // 
            // tsbNext
            // 
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(55, 51);
            this.tsbNext.Text = "Próximo";
            this.tsbNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // tsbLast
            // 
            this.tsbLast.Image = ((System.Drawing.Image)(resources.GetObject("tsbLast.Image")));
            this.tsbLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLast.Name = "tsbLast";
            this.tsbLast.Size = new System.Drawing.Size(47, 51);
            this.tsbLast.Text = "Último";
            this.tsbLast.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLast.Click += new System.EventHandler(this.tsbLast_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 54);
            // 
            // tsbtnNovo
            // 
            this.tsbtnNovo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNovo.Image")));
            this.tsbtnNovo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbtnNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNovo.Name = "tsbtnNovo";
            this.tsbtnNovo.Size = new System.Drawing.Size(40, 51);
            this.tsbtnNovo.Text = "Novo";
            this.tsbtnNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnNovo.Click += new System.EventHandler(this.tsbtnNovo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // tsbtnEditar
            // 
            this.tsbtnEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEditar.Image")));
            this.tsbtnEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbtnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEditar.Name = "tsbtnEditar";
            this.tsbtnEditar.Size = new System.Drawing.Size(41, 51);
            this.tsbtnEditar.Text = "Editar";
            this.tsbtnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnEditar.Click += new System.EventHandler(this.tsbtnEditar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 54);
            // 
            // tsbtnCancelar
            // 
            this.tsbtnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCancelar.Image")));
            this.tsbtnCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCancelar.Name = "tsbtnCancelar";
            this.tsbtnCancelar.Size = new System.Drawing.Size(57, 51);
            this.tsbtnCancelar.Text = "Cancelar";
            this.tsbtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnCancelar.Click += new System.EventHandler(this.tsbtnCancelar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 54);
            // 
            // tsbtnDeletar
            // 
            this.tsbtnDeletar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDeletar.Image")));
            this.tsbtnDeletar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbtnDeletar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnDeletar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDeletar.Name = "tsbtnDeletar";
            this.tsbtnDeletar.Size = new System.Drawing.Size(48, 51);
            this.tsbtnDeletar.Text = "Deletar";
            this.tsbtnDeletar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnDeletar.Click += new System.EventHandler(this.tsbtnDeletar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 54);
            // 
            // tsbtnSalvar
            // 
            this.tsbtnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSalvar.Image")));
            this.tsbtnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbtnSalvar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSalvar.Name = "tsbtnSalvar";
            this.tsbtnSalvar.Size = new System.Drawing.Size(42, 51);
            this.tsbtnSalvar.Text = "Salvar";
            this.tsbtnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSalvar.Click += new System.EventHandler(this.tsbtnSalvar_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 54);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefresh.Image")));
            this.tsbtnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(50, 51);
            this.tsbtnRefresh.Text = "Refresh";
            this.tsbtnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // txtDataCad
            // 
            this.txtDataCad.BackColor = System.Drawing.Color.White;
            this.txtDataCad.Enabled = false;
            this.txtDataCad.Location = new System.Drawing.Point(327, 381);
            this.txtDataCad.Name = "txtDataCad";
            this.txtDataCad.ReadOnly = true;
            this.txtDataCad.Size = new System.Drawing.Size(162, 20);
            this.txtDataCad.TabIndex = 116;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(120, 381);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(162, 20);
            this.txtUsuario.TabIndex = 114;
            // 
            // txtSequencia
            // 
            this.txtSequencia.BackColor = System.Drawing.Color.White;
            this.txtSequencia.Location = new System.Drawing.Point(120, 353);
            this.txtSequencia.Name = "txtSequencia";
            this.txtSequencia.ReadOnly = true;
            this.txtSequencia.Size = new System.Drawing.Size(48, 20);
            this.txtSequencia.TabIndex = 6;
            this.txtSequencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSequencia_KeyPress);
            // 
            // cboResponsavel
            // 
            this.cboResponsavel.BackColor = System.Drawing.Color.White;
            this.cboResponsavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResponsavel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboResponsavel.FormattingEnabled = true;
            this.cboResponsavel.Items.AddRange(new object[] {
            "Passivo",
            "Processamento",
            "Suporte"});
            this.cboResponsavel.Location = new System.Drawing.Point(120, 326);
            this.cboResponsavel.Name = "cboResponsavel";
            this.cboResponsavel.Size = new System.Drawing.Size(126, 21);
            this.cboResponsavel.TabIndex = 5;
            // 
            // txtEsforco
            // 
            this.txtEsforco.BackColor = System.Drawing.Color.White;
            this.txtEsforco.Location = new System.Drawing.Point(120, 300);
            this.txtEsforco.Name = "txtEsforco";
            this.txtEsforco.ReadOnly = true;
            this.txtEsforco.Size = new System.Drawing.Size(48, 20);
            this.txtEsforco.TabIndex = 4;
            this.txtEsforco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEsforco_KeyPress);
            // 
            // txtAtividade
            // 
            this.txtAtividade.BackColor = System.Drawing.Color.White;
            this.txtAtividade.Location = new System.Drawing.Point(120, 166);
            this.txtAtividade.Multiline = true;
            this.txtAtividade.Name = "txtAtividade";
            this.txtAtividade.ReadOnly = true;
            this.txtAtividade.Size = new System.Drawing.Size(443, 128);
            this.txtAtividade.TabIndex = 3;
            // 
            // cboTPEvento
            // 
            this.cboTPEvento.BackColor = System.Drawing.Color.White;
            this.cboTPEvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTPEvento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboTPEvento.FormattingEnabled = true;
            this.cboTPEvento.Location = new System.Drawing.Point(120, 139);
            this.cboTPEvento.Name = "cboTPEvento";
            this.cboTPEvento.Size = new System.Drawing.Size(443, 21);
            this.cboTPEvento.Sorted = true;
            this.cboTPEvento.TabIndex = 2;
            // 
            // txtIdDemanda
            // 
            this.txtIdDemanda.Location = new System.Drawing.Point(301, 227);
            this.txtIdDemanda.Name = "txtIdDemanda";
            this.txtIdDemanda.Size = new System.Drawing.Size(38, 20);
            this.txtIdDemanda.TabIndex = 117;
            // 
            // btnTpEvento
            // 
            this.btnTpEvento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTpEvento.Location = new System.Drawing.Point(569, 138);
            this.btnTpEvento.Name = "btnTpEvento";
            this.btnTpEvento.Size = new System.Drawing.Size(44, 23);
            this.btnTpEvento.TabIndex = 7;
            this.btnTpEvento.Text = "...";
            this.btnTpEvento.UseVisualStyleBackColor = true;
            this.btnTpEvento.Click += new System.EventHandler(this.btnTpEvento_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 125;
            this.label2.Text = "Data:";
            // 
            // lblCadPor
            // 
            this.lblCadPor.AutoSize = true;
            this.lblCadPor.Location = new System.Drawing.Point(21, 384);
            this.lblCadPor.Name = "lblCadPor";
            this.lblCadPor.Size = new System.Drawing.Size(83, 13);
            this.lblCadPor.TabIndex = 124;
            this.lblCadPor.Text = "Cadastrado Por:";
            // 
            // lblSequencia
            // 
            this.lblSequencia.AutoSize = true;
            this.lblSequencia.Location = new System.Drawing.Point(21, 354);
            this.lblSequencia.Name = "lblSequencia";
            this.lblSequencia.Size = new System.Drawing.Size(61, 13);
            this.lblSequencia.TabIndex = 123;
            this.lblSequencia.Text = "Sequência:";
            // 
            // lblResponsavel
            // 
            this.lblResponsavel.AutoSize = true;
            this.lblResponsavel.Location = new System.Drawing.Point(21, 327);
            this.lblResponsavel.Name = "lblResponsavel";
            this.lblResponsavel.Size = new System.Drawing.Size(72, 13);
            this.lblResponsavel.TabIndex = 122;
            this.lblResponsavel.Text = "Responsável:";
            // 
            // lblEsforco
            // 
            this.lblEsforco.AutoSize = true;
            this.lblEsforco.Location = new System.Drawing.Point(21, 301);
            this.lblEsforco.Name = "lblEsforco";
            this.lblEsforco.Size = new System.Drawing.Size(46, 13);
            this.lblEsforco.TabIndex = 121;
            this.lblEsforco.Text = "Esforço:";
            // 
            // lblAtividade
            // 
            this.lblAtividade.AutoSize = true;
            this.lblAtividade.Location = new System.Drawing.Point(21, 167);
            this.lblAtividade.Name = "lblAtividade";
            this.lblAtividade.Size = new System.Drawing.Size(54, 13);
            this.lblAtividade.TabIndex = 120;
            this.lblAtividade.Text = "Atividade:";
            // 
            // lblTpEvento
            // 
            this.lblTpEvento.AutoSize = true;
            this.lblTpEvento.Location = new System.Drawing.Point(21, 140);
            this.lblTpEvento.Name = "lblTpEvento";
            this.lblTpEvento.Size = new System.Drawing.Size(83, 13);
            this.lblTpEvento.TabIndex = 119;
            this.lblTpEvento.Text = "Tipo de Evento:";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(21, 86);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(89, 13);
            this.lblBuscar.TabIndex = 126;
            this.lblBuscar.Text = "Localizar registro:";
            // 
            // txtLocalizar
            // 
            this.txtLocalizar.Location = new System.Drawing.Point(120, 83);
            this.txtLocalizar.Name = "txtLocalizar";
            this.txtLocalizar.Size = new System.Drawing.Size(443, 20);
            this.txtLocalizar.TabIndex = 0;
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.AutoSize = true;
            this.btnLocalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocalizar.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalizar.Image")));
            this.btnLocalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLocalizar.Location = new System.Drawing.Point(569, 65);
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(48, 53);
            this.btnLocalizar.TabIndex = 1;
            this.btnLocalizar.Text = "[Enter]";
            this.btnLocalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLocalizar.UseVisualStyleBackColor = true;
            this.btnLocalizar.Click += new System.EventHandler(this.btnLocalizar_Click);
            // 
            // frmAtividade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(665, 431);
            this.Controls.Add(this.txtDataCad);
            this.Controls.Add(this.btnLocalizar);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtLocalizar);
            this.Controls.Add(this.txtSequencia);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.cboResponsavel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEsforco);
            this.Controls.Add(this.lblCadPor);
            this.Controls.Add(this.txtAtividade);
            this.Controls.Add(this.lblSequencia);
            this.Controls.Add(this.cboTPEvento);
            this.Controls.Add(this.lblResponsavel);
            this.Controls.Add(this.lblEsforco);
            this.Controls.Add(this.lblAtividade);
            this.Controls.Add(this.lblTpEvento);
            this.Controls.Add(this.btnTpEvento);
            this.Controls.Add(this.tsMenuLateral);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtIdDemanda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAtividade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atividades";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAtividade_FormClosing);
            this.Load += new System.EventHandler(this.frmAtividade_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAtividade_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tsMenuLateral.ResumeLayout(false);
            this.tsMenuLateral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenuLateral;
        private System.Windows.Forms.ToolStripButton tsbtnNovo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtnDeletar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbtnSalvar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssMsg;
        private System.Windows.Forms.TextBox txtDataCad;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSequencia;
        private System.Windows.Forms.ComboBox cboResponsavel;
        private System.Windows.Forms.TextBox txtEsforco;
        private System.Windows.Forms.TextBox txtAtividade;
        private System.Windows.Forms.ComboBox cboTPEvento;
        private System.Windows.Forms.TextBox txtIdDemanda;
        private System.Windows.Forms.Button btnTpEvento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCadPor;
        private System.Windows.Forms.Label lblSequencia;
        private System.Windows.Forms.Label lblResponsavel;
        private System.Windows.Forms.Label lblEsforco;
        private System.Windows.Forms.Label lblAtividade;
        private System.Windows.Forms.Label lblTpEvento;
        private System.Windows.Forms.ToolStripButton tsbFirst;
        private System.Windows.Forms.ToolStripButton tsbPrevious;
        private System.Windows.Forms.ToolStripLabel tslStatus;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtLocalizar;
        private System.Windows.Forms.Button btnLocalizar;
    }
}