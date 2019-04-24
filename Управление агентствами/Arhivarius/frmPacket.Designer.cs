namespace Arhivarius
{
    partial class frmPacket
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
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tsBtnNewFind = new System.Windows.Forms.ToolStripButton();
            this.tsBtnNewArh = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tsBtnInfo = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEject = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtLastManager = new System.Windows.Forms.TextBox();
            this.edtStatus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearchArh = new System.Windows.Forms.Button();
            this.edtPacketNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edtDocumentType = new System.Windows.Forms.ComboBox();
            this.edtComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ObjectsInPacketDGV = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblLegendDelete = new System.Windows.Forms.Label();
            this.lblLegendNew = new System.Windows.Forms.Label();
            this.lblLegendActive = new System.Windows.Forms.Label();
            this.toolStripDocument = new System.Windows.Forms.ToolStrip();
            this.tsBtnAddDocument = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsBtnArhive = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectsInPacketDGV)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.toolStripDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNewFind,
            this.tsBtnNewArh,
            this.tsBtnSave,
            this.tsBtnCancel,
            this.tsBtnInfo,
            this.tsBtnEject,
            this.tsBtnArhive,
            this.tsBtnPrint});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(732, 31);
            this.toolStripMain.TabIndex = 27;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // tsBtnNewFind
            // 
            this.tsBtnNewFind.Image = global::Arhivarius.Properties.Resources.Search;
            this.tsBtnNewFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNewFind.Name = "tsBtnNewFind";
            this.tsBtnNewFind.Size = new System.Drawing.Size(100, 28);
            this.tsBtnNewFind.Text = "Новый поиск";
            this.tsBtnNewFind.Click += new System.EventHandler(this.tsBtnNewFind_Click);
            // 
            // tsBtnNewArh
            // 
            this.tsBtnNewArh.Image = global::Arhivarius.Properties.Resources.Add;
            this.tsBtnNewArh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNewArh.Name = "tsBtnNewArh";
            this.tsBtnNewArh.Size = new System.Drawing.Size(111, 28);
            this.tsBtnNewArh.Text = "Создать архив";
            this.tsBtnNewArh.Click += new System.EventHandler(this.tsBtnNewArh_Click);
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.Image = global::Arhivarius.Properties.Resources.Save2;
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(90, 28);
            this.tsBtnSave.Text = "Сохранить";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // tsBtnCancel
            // 
            this.tsBtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnCancel.Image = global::Arhivarius.Properties.Resources.Stop;
            this.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCancel.Name = "tsBtnCancel";
            this.tsBtnCancel.Size = new System.Drawing.Size(120, 28);
            this.tsBtnCancel.Text = "Отмена/закрыть";
            this.tsBtnCancel.Click += new System.EventHandler(this.tsBtnCancel_Click);
            // 
            // tsBtnInfo
            // 
            this.tsBtnInfo.Image = global::Arhivarius.Properties.Resources.Info;
            this.tsBtnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnInfo.Name = "tsBtnInfo";
            this.tsBtnInfo.Size = new System.Drawing.Size(98, 28);
            this.tsBtnInfo.Text = "Информация";
            this.tsBtnInfo.Click += new System.EventHandler(this.tsBtnInfo_Click);
            // 
            // tsBtnEject
            // 
            this.tsBtnEject.Image = global::Arhivarius.Properties.Resources.Login;
            this.tsBtnEject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEject.Name = "tsBtnEject";
            this.tsBtnEject.Size = new System.Drawing.Size(72, 28);
            this.tsBtnEject.Text = "Изъять";
            this.tsBtnEject.Click += new System.EventHandler(this.tsBtnEject_Click);
            // 
            // tsBtnPrint
            // 
            this.tsBtnPrint.Image = global::Arhivarius.Properties.Resources.Print;
            this.tsBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrint.Name = "tsBtnPrint";
            this.tsBtnPrint.Size = new System.Drawing.Size(72, 28);
            this.tsBtnPrint.Text = "Печать";
            this.tsBtnPrint.Click += new System.EventHandler(this.tsBtnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Пакет №:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtLastManager);
            this.groupBox1.Controls.Add(this.edtStatus);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSearchArh);
            this.groupBox1.Controls.Add(this.edtPacketNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.edtDocumentType);
            this.groupBox1.Controls.Add(this.edtComment);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 160);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные по пакету";
            // 
            // edtLastManager
            // 
            this.edtLastManager.BackColor = System.Drawing.SystemColors.Window;
            this.edtLastManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtLastManager.Location = new System.Drawing.Point(433, 46);
            this.edtLastManager.Name = "edtLastManager";
            this.edtLastManager.ReadOnly = true;
            this.edtLastManager.Size = new System.Drawing.Size(288, 20);
            this.edtLastManager.TabIndex = 39;
            // 
            // edtStatus
            // 
            this.edtStatus.BackColor = System.Drawing.SystemColors.Window;
            this.edtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtStatus.Location = new System.Drawing.Point(433, 19);
            this.edtStatus.Name = "edtStatus";
            this.edtStatus.ReadOnly = true;
            this.edtStatus.Size = new System.Drawing.Size(288, 20);
            this.edtStatus.TabIndex = 38;
            this.edtStatus.DoubleClick += new System.EventHandler(this.edtStatus_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(306, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Последний менеджер:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Место нахождения:";
            // 
            // btnSearchArh
            // 
            this.btnSearchArh.Location = new System.Drawing.Point(265, 19);
            this.btnSearchArh.Name = "btnSearchArh";
            this.btnSearchArh.Size = new System.Drawing.Size(24, 20);
            this.btnSearchArh.TabIndex = 35;
            this.btnSearchArh.Text = "...";
            this.btnSearchArh.UseVisualStyleBackColor = true;
            this.btnSearchArh.Click += new System.EventHandler(this.btnSearchArh_Click);
            // 
            // edtPacketNumber
            // 
            this.edtPacketNumber.Location = new System.Drawing.Point(77, 19);
            this.edtPacketNumber.Name = "edtPacketNumber";
            this.edtPacketNumber.Size = new System.Drawing.Size(182, 20);
            this.edtPacketNumber.TabIndex = 34;
            this.edtPacketNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtPacketNumber_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Тип:";
            // 
            // edtDocumentType
            // 
            this.edtDocumentType.FormattingEnabled = true;
            this.edtDocumentType.Location = new System.Drawing.Point(77, 45);
            this.edtDocumentType.Name = "edtDocumentType";
            this.edtDocumentType.Size = new System.Drawing.Size(212, 21);
            this.edtDocumentType.TabIndex = 33;
            this.edtDocumentType.SelectedIndexChanged += new System.EventHandler(this.edtDocumentType_SelectedIndexChanged);
            this.edtDocumentType.TextUpdate += new System.EventHandler(this.edtDocumentType_TextUpdate);
            // 
            // edtComment
            // 
            this.edtComment.Location = new System.Drawing.Point(77, 71);
            this.edtComment.Multiline = true;
            this.edtComment.Name = "edtComment";
            this.edtComment.Size = new System.Drawing.Size(644, 75);
            this.edtComment.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Описание:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ObjectsInPacketDGV);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.toolStripDocument);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(732, 292);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Список документов в пакете";
            // 
            // ObjectsInPacketDGV
            // 
            this.ObjectsInPacketDGV.AllowUserToAddRows = false;
            this.ObjectsInPacketDGV.AllowUserToDeleteRows = false;
            this.ObjectsInPacketDGV.AllowUserToOrderColumns = true;
            this.ObjectsInPacketDGV.AllowUserToResizeRows = false;
            this.ObjectsInPacketDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ObjectsInPacketDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ObjectsInPacketDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ObjectsInPacketDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ObjectsInPacketDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectsInPacketDGV.Location = new System.Drawing.Point(3, 47);
            this.ObjectsInPacketDGV.Name = "ObjectsInPacketDGV";
            this.ObjectsInPacketDGV.ReadOnly = true;
            this.ObjectsInPacketDGV.RowHeadersVisible = false;
            this.ObjectsInPacketDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ObjectsInPacketDGV.Size = new System.Drawing.Size(582, 242);
            this.ObjectsInPacketDGV.TabIndex = 15;
            this.ObjectsInPacketDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ObjectsInPacketDGV_CellDoubleClick);
            this.ObjectsInPacketDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ObjectsInPacketDGV_DataBindingComplete);
            this.ObjectsInPacketDGV.DataSourceChanged += new System.EventHandler(this.ObjectsInPacketDGV_DataSourceChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblLegendDelete);
            this.groupBox3.Controls.Add(this.lblLegendNew);
            this.groupBox3.Controls.Add(this.lblLegendActive);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(585, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 242);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Легенда";
            // 
            // lblLegendDelete
            // 
            this.lblLegendDelete.BackColor = System.Drawing.SystemColors.Window;
            this.lblLegendDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegendDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegendDelete.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblLegendDelete.Location = new System.Drawing.Point(3, 42);
            this.lblLegendDelete.Name = "lblLegendDelete";
            this.lblLegendDelete.Size = new System.Drawing.Size(138, 13);
            this.lblLegendDelete.TabIndex = 3;
            this.lblLegendDelete.Text = "Помечен на удаление";
            // 
            // lblLegendNew
            // 
            this.lblLegendNew.BackColor = System.Drawing.SystemColors.Window;
            this.lblLegendNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegendNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegendNew.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblLegendNew.Location = new System.Drawing.Point(3, 29);
            this.lblLegendNew.Name = "lblLegendNew";
            this.lblLegendNew.Size = new System.Drawing.Size(138, 13);
            this.lblLegendNew.TabIndex = 2;
            this.lblLegendNew.Text = "Новый несохранен";
            // 
            // lblLegendActive
            // 
            this.lblLegendActive.BackColor = System.Drawing.SystemColors.Window;
            this.lblLegendActive.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegendActive.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblLegendActive.Location = new System.Drawing.Point(3, 16);
            this.lblLegendActive.Name = "lblLegendActive";
            this.lblLegendActive.Size = new System.Drawing.Size(138, 13);
            this.lblLegendActive.TabIndex = 1;
            this.lblLegendActive.Text = "Сохранен";
            // 
            // toolStripDocument
            // 
            this.toolStripDocument.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripDocument.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAddDocument,
            this.tsBtnDelete});
            this.toolStripDocument.Location = new System.Drawing.Point(3, 16);
            this.toolStripDocument.Name = "toolStripDocument";
            this.toolStripDocument.Size = new System.Drawing.Size(726, 31);
            this.toolStripDocument.TabIndex = 28;
            this.toolStripDocument.Text = "toolStrip1";
            // 
            // tsBtnAddDocument
            // 
            this.tsBtnAddDocument.Image = global::Arhivarius.Properties.Resources.Apply_Check;
            this.tsBtnAddDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddDocument.Name = "tsBtnAddDocument";
            this.tsBtnAddDocument.Size = new System.Drawing.Size(160, 28);
            this.tsBtnAddDocument.Text = "Присоединить документ";
            this.tsBtnAddDocument.Click += new System.EventHandler(this.tsBtnAddDocument_Click);
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.Image = global::Arhivarius.Properties.Resources.Delete;
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(79, 28);
            this.tsBtnDelete.Text = "Удалить";
            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // tsBtnArhive
            // 
            this.tsBtnArhive.Image = global::Arhivarius.Properties.Resources.Logout;
            this.tsBtnArhive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnArhive.Name = "tsBtnArhive";
            this.tsBtnArhive.Size = new System.Drawing.Size(108, 28);
            this.tsBtnArhive.Text = "Архивировать";
            this.tsBtnArhive.Click += new System.EventHandler(this.tsBtnArhive_Click);
            // 
            // frmPacket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 483);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStripMain);
            this.MinimumSize = new System.Drawing.Size(740, 510);
            this.Name = "frmPacket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Сбор пакета документов";
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectsInPacketDGV)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.toolStripDocument.ResumeLayout(false);
            this.toolStripDocument.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton tsBtnCancel;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox edtComment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStripDocument;
        private System.Windows.Forms.ToolStripButton tsBtnAddDocument;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.DataGridView ObjectsInPacketDGV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox edtDocumentType;
        private System.Windows.Forms.TextBox edtPacketNumber;
        private System.Windows.Forms.ToolStripButton tsBtnNewArh;
        private System.Windows.Forms.Button btnSearchArh;
        private System.Windows.Forms.ToolStripButton tsBtnNewFind;
        private System.Windows.Forms.ToolStripButton tsBtnInfo;
        private System.Windows.Forms.ToolStripButton tsBtnEject;
        private System.Windows.Forms.TextBox edtStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edtLastManager;
        private System.Windows.Forms.ToolStripButton tsBtnPrint;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblLegendNew;
        private System.Windows.Forms.Label lblLegendActive;
        private System.Windows.Forms.Label lblLegendDelete;
        private System.Windows.Forms.ToolStripButton tsBtnArhive;
    }
}