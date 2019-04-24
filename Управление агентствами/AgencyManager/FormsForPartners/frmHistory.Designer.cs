namespace AgencyManager.FormsForPartners
{
    partial class frmHistory
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistory));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsBtnHiModIns = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHiModUpd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHiModDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsBtnFltAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnFltAKK = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnFltPartner = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnFltPrtDogs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnFltCC = new System.Windows.Forms.ToolStripMenuItem();
            this.HistoryDGV = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HistoryDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnClose,
            this.tsBtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(679, 31);
            this.toolStrip1.TabIndex = 21;
            // 
            // tsBtnClose
            // 
            this.tsBtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBtnClose.Image = global::AgencyManager.Properties.Resources.Stop;
            this.tsBtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnClose.Name = "tsBtnClose";
            this.tsBtnClose.Size = new System.Drawing.Size(81, 28);
            this.tsBtnClose.Text = "Закрыть";
            this.tsBtnClose.Click += new System.EventHandler(this.tsBtnClose_Click);
            // 
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.Image = global::AgencyManager.Properties.Resources.Refresh;
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(89, 28);
            this.tsBtnRefresh.Text = "Обновить";
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsBtnRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolStrip2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 45);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтр данных";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnHiModIns,
            this.tsBtnHiModUpd,
            this.tsBtnHiModDel,
            this.toolStripDropDownButton1});
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(673, 25);
            this.toolStrip2.TabIndex = 18;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsBtnHiModIns
            // 
            this.tsBtnHiModIns.CheckOnClick = true;
            this.tsBtnHiModIns.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnHiModIns.Image")));
            this.tsBtnHiModIns.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnHiModIns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnHiModIns.Name = "tsBtnHiModIns";
            this.tsBtnHiModIns.Size = new System.Drawing.Size(94, 22);
            this.tsBtnHiModIns.Text = "Добавление";
            this.tsBtnHiModIns.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsBtnHiModIns.CheckedChanged += new System.EventHandler(this.tsBtn_CheckedChanged);
            // 
            // tsBtnHiModUpd
            // 
            this.tsBtnHiModUpd.CheckOnClick = true;
            this.tsBtnHiModUpd.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnHiModUpd.Image")));
            this.tsBtnHiModUpd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnHiModUpd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnHiModUpd.Name = "tsBtnHiModUpd";
            this.tsBtnHiModUpd.Size = new System.Drawing.Size(89, 22);
            this.tsBtnHiModUpd.Text = "Изменение";
            this.tsBtnHiModUpd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsBtnHiModUpd.CheckedChanged += new System.EventHandler(this.tsBtn_CheckedChanged);
            // 
            // tsBtnHiModDel
            // 
            this.tsBtnHiModDel.CheckOnClick = true;
            this.tsBtnHiModDel.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnHiModDel.Image")));
            this.tsBtnHiModDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnHiModDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnHiModDel.Name = "tsBtnHiModDel";
            this.tsBtnHiModDel.Size = new System.Drawing.Size(150, 22);
            this.tsBtnHiModDel.Text = "Удаление/Блокировка";
            this.tsBtnHiModDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsBtnHiModDel.CheckedChanged += new System.EventHandler(this.tsBtn_CheckedChanged);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnFltAccount,
            this.tsBtnFltAKK,
            this.tsBtnFltPartner,
            this.tsBtnFltPrtDogs,
            this.tsBtnFltCC});
            this.toolStripDropDownButton1.Image = global::AgencyManager.Properties.Resources.Check;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(99, 22);
            this.toolStripDropDownButton1.Text = "Фильр данных";
            // 
            // tsBtnFltAccount
            // 
            this.tsBtnFltAccount.Checked = true;
            this.tsBtnFltAccount.CheckOnClick = true;
            this.tsBtnFltAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsBtnFltAccount.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnFltAccount.Image")));
            this.tsBtnFltAccount.Name = "tsBtnFltAccount";
            this.tsBtnFltAccount.Size = new System.Drawing.Size(172, 22);
            this.tsBtnFltAccount.Text = "Счета";
            this.tsBtnFltAccount.CheckedChanged += new System.EventHandler(this.tsBtn_CheckedChanged);
            // 
            // tsBtnFltAKK
            // 
            this.tsBtnFltAKK.Checked = true;
            this.tsBtnFltAKK.CheckOnClick = true;
            this.tsBtnFltAKK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsBtnFltAKK.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnFltAKK.Image")));
            this.tsBtnFltAKK.Name = "tsBtnFltAKK";
            this.tsBtnFltAKK.Size = new System.Drawing.Size(172, 22);
            this.tsBtnFltAKK.Text = "АКК";
            this.tsBtnFltAKK.CheckedChanged += new System.EventHandler(this.tsBtn_CheckedChanged);
            // 
            // tsBtnFltPartner
            // 
            this.tsBtnFltPartner.Checked = true;
            this.tsBtnFltPartner.CheckOnClick = true;
            this.tsBtnFltPartner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsBtnFltPartner.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnFltPartner.Image")));
            this.tsBtnFltPartner.Name = "tsBtnFltPartner";
            this.tsBtnFltPartner.Size = new System.Drawing.Size(172, 22);
            this.tsBtnFltPartner.Text = "Данные агентства";
            this.tsBtnFltPartner.CheckedChanged += new System.EventHandler(this.tsBtn_CheckedChanged);
            // 
            // tsBtnFltPrtDogs
            // 
            this.tsBtnFltPrtDogs.Checked = true;
            this.tsBtnFltPrtDogs.CheckOnClick = true;
            this.tsBtnFltPrtDogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsBtnFltPrtDogs.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnFltPrtDogs.Image")));
            this.tsBtnFltPrtDogs.Name = "tsBtnFltPrtDogs";
            this.tsBtnFltPrtDogs.Size = new System.Drawing.Size(172, 22);
            this.tsBtnFltPrtDogs.Text = "Договора";
            this.tsBtnFltPrtDogs.CheckedChanged += new System.EventHandler(this.tsBtn_CheckedChanged);
            // 
            // tsBtnFltCC
            // 
            this.tsBtnFltCC.Checked = true;
            this.tsBtnFltCC.CheckOnClick = true;
            this.tsBtnFltCC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsBtnFltCC.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnFltCC.Image")));
            this.tsBtnFltCC.Name = "tsBtnFltCC";
            this.tsBtnFltCC.Size = new System.Drawing.Size(172, 22);
            this.tsBtnFltCC.Text = "CallCenter";
            this.tsBtnFltCC.CheckedChanged += new System.EventHandler(this.tsBtn_CheckedChanged);
            // 
            // HistoryDGV
            // 
            this.HistoryDGV.AllowUserToAddRows = false;
            this.HistoryDGV.AllowUserToDeleteRows = false;
            this.HistoryDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.HistoryDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.HistoryDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HistoryDGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.HistoryDGV.Location = new System.Drawing.Point(0, 76);
            this.HistoryDGV.MultiSelect = false;
            this.HistoryDGV.Name = "HistoryDGV";
            this.HistoryDGV.ReadOnly = true;
            this.HistoryDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HistoryDGV.Size = new System.Drawing.Size(679, 156);
            this.HistoryDGV.TabIndex = 23;
            this.HistoryDGV.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.HistoryDGV_RowEnter);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Refresh.ico");
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 232);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(679, 187);
            this.webBrowser.TabIndex = 26;
            this.webBrowser.Tag = "";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 232);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(679, 4);
            this.splitter1.TabIndex = 27;
            this.splitter1.TabStop = false;
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 419);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.HistoryDGV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmHistory";
            this.Text = "Журнал изменения данных по партнеру";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HistoryDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView HistoryDGV;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsBtnHiModIns;
        private System.Windows.Forms.ToolStripButton tsBtnHiModUpd;
        private System.Windows.Forms.ToolStripButton tsBtnHiModDel;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tsBtnFltAccount;
        private System.Windows.Forms.ToolStripMenuItem tsBtnFltAKK;
        private System.Windows.Forms.ToolStripMenuItem tsBtnFltPartner;
        private System.Windows.Forms.ToolStripMenuItem tsBtnFltPrtDogs;
        private System.Windows.Forms.ToolStripMenuItem tsBtnFltCC;
    }
}