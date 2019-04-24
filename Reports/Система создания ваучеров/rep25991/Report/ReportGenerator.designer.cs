using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rep25991.Report
{
    partial class ReportGenerator
    {
        private void InitializeComponent()
        {
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCreate = new System.Windows.Forms.ToolStripButton();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(539, 327);
            this.reportViewer1.TabIndex = 0;
            // 
            // tsMenu
            // 
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnCancel,
            this.tsBtnCreate});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(539, 31);
            this.tsMenu.TabIndex = 18;
            this.tsMenu.Text = "toolStrip1";
            this.tsMenu.Visible = false;
            // 
            // tsBtnCancel
            // 
            this.tsBtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnCancel.Image = global::rep25991.Properties.Resources.Stop;
            this.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCancel.Name = "tsBtnCancel";
            this.tsBtnCancel.Size = new System.Drawing.Size(89, 28);
            this.tsBtnCancel.Text = "Отменить";
            this.tsBtnCancel.Click += new System.EventHandler(this.tsBtnCancel_Click);
            // 
            // tsBtnCreate
            // 
            this.tsBtnCreate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnCreate.Image = global::rep25991.Properties.Resources.Save2;
            this.tsBtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCreate.Name = "tsBtnCreate";
            this.tsBtnCreate.Size = new System.Drawing.Size(98, 28);
            this.tsBtnCreate.Text = "Применить";
            this.tsBtnCreate.Click += new System.EventHandler(this.tsBtnCreate_Click);
            // 
            // ReportGenerator
            // 
            this.ClientSize = new System.Drawing.Size(539, 327);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.tsMenu);
            this.Name = "ReportGenerator";
            this.Text = "Печатная форма";
            this.Load += new System.EventHandler(this.ReportGenerator_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsBtnCreate;
        private System.Windows.Forms.ToolStripButton tsBtnCancel;
    }
}
