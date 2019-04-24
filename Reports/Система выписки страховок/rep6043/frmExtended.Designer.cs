namespace rep6043
{
    partial class frmExtended
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
            this.ResultListDGV = new ltp_v2.Controls.Forms.lwDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLegendAnyError = new System.Windows.Forms.Label();
            this.lblLegendPrinted = new System.Windows.Forms.Label();
            this.lblLegendLostService = new System.Windows.Forms.Label();
            this.lblLegend0Days = new System.Windows.Forms.Label();
            this.lblLegend1Days = new System.Windows.Forms.Label();
            this.lblLegend5Days = new System.Windows.Forms.Label();
            this.lblLegendNormal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.ResultListDGV.Location = new System.Drawing.Point(0, 0);
            this.ResultListDGV.Name = "ResultListDGV";
            this.ResultListDGV.RowHeadersVisible = false;
            this.ResultListDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultListDGV.Size = new System.Drawing.Size(497, 300);
            this.ResultListDGV.TabIndex = 4;
            this.ResultListDGV.DataSourceChanged += new System.EventHandler(this.ResultListDGV_DataSourceChanged);
            this.ResultListDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ResultListDGV_DataBindingComplete);
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
            this.groupBox1.Location = new System.Drawing.Point(497, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 300);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Легенда";
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
            // frmExtended
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 300);
            this.Controls.Add(this.ResultListDGV);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(330, 300);
            this.Name = "frmExtended";
            this.Text = "frmExtended";
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ltp_v2.Controls.Forms.lwDataGridView ResultListDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLegendAnyError;
        private System.Windows.Forms.Label lblLegendPrinted;
        private System.Windows.Forms.Label lblLegendLostService;
        private System.Windows.Forms.Label lblLegend0Days;
        private System.Windows.Forms.Label lblLegend1Days;
        private System.Windows.Forms.Label lblLegend5Days;
        private System.Windows.Forms.Label lblLegendNormal;
    }
}