namespace AgencyManager.FormsForAccess
{
    partial class frmAviaOnLine
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AviaLoginsDGV = new System.Windows.Forms.DataGridView();
            this.tsButtonMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AviaLoginsDGV)).BeginInit();
            this.tsButtonMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AviaLoginsDGV);
            this.groupBox2.Controls.Add(this.tsButtonMenu);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(708, 341);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры входа в ON-Line";
            // 
            // AviaLoginsDGV
            // 
            this.AviaLoginsDGV.AllowUserToAddRows = false;
            this.AviaLoginsDGV.AllowUserToDeleteRows = false;
            this.AviaLoginsDGV.AllowUserToResizeRows = false;
            this.AviaLoginsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AviaLoginsDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.AviaLoginsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AviaLoginsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AviaLoginsDGV.Location = new System.Drawing.Point(3, 47);
            this.AviaLoginsDGV.MultiSelect = false;
            this.AviaLoginsDGV.Name = "AviaLoginsDGV";
            this.AviaLoginsDGV.ReadOnly = true;
            this.AviaLoginsDGV.RowHeadersVisible = false;
            this.AviaLoginsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AviaLoginsDGV.Size = new System.Drawing.Size(702, 291);
            this.AviaLoginsDGV.TabIndex = 1;
            // 
            // tsButtonMenu
            // 
            this.tsButtonMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsButtonMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAdd});
            this.tsButtonMenu.Location = new System.Drawing.Point(3, 16);
            this.tsButtonMenu.Name = "tsButtonMenu";
            this.tsButtonMenu.Size = new System.Drawing.Size(702, 31);
            this.tsButtonMenu.TabIndex = 13;
            this.tsButtonMenu.Text = "toolStrip1";
            // 
            // tsBtnAdd
            // 
            this.tsBtnAdd.Image = global::AgencyManager.Properties.Resources.Add;
            this.tsBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAdd.Name = "tsBtnAdd";
            this.tsBtnAdd.Size = new System.Drawing.Size(85, 28);
            this.tsBtnAdd.Text = "Добавить";
            this.tsBtnAdd.Click += new System.EventHandler(this.tsBtnAdd_Click);
            // 
            // frmAviaOnLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 341);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmAviaOnLine";
            this.Text = "frmLantaOnLine";
            this.ParentChanged += new System.EventHandler(this.frmAviaOnLine_ParentChanged);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AviaLoginsDGV)).EndInit();
            this.tsButtonMenu.ResumeLayout(false);
            this.tsButtonMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView AviaLoginsDGV;
        private System.Windows.Forms.ToolStrip tsButtonMenu;
        private System.Windows.Forms.ToolStripButton tsBtnAdd;
    }
}