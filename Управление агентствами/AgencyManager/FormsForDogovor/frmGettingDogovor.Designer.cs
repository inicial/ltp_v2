namespace AgencyManager.FormsForDogovor
{
    partial class frmGettingDogovor
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
            this.label1 = new System.Windows.Forms.Label();
            this.edtFindingDogovor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edtGetType = new System.Windows.Forms.ComboBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtCountCopy = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ResultListDGV = new System.Windows.Forms.DataGridView();
            this.tsBtnDelDog = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtCountCopy)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(34, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "№ Договора";
            // 
            // edtFindingDogovor
            // 
            this.edtFindingDogovor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edtFindingDogovor.Location = new System.Drawing.Point(146, 76);
            this.edtFindingDogovor.Name = "edtFindingDogovor";
            this.edtFindingDogovor.Size = new System.Drawing.Size(293, 26);
            this.edtFindingDogovor.TabIndex = 1;
            this.edtFindingDogovor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtFindingDogovor_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип получения:";
            // 
            // edtGetType
            // 
            this.edtGetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edtGetType.FormattingEnabled = true;
            this.edtGetType.Items.AddRange(new object[] {
            "Почта",
            "Почта возврат",
            "Курьер компании",
            "Отказ по причине не полного договора"});
            this.edtGetType.Location = new System.Drawing.Point(146, 19);
            this.edtGetType.Name = "edtGetType";
            this.edtGetType.Size = new System.Drawing.Size(293, 21);
            this.edtGetType.TabIndex = 3;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(105, 367);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(128, 25);
            this.btnGet.TabIndex = 4;
            this.btnGet.Text = "Принять договор(а)";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtCountCopy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.edtGetType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.edtFindingDogovor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 129);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // edtCountCopy
            // 
            this.edtCountCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edtCountCopy.Location = new System.Drawing.Point(146, 49);
            this.edtCountCopy.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.edtCountCopy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edtCountCopy.Name = "edtCountCopy";
            this.edtCountCopy.ReadOnly = true;
            this.edtCountCopy.Size = new System.Drawing.Size(120, 22);
            this.edtCountCopy.TabIndex = 5;
            this.edtCountCopy.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Кол-во копий:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ResultListDGV);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(491, 215);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Список принимаемых договоров";
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
            this.ResultListDGV.Location = new System.Drawing.Point(3, 16);
            this.ResultListDGV.Name = "ResultListDGV";
            this.ResultListDGV.ReadOnly = true;
            this.ResultListDGV.RowHeadersVisible = false;
            this.ResultListDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultListDGV.Size = new System.Drawing.Size(485, 196);
            this.ResultListDGV.TabIndex = 3;
            // 
            // tsBtnDelDog
            // 
            this.tsBtnDelDog.Location = new System.Drawing.Point(248, 367);
            this.tsBtnDelDog.Name = "tsBtnDelDog";
            this.tsBtnDelDog.Size = new System.Drawing.Size(128, 25);
            this.tsBtnDelDog.TabIndex = 7;
            this.tsBtnDelDog.Text = "Удалить выбранные";
            this.tsBtnDelDog.UseVisualStyleBackColor = true;
            this.tsBtnDelDog.Click += new System.EventHandler(this.tsBtnDelDog_Click);
            // 
            // frmGettingDogovor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 416);
            this.Controls.Add(this.tsBtnDelDog);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGet);
            this.Name = "frmGettingDogovor";
            this.Text = "Получение договора";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtCountCopy)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edtFindingDogovor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox edtGetType;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView ResultListDGV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown edtCountCopy;
        private System.Windows.Forms.Button tsBtnDelDog;
    }
}