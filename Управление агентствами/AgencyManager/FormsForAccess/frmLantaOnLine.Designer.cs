namespace AgencyManager.FormsForAccess
{
    partial class frmLantaOnLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLantaOnLine));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OnLineLoginsDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLegendDelete = new System.Windows.Forms.Label();
            this.lblLegendNew = new System.Windows.Forms.Label();
            this.lblLegendActive = new System.Windows.Forms.Label();
            this.lblLegendNotActive = new System.Windows.Forms.Label();
            this.tsButtonMenu = new System.Windows.Forms.ToolStrip();
            this.gbCreateLoginPass = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsBtnBlock = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSetAdminPass = new System.Windows.Forms.ToolStripButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OnLineLoginsDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tsButtonMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OnLineLoginsDGV);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.tsButtonMenu);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(708, 181);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры входа в ON-Line";
            // 
            // OnLineLoginsDGV
            // 
            this.OnLineLoginsDGV.AllowUserToAddRows = false;
            this.OnLineLoginsDGV.AllowUserToDeleteRows = false;
            this.OnLineLoginsDGV.AllowUserToResizeRows = false;
            this.OnLineLoginsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OnLineLoginsDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.OnLineLoginsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OnLineLoginsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OnLineLoginsDGV.Location = new System.Drawing.Point(3, 47);
            this.OnLineLoginsDGV.MultiSelect = false;
            this.OnLineLoginsDGV.Name = "OnLineLoginsDGV";
            this.OnLineLoginsDGV.ReadOnly = true;
            this.OnLineLoginsDGV.RowHeadersVisible = false;
            this.OnLineLoginsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OnLineLoginsDGV.Size = new System.Drawing.Size(558, 131);
            this.OnLineLoginsDGV.TabIndex = 1;
            this.OnLineLoginsDGV.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnLineLoginsDGV_RowEnter);
            this.OnLineLoginsDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OnLineLoginsDGV_DataBindingComplete);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLegendDelete);
            this.groupBox1.Controls.Add(this.lblLegendNew);
            this.groupBox1.Controls.Add(this.lblLegendActive);
            this.groupBox1.Controls.Add(this.lblLegendNotActive);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(561, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 131);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Легенда";
            // 
            // lblLegendDelete
            // 
            this.lblLegendDelete.BackColor = System.Drawing.SystemColors.Window;
            this.lblLegendDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegendDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegendDelete.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblLegendDelete.Location = new System.Drawing.Point(3, 55);
            this.lblLegendDelete.Name = "lblLegendDelete";
            this.lblLegendDelete.Size = new System.Drawing.Size(138, 13);
            this.lblLegendDelete.TabIndex = 3;
            this.lblLegendDelete.Text = "Помечен на удаление";
            // 
            // lblLegendNew
            // 
            this.lblLegendNew.BackColor = System.Drawing.SystemColors.Window;
            this.lblLegendNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegendNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegendNew.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblLegendNew.Location = new System.Drawing.Point(3, 42);
            this.lblLegendNew.Name = "lblLegendNew";
            this.lblLegendNew.Size = new System.Drawing.Size(138, 13);
            this.lblLegendNew.TabIndex = 2;
            this.lblLegendNew.Text = "Новый несохранен";
            // 
            // lblLegendActive
            // 
            this.lblLegendActive.BackColor = System.Drawing.SystemColors.Window;
            this.lblLegendActive.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegendActive.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblLegendActive.Location = new System.Drawing.Point(3, 29);
            this.lblLegendActive.Name = "lblLegendActive";
            this.lblLegendActive.Size = new System.Drawing.Size(138, 13);
            this.lblLegendActive.TabIndex = 1;
            this.lblLegendActive.Text = "Активен";
            // 
            // lblLegendNotActive
            // 
            this.lblLegendNotActive.BackColor = System.Drawing.SystemColors.Window;
            this.lblLegendNotActive.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegendNotActive.ForeColor = System.Drawing.Color.Red;
            this.lblLegendNotActive.Location = new System.Drawing.Point(3, 16);
            this.lblLegendNotActive.Name = "lblLegendNotActive";
            this.lblLegendNotActive.Size = new System.Drawing.Size(138, 13);
            this.lblLegendNotActive.TabIndex = 0;
            this.lblLegendNotActive.Text = "Блокирован";
            // 
            // tsButtonMenu
            // 
            this.tsButtonMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsButtonMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAdd,
            this.tsBtnDelete,
            this.tsBtnBlock,
            this.tsBtnSetAdminPass});
            this.tsButtonMenu.Location = new System.Drawing.Point(3, 16);
            this.tsButtonMenu.Name = "tsButtonMenu";
            this.tsButtonMenu.Size = new System.Drawing.Size(702, 31);
            this.tsButtonMenu.TabIndex = 13;
            this.tsButtonMenu.Text = "toolStrip1";
            // 
            // gbCreateLoginPass
            // 
            this.gbCreateLoginPass.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCreateLoginPass.Location = new System.Drawing.Point(0, 0);
            this.gbCreateLoginPass.Name = "gbCreateLoginPass";
            this.gbCreateLoginPass.Size = new System.Drawing.Size(708, 160);
            this.gbCreateLoginPass.TabIndex = 25;
            this.gbCreateLoginPass.TabStop = false;
            this.gbCreateLoginPass.Text = "Создание логина/пароля";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 160);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(708, 3);
            this.splitter1.TabIndex = 26;
            this.splitter1.TabStop = false;
            // 
            // tsBtnAdd
            // 
            this.tsBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAdd.Image")));
            this.tsBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAdd.Name = "tsBtnAdd";
            this.tsBtnAdd.Size = new System.Drawing.Size(85, 28);
            this.tsBtnAdd.Text = "Добавить";
            this.tsBtnAdd.Click += new System.EventHandler(this.tsBtnAdd_Click);
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.Enabled = false;
            this.tsBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDelete.Image")));
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(79, 28);
            this.tsBtnDelete.Text = "Удалить";
            this.tsBtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // tsBtnBlock
            // 
            this.tsBtnBlock.Enabled = false;
            this.tsBtnBlock.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnBlock.Image")));
            this.tsBtnBlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnBlock.Name = "tsBtnBlock";
            this.tsBtnBlock.Size = new System.Drawing.Size(101, 28);
            this.tsBtnBlock.Text = "Блокировать";
            this.tsBtnBlock.Click += new System.EventHandler(this.tsBtnBlock_Click);
            // 
            // tsBtnSetAdminPass
            // 
            this.tsBtnSetAdminPass.Enabled = false;
            this.tsBtnSetAdminPass.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSetAdminPass.Image")));
            this.tsBtnSetAdminPass.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSetAdminPass.Name = "tsBtnSetAdminPass";
            this.tsBtnSetAdminPass.Size = new System.Drawing.Size(111, 28);
            this.tsBtnSetAdminPass.Text = "Главный логин";
            this.tsBtnSetAdminPass.Click += new System.EventHandler(this.tsBtnSetAdminPass_Click);
            // 
            // frmLantaOnLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 341);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbCreateLoginPass);
            this.Name = "frmLantaOnLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры входа в Lanta On-Line для:";
            this.ParentChanged += new System.EventHandler(this.frmLantaOnLine_ParentChanged);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OnLineLoginsDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tsButtonMenu.ResumeLayout(false);
            this.tsButtonMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView OnLineLoginsDGV;
        private System.Windows.Forms.ToolStrip tsButtonMenu;
        private System.Windows.Forms.ToolStripButton tsBtnAdd;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.ToolStripButton tsBtnBlock;
        private System.Windows.Forms.ToolStripButton tsBtnSetAdminPass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLegendDelete;
        private System.Windows.Forms.Label lblLegendNew;
        private System.Windows.Forms.Label lblLegendActive;
        private System.Windows.Forms.Label lblLegendNotActive;
        private System.Windows.Forms.GroupBox gbCreateLoginPass;
        private System.Windows.Forms.Splitter splitter1;
    }
}