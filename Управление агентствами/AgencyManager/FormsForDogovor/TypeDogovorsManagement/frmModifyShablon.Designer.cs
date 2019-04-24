namespace AgencyManager.FormsForDogovor.TypeDogovorsManagement
{
    partial class frmModifyShablon
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
            this.lbVariants = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddConstant = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnExport = new System.Windows.Forms.ToolStripButton();
            this.lwWordControl1 = new ltp_v2.Controls.Forms.lwWordControl();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbVariants);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAddConstant);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(651, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 587);
            this.panel1.TabIndex = 1;
            // 
            // lbVariants
            // 
            this.lbVariants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbVariants.FormattingEnabled = true;
            this.lbVariants.Location = new System.Drawing.Point(0, 28);
            this.lbVariants.Name = "lbVariants";
            this.lbVariants.Size = new System.Drawing.Size(224, 510);
            this.lbVariants.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 538);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 49);
            this.label1.TabIndex = 2;
            this.label1.Text = "В документе не рекомендуется использование # или <!-- или -->";
            // 
            // btnAddConstant
            // 
            this.btnAddConstant.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddConstant.Location = new System.Drawing.Point(0, 0);
            this.btnAddConstant.Name = "btnAddConstant";
            this.btnAddConstant.Size = new System.Drawing.Size(224, 28);
            this.btnAddConstant.TabIndex = 1;
            this.btnAddConstant.Text = "<-- Добавить";
            this.btnAddConstant.UseVisualStyleBackColor = true;
            this.btnAddConstant.Click += new System.EventHandler(this.btnAddConstant_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSave,
            this.tsBtnCancel,
            this.toolStripSeparator1,
            this.tsBtnExport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(651, 31);
            this.toolStrip1.TabIndex = 22;
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.Image = global::AgencyManager.Properties.Resources.Save2;
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(93, 28);
            this.tsBtnSave.Text = "Сохранить";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // tsBtnCancel
            // 
            this.tsBtnCancel.Image = global::AgencyManager.Properties.Resources.Stop;
            this.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCancel.Name = "tsBtnCancel";
            this.tsBtnCancel.Size = new System.Drawing.Size(77, 28);
            this.tsBtnCancel.Text = "Отмена";
            this.tsBtnCancel.Click += new System.EventHandler(this.tsBtnCancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsBtnExport
            // 
            this.tsBtnExport.Image = global::AgencyManager.Properties.Resources.Print;
            this.tsBtnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExport.Name = "tsBtnExport";
            this.tsBtnExport.Size = new System.Drawing.Size(107, 28);
            this.tsBtnExport.Text = "Печать в PDF";
            this.tsBtnExport.Click += new System.EventHandler(this.tsBtnExport_Click);
            // 
            // lwWordControl1
            // 
            this.lwWordControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwWordControl1.Location = new System.Drawing.Point(0, 31);
            this.lwWordControl1.Name = "lwWordControl1";
            this.lwWordControl1.Size = new System.Drawing.Size(651, 556);
            this.lwWordControl1.TabIndex = 23;
            // 
            // frmModifyShablon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 587);
            this.Controls.Add(this.lwWordControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "frmModifyShablon";
            this.Text = "Изменение шаблона договора";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmModifyShablon_FormClosed);
            this.Shown += new System.EventHandler(this.frmModifyShablon_Shown);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbVariants;
        private System.Windows.Forms.Button btnAddConstant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnExport;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.ToolStripButton tsBtnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ltp_v2.Controls.Forms.lwWordControl lwWordControl1;
    }
}