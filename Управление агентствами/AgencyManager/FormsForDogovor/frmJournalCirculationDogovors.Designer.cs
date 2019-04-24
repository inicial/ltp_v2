namespace AgencyManager.FormsForDogovor
{
    partial class frmJournalCirculationDogovors
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.edtFltDog = new System.Windows.Forms.RadioButton();
            this.edtFltFax = new System.Windows.Forms.RadioButton();
            this.edtFltFirstSend = new System.Windows.Forms.RadioButton();
            this.edtFltSend = new System.Windows.Forms.CheckBox();
            this.edtFltSig = new System.Windows.Forms.CheckBox();
            this.edtFltPack = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edtFltDateBeg = new System.Windows.Forms.DateTimePicker();
            this.edtFltDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCountRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.edtFltDogNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.edtFltEndInWeek = new System.Windows.Forms.CheckBox();
            this.JournalDogovorsDGV = new ltp_v2.Controls.Forms.lwDataGridView();
            this.edtFltPartner = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearchFltPartner = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JournalDogovorsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(47, 73);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 26);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.edtFltDog);
            this.groupBox1.Controls.Add(this.edtFltFax);
            this.groupBox1.Controls.Add(this.edtFltFirstSend);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(209, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 114);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(9, 13);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(94, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Все договора";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // edtFltDog
            // 
            this.edtFltDog.AutoSize = true;
            this.edtFltDog.Location = new System.Drawing.Point(9, 82);
            this.edtFltDog.Name = "edtFltDog";
            this.edtFltDog.Size = new System.Drawing.Size(145, 17);
            this.edtFltDog.TabIndex = 2;
            this.edtFltDog.Text = "Полученные оригиналы";
            this.edtFltDog.UseVisualStyleBackColor = true;
            // 
            // edtFltFax
            // 
            this.edtFltFax.AutoSize = true;
            this.edtFltFax.Location = new System.Drawing.Point(9, 59);
            this.edtFltFax.Name = "edtFltFax";
            this.edtFltFax.Size = new System.Drawing.Size(136, 17);
            this.edtFltFax.TabIndex = 1;
            this.edtFltFax.Text = "Полученные по факсу";
            this.edtFltFax.UseVisualStyleBackColor = true;
            // 
            // edtFltFirstSend
            // 
            this.edtFltFirstSend.AutoSize = true;
            this.edtFltFirstSend.Location = new System.Drawing.Point(9, 36);
            this.edtFltFirstSend.Name = "edtFltFirstSend";
            this.edtFltFirstSend.Size = new System.Drawing.Size(164, 17);
            this.edtFltFirstSend.TabIndex = 0;
            this.edtFltFirstSend.Text = "На подписание агентством";
            this.edtFltFirstSend.UseVisualStyleBackColor = true;
            // 
            // edtFltSend
            // 
            this.edtFltSend.AutoSize = true;
            this.edtFltSend.Location = new System.Drawing.Point(12, 59);
            this.edtFltSend.Name = "edtFltSend";
            this.edtFltSend.Size = new System.Drawing.Size(121, 17);
            this.edtFltSend.TabIndex = 4;
            this.edtFltSend.Text = "Отдан на отправку";
            this.edtFltSend.UseVisualStyleBackColor = true;
            // 
            // edtFltSig
            // 
            this.edtFltSig.AutoSize = true;
            this.edtFltSig.Location = new System.Drawing.Point(12, 13);
            this.edtFltSig.Name = "edtFltSig";
            this.edtFltSig.Size = new System.Drawing.Size(125, 17);
            this.edtFltSig.TabIndex = 2;
            this.edtFltSig.Text = "Подписанные нами";
            this.edtFltSig.UseVisualStyleBackColor = true;
            // 
            // edtFltPack
            // 
            this.edtFltPack.AutoSize = true;
            this.edtFltPack.Location = new System.Drawing.Point(12, 36);
            this.edtFltPack.Name = "edtFltPack";
            this.edtFltPack.Size = new System.Drawing.Size(119, 17);
            this.edtFltPack.TabIndex = 3;
            this.edtFltPack.Text = "Составлена опись";
            this.edtFltPack.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edtFltDateBeg);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.edtFltDateEnd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 114);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Последние действия за период";
            // 
            // edtFltDateBeg
            // 
            this.edtFltDateBeg.Location = new System.Drawing.Point(35, 16);
            this.edtFltDateBeg.Name = "edtFltDateBeg";
            this.edtFltDateBeg.Size = new System.Drawing.Size(141, 20);
            this.edtFltDateBeg.TabIndex = 0;
            // 
            // edtFltDateEnd
            // 
            this.edtFltDateEnd.Location = new System.Drawing.Point(35, 45);
            this.edtFltDateEnd.Name = "edtFltDateEnd";
            this.edtFltDateEnd.Size = new System.Drawing.Size(141, 20);
            this.edtFltDateEnd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "с";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "по";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblCountRows});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(819, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(147, 17);
            this.toolStripStatusLabel1.Text = "Итого записей на экране:";
            // 
            // lblCountRows
            // 
            this.lblCountRows.Name = "lblCountRows";
            this.lblCountRows.Size = new System.Drawing.Size(13, 17);
            this.lblCountRows.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(819, 133);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Фильтр данных";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSearchFltPartner);
            this.groupBox5.Controls.Add(this.edtFltPartner);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.edtFltDogNumber);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(622, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(191, 114);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            // 
            // edtFltDogNumber
            // 
            this.edtFltDogNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edtFltDogNumber.Location = new System.Drawing.Point(17, 33);
            this.edtFltDogNumber.Name = "edtFltDogNumber";
            this.edtFltDogNumber.Size = new System.Drawing.Size(159, 22);
            this.edtFltDogNumber.TabIndex = 1;
            this.edtFltDogNumber.TextChanged += new System.EventHandler(this.edtFltDogNumber_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "№ Договора";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.edtFltEndInWeek);
            this.groupBox4.Controls.Add(this.edtFltSig);
            this.groupBox4.Controls.Add(this.edtFltSend);
            this.groupBox4.Controls.Add(this.edtFltPack);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(401, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(221, 114);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // edtFltEndInWeek
            // 
            this.edtFltEndInWeek.AutoSize = true;
            this.edtFltEndInWeek.Location = new System.Drawing.Point(12, 82);
            this.edtFltEndInWeek.Name = "edtFltEndInWeek";
            this.edtFltEndInWeek.Size = new System.Drawing.Size(176, 17);
            this.edtFltEndInWeek.TabIndex = 5;
            this.edtFltEndInWeek.Text = "Закончится в течение недели";
            this.edtFltEndInWeek.UseVisualStyleBackColor = true;
            this.edtFltEndInWeek.CheckedChanged += new System.EventHandler(this.edtFltEndInWeek_CheckedChanged);
            // 
            // JournalDogovorsDGV
            // 
            this.JournalDogovorsDGV.AllowUserToAddRows = false;
            this.JournalDogovorsDGV.AllowUserToDeleteRows = false;
            this.JournalDogovorsDGV.AllowUserToResizeRows = false;
            this.JournalDogovorsDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.JournalDogovorsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.JournalDogovorsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JournalDogovorsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JournalDogovorsDGV.Location = new System.Drawing.Point(0, 133);
            this.JournalDogovorsDGV.MultiSelect = false;
            this.JournalDogovorsDGV.Name = "JournalDogovorsDGV";
            this.JournalDogovorsDGV.ReadOnly = true;
            this.JournalDogovorsDGV.RowHeadersWidth = 70;
            this.JournalDogovorsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.JournalDogovorsDGV.ShowCellErrors = false;
            this.JournalDogovorsDGV.ShowCellToolTips = false;
            this.JournalDogovorsDGV.ShowEditingIcon = false;
            this.JournalDogovorsDGV.ShowRowErrors = false;
            this.JournalDogovorsDGV.Size = new System.Drawing.Size(819, 396);
            this.JournalDogovorsDGV.TabIndex = 1;
            this.JournalDogovorsDGV.DataSourceChanged += new System.EventHandler(this.JournalDogovorsDGV_DataSourceChanged);
            this.JournalDogovorsDGV.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.JournalDogovorsDGV_CellContentDoubleClick);
            this.JournalDogovorsDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.JournalDogovorsDGV_DataBindingComplete);
            this.JournalDogovorsDGV.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.JournalDogovorsDGV_RowPrePaint);
            // 
            // edtFltPartner
            // 
            this.edtFltPartner.BackColor = System.Drawing.SystemColors.Window;
            this.edtFltPartner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edtFltPartner.Location = new System.Drawing.Point(17, 73);
            this.edtFltPartner.Name = "edtFltPartner";
            this.edtFltPartner.ReadOnly = true;
            this.edtFltPartner.Size = new System.Drawing.Size(136, 22);
            this.edtFltPartner.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Партнер";
            // 
            // btnSearchFltPartner
            // 
            this.btnSearchFltPartner.Location = new System.Drawing.Point(154, 72);
            this.btnSearchFltPartner.Name = "btnSearchFltPartner";
            this.btnSearchFltPartner.Size = new System.Drawing.Size(32, 23);
            this.btnSearchFltPartner.TabIndex = 4;
            this.btnSearchFltPartner.Text = "...";
            this.btnSearchFltPartner.UseVisualStyleBackColor = true;
            this.btnSearchFltPartner.Click += new System.EventHandler(this.btnSearchFltPartner_Click);
            // 
            // frmJournalCirculationDogovors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 551);
            this.Controls.Add(this.JournalDogovorsDGV);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmJournalCirculationDogovors";
            this.Text = "Журнал оборота договоров";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JournalDogovorsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ltp_v2.Controls.Forms.lwDataGridView JournalDogovorsDGV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker edtFltDateEnd;
        private System.Windows.Forms.DateTimePicker edtFltDateBeg;
        private System.Windows.Forms.CheckBox edtFltSig;
        private System.Windows.Forms.CheckBox edtFltSend;
        private System.Windows.Forms.CheckBox edtFltPack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton edtFltDog;
        private System.Windows.Forms.RadioButton edtFltFax;
        private System.Windows.Forms.RadioButton edtFltFirstSend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblCountRows;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox edtFltDogNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox edtFltEndInWeek;
        private System.Windows.Forms.Button btnSearchFltPartner;
        private System.Windows.Forms.TextBox edtFltPartner;
        private System.Windows.Forms.Label label4;
    }
}