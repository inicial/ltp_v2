namespace AgencyManager.FormsForDogovor
{
    partial class frmSigningDogovors
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnActivate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.EdtComment = new System.Windows.Forms.TextBox();
            this.edtDogovorNum = new ltp_v2.Controls.Forms.lwTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.wbPrtInfo = new System.Windows.Forms.WebBrowser();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnActivate,
            this.tsBtnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(504, 31);
            this.toolStrip1.TabIndex = 21;
            // 
            // tsBtnActivate
            // 
            this.tsBtnActivate.Enabled = false;
            this.tsBtnActivate.Image = global::AgencyManager.Properties.Resources.Apply_Check;
            this.tsBtnActivate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnActivate.Name = "tsBtnActivate";
            this.tsBtnActivate.Size = new System.Drawing.Size(121, 28);
            this.tsBtnActivate.Text = "Регестрировать";
            this.tsBtnActivate.Click += new System.EventHandler(this.tsBtnActivate_Click);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 78);
            this.panel1.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.EdtComment, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.edtDogovorNum, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(504, 78);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(75, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 53);
            this.label4.TabIndex = 12;
            this.label4.Text = "Комментарий:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EdtComment
            // 
            this.EdtComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EdtComment.Location = new System.Drawing.Point(161, 28);
            this.EdtComment.Multiline = true;
            this.EdtComment.Name = "EdtComment";
            this.EdtComment.Size = new System.Drawing.Size(340, 47);
            this.EdtComment.TabIndex = 13;
            this.EdtComment.TextChanged += new System.EventHandler(this.EdtComment_TextChanged);
            // 
            // edtDogovorNum
            // 
            this.edtDogovorNum.BackColor = System.Drawing.SystemColors.Window;
            this.edtDogovorNum.ChangeBackGroundColor = System.Drawing.SystemColors.Window;
            this.edtDogovorNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtDogovorNum.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.edtDogovorNum.ErrorProvider = null;
            this.edtDogovorNum.Location = new System.Drawing.Point(161, 3);
            this.edtDogovorNum.MessageInformationError = "Обязательное поле при активации";
            this.edtDogovorNum.Name = "edtDogovorNum";
            this.edtDogovorNum.RegexVerify = "(\\s*\\S+\\s*)+";
            this.edtDogovorNum.Size = new System.Drawing.Size(340, 20);
            this.edtDogovorNum.TabIndex = 9;
            this.edtDogovorNum.VerifyMaxLength = -1;
            this.edtDogovorNum.TextChanged += new System.EventHandler(this.edtDogovorNum_TextChanged);
            this.edtDogovorNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtDogovorNum_KeyDown);
            this.edtDogovorNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtDogovorNum_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(84, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "№ Договора";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 213);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация о выбранном договоре";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.wbPrtInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 194);
            this.panel2.TabIndex = 0;
            // 
            // wbPrtInfo
            // 
            this.wbPrtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbPrtInfo.Location = new System.Drawing.Point(0, 0);
            this.wbPrtInfo.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPrtInfo.Name = "wbPrtInfo";
            this.wbPrtInfo.Size = new System.Drawing.Size(498, 194);
            this.wbPrtInfo.TabIndex = 2;
            // 
            // frmSigningDogovors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 322);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmSigningDogovors";
            this.Text = "Подписание договоров";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnActivate;
        private System.Windows.Forms.ToolStripButton tsBtnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private ltp_v2.Controls.Forms.lwTextBox edtDogovorNum;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EdtComment;
        private System.Windows.Forms.WebBrowser wbPrtInfo;
    }
}