namespace AgencyManager.FormsForDogovor
{
    partial class frmActivateDogovor
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wbPrtInfo = new System.Windows.Forms.WebBrowser();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClearComments = new System.Windows.Forms.Button();
            this.edtComment = new System.Windows.Forms.TextBox();
            this.edtDogovorNum = new ltp_v2.Controls.Forms.lwTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblComment = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DogovorsDGV = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnActivate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDelDogovor = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DogovorsDGV)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(763, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.wbPrtInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(293, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 205);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация о выбранном договоре";
            // 
            // wbPrtInfo
            // 
            this.wbPrtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbPrtInfo.Location = new System.Drawing.Point(3, 16);
            this.wbPrtInfo.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPrtInfo.Name = "wbPrtInfo";
            this.wbPrtInfo.Size = new System.Drawing.Size(461, 186);
            this.wbPrtInfo.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClearComments);
            this.panel3.Controls.Add(this.edtComment);
            this.panel3.Controls.Add(this.edtDogovorNum);
            this.panel3.Controls.Add(this.lblComment);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 205);
            this.panel3.TabIndex = 26;
            // 
            // btnClearComments
            // 
            this.btnClearComments.Location = new System.Drawing.Point(61, 155);
            this.btnClearComments.Name = "btnClearComments";
            this.btnClearComments.Size = new System.Drawing.Size(162, 36);
            this.btnClearComments.TabIndex = 12;
            this.btnClearComments.Text = "Удалить коментарии";
            this.btnClearComments.UseVisualStyleBackColor = true;
            this.btnClearComments.Click += new System.EventHandler(this.btnClearComments_Click);
            // 
            // edtComment
            // 
            this.edtComment.Location = new System.Drawing.Point(6, 54);
            this.edtComment.Multiline = true;
            this.edtComment.Name = "edtComment";
            this.edtComment.Size = new System.Drawing.Size(278, 95);
            this.edtComment.TabIndex = 4;
            this.edtComment.Visible = false;
            this.edtComment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtComment_KeyUp);
            // 
            // edtDogovorNum
            // 
            this.edtDogovorNum.BackColor = System.Drawing.SystemColors.Window;
            this.edtDogovorNum.ChangeBackGroundColor = System.Drawing.SystemColors.Window;
            this.edtDogovorNum.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.edtDogovorNum.ErrorProvider = this.errorProvider1;
            this.edtDogovorNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorProvider1.SetIconAlignment(this.edtDogovorNum, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.edtDogovorNum.Location = new System.Drawing.Point(77, 4);
            this.edtDogovorNum.MessageInformationError = "Обязательное поле при активации";
            this.edtDogovorNum.Name = "edtDogovorNum";
            this.edtDogovorNum.RegexVerify = "(\\s*\\S+\\s*)+";
            this.edtDogovorNum.Size = new System.Drawing.Size(207, 24);
            this.edtDogovorNum.TabIndex = 0;
            this.edtDogovorNum.VerifyMaxLength = -1;
            this.edtDogovorNum.TextChanged += new System.EventHandler(this.edtDogovorNum_TextChanged);
            this.edtDogovorNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtDogovorNum_KeyDown);
            this.edtDogovorNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtDogovorNum_KeyUp);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(3, 38);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(80, 13);
            this.lblComment.TabIndex = 11;
            this.lblComment.Text = "Комментарий:";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblComment.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "№ договора";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DogovorsDGV);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(763, 192);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Список выбранных договоров";
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
            this.DogovorsDGV.Location = new System.Drawing.Point(3, 16);
            this.DogovorsDGV.Name = "DogovorsDGV";
            this.DogovorsDGV.RowHeadersVisible = false;
            this.DogovorsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DogovorsDGV.ShowCellErrors = false;
            this.DogovorsDGV.ShowCellToolTips = false;
            this.DogovorsDGV.ShowRowErrors = false;
            this.DogovorsDGV.Size = new System.Drawing.Size(757, 173);
            this.DogovorsDGV.TabIndex = 23;
            this.DogovorsDGV.DataSourceChanged += new System.EventHandler(this.DogovorsDGV_DataSourceChanged);
            this.DogovorsDGV.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DogovorsDGV_CellEnter);
            this.DogovorsDGV.SelectionChanged += new System.EventHandler(this.DogovorsDGV_SelectionChanged);
            this.DogovorsDGV.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DogovorsDGV_MouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnActivate,
            this.tsBtnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(763, 31);
            this.toolStrip1.TabIndex = 1;
            // 
            // tsBtnActivate
            // 
            this.tsBtnActivate.Enabled = false;
            this.tsBtnActivate.Image = global::AgencyManager.Properties.Resources.Apply_Check;
            this.tsBtnActivate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnActivate.Name = "tsBtnActivate";
            this.tsBtnActivate.Size = new System.Drawing.Size(190, 28);
            this.tsBtnActivate.Text = "Активировать/Добавить тип";
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDelDogovor});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(194, 26);
            // 
            // tsmiDelDogovor
            // 
            this.tsmiDelDogovor.Name = "tsmiDelDogovor";
            this.tsmiDelDogovor.Size = new System.Drawing.Size(193, 22);
            this.tsmiDelDogovor.Text = "Удалить из активации";
            this.tsmiDelDogovor.Click += new System.EventHandler(this.tsmiDelDogovor_Click);
            // 
            // frmActivateDogovor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 444);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmActivateDogovor";
            this.Text = "Активация договоров";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DogovorsDGV)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ltp_v2.Controls.Forms.lwTextBox edtDogovorNum;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnActivate;
        private System.Windows.Forms.ToolStripButton tsBtnClose;
        private System.Windows.Forms.WebBrowser wbPrtInfo;
        private System.Windows.Forms.DataGridView DogovorsDGV;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelDogovor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClearComments;
        private System.Windows.Forms.TextBox edtComment;
        private System.Windows.Forms.Label lblComment;
    }
}