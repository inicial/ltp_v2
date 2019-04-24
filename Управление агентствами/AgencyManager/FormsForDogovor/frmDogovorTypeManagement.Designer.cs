namespace AgencyManager.FormsForDogovor
{
    partial class frmDogovorTypeManagement
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsFltViewState = new System.Windows.Forms.ToolStripComboBox();
            this.tsFltTypeDogovor = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFltAgencyType = new System.Windows.Forms.ToolStripComboBox();
            this.DogovorTypesDGV = new System.Windows.Forms.DataGridView();
            this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DogovorTypesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAdd,
            this.tsBtnEdit,
            this.toolStripSeparator1,
            this.tsFltViewState,
            this.tsFltTypeDogovor,
            this.tsFltAgencyType,
            this.tsBtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(664, 31);
            this.toolStrip1.TabIndex = 22;
            // 
            // tsFltViewState
            // 
            this.tsFltViewState.Name = "tsFltViewState";
            this.tsFltViewState.Size = new System.Drawing.Size(121, 31);
            // 
            // tsFltTypeDogovor
            // 
            this.tsFltTypeDogovor.Name = "tsFltTypeDogovor";
            this.tsFltTypeDogovor.Size = new System.Drawing.Size(121, 31);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsFltAgencyType
            // 
            this.tsFltAgencyType.Name = "tsFltAgencyType";
            this.tsFltAgencyType.Size = new System.Drawing.Size(121, 31);
            // 
            // DogovorTypesDGV
            // 
            this.DogovorTypesDGV.AllowUserToAddRows = false;
            this.DogovorTypesDGV.AllowUserToDeleteRows = false;
            this.DogovorTypesDGV.AllowUserToOrderColumns = true;
            this.DogovorTypesDGV.AllowUserToResizeRows = false;
            this.DogovorTypesDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DogovorTypesDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DogovorTypesDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DogovorTypesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DogovorTypesDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DogovorTypesDGV.Location = new System.Drawing.Point(0, 31);
            this.DogovorTypesDGV.Name = "DogovorTypesDGV";
            this.DogovorTypesDGV.ReadOnly = true;
            this.DogovorTypesDGV.RowHeadersVisible = false;
            this.DogovorTypesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DogovorTypesDGV.Size = new System.Drawing.Size(664, 431);
            this.DogovorTypesDGV.TabIndex = 23;
            // 
            // tsBtnAdd
            // 
            this.tsBtnAdd.Image = global::AgencyManager.Properties.Resources.Add;
            this.tsBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAdd.Name = "tsBtnAdd";
            this.tsBtnAdd.Size = new System.Drawing.Size(87, 28);
            this.tsBtnAdd.Text = "Добавить";
            this.tsBtnAdd.Click += new System.EventHandler(this.tsBtnAdd_Click);
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
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.Image = global::AgencyManager.Properties.Resources.Refresh;
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(89, 28);
            this.tsBtnRefresh.Text = "Обновить";
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsBtnRefresh_Click);
            // 
            // frmDogovorTypeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 462);
            this.Controls.Add(this.DogovorTypesDGV);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmDogovorTypeManagement";
            this.Text = "Настройка типов договоров";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DogovorTypesDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnAdd;
        private System.Windows.Forms.ToolStripButton tsBtnEdit;
        private System.Windows.Forms.ToolStripComboBox tsFltViewState;
        private System.Windows.Forms.ToolStripComboBox tsFltTypeDogovor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private System.Windows.Forms.ToolStripComboBox tsFltAgencyType;
        private System.Windows.Forms.DataGridView DogovorTypesDGV;
    }
}