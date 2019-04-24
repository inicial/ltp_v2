using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Master32
{
    partial class frmUpdate
    {
        private IContainer components = null;
        private Label lblProcess;
        private ProgressBar progressBar1;
        private Timer CopyTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CopyTimer = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProcess = new System.Windows.Forms.Label();
            this.lbl_Holiday = new System.Windows.Forms.Label();
            this.BreakTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CopyTimer
            // 
            this.CopyTimer.Tick += new System.EventHandler(this.CopyTimer_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(138, 90);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(250, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // lblProcess
            // 
            this.lblProcess.BackColor = System.Drawing.Color.Transparent;
            this.lblProcess.ForeColor = System.Drawing.Color.White;
            this.lblProcess.Location = new System.Drawing.Point(137, 58);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(251, 27);
            this.lblProcess.TabIndex = 1;
            this.lblProcess.Text = "lblProcess";
            // 
            // lbl_Holiday
            // 
            this.lbl_Holiday.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Holiday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Holiday.ForeColor = System.Drawing.Color.White;
            this.lbl_Holiday.Location = new System.Drawing.Point(138, 127);
            this.lbl_Holiday.Name = "lbl_Holiday";
            this.lbl_Holiday.Size = new System.Drawing.Size(250, 48);
            this.lbl_Holiday.TabIndex = 2;
            this.lbl_Holiday.Text = "label1";
            this.lbl_Holiday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BreakTimer
            // 
            this.BreakTimer.Interval = 1500;
            this.BreakTimer.Tick += new System.EventHandler(this.BreakTimer_Tick);
            // 
            // frmUpdate
            // 
            this.BackgroundImage = global::Master32.Properties.Resources.BackGround;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.lbl_Holiday);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Master Tour";
            this.ResumeLayout(false);

        }

        private Label lbl_Holiday;
        private Timer BreakTimer;
    }
}
