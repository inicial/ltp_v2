namespace AgencyManager.FormsForDogovor
{
    partial class frmSendToCourier
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DogovorsDGV = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.edtPacketNum = new ltp_v2.Controls.Forms.lwTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnActivate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DogovorsDGV)).BeginInit();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DogovorsDGV);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(566, 346);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Список выбранных пакетов";
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
            this.DogovorsDGV.Size = new System.Drawing.Size(560, 327);
            this.DogovorsDGV.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.edtPacketNum);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(566, 52);
            this.panel3.TabIndex = 28;
            // 
            // edtDogovorNum
            // 
            this.edtPacketNum.BackColor = System.Drawing.SystemColors.Window;
            this.edtPacketNum.ChangeBackGroundColor = System.Drawing.SystemColors.Window;
            this.edtPacketNum.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.edtPacketNum.ErrorProvider = null;
            this.edtPacketNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edtPacketNum.Location = new System.Drawing.Point(85, 12);
            this.edtPacketNum.MessageInformationError = "Обязательное поле при активации";
            this.edtPacketNum.Name = "edtDogovorNum";
            this.edtPacketNum.RegexVerify = "(\\s*\\S+\\s*)+";
            this.edtPacketNum.Size = new System.Drawing.Size(207, 24);
            this.edtPacketNum.TabIndex = 0;
            this.edtPacketNum.VerifyMaxLength = -1;
            this.edtPacketNum.TextChanged += new System.EventHandler(this.edtDogovorNum_TextChanged);
            this.edtPacketNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtDogovorNum_KeyDown);
            this.edtPacketNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtDogovorNum_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "№ Пакета";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnActivate,
            this.tsBtnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(566, 31);
            this.toolStrip1.TabIndex = 30;
            // 
            // tsBtnActivate
            // 
            this.tsBtnActivate.Enabled = false;
            this.tsBtnActivate.Image = global::AgencyManager.Properties.Resources.Apply_Check;
            this.tsBtnActivate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnActivate.Name = "tsBtnActivate";
            this.tsBtnActivate.Size = new System.Drawing.Size(86, 28);
            this.tsBtnActivate.Text = "Передать";
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
            // frmSendToCourier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 429);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmSendToCourier";
            this.Text = "Передача пакетов в курьерскую";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DogovorsDGV)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DogovorsDGV;
        private System.Windows.Forms.Panel panel3;
        private ltp_v2.Controls.Forms.lwTextBox edtPacketNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnActivate;
        private System.Windows.Forms.ToolStripButton tsBtnClose;
    }
}