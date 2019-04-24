namespace AgencyManager.FormsForAccounts
{
    partial class frmBanks
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.edtBIK = new ltp_v2.Controls.Forms.lwTextBox();
            this.edtKS = new ltp_v2.Controls.Forms.lwTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.edtBankName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BanksDGV = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.edtFltBankName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnUse = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.edtFindBIK = new ltp_v2.Controls.Forms.lwTextBox();
            this.edtFindKS = new ltp_v2.Controls.Forms.lwTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.edtFindBankName = new ltp_v2.Controls.Forms.lwTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BanksDGV)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.edtBIK, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.edtKS, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.edtBankName, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(339, 84);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // edtBIK
            // 
            this.edtBIK.BackColor = System.Drawing.SystemColors.Window;
            this.edtBIK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtBIK.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.edtBIK.ErrorProvider = null;
            this.edtBIK.Location = new System.Drawing.Point(123, 57);
            this.edtBIK.MessageInformationError = "";
            this.edtBIK.Name = "edtBIK";
            this.edtBIK.ReadOnly = true;
            this.edtBIK.RegexVerify = "";
            this.edtBIK.Size = new System.Drawing.Size(213, 20);
            this.edtBIK.TabIndex = 4;
            this.edtBIK.VerifyMaxLength = -1;
            // 
            // edtKS
            // 
            this.edtKS.BackColor = System.Drawing.SystemColors.Window;
            this.edtKS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtKS.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.edtKS.ErrorProvider = null;
            this.edtKS.Location = new System.Drawing.Point(123, 30);
            this.edtKS.MessageInformationError = "";
            this.edtKS.Name = "edtKS";
            this.edtKS.ReadOnly = true;
            this.edtKS.RegexVerify = "";
            this.edtKS.Size = new System.Drawing.Size(213, 20);
            this.edtKS.TabIndex = 4;
            this.edtKS.VerifyMaxLength = -1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(24, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название банка:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(60, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Кор. счет:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(85, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 30);
            this.label6.TabIndex = 5;
            this.label6.Text = "БИК:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtBankName
            // 
            this.edtBankName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtBankName.Location = new System.Drawing.Point(123, 3);
            this.edtBankName.Name = "edtBankName";
            this.edtBankName.ReadOnly = true;
            this.edtBankName.Size = new System.Drawing.Size(213, 20);
            this.edtBankName.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BanksDGV);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 356);
            this.panel1.TabIndex = 2;
            // 
            // BanksDGV
            // 
            this.BanksDGV.AllowUserToAddRows = false;
            this.BanksDGV.AllowUserToDeleteRows = false;
            this.BanksDGV.AllowUserToOrderColumns = true;
            this.BanksDGV.AllowUserToResizeColumns = false;
            this.BanksDGV.AllowUserToResizeRows = false;
            this.BanksDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BanksDGV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.BanksDGV.ColumnHeadersVisible = false;
            this.BanksDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BanksDGV.Location = new System.Drawing.Point(0, 35);
            this.BanksDGV.Name = "BanksDGV";
            this.BanksDGV.RowHeadersVisible = false;
            this.BanksDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BanksDGV.Size = new System.Drawing.Size(273, 321);
            this.BanksDGV.TabIndex = 1;
            this.BanksDGV.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBanks_RowEnter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.edtFltBankName);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 35);
            this.panel2.TabIndex = 2;
            // 
            // edtFltBankName
            // 
            this.edtFltBankName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.edtFltBankName.Location = new System.Drawing.Point(0, 15);
            this.edtFltBankName.Name = "edtFltBankName";
            this.edtFltBankName.Size = new System.Drawing.Size(273, 20);
            this.edtFltBankName.TabIndex = 1;
            this.edtFltBankName.TextChanged += new System.EventHandler(this.edtFltBankName_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Фильтр по названию банка";
            // 
            // btnUse
            // 
            this.btnUse.Location = new System.Drawing.Point(358, 309);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(94, 23);
            this.btnUse.TabIndex = 5;
            this.btnUse.Text = "Использовать";
            this.btnUse.UseVisualStyleBackColor = true;
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(458, 309);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(273, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 103);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные по выбранному банку";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCreate);
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(273, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 129);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные по искомому банку/Создание банка";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(185, 100);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(154, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Создать/Использовать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.edtFindBIK, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.edtFindKS, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.edtFindBankName, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(339, 78);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // edtFindBIK
            // 
            this.edtFindBIK.BackColor = System.Drawing.SystemColors.Window;
            this.edtFindBIK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtFindBIK.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.edtFindBIK.ErrorProvider = null;
            this.edtFindBIK.Location = new System.Drawing.Point(123, 53);
            this.edtFindBIK.MessageInformationError = "";
            this.edtFindBIK.Name = "edtFindBIK";
            this.edtFindBIK.RegexVerify = "[0-9]*";
            this.edtFindBIK.Size = new System.Drawing.Size(213, 20);
            this.edtFindBIK.TabIndex = 10;
            this.edtFindBIK.VerifyMaxLength = -1;
            // 
            // edtFindKS
            // 
            this.edtFindKS.BackColor = System.Drawing.SystemColors.Window;
            this.edtFindKS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtFindKS.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.edtFindKS.ErrorProvider = null;
            this.edtFindKS.Location = new System.Drawing.Point(123, 28);
            this.edtFindKS.MessageInformationError = "";
            this.edtFindKS.Name = "edtFindKS";
            this.edtFindKS.RegexVerify = "[0-9]*";
            this.edtFindKS.Size = new System.Drawing.Size(213, 20);
            this.edtFindKS.TabIndex = 9;
            this.edtFindKS.VerifyMaxLength = -1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(24, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Название банка:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(60, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Кор. счет:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Location = new System.Drawing.Point(85, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 28);
            this.label5.TabIndex = 5;
            this.label5.Text = "БИК:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtFindBankName
            // 
            this.edtFindBankName.BackColor = System.Drawing.SystemColors.Window;
            this.edtFindBankName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtFindBankName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
            this.edtFindBankName.ErrorProvider = null;
            this.edtFindBankName.Location = new System.Drawing.Point(123, 3);
            this.edtFindBankName.MessageInformationError = "";
            this.edtFindBankName.Name = "edtFindBankName";
            this.edtFindBankName.RegexVerify = "";
            this.edtFindBankName.Size = new System.Drawing.Size(213, 20);
            this.edtFindBankName.TabIndex = 7;
            this.edtFindBankName.VerifyMaxLength = -1;
            // 
            // frmBanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 356);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUse);
            this.Controls.Add(this.panel1);
            this.Name = "frmBanks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Банки";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BanksDGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edtBankName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView BanksDGV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox edtFltBankName;
        private System.Windows.Forms.Label label8;
        private ltp_v2.Controls.Forms.lwTextBox edtBIK;
        private ltp_v2.Controls.Forms.lwTextBox edtKS;
        private System.Windows.Forms.Button btnUse;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ltp_v2.Controls.Forms.lwTextBox edtFindBankName;
        private ltp_v2.Controls.Forms.lwTextBox edtFindBIK;
        private ltp_v2.Controls.Forms.lwTextBox edtFindKS;
        private System.Windows.Forms.Button btnCreate;
    }
}