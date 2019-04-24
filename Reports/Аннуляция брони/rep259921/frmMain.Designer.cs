namespace rep259921
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPricePayed = new System.Windows.Forms.Label();
            this.lblTourDate = new System.Windows.Forms.Label();
            this.lblBronNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edtAnnulReasons = new System.Windows.Forms.ComboBox();
            this.pnlForms = new System.Windows.Forms.Panel();
            this.gpInsurances = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.ResultListDGV = new System.Windows.Forms.DataGridView();
            this.gpVoucher = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.gpServices = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.ServicesDGV = new ltp_v2.Controls.Forms.lwDataGridView();
            this.pnlSubmit = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.pnlForms.SuspendLayout();
            this.gpInsurances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).BeginInit();
            this.gpVoucher.SuspendLayout();
            this.gpServices.PnlContainer.SuspendLayout();
            this.gpServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDGV)).BeginInit();
            this.pnlSubmit.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.lblPricePayed);
            this.groupBox1.Controls.Add(this.lblTourDate);
            this.groupBox1.Controls.Add(this.lblBronNum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 75);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация по договору";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Location = new System.Drawing.Point(478, 16);
            this.btnRefresh.MaximumSize = new System.Drawing.Size(150, 23);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(0, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 23);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Перезагрузить данные";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.InitializeDataValues);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(628, 16);
            this.btnCancel.MaximumSize = new System.Drawing.Size(75, 23);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPricePayed
            // 
            this.lblPricePayed.AutoSize = true;
            this.lblPricePayed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblPricePayed.ForeColor = System.Drawing.Color.Navy;
            this.lblPricePayed.Location = new System.Drawing.Point(107, 49);
            this.lblPricePayed.Name = "lblPricePayed";
            this.lblPricePayed.Size = new System.Drawing.Size(19, 14);
            this.lblPricePayed.TabIndex = 5;
            this.lblPricePayed.Text = "...";
            // 
            // lblTourDate
            // 
            this.lblTourDate.AutoSize = true;
            this.lblTourDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTourDate.ForeColor = System.Drawing.Color.Navy;
            this.lblTourDate.Location = new System.Drawing.Point(206, 23);
            this.lblTourDate.Name = "lblTourDate";
            this.lblTourDate.Size = new System.Drawing.Size(19, 14);
            this.lblTourDate.TabIndex = 4;
            this.lblTourDate.Text = "...";
            // 
            // lblBronNum
            // 
            this.lblBronNum.AutoSize = true;
            this.lblBronNum.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBronNum.ForeColor = System.Drawing.Color.Navy;
            this.lblBronNum.Location = new System.Drawing.Point(58, 23);
            this.lblBronNum.Name = "lblBronNum";
            this.lblBronNum.Size = new System.Drawing.Size(19, 14);
            this.lblBronNum.TabIndex = 3;
            this.lblBronNum.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Стоимость/оплата:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата тура:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "№ Брони:";
            // 
            // edtAnnulReasons
            // 
            this.edtAnnulReasons.FormattingEnabled = true;
            this.edtAnnulReasons.Location = new System.Drawing.Point(192, 4);
            this.edtAnnulReasons.Name = "edtAnnulReasons";
            this.edtAnnulReasons.Size = new System.Drawing.Size(338, 21);
            this.edtAnnulReasons.TabIndex = 9;
            // 
            // pnlForms
            // 
            this.pnlForms.AutoScroll = true;
            this.pnlForms.Controls.Add(this.gpInsurances);
            this.pnlForms.Controls.Add(this.ResultListDGV);
            this.pnlForms.Controls.Add(this.gpVoucher);
            this.pnlForms.Controls.Add(this.gpServices);
            this.pnlForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForms.Location = new System.Drawing.Point(0, 128);
            this.pnlForms.Name = "pnlForms";
            this.pnlForms.Size = new System.Drawing.Size(706, 430);
            this.pnlForms.TabIndex = 3;
            // 
            // gpInsurances
            // 
            this.gpInsurances.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpInsurances.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpInsurances.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gpInsurances.FullView = true;
            this.gpInsurances.Location = new System.Drawing.Point(0, 592);
            this.gpInsurances.Name = "gpInsurances";
            // 
            // gpInsurances.PnlContainer
            // 
            this.gpInsurances.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpInsurances.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.gpInsurances.PnlContainer.Name = "PnlContainer";
            this.gpInsurances.PnlContainer.Size = new System.Drawing.Size(687, 167);
            this.gpInsurances.PnlContainer.TabIndex = 1;
            this.gpInsurances.PnlContainer.VisibleChanged += new System.EventHandler(this.PnlContainer_VisibleChanged);
            this.gpInsurances.Size = new System.Drawing.Size(689, 190);
            this.gpInsurances.TabIndex = 0;
            this.gpInsurances.TabStop = false;
            this.gpInsurances.TextHeader = "Страховки";
            // 
            // ResultListDGV
            // 
            this.ResultListDGV.AllowUserToAddRows = false;
            this.ResultListDGV.AllowUserToDeleteRows = false;
            this.ResultListDGV.AllowUserToOrderColumns = true;
            this.ResultListDGV.AllowUserToResizeRows = false;
            this.ResultListDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ResultListDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ResultListDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ResultListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultListDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultListDGV.Location = new System.Drawing.Point(0, 592);
            this.ResultListDGV.Name = "ResultListDGV";
            this.ResultListDGV.RowHeadersVisible = false;
            this.ResultListDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultListDGV.Size = new System.Drawing.Size(689, 190);
            this.ResultListDGV.TabIndex = 17;
            // 
            // gpVoucher
            // 
            this.gpVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpVoucher.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpVoucher.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gpVoucher.FullView = true;
            this.gpVoucher.Location = new System.Drawing.Point(0, 377);
            this.gpVoucher.Name = "gpVoucher";
            // 
            // gpVoucher.PnlContainer
            // 
            this.gpVoucher.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpVoucher.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.gpVoucher.PnlContainer.Name = "PnlContainer";
            this.gpVoucher.PnlContainer.Size = new System.Drawing.Size(687, 192);
            this.gpVoucher.PnlContainer.TabIndex = 1;
            this.gpVoucher.PnlContainer.VisibleChanged += new System.EventHandler(this.PnlContainer_VisibleChanged);
            this.gpVoucher.Size = new System.Drawing.Size(689, 215);
            this.gpVoucher.TabIndex = 1;
            this.gpVoucher.TabStop = false;
            this.gpVoucher.TextHeader = "Ваучеры";
            // 
            // gpServices
            // 
            this.gpServices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpServices.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gpServices.FullView = true;
            this.gpServices.Location = new System.Drawing.Point(0, 0);
            this.gpServices.MinimumSize = new System.Drawing.Size(2, 377);
            this.gpServices.Name = "gpServices";
            // 
            // gpServices.PnlContainer
            // 
            this.gpServices.PnlContainer.Controls.Add(this.ServicesDGV);
            this.gpServices.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpServices.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.gpServices.PnlContainer.Name = "PnlContainer";
            this.gpServices.PnlContainer.Size = new System.Drawing.Size(687, 354);
            this.gpServices.PnlContainer.TabIndex = 1;
            this.gpServices.Size = new System.Drawing.Size(689, 377);
            this.gpServices.TabIndex = 16;
            this.gpServices.TabStop = false;
            this.gpServices.TextHeader = "Услуги тура";
            // 
            // ServicesDGV
            // 
            this.ServicesDGV.AllowUserToAddRows = false;
            this.ServicesDGV.AllowUserToDeleteRows = false;
            this.ServicesDGV.AllowUserToOrderColumns = true;
            this.ServicesDGV.AllowUserToResizeRows = false;
            this.ServicesDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ServicesDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ServicesDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServicesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServicesDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServicesDGV.Location = new System.Drawing.Point(0, 0);
            this.ServicesDGV.Name = "ServicesDGV";
            this.ServicesDGV.RowHeadersVisible = false;
            this.ServicesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ServicesDGV.Size = new System.Drawing.Size(687, 354);
            this.ServicesDGV.TabIndex = 16;
            this.ServicesDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ServicesDGV_CellEndEdit);
            this.ServicesDGV.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ServicesDGV_CellMouseUp);
            this.ServicesDGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ServicesDGV_CellValidating);
            this.ServicesDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ServicesDGV_DataBindingComplete);
            // 
            // pnlSubmit
            // 
            this.pnlSubmit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSubmit.Controls.Add(this.edtAnnulReasons);
            this.pnlSubmit.Controls.Add(this.label4);
            this.pnlSubmit.Controls.Add(this.btnSubmit);
            this.pnlSubmit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSubmit.Location = new System.Drawing.Point(0, 558);
            this.pnlSubmit.Name = "pnlSubmit";
            this.pnlSubmit.Size = new System.Drawing.Size(706, 54);
            this.pnlSubmit.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Причина аннуляции:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubmit.Location = new System.Drawing.Point(577, 0);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(127, 52);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Аннуляция тура";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblError);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(706, 53);
            this.panel2.TabIndex = 19;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblError.Location = new System.Drawing.Point(0, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(706, 53);
            this.lblError.TabIndex = 0;
            this.lblError.Text = "label6";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 612);
            this.Controls.Add(this.pnlForms);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlSubmit);
            this.MinimumSize = new System.Drawing.Size(722, 650);
            this.Name = "frmMain";
            this.Text = "Аннуляция брони";
            this.Load += new System.EventHandler(this.InitializeDataValues);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlForms.ResumeLayout(false);
            this.gpInsurances.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).EndInit();
            this.gpVoucher.ResumeLayout(false);
            this.gpServices.PnlContainer.ResumeLayout(false);
            this.gpServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDGV)).EndInit();
            this.pnlSubmit.ResumeLayout(false);
            this.pnlSubmit.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPricePayed;
        private System.Windows.Forms.Label lblTourDate;
        private System.Windows.Forms.Label lblBronNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlForms;
        private System.Windows.Forms.Panel pnlSubmit;
        private System.Windows.Forms.Button btnSubmit;
        private ltp_v2.Controls.Forms.lwGroupContainer gpInsurances;
        private ltp_v2.Controls.Forms.lwGroupContainer gpVoucher;
        private System.Windows.Forms.DataGridView ResultListDGV;
        private ltp_v2.Controls.Forms.lwGroupContainer gpServices;
        private ltp_v2.Controls.Forms.lwDataGridView ServicesDGV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox edtAnnulReasons;
        private System.Windows.Forms.Label label4;
    }
}