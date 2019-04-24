using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ltp_v2.Controls.DialogFroms.Dialogs
{
    partial class frmDateTime
    {
        public Label lblInfo;
        private Button btnCancel;
        public DateTimePicker edtDateTime;
        private Button btnOK;

        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.edtDateTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(44, 100);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(23, 30);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 13);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "lblInfo";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(162, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // edtDateTime
            // 
            this.edtDateTime.Location = new System.Drawing.Point(26, 58);
            this.edtDateTime.Name = "edtDateTime";
            this.edtDateTime.Size = new System.Drawing.Size(225, 20);
            this.edtDateTime.TabIndex = 3;
            this.edtDateTime.ValueChanged += new System.EventHandler(this.edtDateTime_ValueChanged);
            // 
            // frmDateTime
            // 
            this.ClientSize = new System.Drawing.Size(281, 153);
            this.Controls.Add(this.edtDateTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDateTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
