namespace AccreditationCards
{
    partial class frmActivate
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
            this.edtCurierName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clbCardForActivation = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edtFindCardNum = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО Курьера";
            // 
            // edtCurierName
            // 
            this.edtCurierName.Location = new System.Drawing.Point(100, 49);
            this.edtCurierName.Name = "edtCurierName";
            this.edtCurierName.Size = new System.Drawing.Size(279, 20);
            this.edtCurierName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Список доступных для активации АКК";
            // 
            // clbCardForActivation
            // 
            this.clbCardForActivation.CheckOnClick = true;
            this.clbCardForActivation.FormattingEnabled = true;
            this.clbCardForActivation.Location = new System.Drawing.Point(21, 103);
            this.clbCardForActivation.Name = "clbCardForActivation";
            this.clbCardForActivation.Size = new System.Drawing.Size(357, 139);
            this.clbCardForActivation.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Штрих код";
            // 
            // edtFindCardNum
            // 
            this.edtFindCardNum.Location = new System.Drawing.Point(95, 253);
            this.edtFindCardNum.Name = "edtFindCardNum";
            this.edtFindCardNum.Size = new System.Drawing.Size(239, 20);
            this.edtFindCardNum.TabIndex = 5;
            this.edtFindCardNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtFindCardNum_KeyUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSave,
            this.tsBtnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(408, 31);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.Image = global::AccreditationCards.Properties.Resources.Check;
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(90, 28);
            this.tsBtnSave.Text = "Сохранить";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // tsBtnCancel
            // 
            this.tsBtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnCancel.Image = global::AccreditationCards.Properties.Resources.Stop;
            this.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCancel.Name = "tsBtnCancel";
            this.tsBtnCancel.Size = new System.Drawing.Size(73, 28);
            this.tsBtnCancel.Text = "Отмена";
            this.tsBtnCancel.Click += new System.EventHandler(this.tsBtnCancel_Click);
            // 
            // frmActivate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 282);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.edtFindCardNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clbCardForActivation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtCurierName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmActivate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выдача АКК";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edtCurierName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbCardForActivation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtFindCardNum;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.ToolStripButton tsBtnCancel;
    }
}