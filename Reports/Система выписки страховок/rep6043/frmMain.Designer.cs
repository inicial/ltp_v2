namespace rep6043
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
            this.ResultListDGV = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCreateInsurances = new System.Windows.Forms.ToolStripButton();
            this.tsBtnOpenEdit = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAnulate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.tsBtnExport = new System.Windows.Forms.ToolStripButton();
            this.tsBtnShowWarning = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edtFltCountry = new System.Windows.Forms.ComboBox();
            this.edtFltDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edtFltBronNumber = new System.Windows.Forms.TextBox();
            this.lblTypFilter = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLegendPrinted = new System.Windows.Forms.Label();
            this.lblLegendLostService = new System.Windows.Forms.Label();
            this.lblLegend0Days = new System.Windows.Forms.Label();
            this.lblLegend1Days = new System.Windows.Forms.Label();
            this.lblLegend5Days = new System.Windows.Forms.Label();
            this.lblLegendNormal = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLblCountRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLblCountTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLegendAnyError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.ResultListDGV.Location = new System.Drawing.Point(0, 66);
            this.ResultListDGV.Name = "ResultListDGV";
            this.ResultListDGV.ReadOnly = true;
            this.ResultListDGV.RowHeadersVisible = false;
            this.ResultListDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultListDGV.Size = new System.Drawing.Size(714, 344);
            this.ResultListDGV.TabIndex = 2;
            this.ResultListDGV.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultListDGV_CellEnter);
            this.ResultListDGV.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ResultListDGV_ColumnHeaderMouseClick);
            this.ResultListDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ResultListDGV_DataBindingComplete);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnRefresh,
            this.tsBtnCreateInsurances,
            this.tsBtnOpenEdit,
            this.tsBtnAnulate,
            this.tsBtnPrint,
            this.tsBtnExport,
            this.tsBtnShowWarning});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(860, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.Image = global::rep6043.Properties.Resources.Refresh;
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(89, 28);
            this.tsBtnRefresh.Text = "Обновить";
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsBtnRefresh_Click);
            // 
            // tsBtnCreateInsurances
            // 
            this.tsBtnCreateInsurances.Enabled = false;
            this.tsBtnCreateInsurances.Image = global::rep6043.Properties.Resources.Add;
            this.tsBtnCreateInsurances.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCreateInsurances.Name = "tsBtnCreateInsurances";
            this.tsBtnCreateInsurances.Size = new System.Drawing.Size(115, 28);
            this.tsBtnCreateInsurances.Text = "Создать полис";
            this.tsBtnCreateInsurances.Click += new System.EventHandler(this.tsBtnCreateInsurances_Click);
            // 
            // tsBtnOpenEdit
            // 
            this.tsBtnOpenEdit.Enabled = false;
            this.tsBtnOpenEdit.Image = global::rep6043.Properties.Resources.Edit;
            this.tsBtnOpenEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOpenEdit.Name = "tsBtnOpenEdit";
            this.tsBtnOpenEdit.Size = new System.Drawing.Size(141, 28);
            this.tsBtnOpenEdit.Text = "Открыть/Изменить";
            this.tsBtnOpenEdit.Click += new System.EventHandler(this.tsBtnOpenEdit_Click);
            // 
            // tsBtnAnulate
            // 
            this.tsBtnAnulate.Enabled = false;
            this.tsBtnAnulate.Image = global::rep6043.Properties.Resources.Delete;
            this.tsBtnAnulate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAnulate.Name = "tsBtnAnulate";
            this.tsBtnAnulate.Size = new System.Drawing.Size(107, 28);
            this.tsBtnAnulate.Text = "Анулировать";
            this.tsBtnAnulate.Click += new System.EventHandler(this.tsBtnAnulate_Click);
            // 
            // tsBtnPrint
            // 
            this.tsBtnPrint.Enabled = false;
            this.tsBtnPrint.Image = global::rep6043.Properties.Resources.Print;
            this.tsBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrint.Name = "tsBtnPrint";
            this.tsBtnPrint.Size = new System.Drawing.Size(74, 28);
            this.tsBtnPrint.Text = "Печать";
            this.tsBtnPrint.Click += new System.EventHandler(this.tsBtnPrint_Click);
            // 
            // tsBtnExport
            // 
            this.tsBtnExport.Image = global::rep6043.Properties.Resources.Export;
            this.tsBtnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExport.Name = "tsBtnExport";
            this.tsBtnExport.Size = new System.Drawing.Size(86, 28);
            this.tsBtnExport.Text = "Выгрузка";
            this.tsBtnExport.Click += new System.EventHandler(this.tsBtnExport_Click);
            // 
            // tsBtnShowWarning
            // 
            this.tsBtnShowWarning.Image = global::rep6043.Properties.Resources.Help;
            this.tsBtnShowWarning.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnShowWarning.Name = "tsBtnShowWarning";
            this.tsBtnShowWarning.Size = new System.Drawing.Size(136, 28);
            this.tsBtnShowWarning.Text = "Показать причину";
            this.tsBtnShowWarning.Click += new System.EventHandler(this.tsBtnShowWarning_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edtFltCountry);
            this.panel1.Controls.Add(this.edtFltDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.edtFltBronNumber);
            this.panel1.Controls.Add(this.lblTypFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 35);
            this.panel1.TabIndex = 0;
            // 
            // edtFltCountry
            // 
            this.edtFltCountry.FormattingEnabled = true;
            this.edtFltCountry.Location = new System.Drawing.Point(481, 7);
            this.edtFltCountry.Name = "edtFltCountry";
            this.edtFltCountry.Size = new System.Drawing.Size(154, 21);
            this.edtFltCountry.TabIndex = 2;
            // 
            // edtFltDate
            // 
            this.edtFltDate.CustomFormat = "dd.MM.yyyy";
            this.edtFltDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.edtFltDate.Location = new System.Drawing.Point(291, 7);
            this.edtFltDate.Name = "edtFltDate";
            this.edtFltDate.Size = new System.Drawing.Size(94, 20);
            this.edtFltDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата заезда";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Страна заезда";
            // 
            // edtFltBronNumber
            // 
            this.edtFltBronNumber.Location = new System.Drawing.Point(61, 7);
            this.edtFltBronNumber.Name = "edtFltBronNumber";
            this.edtFltBronNumber.Size = new System.Drawing.Size(148, 20);
            this.edtFltBronNumber.TabIndex = 0;
            this.edtFltBronNumber.TextChanged += new System.EventHandler(this.edtFltBronNumber_TextChanged);
            // 
            // lblTypFilter
            // 
            this.lblTypFilter.AutoSize = true;
            this.lblTypFilter.Location = new System.Drawing.Point(5, 11);
            this.lblTypFilter.Name = "lblTypFilter";
            this.lblTypFilter.Size = new System.Drawing.Size(52, 13);
            this.lblTypFilter.TabIndex = 0;
            this.lblTypFilter.Text = "№ Брони";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLegendAnyError);
            this.groupBox1.Controls.Add(this.lblLegendPrinted);
            this.groupBox1.Controls.Add(this.lblLegendLostService);
            this.groupBox1.Controls.Add(this.lblLegend0Days);
            this.groupBox1.Controls.Add(this.lblLegend1Days);
            this.groupBox1.Controls.Add(this.lblLegend5Days);
            this.groupBox1.Controls.Add(this.lblLegendNormal);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(714, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 366);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Легенда";
            // 
            // lblLegendPrinted
            // 
            this.lblLegendPrinted.BackColor = System.Drawing.Color.White;
            this.lblLegendPrinted.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegendPrinted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegendPrinted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblLegendPrinted.Location = new System.Drawing.Point(3, 171);
            this.lblLegendPrinted.Name = "lblLegendPrinted";
            this.lblLegendPrinted.Size = new System.Drawing.Size(140, 31);
            this.lblLegendPrinted.TabIndex = 3;
            this.lblLegendPrinted.Text = "Распечатан";
            this.lblLegendPrinted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLegendLostService
            // 
            this.lblLegendLostService.BackColor = System.Drawing.Color.Black;
            this.lblLegendLostService.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegendLostService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegendLostService.ForeColor = System.Drawing.Color.Cyan;
            this.lblLegendLostService.Location = new System.Drawing.Point(3, 140);
            this.lblLegendLostService.Name = "lblLegendLostService";
            this.lblLegendLostService.Size = new System.Drawing.Size(140, 31);
            this.lblLegendLostService.TabIndex = 2;
            this.lblLegendLostService.Text = "Несоответствие данных МТ и Полиса";
            this.lblLegendLostService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLegend0Days
            // 
            this.lblLegend0Days.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblLegend0Days.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegend0Days.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegend0Days.ForeColor = System.Drawing.Color.Red;
            this.lblLegend0Days.Location = new System.Drawing.Point(3, 109);
            this.lblLegend0Days.Name = "lblLegend0Days";
            this.lblLegend0Days.Size = new System.Drawing.Size(140, 31);
            this.lblLegend0Days.TabIndex = 1;
            this.lblLegend0Days.Text = "Выписка просрочена";
            this.lblLegend0Days.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLegend1Days
            // 
            this.lblLegend1Days.BackColor = System.Drawing.Color.Yellow;
            this.lblLegend1Days.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegend1Days.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegend1Days.ForeColor = System.Drawing.Color.Navy;
            this.lblLegend1Days.Location = new System.Drawing.Point(3, 78);
            this.lblLegend1Days.Name = "lblLegend1Days";
            this.lblLegend1Days.Size = new System.Drawing.Size(140, 31);
            this.lblLegend1Days.TabIndex = 5;
            this.lblLegend1Days.Text = "Последний день что бы выписать";
            this.lblLegend1Days.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLegend5Days
            // 
            this.lblLegend5Days.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblLegend5Days.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegend5Days.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegend5Days.ForeColor = System.Drawing.Color.Navy;
            this.lblLegend5Days.Location = new System.Drawing.Point(3, 47);
            this.lblLegend5Days.Name = "lblLegend5Days";
            this.lblLegend5Days.Size = new System.Drawing.Size(140, 31);
            this.lblLegend5Days.TabIndex = 0;
            this.lblLegend5Days.Text = "Осталось менее 5 дней что бы выписать";
            this.lblLegend5Days.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLegendNormal
            // 
            this.lblLegendNormal.BackColor = System.Drawing.Color.White;
            this.lblLegendNormal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegendNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegendNormal.ForeColor = System.Drawing.Color.Black;
            this.lblLegendNormal.Location = new System.Drawing.Point(3, 16);
            this.lblLegendNormal.Name = "lblLegendNormal";
            this.lblLegendNormal.Size = new System.Drawing.Size(140, 31);
            this.lblLegendNormal.TabIndex = 4;
            this.lblLegendNormal.Text = "Все нормально";
            this.lblLegendNormal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsLblCountRows,
            this.toolStripStatusLabel2,
            this.tsLblCountTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 410);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(714, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(77, 17);
            this.toolStripStatusLabel1.Text = "Итого строк:";
            // 
            // tsLblCountRows
            // 
            this.tsLblCountRows.Name = "tsLblCountRows";
            this.tsLblCountRows.Size = new System.Drawing.Size(12, 17);
            this.tsLblCountRows.Text = "-";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(107, 17);
            this.toolStripStatusLabel2.Text = "Время обработки:";
            // 
            // tsLblCountTime
            // 
            this.tsLblCountTime.Name = "tsLblCountTime";
            this.tsLblCountTime.Size = new System.Drawing.Size(12, 17);
            this.tsLblCountTime.Text = "-";
            // 
            // lblLegendAnyError
            // 
            this.lblLegendAnyError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblLegendAnyError.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegendAnyError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegendAnyError.ForeColor = System.Drawing.Color.Black;
            this.lblLegendAnyError.Location = new System.Drawing.Point(3, 202);
            this.lblLegendAnyError.Name = "lblLegendAnyError";
            this.lblLegendAnyError.Size = new System.Drawing.Size(140, 31);
            this.lblLegendAnyError.TabIndex = 6;
            this.lblLegendAnyError.Text = "Другая ошибка";
            this.lblLegendAnyError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 432);
            this.Controls.Add(this.ResultListDGV);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "Форма выписки страховок";
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ResultListDGV;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox edtFltBronNumber;
        private System.Windows.Forms.Label lblTypFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker edtFltDate;
        private System.Windows.Forms.ComboBox edtFltCountry;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLegendPrinted;
        private System.Windows.Forms.Label lblLegendLostService;
        private System.Windows.Forms.Label lblLegend0Days;
        private System.Windows.Forms.Label lblLegend5Days;
        private System.Windows.Forms.Label lblLegendNormal;
        private System.Windows.Forms.ToolStripButton tsBtnCreateInsurances;
        private System.Windows.Forms.ToolStripButton tsBtnAnulate;
        private System.Windows.Forms.ToolStripButton tsBtnPrint;
        private System.Windows.Forms.ToolStripButton tsBtnOpenEdit;
        private System.Windows.Forms.ToolStripButton tsBtnExport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsLblCountRows;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsLblCountTime;
        private System.Windows.Forms.ToolStripButton tsBtnShowWarning;
        private System.Windows.Forms.Label lblLegend1Days;
        private System.Windows.Forms.Label lblLegendAnyError;
    }
}

