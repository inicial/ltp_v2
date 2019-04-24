namespace AgencyManager.FormsForDogovor
{
    partial class frmDogovorsList
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
            this.CombineDogovorsDGV = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnCreateDogovor = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsLblSelect = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnCheckDogovor = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsBtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSelect = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLegendDopDogovor = new System.Windows.Forms.Label();
            this.lblLegendDelete = new System.Windows.Forms.Label();
            this.lblLegendNew = new System.Windows.Forms.Label();
            this.lblLegendActive = new System.Windows.Forms.Label();
            this.lblLegendTempActive = new System.Windows.Forms.Label();
            this.lblLegendNotActive = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CombineDogovorsDGV)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CombineDogovorsDGV
            // 
            this.CombineDogovorsDGV.AllowUserToAddRows = false;
            this.CombineDogovorsDGV.AllowUserToDeleteRows = false;
            this.CombineDogovorsDGV.AllowUserToResizeRows = false;
            this.CombineDogovorsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CombineDogovorsDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.CombineDogovorsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CombineDogovorsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CombineDogovorsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CombineDogovorsDGV.Location = new System.Drawing.Point(0, 31);
            this.CombineDogovorsDGV.MultiSelect = false;
            this.CombineDogovorsDGV.Name = "CombineDogovorsDGV";
            this.CombineDogovorsDGV.ReadOnly = true;
            this.CombineDogovorsDGV.RowHeadersVisible = false;
            this.CombineDogovorsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CombineDogovorsDGV.Size = new System.Drawing.Size(737, 334);
            this.CombineDogovorsDGV.TabIndex = 20;
            this.CombineDogovorsDGV.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CombineDogovorsDGV_RowEnter);
            this.CombineDogovorsDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.CombineDogovorsDGV_DataBindingComplete);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnCreateDogovor,
            this.tsBtnEdit,
            this.tsLblSelect,
            this.tsBtnCheckDogovor,
            this.tsBtnDelete,
            this.tsBtnClose,
            this.tsBtnPrint,
            this.tsBtnSelect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(881, 31);
            this.toolStrip1.TabIndex = 19;
            // 
            // tsBtnCreateDogovor
            // 
            this.tsBtnCreateDogovor.Image = global::AgencyManager.Properties.Resources.Add;
            this.tsBtnCreateDogovor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCreateDogovor.Name = "tsBtnCreateDogovor";
            this.tsBtnCreateDogovor.Size = new System.Drawing.Size(78, 28);
            this.tsBtnCreateDogovor.Text = "Создать";
            this.tsBtnCreateDogovor.Click += new System.EventHandler(this.tsBtnCreateDogovor_Click);
            // 
            // tsBtnEdit
            // 
            this.tsBtnEdit.Image = global::AgencyManager.Properties.Resources.Edit;
            this.tsBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEdit.Name = "tsBtnEdit";
            this.tsBtnEdit.Size = new System.Drawing.Size(89, 28);
            this.tsBtnEdit.Text = "Изменить";
            this.tsBtnEdit.Click += new System.EventHandler(this.tsBtnEdit_Click);
            // 
            // tsLblSelect
            // 
            this.tsLblSelect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsLblSelect.ForeColor = System.Drawing.Color.Red;
            this.tsLblSelect.Name = "tsLblSelect";
            this.tsLblSelect.Size = new System.Drawing.Size(93, 28);
            this.tsLblSelect.Text = "toolStripLabel1";
            // 
            // tsBtnCheckDogovor
            // 
            this.tsBtnCheckDogovor.Image = global::AgencyManager.Properties.Resources.Construction;
            this.tsBtnCheckDogovor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCheckDogovor.Name = "tsBtnCheckDogovor";
            this.tsBtnCheckDogovor.Size = new System.Drawing.Size(119, 28);
            this.tsBtnCheckDogovor.Text = "Переподвесить";
            this.tsBtnCheckDogovor.Click += new System.EventHandler(this.tsBtnCheckDogovor_Click);
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.Image = global::AgencyManager.Properties.Resources.Delete;
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(79, 28);
            this.tsBtnDelete.Text = "Удалить";
            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // tsBtnClose
            // 
            this.tsBtnClose.Image = global::AgencyManager.Properties.Resources.Stop;
            this.tsBtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnClose.Name = "tsBtnClose";
            this.tsBtnClose.Size = new System.Drawing.Size(81, 28);
            this.tsBtnClose.Text = "Закрыть";
            this.tsBtnClose.Click += new System.EventHandler(this.tsBtnClose_Click);
            // 
            // tsBtnPrint
            // 
            this.tsBtnPrint.Image = global::AgencyManager.Properties.Resources.Print;
            this.tsBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrint.Name = "tsBtnPrint";
            this.tsBtnPrint.Size = new System.Drawing.Size(74, 28);
            this.tsBtnPrint.Text = "Печать";
            this.tsBtnPrint.Click += new System.EventHandler(this.tsBtnPrint_Click);
            // 
            // tsBtnSelect
            // 
            this.tsBtnSelect.Image = global::AgencyManager.Properties.Resources.Apply_Check;
            this.tsBtnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSelect.Name = "tsBtnSelect";
            this.tsBtnSelect.Size = new System.Drawing.Size(171, 28);
            this.tsBtnSelect.Text = "Выбрать все неактивные";
            this.tsBtnSelect.Click += new System.EventHandler(this.tsBtnSelect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLegendDopDogovor);
            this.groupBox1.Controls.Add(this.lblLegendDelete);
            this.groupBox1.Controls.Add(this.lblLegendNew);
            this.groupBox1.Controls.Add(this.lblLegendActive);
            this.groupBox1.Controls.Add(this.lblLegendTempActive);
            this.groupBox1.Controls.Add(this.lblLegendNotActive);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(737, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 334);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Легенда";
            // 
            // lblLegendDopDogovor
            // 
            this.lblLegendDopDogovor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblLegendDopDogovor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegendDopDogovor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblLegendDopDogovor.Location = new System.Drawing.Point(3, 81);
            this.lblLegendDopDogovor.Name = "lblLegendDopDogovor";
            this.lblLegendDopDogovor.Size = new System.Drawing.Size(138, 13);
            this.lblLegendDopDogovor.TabIndex = 4;
            this.lblLegendDopDogovor.Text = "Связанные доп/дог";
            // 
            // lblLegendDelete
            // 
            this.lblLegendDelete.BackColor = System.Drawing.SystemColors.Window;
            this.lblLegendDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegendDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegendDelete.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblLegendDelete.Location = new System.Drawing.Point(3, 68);
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
            this.lblLegendNew.Location = new System.Drawing.Point(3, 55);
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
            this.lblLegendActive.Location = new System.Drawing.Point(3, 42);
            this.lblLegendActive.Name = "lblLegendActive";
            this.lblLegendActive.Size = new System.Drawing.Size(138, 13);
            this.lblLegendActive.TabIndex = 1;
            this.lblLegendActive.Text = "Активирован";
            // 
            // lblLegendTempActive
            // 
            this.lblLegendTempActive.BackColor = System.Drawing.SystemColors.Window;
            this.lblLegendTempActive.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLegendTempActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegendTempActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblLegendTempActive.Location = new System.Drawing.Point(3, 29);
            this.lblLegendTempActive.Name = "lblLegendTempActive";
            this.lblLegendTempActive.Size = new System.Drawing.Size(138, 13);
            this.lblLegendTempActive.TabIndex = 5;
            this.lblLegendTempActive.Text = "По факсу";
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
            this.lblLegendNotActive.Text = "Неактивен";
            // 
            // frmDogovorsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 365);
            this.Controls.Add(this.CombineDogovorsDGV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmDogovorsList";
            this.Text = "frmDogovorsList";
            this.ParentChanged += new System.EventHandler(this.frmDogovorsList_ParentChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDogovorsList_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CombineDogovorsDGV)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CombineDogovorsDGV;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.ToolStripButton tsBtnPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLegendDelete;
        private System.Windows.Forms.Label lblLegendNew;
        private System.Windows.Forms.Label lblLegendActive;
        private System.Windows.Forms.Label lblLegendNotActive;
        private System.Windows.Forms.Label lblLegendDopDogovor;
        private System.Windows.Forms.ToolStripButton tsBtnCreateDogovor;
        private System.Windows.Forms.ToolStripButton tsBtnSelect;
        private System.Windows.Forms.ToolStripLabel tsLblSelect;
        private System.Windows.Forms.Label lblLegendTempActive;
        private System.Windows.Forms.ToolStripButton tsBtnCheckDogovor;
        private System.Windows.Forms.ToolStripButton tsBtnClose;
        private System.Windows.Forms.ToolStripButton tsBtnEdit;
    }
}