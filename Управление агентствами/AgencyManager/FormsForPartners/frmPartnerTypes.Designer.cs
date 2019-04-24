using System.Windows.Forms;
namespace AgencyManager.FormsForPartners
{
    partial class frmPartnerTypes
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
            this.PnlContainer = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTypePartner = new System.Windows.Forms.CheckedListBox();
            this.toolStripPanel = new System.Windows.Forms.ToolStrip();
            this.tsBtnOk = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.toolStripPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlContainer
            // 
            this.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.PnlContainer.Name = "PnlContainer";
            this.PnlContainer.Size = new System.Drawing.Size(150, 100);
            this.PnlContainer.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTypePartner);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 381);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип партнера";
            // 
            // cbTypePartner
            // 
            this.cbTypePartner.CheckOnClick = true;
            this.cbTypePartner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTypePartner.FormattingEnabled = true;
            this.cbTypePartner.Location = new System.Drawing.Point(3, 16);
            this.cbTypePartner.Name = "cbTypePartner";
            this.cbTypePartner.Size = new System.Drawing.Size(309, 349);
            this.cbTypePartner.TabIndex = 0;
            // 
            // toolStripPanel
            // 
            this.toolStripPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripPanel.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnOk,
            this.tsBtnCancel});
            this.toolStripPanel.Location = new System.Drawing.Point(0, 350);
            this.toolStripPanel.Name = "toolStripPanel";
            this.toolStripPanel.Size = new System.Drawing.Size(315, 31);
            this.toolStripPanel.TabIndex = 20;
            this.toolStripPanel.Text = "toolStrip1";
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
            // frmPartnerTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 381);
            this.Controls.Add(this.toolStripPanel);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPartnerTypes";
            this.Text = "Тип партнера";
            this.groupBox1.ResumeLayout(false);
            this.toolStripPanel.ResumeLayout(false);
            this.toolStripPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlContainer;
        private System.Windows.Forms.GroupBox groupBox1;
        private CheckedListBox cbTypePartner;
        private ToolStrip toolStripPanel;
        private ToolStripButton tsBtnOk;
        private ToolStripButton tsBtnCancel;

    }
}