namespace Arhivarius
{
    partial class frmFindDocument
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edtDocumentType = new System.Windows.Forms.ComboBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.toolStripPanel = new System.Windows.Forms.ToolStrip();
            this.tsBtnFind = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.edtDocumentNum = new System.Windows.Forms.TextBox();
            this.toolStripPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "№ документа:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(4, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип документа:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtDocumentType
            // 
            this.edtDocumentType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtDocumentType.FormattingEnabled = true;
            this.edtDocumentType.Location = new System.Drawing.Point(96, 28);
            this.edtDocumentType.Name = "edtDocumentType";
            this.edtDocumentType.Size = new System.Drawing.Size(324, 21);
            this.edtDocumentType.TabIndex = 3;
            this.edtDocumentType.SelectedIndexChanged += new System.EventHandler(this.edtDocumentType_SelectedIndexChanged);
            this.edtDocumentType.TextUpdate += new System.EventHandler(this.edtDocumentType_TextUpdate);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 100);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(429, 257);
            this.webBrowser1.TabIndex = 4;
            // 
            // toolStripPanel
            // 
            this.toolStripPanel.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnFind,
            this.tsBtnCancel});
            this.toolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.toolStripPanel.Name = "toolStripPanel";
            this.toolStripPanel.Size = new System.Drawing.Size(429, 31);
            this.toolStripPanel.TabIndex = 26;
            this.toolStripPanel.Text = "toolStrip1";
            // 
            // tsBtnFind
            // 
            this.tsBtnFind.CheckOnClick = true;
            this.tsBtnFind.Image = global::Arhivarius.Properties.Resources.UnCheck;
            this.tsBtnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnFind.Name = "tsBtnFind";
            this.tsBtnFind.Size = new System.Drawing.Size(117, 28);
            this.tsBtnFind.Text = "Исп. как поиск";
            this.tsBtnFind.CheckedChanged += new System.EventHandler(this.tsBtnFind_CheckedChanged);
            // 
            // tsBtnCancel
            // 
            this.tsBtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnCancel.Image = global::Arhivarius.Properties.Resources.Stop;
            this.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCancel.Name = "tsBtnCancel";
            this.tsBtnCancel.Size = new System.Drawing.Size(126, 28);
            this.tsBtnCancel.Text = "Отмена/закрыть";
            this.tsBtnCancel.Click += new System.EventHandler(this.tsBtnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 69);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск документа";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.edtDocumentType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.edtDocumentNum, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(423, 50);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // edtDocumentNum
            // 
            this.edtDocumentNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtDocumentNum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.edtDocumentNum.Location = new System.Drawing.Point(96, 3);
            this.edtDocumentNum.Name = "edtDocumentNum";
            this.edtDocumentNum.Size = new System.Drawing.Size(324, 20);
            this.edtDocumentNum.TabIndex = 1;
            this.edtDocumentNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtDocumentNum_KeyDown);
            this.edtDocumentNum.Leave += new System.EventHandler(this.edtDocumentNum_Leave);
            // 
            // frmFindDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 357);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStripPanel);
            this.Name = "frmFindDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор документа";
            this.toolStripPanel.ResumeLayout(false);
            this.toolStripPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox edtDocumentType;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStrip toolStripPanel;
        private System.Windows.Forms.ToolStripButton tsBtnFind;
        private System.Windows.Forms.ToolStripButton tsBtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox edtDocumentNum;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}