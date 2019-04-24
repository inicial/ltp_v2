namespace rep25991.Controls.Forms.Voucher
{
    partial class frmListServices
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.legServiceNotNeedCreate = new System.Windows.Forms.Label();
            this.legIndividualService = new System.Windows.Forms.Label();
            this.legErrorService = new System.Windows.Forms.Label();
            this.legPrintedVoucher = new System.Windows.Forms.Label();
            this.legPresentVoucher = new System.Windows.Forms.Label();
            this.legNoVoucher = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCreate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSkipCreatedVoucher = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSecondPrintAllow = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.ResultListDGV.Location = new System.Drawing.Point(0, 31);
            this.ResultListDGV.Name = "ResultListDGV";
            this.ResultListDGV.ReadOnly = true;
            this.ResultListDGV.RowHeadersVisible = false;
            this.ResultListDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultListDGV.Size = new System.Drawing.Size(604, 399);
            this.ResultListDGV.TabIndex = 12;
            this.ResultListDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ResultListDGV_DataBindingComplete);
            this.ResultListDGV.SelectionChanged += new System.EventHandler(this.ResultListDGV_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.legServiceNotNeedCreate);
            this.groupBox1.Controls.Add(this.legIndividualService);
            this.groupBox1.Controls.Add(this.legErrorService);
            this.groupBox1.Controls.Add(this.legPrintedVoucher);
            this.groupBox1.Controls.Add(this.legPresentVoucher);
            this.groupBox1.Controls.Add(this.legNoVoucher);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(604, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 399);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Легенда";
            // 
            // legServiceNotNeedCreate
            // 
            this.legServiceNotNeedCreate.BackColor = System.Drawing.Color.White;
            this.legServiceNotNeedCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.legServiceNotNeedCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.legServiceNotNeedCreate.ForeColor = System.Drawing.Color.Gray;
            this.legServiceNotNeedCreate.Location = new System.Drawing.Point(3, 171);
            this.legServiceNotNeedCreate.Name = "legServiceNotNeedCreate";
            this.legServiceNotNeedCreate.Size = new System.Drawing.Size(140, 31);
            this.legServiceNotNeedCreate.TabIndex = 15;
            this.legServiceNotNeedCreate.Text = "Услуга не нуждается в ваучере";
            this.legServiceNotNeedCreate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // legIndividualService
            // 
            this.legIndividualService.BackColor = System.Drawing.Color.White;
            this.legIndividualService.Dock = System.Windows.Forms.DockStyle.Top;
            this.legIndividualService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.legIndividualService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.legIndividualService.Location = new System.Drawing.Point(3, 140);
            this.legIndividualService.Name = "legIndividualService";
            this.legIndividualService.Size = new System.Drawing.Size(140, 31);
            this.legIndividualService.TabIndex = 14;
            this.legIndividualService.Text = "Внепакетная услуга";
            this.legIndividualService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.legErrorService.TabIndex = 13;
            this.legErrorService.Text = "Ошибка в услуге";
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
            this.legPrintedVoucher.TabIndex = 16;
            this.legPrintedVoucher.Text = "Ваучер распечатан";
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
            this.legPresentVoucher.TabIndex = 12;
            this.legPresentVoucher.Text = "На услугу создан ваучер";
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
            this.legNoVoucher.TabIndex = 11;
            this.legNoVoucher.Text = "Нет ваучера";
            this.legNoVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnRefresh,
            this.tsBtnCreate,
            this.tsBtnSkipCreatedVoucher,
            this.tsBtnDelete,
            this.tsBtnPrint,
            this.tsBtnSecondPrintAllow});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(750, 31);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.Image = global::rep25991.Properties.Resources.Refresh;
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(89, 28);
            this.tsBtnRefresh.Text = "Обновить";
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
            // tsBtnSkipCreatedVoucher
            // 
            this.tsBtnSkipCreatedVoucher.Image = global::rep25991.Properties.Resources.Restricted;
            this.tsBtnSkipCreatedVoucher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSkipCreatedVoucher.Name = "tsBtnSkipCreatedVoucher";
            this.tsBtnSkipCreatedVoucher.Size = new System.Drawing.Size(128, 28);
            this.tsBtnSkipCreatedVoucher.Text = "Отказ от ваучера";
            this.tsBtnSkipCreatedVoucher.Click += new System.EventHandler(this.tsBtnSkipCreatedVoucher_Click);
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.Enabled = false;
            this.tsBtnDelete.Image = global::rep25991.Properties.Resources.Delete;
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(89, 28);
            this.tsBtnDelete.Text = "Ануляция";
            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
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
            // tsBtnSecondPrintAllow
            // 
            this.tsBtnSecondPrintAllow.Image = global::rep25991.Properties.Resources.Apply_Check;
            this.tsBtnSecondPrintAllow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSecondPrintAllow.Name = "tsBtnSecondPrintAllow";
            this.tsBtnSecondPrintAllow.Size = new System.Drawing.Size(135, 28);
            this.tsBtnSecondPrintAllow.Text = "Повторная печать";
            this.tsBtnSecondPrintAllow.Click += new System.EventHandler(this.tsBtnSecondPrintAllow_Click);
            // 
            // frmListServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 430);
            this.Controls.Add(this.ResultListDGV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmListServices";
            this.Text = "Список услуг брони №";
            this.Load += new System.EventHandler(this.frmListServices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ResultListDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private System.Windows.Forms.ToolStripButton tsBtnCreate;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.ToolStripButton tsBtnPrint;
        private System.Windows.Forms.ToolStripButton tsBtnSecondPrintAllow;
        private System.Windows.Forms.ToolStripButton tsBtnSkipCreatedVoucher;
        private System.Windows.Forms.Label legServiceNotNeedCreate;
        private System.Windows.Forms.Label legIndividualService;
        private System.Windows.Forms.Label legErrorService;
        private System.Windows.Forms.Label legPrintedVoucher;
        private System.Windows.Forms.Label legPresentVoucher;
        private System.Windows.Forms.Label legNoVoucher;
    }
}