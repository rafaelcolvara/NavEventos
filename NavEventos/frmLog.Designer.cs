namespace NavEventos
{
    partial class frmLog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLog));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Log do Sistema");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Log de Atenção");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Visualizador (Local)", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtForm = new System.Windows.Forms.TextBox();
            this.lblForm = new System.Windows.Forms.Label();
            this.txtEvento = new System.Windows.Forms.TextBox();
            this.lblEventoMetodo = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.txtUsuarioSistema = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuarioRede = new System.Windows.Forms.TextBox();
            this.lblUserRede = new System.Windows.Forms.Label();
            this.txtTerminal = new System.Windows.Forms.TextBox();
            this.lblTerminal = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tspMenuSuperior = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnFirst = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPrevious = new System.Windows.Forms.ToolStripButton();
            this.tslblStatus = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnNext = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLast = new System.Windows.Forms.ToolStripButton();
            this.btnFechar = new System.Windows.Forms.Button();
            this.trvLog = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tspMenuSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(194, 41);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(283, 38);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(351, 20);
            this.txtID.TabIndex = 1;
            // 
            // txtForm
            // 
            this.txtForm.Location = new System.Drawing.Point(283, 64);
            this.txtForm.Name = "txtForm";
            this.txtForm.ReadOnly = true;
            this.txtForm.Size = new System.Drawing.Size(351, 20);
            this.txtForm.TabIndex = 3;
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Location = new System.Drawing.Point(194, 67);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(58, 13);
            this.lblForm.TabIndex = 2;
            this.lblForm.Text = "Formulário:";
            // 
            // txtEvento
            // 
            this.txtEvento.Location = new System.Drawing.Point(283, 90);
            this.txtEvento.Name = "txtEvento";
            this.txtEvento.ReadOnly = true;
            this.txtEvento.Size = new System.Drawing.Size(351, 20);
            this.txtEvento.TabIndex = 5;
            // 
            // lblEventoMetodo
            // 
            this.lblEventoMetodo.AutoSize = true;
            this.lblEventoMetodo.Location = new System.Drawing.Point(194, 93);
            this.lblEventoMetodo.Name = "lblEventoMetodo";
            this.lblEventoMetodo.Size = new System.Drawing.Size(85, 13);
            this.lblEventoMetodo.TabIndex = 4;
            this.lblEventoMetodo.Text = "Evento/Método:";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(283, 116);
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = new System.Drawing.Size(139, 20);
            this.txtData.TabIndex = 7;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(194, 119);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(33, 13);
            this.lblData.TabIndex = 6;
            this.lblData.Text = "Data:";
            // 
            // txtUsuarioSistema
            // 
            this.txtUsuarioSistema.Location = new System.Drawing.Point(495, 116);
            this.txtUsuarioSistema.Name = "txtUsuarioSistema";
            this.txtUsuarioSistema.ReadOnly = true;
            this.txtUsuarioSistema.Size = new System.Drawing.Size(139, 20);
            this.txtUsuarioSistema.TabIndex = 9;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(432, 119);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 8;
            this.lblUsuario.Text = "Usuário:";
            // 
            // txtUsuarioRede
            // 
            this.txtUsuarioRede.Location = new System.Drawing.Point(283, 142);
            this.txtUsuarioRede.Name = "txtUsuarioRede";
            this.txtUsuarioRede.ReadOnly = true;
            this.txtUsuarioRede.Size = new System.Drawing.Size(139, 20);
            this.txtUsuarioRede.TabIndex = 11;
            // 
            // lblUserRede
            // 
            this.lblUserRede.AutoSize = true;
            this.lblUserRede.Location = new System.Drawing.Point(194, 145);
            this.lblUserRede.Name = "lblUserRede";
            this.lblUserRede.Size = new System.Drawing.Size(75, 13);
            this.lblUserRede.TabIndex = 10;
            this.lblUserRede.Text = "Usuário Rede:";
            // 
            // txtTerminal
            // 
            this.txtTerminal.Location = new System.Drawing.Point(495, 142);
            this.txtTerminal.Name = "txtTerminal";
            this.txtTerminal.ReadOnly = true;
            this.txtTerminal.Size = new System.Drawing.Size(139, 20);
            this.txtTerminal.TabIndex = 13;
            // 
            // lblTerminal
            // 
            this.lblTerminal.AutoSize = true;
            this.lblTerminal.Location = new System.Drawing.Point(432, 145);
            this.lblTerminal.Name = "lblTerminal";
            this.lblTerminal.Size = new System.Drawing.Size(50, 13);
            this.lblTerminal.TabIndex = 12;
            this.lblTerminal.Text = "Terminal:";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(283, 168);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(351, 119);
            this.txtLog.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Log:";
            // 
            // tspMenuSuperior
            // 
            this.tspMenuSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsbtnFirst,
            this.tsbtnPrevious,
            this.tslblStatus,
            this.tsbtnNext,
            this.tsbtnLast});
            this.tspMenuSuperior.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tspMenuSuperior.Location = new System.Drawing.Point(0, 0);
            this.tspMenuSuperior.Name = "tspMenuSuperior";
            this.tspMenuSuperior.Size = new System.Drawing.Size(639, 25);
            this.tspMenuSuperior.TabIndex = 16;
            this.tspMenuSuperior.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(190, 22);
            // 
            // tsbtnFirst
            // 
            this.tsbtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFirst.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFirst.Image")));
            this.tsbtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFirst.Name = "tsbtnFirst";
            this.tsbtnFirst.Size = new System.Drawing.Size(23, 22);
            this.tsbtnFirst.Text = "Primeiro";
            this.tsbtnFirst.Click += new System.EventHandler(this.tsbtnFirst_Click);
            // 
            // tsbtnPrevious
            // 
            this.tsbtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPrevious.Image")));
            this.tsbtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPrevious.Name = "tsbtnPrevious";
            this.tsbtnPrevious.Size = new System.Drawing.Size(23, 22);
            this.tsbtnPrevious.Text = "Anterior";
            this.tsbtnPrevious.Click += new System.EventHandler(this.tsbtnPrevious_Click);
            // 
            // tslblStatus
            // 
            this.tslblStatus.AutoSize = false;
            this.tslblStatus.Name = "tslblStatus";
            this.tslblStatus.Size = new System.Drawing.Size(100, 22);
            this.tslblStatus.Text = "0/0";
            // 
            // tsbtnNext
            // 
            this.tsbtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNext.Image")));
            this.tsbtnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNext.Name = "tsbtnNext";
            this.tsbtnNext.Size = new System.Drawing.Size(23, 22);
            this.tsbtnNext.Text = "Próximo";
            this.tsbtnNext.Click += new System.EventHandler(this.tsbtnNext_Click);
            // 
            // tsbtnLast
            // 
            this.tsbtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLast.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLast.Image")));
            this.tsbtnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLast.Name = "tsbtnLast";
            this.tsbtnLast.Size = new System.Drawing.Size(23, 22);
            this.tsbtnLast.Text = "Último";
            this.tsbtnLast.Click += new System.EventHandler(this.tsbtnLast_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Location = new System.Drawing.Point(559, 293);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 17;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // trvLog
            // 
            this.trvLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trvLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvLog.ImageIndex = 0;
            this.trvLog.ImageList = this.imageList1;
            this.trvLog.Location = new System.Drawing.Point(0, 0);
            this.trvLog.Name = "trvLog";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "Node1";
            treeNode1.SelectedImageKey = "Meu Computador.ico";
            treeNode1.Text = "Log do Sistema";
            treeNode2.ImageIndex = 2;
            treeNode2.Name = "Node3";
            treeNode2.SelectedImageKey = "ActionCenter_2.ico";
            treeNode2.Text = "Log de Atenção";
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "Node0";
            treeNode3.Text = "Visualizador (Local)";
            this.trvLog.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.trvLog.SelectedImageIndex = 0;
            this.trvLog.Size = new System.Drawing.Size(187, 311);
            this.trvLog.TabIndex = 18;
            this.trvLog.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvLog_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "VIEWER4.ICO");
            this.imageList1.Images.SetKeyName(1, "Meu Computador.ico");
            this.imageList1.Images.SetKeyName(2, "ActionCenter_2.ico");
            // 
            // frmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(639, 321);
            this.Controls.Add(this.trvLog);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.tspMenuSuperior);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTerminal);
            this.Controls.Add(this.lblTerminal);
            this.Controls.Add(this.txtUsuarioRede);
            this.Controls.Add(this.lblUserRede);
            this.Controls.Add(this.txtUsuarioSistema);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.txtEvento);
            this.Controls.Add(this.lblEventoMetodo);
            this.Controls.Add(this.txtForm);
            this.Controls.Add(this.lblForm);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLog_FormClosing);
            this.Load += new System.EventHandler(this.frmLog_Load);
            this.tspMenuSuperior.ResumeLayout(false);
            this.tspMenuSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtForm;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.TextBox txtEvento;
        private System.Windows.Forms.Label lblEventoMetodo;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.TextBox txtUsuarioSistema;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuarioRede;
        private System.Windows.Forms.Label lblUserRede;
        private System.Windows.Forms.TextBox txtTerminal;
        private System.Windows.Forms.Label lblTerminal;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip tspMenuSuperior;
        private System.Windows.Forms.ToolStripButton tsbtnFirst;
        private System.Windows.Forms.ToolStripButton tsbtnPrevious;
        private System.Windows.Forms.ToolStripLabel tslblStatus;
        private System.Windows.Forms.ToolStripButton tsbtnNext;
        private System.Windows.Forms.ToolStripButton tsbtnLast;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.TreeView trvLog;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}