namespace rep6043
{
    partial class frmListAnnuledInsurances
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
            this.edtRTB = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edtFtlCreateDateFrom = new System.Windows.Forms.DateTimePicker();
            this.edtFtlCreateDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ResultListDGV = new System.Windows.Forms.DataGridView();
            this.btnUse = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtRTB);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(506, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 422);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация о договоре";
            // 
            // edtRTB
            // 
            this.edtRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtRTB.Location = new System.Drawing.Point(3, 16);
            this.edtRTB.Name = "edtRTB";
            this.edtRTB.Size = new System.Drawing.Size(185, 403);
            this.edtRTB.TabIndex = 0;
            this.edtRTB.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUse);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.edtFtlCreateDateTo);
            this.panel1.Controls.Add(this.edtFtlCreateDateFrom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 39);
            this.panel1.TabIndex = 1;
            // 
            // edtFtlCreateDateFrom
            // 
            this.edtFtlCreateDateFrom.CustomFormat = "dd.MM.yyyy";
            this.edtFtlCreateDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.edtFtlCreateDateFrom.Location = new System.Drawing.Point(155, 6);
            this.edtFtlCreateDateFrom.Name = "edtFtlCreateDateFrom";
            this.edtFtlCreateDateFrom.Size = new System.Drawing.Size(96, 20);
            this.edtFtlCreateDateFrom.TabIndex = 0;
            this.edtFtlCreateDateFrom.ValueChanged += new System.EventHandler(this.edtFtlCreateDateFrom_ValueChanged);
            // 
            // edtFtlCreateDateTo
            // 
            this.edtFtlCreateDateTo.CustomFormat = "dd.MM.yyyy";
            this.edtFtlCreateDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.edtFtlCreateDateTo.Location = new System.Drawing.Point(282, 6);
            this.edtFtlCreateDateTo.Name = "edtFtlCreateDateTo";
            this.edtFtlCreateDateTo.Size = new System.Drawing.Size(96, 20);
            this.edtFtlCreateDateTo.TabIndex = 1;
            this.edtFtlCreateDateTo.ValueChanged += new System.EventHandler(this.edtFtlCreateDateTo_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата создания полисов с:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "по";
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
            this.ResultListDGV.Location = new System.Drawing.Point(0, 39);
            this.ResultListDGV.Name = "ResultListDGV";
            this.ResultListDGV.ReadOnly = true;
            this.ResultListDGV.RowHeadersVisible = false;
            this.ResultListDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultListDGV.Size = new System.Drawing.Size(506, 383);
            this.ResultListDGV.TabIndex = 3;
            // 
            // btnUse
            // 
            this.btnUse.Location = new System.Drawing.Point(405, 8);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(95, 23);
            this.btnUse.TabIndex = 4;
            this.btnUse.Text = "Использовать";
            this.btnUse.UseVisualStyleBackColor = true;
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // frmListAnnuledInsurances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 422);
            this.Controls.Add(this.ResultListDGV);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmListAnnuledInsurances";
            this.Text = "Список аннулированных страховок";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox edtRTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker edtFtlCreateDateTo;
        private System.Windows.Forms.DateTimePicker edtFtlCreateDateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ResultListDGV;
        private System.Windows.Forms.Button btnUse;
    }
}