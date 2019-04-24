using System.Windows.Forms;
namespace AccreditationCards
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsFltYear = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsFltNumberZakaz = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.tsBtnActivate = new System.Windows.Forms.ToolStripButton();
            this.PartnersDGV = new ltp_v2.Controls.Forms.lwDataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lwContainerAccounts = new ltp_v2.Controls.Forms.lwGroupContainer();
            this.AccountsDGV = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsBtnPrintAccount = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statLblCountItems = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PartnersDGV)).BeginInit();
            this.lwContainerAccounts.PnlContainer.SuspendLayout();
            this.lwContainerAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountsDGV)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.tsFltYear,
            this.toolStripLabel1,
            this.tsFltNumberZakaz,
            this.tsBtnRefresh,
            this.tsBtnPrint,
            this.tsBtnActivate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(712, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(29, 28);
            this.toolStripLabel2.Text = "Год:";
            // 
            // tsFltYear
            // 
            this.tsFltYear.Name = "tsFltYear";
            this.tsFltYear.Size = new System.Drawing.Size(121, 31);
            this.tsFltYear.SelectedIndexChanged += new System.EventHandler(this.tsFltYear_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(141, 28);
            this.toolStripLabel1.Text = "№ заявки на получение:";
            // 
            // tsFltNumberZakaz
            // 
            this.tsFltNumberZakaz.Name = "tsFltNumberZakaz";
            this.tsFltNumberZakaz.Size = new System.Drawing.Size(100, 31);
            this.tsFltNumberZakaz.Text = " ";
            this.tsFltNumberZakaz.TextChanged += new System.EventHandler(this.tsFltNumberZakaz_TextChanged);
            // 
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.Image = global::AccreditationCards.Properties.Resources.Refresh;
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(89, 28);
            this.tsBtnRefresh.Text = "Обновить";
            this.tsBtnRefresh.Click += new System.EventHandler(this.flt_Leave_Click);
            // 
            // tsBtnPrint
            // 
            this.tsBtnPrint.Image = global::AccreditationCards.Properties.Resources.Print;
            this.tsBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrint.Name = "tsBtnPrint";
            this.tsBtnPrint.Size = new System.Drawing.Size(74, 28);
            this.tsBtnPrint.Text = "Печать";
            this.tsBtnPrint.Click += new System.EventHandler(this.tsBtnPrint_Click);
            // 
            // tsBtnActivate
            // 
            this.tsBtnActivate.Image = global::AccreditationCards.Properties.Resources.Login;
            this.tsBtnActivate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnActivate.Name = "tsBtnActivate";
            this.tsBtnActivate.Size = new System.Drawing.Size(93, 28);
            this.tsBtnActivate.Text = "Активация";
            this.tsBtnActivate.Click += new System.EventHandler(this.tsBtnActivate_Click);
            // 
            // PartnersDGV
            // 
            this.PartnersDGV.AllowUserToAddRows = false;
            this.PartnersDGV.AllowUserToDeleteRows = false;
            this.PartnersDGV.AllowUserToResizeRows = false;
            this.PartnersDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PartnersDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.PartnersDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PartnersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PartnersDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PartnersDGV.Location = new System.Drawing.Point(0, 31);
            this.PartnersDGV.Name = "PartnersDGV";
            this.PartnersDGV.ReadOnly = true;
            this.PartnersDGV.RowHeadersWidth = 50;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.PartnersDGV.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.PartnersDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PartnersDGV.Size = new System.Drawing.Size(712, 253);
            this.PartnersDGV.TabIndex = 3;
            this.PartnersDGV.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.PartnersDGV_RowEnter);
            this.PartnersDGV.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.PartnersDGV_RowPrePaint);
            this.PartnersDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.PartnersDGV_DataBindingComplete);
            this.PartnersDGV.SelectionChanged += new System.EventHandler(this.PartnersDGV_SelectionChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 306);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(712, 10);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // lwContainerAccounts
            // 
            this.lwContainerAccounts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lwContainerAccounts.FontHeaderText = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lwContainerAccounts.FullView = true;
            this.lwContainerAccounts.Location = new System.Drawing.Point(0, 316);
            this.lwContainerAccounts.Name = "lwContainerAccounts";
            // 
            // lwContainerAccounts.PnlContainer
            // 
            this.lwContainerAccounts.PnlContainer.Controls.Add(this.AccountsDGV);
            this.lwContainerAccounts.PnlContainer.Controls.Add(this.toolStrip2);
            this.lwContainerAccounts.PnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lwContainerAccounts.PnlContainer.Location = new System.Drawing.Point(0, 23);
            this.lwContainerAccounts.PnlContainer.Name = "PnlContainer";
            this.lwContainerAccounts.PnlContainer.Size = new System.Drawing.Size(712, 108);
            this.lwContainerAccounts.PnlContainer.TabIndex = 1;
            this.lwContainerAccounts.PnlContainer.VisibleChanged += new System.EventHandler(this.lwGroupContainer1_PnlContainer_VisibleChanged);
            this.lwContainerAccounts.Size = new System.Drawing.Size(712, 131);
            this.lwContainerAccounts.TabIndex = 4;
            this.lwContainerAccounts.TextHeader = "Журнал счетов на оплату по выбранной карте";
            // 
            // AccountsDGV
            // 
            this.AccountsDGV.AllowUserToAddRows = false;
            this.AccountsDGV.AllowUserToDeleteRows = false;
            this.AccountsDGV.AllowUserToResizeRows = false;
            this.AccountsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AccountsDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.AccountsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AccountsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountsDGV.Location = new System.Drawing.Point(0, 31);
            this.AccountsDGV.MultiSelect = false;
            this.AccountsDGV.Name = "AccountsDGV";
            this.AccountsDGV.ReadOnly = true;
            this.AccountsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AccountsDGV.Size = new System.Drawing.Size(712, 77);
            this.AccountsDGV.TabIndex = 4;
            this.AccountsDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.AccountsDGV_DataBindingComplete);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnPrintAccount});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(712, 31);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsBtnPrintAccount
            // 
            this.tsBtnPrintAccount.Image = global::AccreditationCards.Properties.Resources.Print;
            this.tsBtnPrintAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrintAccount.Name = "tsBtnPrintAccount";
            this.tsBtnPrintAccount.Size = new System.Drawing.Size(74, 28);
            this.tsBtnPrintAccount.Text = "Печать";
            this.tsBtnPrintAccount.Click += new System.EventHandler(this.tsBtnPrintAccount_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statLblCountItems});
            this.statusStrip1.Location = new System.Drawing.Point(0, 284);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(712, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statLblCountItems
            // 
            this.statLblCountItems.Name = "statLblCountItems";
            this.statLblCountItems.Size = new System.Drawing.Size(104, 17);
            this.statLblCountItems.Text = "statLblCountItems";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 447);
            this.Controls.Add(this.PartnersDGV);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lwContainerAccounts);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "Журнал регистрации АКК";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PartnersDGV)).EndInit();
            this.lwContainerAccounts.PnlContainer.ResumeLayout(false);
            this.lwContainerAccounts.PnlContainer.PerformLayout();
            this.lwContainerAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AccountsDGV)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private ltp_v2.Controls.Forms.lwDataGridView PartnersDGV;
        private System.Windows.Forms.ToolStripButton tsBtnPrint;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tsFltNumberZakaz;
        private ltp_v2.Controls.Forms.lwGroupContainer lwContainerAccounts;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView AccountsDGV;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsBtnPrintAccount;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox tsFltYear;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statLblCountItems;
        private ToolStripButton tsBtnActivate;
    }
}

