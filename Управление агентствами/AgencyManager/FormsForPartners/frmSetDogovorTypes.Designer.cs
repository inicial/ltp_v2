namespace AgencyManager.FormsForPartners
{
    partial class frmSetDogovorTypes
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
            this.tsBtnOk = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.edt_Filter_DogovorType = new System.Windows.Forms.CheckedListBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnOk,
            this.tsBtnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 300);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(244, 31);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnOk
            // 
            this.tsBtnOk.Image = global::AgencyManager.Properties.Resources.Apply_Check;
            this.tsBtnOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOk.Name = "tsBtnOk";
            this.tsBtnOk.Size = new System.Drawing.Size(51, 28);
            this.tsBtnOk.Text = "OK";
            this.tsBtnOk.Click += new System.EventHandler(this.tsBtnOk_Click);
            // 
            // tsBtnCancel
            // 
            this.tsBtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnCancel.Image = global::AgencyManager.Properties.Resources.Stop;
            this.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCancel.Name = "tsBtnCancel";
            this.tsBtnCancel.Size = new System.Drawing.Size(77, 28);
            this.tsBtnCancel.Text = "Отмена";
            this.tsBtnCancel.Click += new System.EventHandler(this.tsBtnCancel_Click);
            // 
            // edt_Filter_DogovorType
            // 
            this.edt_Filter_DogovorType.CheckOnClick = true;
            this.edt_Filter_DogovorType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edt_Filter_DogovorType.FormattingEnabled = true;
            this.edt_Filter_DogovorType.Location = new System.Drawing.Point(0, 0);
            this.edt_Filter_DogovorType.Name = "edt_Filter_DogovorType";
            this.edt_Filter_DogovorType.Size = new System.Drawing.Size(244, 289);
            this.edt_Filter_DogovorType.TabIndex = 26;
            // 
            // frmSetDogovorTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 331);
            this.Controls.Add(this.edt_Filter_DogovorType);
            this.Controls.Add(this.toolStrip1);
            this.MaximumSize = new System.Drawing.Size(260, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(260, 38);
            this.Name = "frmSetDogovorTypes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор типов договора";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnOk;
        private System.Windows.Forms.ToolStripButton tsBtnCancel;
        private System.Windows.Forms.CheckedListBox edt_Filter_DogovorType;
    }
}