using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ltp_v2.AccountCreator
{
    partial class Viewer
    {
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.reportViewer = new ltp_v2.Controls.Forms.lwMRViwer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.bsAccount = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer.Location = new System.Drawing.Point(0, 31);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ShowBackButton = false;
            this.reportViewer.ShowContextMenu = false;
            this.reportViewer.ShowCredentialPrompts = false;
            this.reportViewer.ShowDocumentMapButton = false;
            this.reportViewer.ShowFindControls = false;
            this.reportViewer.ShowParameterPrompts = false;
            this.reportViewer.ShowPromptAreaButton = false;
            this.reportViewer.ShowRefreshButton = false;
            this.reportViewer.ShowStopButton = false;
            this.reportViewer.ShowToolBar = false;
            this.reportViewer.Size = new System.Drawing.Size(686, 483);
            this.reportViewer.TabIndex = 0;
            this.reportViewer.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer_RenderingComplete);
            this.reportViewer.ReportError += new Microsoft.Reporting.WinForms.ReportErrorEventHandler(this.reportViewer_ReportError);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSave,
            this.tsBtnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(686, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.Image = global::ltp_v2.AccountCreator.LocalResource.Save2;
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(90, 28);
            this.tsBtnSave.Text = "Сохранить";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // tsBtnCancel
            // 
            this.tsBtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnCancel.Image = global::ltp_v2.AccountCreator.LocalResource.Stop;
            this.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCancel.Name = "tsBtnCancel";
            this.tsBtnCancel.Size = new System.Drawing.Size(133, 28);
            this.tsBtnCancel.Text = "Закрыть/Отменить";
            this.tsBtnCancel.Click += new System.EventHandler(this.tsBtnCancel_Click);
            // 
            // Viewer
            // 
            this.ClientSize = new System.Drawing.Size(686, 514);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Viewer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #region Объекты

        private ltp_v2.Controls.Forms.lwMRViwer reportViewer;
        #endregion
        private ToolStrip toolStrip1;
        private ToolStripButton tsBtnSave;
        private ToolStripButton tsBtnCancel;
        private BindingSource bsAccount;
        private System.ComponentModel.IContainer components;

    }
}
