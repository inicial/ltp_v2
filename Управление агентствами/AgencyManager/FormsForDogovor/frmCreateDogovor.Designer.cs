namespace AgencyManager.FormsForDogovor
{
    partial class frmCreateDogovor
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
            this.tsBtnCreate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cblDogovorType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.edtDateEnd = new System.Windows.Forms.DateTimePicker();
            this.edtDateBeg = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnCreate,
            this.tsBtnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(573, 31);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnCreate
            // 
            this.tsBtnCreate.Image = global::AgencyManager.Properties.Resources.Apply_Check;
            this.tsBtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCreate.Name = "tsBtnCreate";
            this.tsBtnCreate.Size = new System.Drawing.Size(78, 28);
            this.tsBtnCreate.Text = "Создать";
            this.tsBtnCreate.Click += new System.EventHandler(this.tsBtnCreate_Click);
            // 
            // tsBtnCancel
            // 
            this.tsBtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnCancel.Image = global::AgencyManager.Properties.Resources.Stop;
            this.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCancel.Name = "tsBtnCancel";
            this.tsBtnCancel.Size = new System.Drawing.Size(81, 28);
            this.tsBtnCancel.Text = "Закрыть";
            this.tsBtnCancel.Click += new System.EventHandler(this.tsBtnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Тип договора:";
            // 
            // cblDogovorType
            // 
            this.cblDogovorType.FormattingEnabled = true;
            this.cblDogovorType.Location = new System.Drawing.Point(115, 3);
            this.cblDogovorType.Name = "cblDogovorType";
            this.cblDogovorType.Size = new System.Drawing.Size(284, 21);
            this.cblDogovorType.TabIndex = 6;
            this.cblDogovorType.SelectedIndexChanged += new System.EventHandler(this.cblDogovorType_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.edtDateEnd);
            this.panel1.Controls.Add(this.edtDateBeg);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cblDogovorType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 66);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Дата начала действия:";
            // 
            // edtDateEnd
            // 
            this.edtDateEnd.Location = new System.Drawing.Point(440, 30);
            this.edtDateEnd.Name = "edtDateEnd";
            this.edtDateEnd.Size = new System.Drawing.Size(121, 20);
            this.edtDateEnd.TabIndex = 17;
            this.edtDateEnd.ValueChanged += new System.EventHandler(this.edtDateEnd_ValueChanged);
            // 
            // edtDateBeg
            // 
            this.edtDateBeg.Location = new System.Drawing.Point(156, 30);
            this.edtDateBeg.Name = "edtDateBeg";
            this.edtDateBeg.Size = new System.Drawing.Size(123, 20);
            this.edtDateBeg.TabIndex = 16;
            this.edtDateBeg.ValueChanged += new System.EventHandler(this.edtDateBeg_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Дата завершения действия:";
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 172);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Доступные договора";
            // 
            // frmCreateDogovor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 269);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmCreateDogovor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание договоров для:";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCreateDogovor_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnCreate;
        private System.Windows.Forms.ToolStripButton tsBtnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cblDogovorType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker edtDateEnd;
        private System.Windows.Forms.DateTimePicker edtDateBeg;
        private System.Windows.Forms.Label label3;
    }
}