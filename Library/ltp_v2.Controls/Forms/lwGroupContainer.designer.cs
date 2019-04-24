using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ltp_v2.Controls.Forms
{
    partial class lwGroupContainer
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public System.Windows.Forms.Panel PnlContainer { get { return pnlContainer; } }
        private System.Windows.Forms.PictureBox pbMinimizeButton;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label lblGBText;

        private void InitializeComponent()
        {
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.lblGBText = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pbMinimizeButton = new System.Windows.Forms.PictureBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeButton)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContainer.Location = new System.Drawing.Point(0, 23);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(148, 100);
            this.pnlContainer.TabIndex = 1;
            this.pnlContainer.DockChanged += new System.EventHandler(this.pnlContainer_DockChanged);
            // 
            // lblGBText
            // 
            this.lblGBText.BackColor = System.Drawing.Color.Transparent;
            this.lblGBText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGBText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblGBText.ForeColor = System.Drawing.Color.Black;
            this.lblGBText.Location = new System.Drawing.Point(0, 0);
            this.lblGBText.Name = "lblGBText";
            this.lblGBText.Size = new System.Drawing.Size(125, 23);
            this.lblGBText.TabIndex = 0;
            this.lblGBText.Text = "lblGBText";
            this.lblGBText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblGBText);
            this.pnlTop.Controls.Add(this.pbMinimizeButton);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.MinimumSize = new System.Drawing.Size(100, 23);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(148, 23);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTop_Paint);
            // 
            // pbMinimizeButton
            // 
            this.pbMinimizeButton.BackColor = System.Drawing.Color.Transparent;
            this.pbMinimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbMinimizeButton.Location = new System.Drawing.Point(125, 0);
            this.pbMinimizeButton.Name = "pbMinimizeButton";
            this.pbMinimizeButton.Size = new System.Drawing.Size(23, 23);
            this.pbMinimizeButton.TabIndex = 1;
            this.pbMinimizeButton.TabStop = false;
            this.pbMinimizeButton.Click += new System.EventHandler(this.pbMinimizeButton_Click);
            this.pbMinimizeButton.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMinimizeButton_Paint);
            // 
            // lwGroupContainer
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlTop);
            this.Name = "lwGroupContainer";
            this.Size = new System.Drawing.Size(148, 148);
            this.Resize += new System.EventHandler(this.lwGroupContainer_Resize);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizeButton)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
