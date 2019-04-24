namespace rep25991.Controls.Forms.Voucher
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
            this.pnlAnyFilter = new System.Windows.Forms.Panel();
            this.fltBronNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fltTourName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fltDate = new System.Windows.Forms.DateTimePicker();
            this.fltCountry = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCreate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPrintCons = new System.Windows.Forms.ToolStripButton();
            this.tsBtnView = new System.Windows.Forms.ToolStripButton();
            this.tsBtnConfigureShablon = new System.Windows.Forms.ToolStripButton();
            this.ResultListDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.legStateWait = new System.Windows.Forms.Label();
            this.legNotPayed = new System.Windows.Forms.Label();
            this.legPresentIndividual = new System.Windows.Forms.Label();
            this.legErrorService = new System.Windows.Forms.Label();
            this.legPrintedVoucher = new System.Windows.Forms.Label();
            this.legPresentVoucher = new System.Windows.Forms.Label();
            this.legNoVoucher = new System.Windows.Forms.Label();
            this.pnlAnyFilter.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAnyFilter
            // 
            this.pnlAnyFilter.Controls.Add(this.fltBronNumber);
            this.pnlAnyFilter.Controls.Add(this.label4);
            this.pnlAnyFilter.Controls.Add(this.label5);
            this.pnlAnyFilter.Controls.Add(this.fltTourName);
            this.pnlAnyFilter.Controls.Add(this.label2);
            this.pnlAnyFilter.Controls.Add(this.label1);
            this.pnlAnyFilter.Controls.Add(this.fltDate);
            this.pnlAnyFilter.Controls.Add(this.fltCountry);
            this.pnlAnyFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAnyFilter.Location = new System.Drawing.Point(0, 31);
            this.pnlAnyFilter.Name = "pnlAnyFilter";
            this.pnlAnyFilter.Size = new System.Drawing.Size(761, 46);
            this.pnlAnyFilter.TabIndex = 8;
            // 
            // fltBronNumber
            // 
            this.fltBronNumber.Location = new System.Drawing.Point(551, 19);
            this.fltBronNumber.Name = "fltBronNumber";
            this.fltBronNumber.Size = new System.Drawing.Size(170, 20);
            this.fltBronNumber.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(548, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "№ брони";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Название тура:";
            // 
            // fltTourName
            // 
            this.fltTourName.FormattingEnabled = true;
            this.fltTourName.Location = new System.Drawing.Point(254, 20);
            this.fltTourName.Name = "fltTourName";
            this.fltTourName.Size = new System.Drawing.Size(285, 21);
            this.fltTourName.TabIndex = 8;
            this.fltTourName.SelectedIndexChanged += new System.EventHandler(this.fltTourName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Страна заезда";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата заезда";
            // 
            // fltDate
            // 
            this.fltDate.CustomFormat = "dd.MM.yyyy";
            this.fltDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fltDate.Location = new System.Drawing.Point(7, 20);
            this.fltDate.Name = "fltDate";
            this.fltDate.Size = new System.Drawing.Size(94, 20);
            this.fltDate.TabIndex = 1;
            this.fltDate.ValueChanged += new System.EventHandler(this.fltDate_ValueChanged);
            this.fltDate.Enter += new System.EventHandler(this.fltDate_Enter);
            this.fltDate.Leave += new System.EventHandler(this.fltDate_Leave);
            // 
            // fltCountry
            // 
            this.fltCountry.FormattingEnabled = true;
            this.fltCountry.Location = new System.Drawing.Point(113, 20);
            this.fltCountry.Name = "fltCountry";
            this.fltCountry.Size = new System.Drawing.Size(129, 21);
            this.fltCountry.TabIndex = 2;
            this.fltCountry.SelectedIndexChanged += new System.EventHandler(this.fltCountry_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnRefresh,
            this.tsBtnOpen,
            this.tsBtnCreate,
            this.tsBtnPrint,
            this.tsBtnPrintCons,
            this.tsBtnView,
            this.tsBtnConfigureShablon});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(761, 31);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.Image = global::rep25991.Properties.Resources.Refresh;
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(89, 28);
            this.tsBtnRefresh.Text = "Обновить";
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsBtnRefresh_Click);
            // 
            // tsBtnOpen
            // 
            this.tsBtnOpen.Image = global::rep25991.Properties.Resources.direction_right;
            this.tsBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOpen.Name = "tsBtnOpen";
            this.tsBtnOpen.Size = new System.Drawing.Size(97, 28);
            this.tsBtnOpen.Text = "Подробнее";
            this.tsBtnOpen.Click += new System.EventHandler(this.tsBtnOpen_Click);
            // 
            // tsBtnCreate
            // 
            this.tsBtnCreate.Image = global::rep25991.Properties.Resources.Add;
            this.tsBtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCreate.Name = "tsBtnCreate";
            this.tsBtnCreate.Size = new System.Drawing.Size(78, 28);
            this.tsBtnCreate.Text = "Создать";
            this.tsBtnCreate.Click += new System.EventHandler(this.tsBtnCreate_Click);
            // 
            // tsBtnPrint
            // 
            this.tsBtnPrint.Image = global::rep25991.Properties.Resources.Print;
            this.tsBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrint.Name = "tsBtnPrint";
            this.tsBtnPrint.Size = new System.Drawing.Size(74, 28);
            this.tsBtnPrint.Text = "Печать";
            this.tsBtnPrint.Click += new System.EventHandler(this.tsBtnPrint_Click);
            // 
            // tsBtnPrintCons
            // 
            this.tsBtnPrintCons.Image = global::rep25991.Properties.Resources.Print;
            this.tsBtnPrintCons.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrintCons.Name = "tsBtnPrintCons";
            this.tsBtnPrintCons.Size = new System.Drawing.Size(166, 28);
            this.tsBtnPrintCons.Text = "Печать для консультств";
            this.tsBtnPrintCons.Click += new System.EventHandler(this.tsBtnPrintCons_Click);
            // 
            // tsBtnView
            // 
            this.tsBtnView.Image = global::rep25991.Properties.Resources.Apply_Check;
            this.tsBtnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnView.Name = "tsBtnView";
            this.tsBtnView.Size = new System.Drawing.Size(118, 28);
            this.tsBtnView.Text = "Предпросмотр";
            this.tsBtnView.Click += new System.EventHandler(this.tsBtnView_Click);
            // 
            // tsBtnConfigureShablon
            // 
            this.tsBtnConfigureShablon.Image = global::rep25991.Properties.Resources.Apply_Check;
            this.tsBtnConfigureShablon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnConfigureShablon.Name = "tsBtnConfigureShablon";
            this.tsBtnConfigureShablon.Size = new System.Drawing.Size(94, 28);
            this.tsBtnConfigureShablon.Text = "Настройка";
            this.tsBtnConfigureShablon.Click += new System.EventHandler(this.tsBtnConfigureShablon_Click);
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
            this.ResultListDGV.Location = new System.Drawing.Point(0, 77);
            this.ResultListDGV.Name = "ResultListDGV";
            this.ResultListDGV.ReadOnly = true;
            this.ResultListDGV.RowHeadersVisible = false;
            this.ResultListDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultListDGV.Size = new System.Drawing.Size(615, 315);
            this.ResultListDGV.TabIndex = 9;
            this.ResultListDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ResultListDGV_DataBindingComplete);
            this.ResultListDGV.SelectionChanged += new System.EventHandler(this.ResultListDGV_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.legStateWait);
            this.groupBox1.Controls.Add(this.legNotPayed);
            this.groupBox1.Controls.Add(this.legPresentIndividual);
            this.groupBox1.Controls.Add(this.legErrorService);
            this.groupBox1.Controls.Add(this.legPrintedVoucher);
            this.groupBox1.Controls.Add(this.legPresentVoucher);
            this.groupBox1.Controls.Add(this.legNoVoucher);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(615, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 315);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Легенда";
            // 
            // legStateWait
            // 
            this.legStateWait.BackColor = System.Drawing.Color.White;
            this.legStateWait.Dock = System.Windows.Forms.DockStyle.Top;
            this.legStateWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.legStateWait.ForeColor = System.Drawing.Color.Red;
            this.legStateWait.Location = new System.Drawing.Point(3, 202);
            this.legStateWait.Name = "legStateWait";
            this.legStateWait.Size = new System.Drawing.Size(140, 31);
            this.legStateWait.TabIndex = 12;
            this.legStateWait.Text = "Не подтвержден";
            this.legStateWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // legNotPayed
            // 
            this.legNotPayed.BackColor = System.Drawing.Color.White;
            this.legNotPayed.Dock = System.Windows.Forms.DockStyle.Top;
            this.legNotPayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.legNotPayed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.legNotPayed.Location = new System.Drawing.Point(3, 171);
            this.legNotPayed.Name = "legNotPayed";
            this.legNotPayed.Size = new System.Drawing.Size(140, 31);
            this.legNotPayed.TabIndex = 11;
            this.legNotPayed.Text = "Бронь не оплачена";
            this.legNotPayed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // legPresentIndividual
            // 
            this.legPresentIndividual.BackColor = System.Drawing.Color.White;
            this.legPresentIndividual.Dock = System.Windows.Forms.DockStyle.Top;
            this.legPresentIndividual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.legPresentIndividual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.legPresentIndividual.Location = new System.Drawing.Point(3, 140);
            this.legPresentIndividual.Name = "legPresentIndividual";
            this.legPresentIndividual.Size = new System.Drawing.Size(140, 31);
            this.legPresentIndividual.TabIndex = 8;
            this.legPresentIndividual.Text = "Есть внепакетные услуги";
            this.legPresentIndividual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // legErrorService
            // 
            this.legErrorService.BackColor = System.Drawing.Color.White;
            this.legErrorService.Dock = System.Windows.Forms.DockStyle.Top;
            this.legErrorService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.legErrorService.ForeColor = System.Drawing.Color.Red;
            this.legErrorService.Location = new System.Drawing.Point(3, 109);
            this.legErrorService.Name = "legErrorService";
            this.legErrorService.Size = new System.Drawing.Size(140, 31);
            this.legErrorService.TabIndex = 7;
            this.legErrorService.Text = "Ошибка в туре";
            this.legErrorService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // legPrintedVoucher
            // 
            this.legPrintedVoucher.BackColor = System.Drawing.Color.White;
            this.legPrintedVoucher.Dock = System.Windows.Forms.DockStyle.Top;
            this.legPrintedVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.legPrintedVoucher.ForeColor = System.Drawing.Color.Blue;
            this.legPrintedVoucher.Location = new System.Drawing.Point(3, 78);
            this.legPrintedVoucher.Name = "legPrintedVoucher";
            this.legPrintedVoucher.Size = new System.Drawing.Size(140, 31);
            this.legPrintedVoucher.TabIndex = 10;
            this.legPrintedVoucher.Text = "На все услуги ваучеры распечатаны";
            this.legPrintedVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // legPresentVoucher
            // 
            this.legPresentVoucher.BackColor = System.Drawing.Color.White;
            this.legPresentVoucher.Dock = System.Windows.Forms.DockStyle.Top;
            this.legPresentVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.legPresentVoucher.ForeColor = System.Drawing.Color.Blue;
            this.legPresentVoucher.Location = new System.Drawing.Point(3, 47);
            this.legPresentVoucher.Name = "legPresentVoucher";
            this.legPresentVoucher.Size = new System.Drawing.Size(140, 31);
            this.legPresentVoucher.TabIndex = 6;
            this.legPresentVoucher.Text = "На все услуги есть ваучеры";
            this.legPresentVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // legNoVoucher
            // 
            this.legNoVoucher.BackColor = System.Drawing.Color.White;
            this.legNoVoucher.Dock = System.Windows.Forms.DockStyle.Top;
            this.legNoVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.legNoVoucher.ForeColor = System.Drawing.Color.Black;
            this.legNoVoucher.Location = new System.Drawing.Point(3, 16);
            this.legNoVoucher.Name = "legNoVoucher";
            this.legNoVoucher.Size = new System.Drawing.Size(140, 31);
            this.legNoVoucher.TabIndex = 4;
            this.legNoVoucher.Text = "Нет ваучера(ов)";
            this.legNoVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 392);
            this.Controls.Add(this.ResultListDGV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlAnyFilter);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "Ваучер - форма вывода на печать";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlAnyFilter.ResumeLayout(false);
            this.pnlAnyFilter.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAnyFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox fltTourName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fltDate;
        private System.Windows.Forms.ComboBox fltCountry;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private System.Windows.Forms.ToolStripButton tsBtnOpen;
        private System.Windows.Forms.ToolStripButton tsBtnPrint;
        private System.Windows.Forms.ToolStripButton tsBtnPrintCons;
        private System.Windows.Forms.ToolStripButton tsBtnConfigureShablon;
        private System.Windows.Forms.DataGridView ResultListDGV;
        private System.Windows.Forms.TextBox fltBronNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label legErrorService;
        private System.Windows.Forms.Label legNoVoucher;
        private System.Windows.Forms.Label legPresentIndividual;
        private System.Windows.Forms.Label legPresentVoucher;
        private System.Windows.Forms.ToolStripButton tsBtnCreate;
        private System.Windows.Forms.Label legPrintedVoucher;
        private System.Windows.Forms.Label legNotPayed;
        private System.Windows.Forms.ToolStripButton tsBtnView;
        private System.Windows.Forms.Label legStateWait;
    }
}