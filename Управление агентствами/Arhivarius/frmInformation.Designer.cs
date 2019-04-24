namespace Arhivarius
{
    partial class frmInformation
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
            this.HistoryListDGV = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.HistoryListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // HistoryListDGV
            // 
            this.HistoryListDGV.AllowUserToAddRows = false;
            this.HistoryListDGV.AllowUserToDeleteRows = false;
            this.HistoryListDGV.AllowUserToOrderColumns = true;
            this.HistoryListDGV.AllowUserToResizeRows = false;
            this.HistoryListDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.HistoryListDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.HistoryListDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HistoryListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HistoryListDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistoryListDGV.Location = new System.Drawing.Point(253, 0);
            this.HistoryListDGV.Name = "HistoryListDGV";
            this.HistoryListDGV.ReadOnly = true;
            this.HistoryListDGV.RowHeadersVisible = false;
            this.HistoryListDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HistoryListDGV.Size = new System.Drawing.Size(210, 318);
            this.HistoryListDGV.TabIndex = 16;
            this.HistoryListDGV.DataSourceChanged += new System.EventHandler(this.HistoryListDGV_DataSourceChanged);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(253, 318);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 318);
            this.panel1.TabIndex = 17;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(253, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 318);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // frmInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 318);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.HistoryListDGV);
            this.Controls.Add(this.panel1);
            this.Name = "frmInformation";
            this.Text = "Информация по работе с:";
            ((System.ComponentModel.ISupportInitialize)(this.HistoryListDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView HistoryListDGV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;

    }
}