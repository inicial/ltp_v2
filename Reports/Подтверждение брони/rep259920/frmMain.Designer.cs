namespace rep259920
{
    partial class frmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAnyErrors = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.lblBronNum = new System.Windows.Forms.Label();
            this.lblPaymentInfo = new System.Windows.Forms.Label();
            this.lblTourDate = new System.Windows.Forms.Label();
            this.lblPPaymentDate = new System.Windows.Forms.Label();
            this.lblPricePayed = new System.Windows.Forms.Label();
            this.lblPPaymentInfo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlForms = new System.Windows.Forms.Panel();
            this.pnlSubmit = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.gpInsurances = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.gpVoucher = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.gpRep99011 = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlForms.SuspendLayout();
            this.pnlSubmit.SuspendLayout();
            this.gpInsurances.SuspendLayout();
            this.gpVoucher.SuspendLayout();
            this.gpRep99011.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lblAnyErrors);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(749, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация по договору";
            // 
            // lblAnyErrors
            // 
            this.lblAnyErrors.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAnyErrors.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblAnyErrors.ForeColor = System.Drawing.Color.Red;
            this.lblAnyErrors.Location = new System.Drawing.Point(3, 97);
            this.lblAnyErrors.Name = "lblAnyErrors";
            this.lblAnyErrors.Size = new System.Drawing.Size(668, 33);
            this.lblAnyErrors.TabIndex = 11;
            this.lblAnyErrors.Text = "...";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblPaymentDate);
            this.panel1.Controls.Add(this.lblBronNum);
            this.panel1.Controls.Add(this.lblPaymentInfo);
            this.panel1.Controls.Add(this.lblTourDate);
            this.panel1.Controls.Add(this.lblPPaymentDate);
            this.panel1.Controls.Add(this.lblPricePayed);
            this.panel1.Controls.Add(this.lblPPaymentInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 81);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "№ Брони:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата тура:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Стоимость/оплата:";
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaymentDate.ForeColor = System.Drawing.Color.Navy;
            this.lblPaymentDate.Location = new System.Drawing.Point(312, 60);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(19, 14);
            this.lblPaymentDate.TabIndex = 10;
            this.lblPaymentDate.Text = "...";
            // 
            // lblBronNum
            // 
            this.lblBronNum.AutoSize = true;
            this.lblBronNum.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBronNum.ForeColor = System.Drawing.Color.Navy;
            this.lblBronNum.Location = new System.Drawing.Point(55, 8);
            this.lblBronNum.Name = "lblBronNum";
            this.lblBronNum.Size = new System.Drawing.Size(19, 14);
            this.lblBronNum.TabIndex = 3;
            this.lblBronNum.Text = "...";
            // 
            // lblPaymentInfo
            // 
            this.lblPaymentInfo.AutoSize = true;
            this.lblPaymentInfo.Location = new System.Drawing.Point(191, 61);
            this.lblPaymentInfo.Name = "lblPaymentInfo";
            this.lblPaymentInfo.Size = new System.Drawing.Size(115, 13);
            this.lblPaymentInfo.TabIndex = 9;
            this.lblPaymentInfo.Text = "Дата полной оплаты:";
            // 
            // lblTourDate
            // 
            this.lblTourDate.AutoSize = true;
            this.lblTourDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTourDate.ForeColor = System.Drawing.Color.Navy;
            this.lblTourDate.Location = new System.Drawing.Point(203, 8);
            this.lblTourDate.Name = "lblTourDate";
            this.lblTourDate.Size = new System.Drawing.Size(19, 14);
            this.lblTourDate.TabIndex = 4;
            this.lblTourDate.Text = "...";
            // 
            // lblPPaymentDate
            // 
            this.lblPPaymentDate.AutoSize = true;
            this.lblPPaymentDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblPPaymentDate.ForeColor = System.Drawing.Color.Navy;
            this.lblPPaymentDate.Location = new System.Drawing.Point(104, 59);
            this.lblPPaymentDate.Name = "lblPPaymentDate";
            this.lblPPaymentDate.Size = new System.Drawing.Size(19, 14);
            this.lblPPaymentDate.TabIndex = 8;
            this.lblPPaymentDate.Text = "...";
            // 
            // lblPricePayed
            // 
            this.lblPricePayed.AutoSize = true;
            this.lblPricePayed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblPricePayed.ForeColor = System.Drawing.Color.Navy;
            this.lblPricePayed.Location = new System.Drawing.Point(104, 34);
            this.lblPricePayed.Name = "lblPricePayed";
            this.lblPricePayed.Size = new System.Drawing.Size(19, 14);
            this.lblPricePayed.TabIndex = 5;
            this.lblPricePayed.Text = "...";
            // 
            // lblPPaymentInfo
            // 
            this.lblPPaymentInfo.AutoSize = true;
            this.lblPPaymentInfo.Location = new System.Drawing.Point(3, 61);
            this.lblPPaymentInfo.Name = "lblPPaymentInfo";
            this.lblPPaymentInfo.Size = new System.Drawing.Size(100, 13);
            this.lblPPaymentInfo.TabIndex = 7;
            this.lblPPaymentInfo.Text = "Дата предоплаты:";
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(671, 16);
            this.btnCancel.MaximumSize = new System.Drawing.Size(75, 23);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlForms
            // 
            this.pnlForms.AutoScroll = true;
            this.pnlForms.Controls.Add(this.pnlSubmit);
            this.pnlForms.Controls.Add(this.gpInsurances);
            this.pnlForms.Controls.Add(this.gpVoucher);
            this.pnlForms.Controls.Add(this.gpRep99011);
            this.pnlForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForms.Location = new System.Drawing.Point(0, 133);
            this.pnlForms.Name = "pnlForms";
            this.pnlForms.Size = new System.Drawing.Size(749, 314);
            this.pnlForms.TabIndex = 2;
            // 
            // pnlSubmit
            // 
            this.pnlSubmit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSubmit.Controls.Add(this.btnSubmit);
            this.pnlSubmit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubmit.Location = new System.Drawing.Point(0, 595);
            this.pnlSubmit.Name = "pnlSubmit";
            this.pnlSubmit.Size = new System.Drawing.Size(732, 40);
            this.pnlSubmit.TabIndex = 2;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubmit.Location = new System.Drawing.Point(0, 0);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(127, 38);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Подтверждение тура";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // gpInsurances
            // 
            this.gpInsurances.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpInsurances.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpInsurances.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gpInsurances.FullView = true;
            this.gpInsurances.Location = new System.Drawing.Point(0, 405);
            this.gpInsurances.Name = "gpInsurances";
            // 
            // gpInsurances.PnlContainer
            // 
            this.gpInsurances.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpInsurances.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.gpInsurances.PnlContainer.Name = "PnlContainer";
            this.gpInsurances.PnlContainer.Size = new System.Drawing.Size(730, 167);
            this.gpInsurances.PnlContainer.TabIndex = 1;
            this.gpInsurances.Size = new System.Drawing.Size(732, 190);
            this.gpInsurances.TabIndex = 0;
            this.gpInsurances.TabStop = false;
            this.gpInsurances.TextHeader = "Страховки";
            // 
            // gpVoucher
            // 
            this.gpVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpVoucher.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpVoucher.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gpVoucher.FullView = true;
            this.gpVoucher.Location = new System.Drawing.Point(0, 190);
            this.gpVoucher.Name = "gpVoucher";
            // 
            // gpVoucher.PnlContainer
            // 
            this.gpVoucher.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpVoucher.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.gpVoucher.PnlContainer.Name = "PnlContainer";
            this.gpVoucher.PnlContainer.Size = new System.Drawing.Size(730, 192);
            this.gpVoucher.PnlContainer.TabIndex = 1;
            this.gpVoucher.Size = new System.Drawing.Size(732, 215);
            this.gpVoucher.TabIndex = 1;
            this.gpVoucher.TabStop = false;
            this.gpVoucher.TextHeader = "Ваучеры";
            // 
            // gpRep99011
            // 
            this.gpRep99011.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpRep99011.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpRep99011.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gpRep99011.FullView = true;
            this.gpRep99011.Location = new System.Drawing.Point(0, 0);
            this.gpRep99011.Name = "gpRep99011";
            // 
            // gpRep99011.PnlContainer
            // 
            this.gpRep99011.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpRep99011.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.gpRep99011.PnlContainer.Name = "PnlContainer";
            this.gpRep99011.PnlContainer.Size = new System.Drawing.Size(730, 167);
            this.gpRep99011.PnlContainer.TabIndex = 1;
            this.gpRep99011.Size = new System.Drawing.Size(732, 190);
            this.gpRep99011.TabIndex = 3;
            this.gpRep99011.TabStop = false;
            this.gpRep99011.TextHeader = "Программы тура";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 447);
            this.Controls.Add(this.pnlForms);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.Text = "Подтверждение тура";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlForms.ResumeLayout(false);
            this.pnlSubmit.ResumeLayout(false);
            this.gpInsurances.ResumeLayout(false);
            this.gpVoucher.ResumeLayout(false);
            this.gpRep99011.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPricePayed;
        private System.Windows.Forms.Label lblTourDate;
        private System.Windows.Forms.Label lblBronNum;
        private System.Windows.Forms.Panel pnlForms;
        private ltp_v2.Controls.Forms.lwGroupContainer gpInsurances;
        private System.Windows.Forms.Panel pnlSubmit;
        private System.Windows.Forms.Button btnSubmit;
        private ltp_v2.Controls.Forms.lwGroupContainer gpVoucher;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblPaymentInfo;
        private System.Windows.Forms.Label lblPPaymentDate;
        private System.Windows.Forms.Label lblPPaymentInfo;
        private System.Windows.Forms.Label lblAnyErrors;
        private System.Windows.Forms.Panel panel1;
        private ltp_v2.Controls.Forms.lwGroupContainer gpRep99011;
    }
}

