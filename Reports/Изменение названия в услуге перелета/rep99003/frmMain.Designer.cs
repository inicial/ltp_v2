namespace rep99003
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edtFltCityTo = new System.Windows.Forms.ComboBox();
            this.edtFltCountryTo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtFltCityFrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edtFltCountryFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OutListDGV = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 71);
            this.panel1.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(515, 16);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(93, 38);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Применить к выбранным";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edtFltCityTo);
            this.groupBox2.Controls.Add(this.edtFltCountryTo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(227, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 71);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Прилет";
            // 
            // edtFltCityTo
            // 
            this.edtFltCityTo.FormattingEnabled = true;
            this.edtFltCityTo.Location = new System.Drawing.Point(53, 39);
            this.edtFltCityTo.Name = "edtFltCityTo";
            this.edtFltCityTo.Size = new System.Drawing.Size(168, 21);
            this.edtFltCityTo.TabIndex = 6;
            this.edtFltCityTo.SelectedIndexChanged += new System.EventHandler(this.edtFltCityTo_SelectedIndexChanged);
            this.edtFltCityTo.TextChanged += new System.EventHandler(this.edtFlt_TextChanged);
            // 
            // edtFltCountryTo
            // 
            this.edtFltCountryTo.FormattingEnabled = true;
            this.edtFltCountryTo.Location = new System.Drawing.Point(53, 12);
            this.edtFltCountryTo.Name = "edtFltCountryTo";
            this.edtFltCountryTo.Size = new System.Drawing.Size(168, 21);
            this.edtFltCountryTo.TabIndex = 3;
            this.edtFltCountryTo.SelectedIndexChanged += new System.EventHandler(this.edtFltCountryTo_SelectedIndexChanged);
            this.edtFltCountryTo.TextChanged += new System.EventHandler(this.edtFlt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Город";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Страна";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtFltCityFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.edtFltCountryFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вылет";
            // 
            // edtFltCityFrom
            // 
            this.edtFltCityFrom.FormattingEnabled = true;
            this.edtFltCityFrom.Location = new System.Drawing.Point(53, 40);
            this.edtFltCityFrom.Name = "edtFltCityFrom";
            this.edtFltCityFrom.Size = new System.Drawing.Size(168, 21);
            this.edtFltCityFrom.TabIndex = 2;
            this.edtFltCityFrom.SelectedIndexChanged += new System.EventHandler(this.edtFltCityFrom_SelectedIndexChanged);
            this.edtFltCityFrom.TextChanged += new System.EventHandler(this.edtFlt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Город";
            // 
            // edtFltCountryFrom
            // 
            this.edtFltCountryFrom.FormattingEnabled = true;
            this.edtFltCountryFrom.Location = new System.Drawing.Point(53, 13);
            this.edtFltCountryFrom.Name = "edtFltCountryFrom";
            this.edtFltCountryFrom.Size = new System.Drawing.Size(168, 21);
            this.edtFltCountryFrom.TabIndex = 0;
            this.edtFltCountryFrom.SelectedIndexChanged += new System.EventHandler(this.edtFltCountryFrom_SelectedIndexChanged);
            this.edtFltCountryFrom.TextChanged += new System.EventHandler(this.edtFlt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Страна";
            // 
            // OutListDGV
            // 
            this.OutListDGV.AllowUserToAddRows = false;
            this.OutListDGV.AllowUserToDeleteRows = false;
            this.OutListDGV.AllowUserToOrderColumns = true;
            this.OutListDGV.AllowUserToResizeRows = false;
            this.OutListDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OutListDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.OutListDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OutListDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutListDGV.Location = new System.Drawing.Point(0, 71);
            this.OutListDGV.Name = "OutListDGV";
            this.OutListDGV.RowHeadersVisible = false;
            this.OutListDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OutListDGV.Size = new System.Drawing.Size(658, 340);
            this.OutListDGV.TabIndex = 15;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 411);
            this.Controls.Add(this.OutListDGV);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "Изменение названия в услуге перелета";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutListDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox edtFltCityTo;
        private System.Windows.Forms.ComboBox edtFltCountryTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox edtFltCityFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox edtFltCountryFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridView OutListDGV;
    }
}

