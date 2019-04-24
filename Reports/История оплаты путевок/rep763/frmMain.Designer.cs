namespace rep763
{
    partial class frmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPartnerList = new System.Windows.Forms.ComboBox();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtBegin = new System.Windows.Forms.DateTimePicker();
            this.cbCountryList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbUsedDGCode = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edtManualDGCodeEnter = new System.Windows.Forms.TextBox();
            this.repViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tsBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbPartnerList);
            this.panel1.Controls.Add(this.dtEnd);
            this.panel1.Controls.Add(this.dtBegin);
            this.panel1.Controls.Add(this.cbCountryList);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 34);
            this.panel1.TabIndex = 1;
            // 
            // cbPartnerList
            // 
            this.cbPartnerList.FormattingEnabled = true;
            this.cbPartnerList.Location = new System.Drawing.Point(505, 5);
            this.cbPartnerList.Name = "cbPartnerList";
            this.cbPartnerList.Size = new System.Drawing.Size(125, 21);
            this.cbPartnerList.TabIndex = 7;
            this.cbPartnerList.SelectedIndexChanged += new System.EventHandler(this.cbPartnerList_SelectedIndexChanged);
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(372, 5);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(77, 20);
            this.dtEnd.TabIndex = 6;
            this.dtEnd.ValueChanged += new System.EventHandler(this.dtEnd_ValueChanged);
            // 
            // dtBegin
            // 
            this.dtBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBegin.Location = new System.Drawing.Point(275, 5);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(77, 20);
            this.dtBegin.TabIndex = 5;
            this.dtBegin.ValueChanged += new System.EventHandler(this.dtBegin_ValueChanged);
            // 
            // cbCountryList
            // 
            this.cbCountryList.FormattingEnabled = true;
            this.cbCountryList.Location = new System.Drawing.Point(64, 5);
            this.cbCountryList.Name = "cbCountryList";
            this.cbCountryList.Size = new System.Drawing.Size(125, 21);
            this.cbCountryList.TabIndex = 4;
            this.cbCountryList.SelectedIndexChanged += new System.EventHandler(this.cbCountryList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(455, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Партнер:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(352, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "по:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(195, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата заезда с:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Страна:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbUsedDGCode);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 362);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список использующихся заездов";
            // 
            // lbUsedDGCode
            // 
            this.lbUsedDGCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUsedDGCode.FormattingEnabled = true;
            this.lbUsedDGCode.Location = new System.Drawing.Point(3, 47);
            this.lbUsedDGCode.Name = "lbUsedDGCode";
            this.lbUsedDGCode.Size = new System.Drawing.Size(209, 264);
            this.lbUsedDGCode.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnDelete,
            this.tsBtnPrint});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(209, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.Image = global::rep763.Properties.Resources.Delete;
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(79, 28);
            this.tsBtnDelete.Text = "Удалить";
            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edtManualDGCodeEnter);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 311);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 48);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ручной ввод";
            // 
            // edtManualDGCodeEnter
            // 
            this.edtManualDGCodeEnter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtManualDGCodeEnter.Location = new System.Drawing.Point(3, 16);
            this.edtManualDGCodeEnter.Name = "edtManualDGCodeEnter";
            this.edtManualDGCodeEnter.Size = new System.Drawing.Size(203, 20);
            this.edtManualDGCodeEnter.TabIndex = 0;
            this.edtManualDGCodeEnter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtManualDGCodeEnter_KeyUp);
            // 
            // repViewer
            // 
            this.repViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.repViewer.Location = new System.Drawing.Point(215, 34);
            this.repViewer.Name = "repViewer";
            this.repViewer.Size = new System.Drawing.Size(531, 362);
            this.repViewer.TabIndex = 3;
            this.repViewer.BookmarkNavigation += new Microsoft.Reporting.WinForms.BookmarkNavigationEventHandler(this.repViewer_BookmarkNavigation);
            // 
            // tsBtnPrint
            // 
            this.tsBtnPrint.Image = global::rep763.Properties.Resources.Print;
            this.tsBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrint.Name = "tsBtnPrint";
            this.tsBtnPrint.Size = new System.Drawing.Size(74, 28);
            this.tsBtnPrint.Text = "Печать";
            this.tsBtnPrint.Click += new System.EventHandler(this.tsBtnPrint_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 396);
            this.Controls.Add(this.repViewer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "История оплаты путевок ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbPartnerList;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtBegin;
        private System.Windows.Forms.ComboBox cbCountryList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbUsedDGCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox edtManualDGCodeEnter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private Microsoft.Reporting.WinForms.ReportViewer repViewer;
        private System.Windows.Forms.ToolStripButton tsBtnPrint;
    }
}

