namespace AgencyManager.FormsForDogovor
{
    partial class frmPrintingEnvelopes
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.edtDogovorNum = new ltp_v2.Controls.Forms.lwTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnActivate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnClear = new System.Windows.Forms.ToolStripButton();
            this.tsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.rptPrinter = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DogovorsDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DogovorsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(609, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.edtDogovorNum, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(603, 26);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(87, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "№ договора";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtDogovorNum
            // 
            this.edtDogovorNum.BackColor = System.Drawing.SystemColors.Window;
            this.edtDogovorNum.ChangeBackGroundColor = System.Drawing.SystemColors.Window;
            this.edtDogovorNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtDogovorNum.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.edtDogovorNum.ErrorProvider = this.errorProvider1;
            this.errorProvider1.SetIconAlignment(this.edtDogovorNum, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.edtDogovorNum.Location = new System.Drawing.Point(161, 3);
            this.edtDogovorNum.MessageInformationError = "Обязательное поле при активации";
            this.edtDogovorNum.Name = "edtDogovorNum";
            this.edtDogovorNum.RegexVerify = "(\\s*\\S+\\s*)+";
            this.edtDogovorNum.Size = new System.Drawing.Size(439, 20);
            this.edtDogovorNum.TabIndex = 7;
            this.edtDogovorNum.VerifyMaxLength = -1;
            this.edtDogovorNum.TextChanged += new System.EventHandler(this.edtDogovorNum_TextChanged);
            this.edtDogovorNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtDogovorNum_KeyDown);
            this.edtDogovorNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtDogovorNum_KeyUp);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnActivate,
            this.tsBtnClear,
            this.tsBtnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(609, 31);
            this.toolStrip1.TabIndex = 20;
            // 
            // tsBtnActivate
            // 
            this.tsBtnActivate.Enabled = false;
            this.tsBtnActivate.Image = global::AgencyManager.Properties.Resources.Apply_Check;
            this.tsBtnActivate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnActivate.Name = "tsBtnActivate";
            this.tsBtnActivate.Size = new System.Drawing.Size(111, 28);
            this.tsBtnActivate.Text = "Создать пакет";
            this.tsBtnActivate.Click += new System.EventHandler(this.tsBtnActivate_Click);
            // 
            // tsBtnClear
            // 
            this.tsBtnClear.Enabled = false;
            this.tsBtnClear.Image = global::AgencyManager.Properties.Resources.Delete;
            this.tsBtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnClear.Name = "tsBtnClear";
            this.tsBtnClear.Size = new System.Drawing.Size(88, 28);
            this.tsBtnClear.Text = "Сбросить";
            this.tsBtnClear.Click += new System.EventHandler(this.tsBtnClear_Click);
            // 
            // tsBtnClose
            // 
            this.tsBtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnClose.Image = global::AgencyManager.Properties.Resources.Stop;
            this.tsBtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnClose.Name = "tsBtnClose";
            this.tsBtnClose.Size = new System.Drawing.Size(81, 28);
            this.tsBtnClose.Text = "Закрыть";
            this.tsBtnClose.Click += new System.EventHandler(this.tsBtnClose_Click);
            // 
            // rptPrinter
            // 
            this.rptPrinter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptPrinter.Location = new System.Drawing.Point(0, 73);
            this.rptPrinter.Name = "rptPrinter";
            this.rptPrinter.Size = new System.Drawing.Size(609, 358);
            this.rptPrinter.TabIndex = 21;
            this.rptPrinter.Print += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(rptPrinter_Print);
            // 
            // DogovorsDGV
            // 
            this.DogovorsDGV.AllowUserToAddRows = false;
            this.DogovorsDGV.AllowUserToDeleteRows = false;
            this.DogovorsDGV.AllowUserToResizeRows = false;
            this.DogovorsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DogovorsDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DogovorsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DogovorsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DogovorsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DogovorsDGV.Location = new System.Drawing.Point(0, 73);
            this.DogovorsDGV.Name = "DogovorsDGV";
            this.DogovorsDGV.ReadOnly = true;
            this.DogovorsDGV.RowHeadersVisible = false;
            this.DogovorsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DogovorsDGV.Size = new System.Drawing.Size(609, 358);
            this.DogovorsDGV.TabIndex = 22;
            this.DogovorsDGV.DataSourceChanged += new System.EventHandler(this.DogovorsDGV_DataSourceChanged);
            // 
            // frmPrintingEnvelopes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 431);
            this.Controls.Add(this.DogovorsDGV);
            this.Controls.Add(this.rptPrinter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmPrintingEnvelopes";
            this.Text = "Создание и печать конверта";
            this.Load += new System.EventHandler(this.frmPrintingEnvelopes_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DogovorsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ltp_v2.Controls.Forms.lwTextBox edtDogovorNum;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnActivate;
        private System.Windows.Forms.ToolStripButton tsBtnClose;
        private Microsoft.Reporting.WinForms.ReportViewer rptPrinter;
        private System.Windows.Forms.DataGridView DogovorsDGV;
        private System.Windows.Forms.ToolStripButton tsBtnClear;
    }
}