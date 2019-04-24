using ltp_v2.Controls.Forms;
namespace AgencyManager
{
    partial class frmNewRegistration
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
            this.NewPartnersDGV = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnReloadData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnMoveToMaster = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.pnlFilter = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edt_filter_Address = new ltp_v2.Controls.Forms.lwFilterTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edt_Filter_DogovorType = new System.Windows.Forms.TextBox();
            this.edt_filter_Name = new ltp_v2.Controls.Forms.lwFilterTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edt_filter_EMail = new ltp_v2.Controls.Forms.lwFilterTextBox();
            this.edt_filter_Inn = new ltp_v2.Controls.Forms.lwFilterTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.edt_filter_Fax = new ltp_v2.Controls.Forms.lwFilterTextBox();
            this.edt_filter_Phone = new ltp_v2.Controls.Forms.lwFilterTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsBtnGetNew = new System.Windows.Forms.ToolStripButton();
            this.tsBtnGetUsed = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssCountRows = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.NewPartnersDGV)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewPartnersDGV
            // 
            this.NewPartnersDGV.AllowUserToAddRows = false;
            this.NewPartnersDGV.AllowUserToDeleteRows = false;
            this.NewPartnersDGV.AllowUserToOrderColumns = true;
            this.NewPartnersDGV.AllowUserToResizeRows = false;
            this.NewPartnersDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NewPartnersDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.NewPartnersDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NewPartnersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NewPartnersDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewPartnersDGV.Location = new System.Drawing.Point(229, 31);
            this.NewPartnersDGV.Name = "NewPartnersDGV";
            this.NewPartnersDGV.ReadOnly = true;
            this.NewPartnersDGV.RowHeadersVisible = false;
            this.NewPartnersDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NewPartnersDGV.Size = new System.Drawing.Size(478, 460);
            this.NewPartnersDGV.TabIndex = 14;
            this.NewPartnersDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.NewPartnersDGV_DataBindingComplete);
            this.NewPartnersDGV.DataSourceChanged += new System.EventHandler(this.NewPartnersDGV_DataSourceChanged);
            this.NewPartnersDGV.SelectionChanged += new System.EventHandler(this.NewPartnersDGV_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReloadData,
            this.toolStripSeparator1,
            this.tsBtnMoveToMaster,
            this.tsBtnDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(707, 31);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnReloadData
            // 
            this.btnReloadData.Image = global::AgencyManager.Properties.Resources.Refresh;
            this.btnReloadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(133, 28);
            this.btnReloadData.Text = "Обновить данные";
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsBtnMoveToMaster
            // 
            this.tsBtnMoveToMaster.Enabled = false;
            this.tsBtnMoveToMaster.Image = global::AgencyManager.Properties.Resources.Construction;
            this.tsBtnMoveToMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnMoveToMaster.Name = "tsBtnMoveToMaster";
            this.tsBtnMoveToMaster.Size = new System.Drawing.Size(124, 28);
            this.tsBtnMoveToMaster.Text = "Перенести в МТ";
            this.tsBtnMoveToMaster.Click += new System.EventHandler(this.tsBtnMoveToMaster_Click);
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.Enabled = false;
            this.tsBtnDelete.Image = global::AgencyManager.Properties.Resources.Restricted;
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(76, 28);
            this.tsBtnDelete.Text = "Скрыть";
            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.panel1);
            this.pnlFilter.Controls.Add(this.toolStrip2);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilter.Location = new System.Drawing.Point(0, 31);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(0);
            this.pnlFilter.Size = new System.Drawing.Size(229, 482);
            this.pnlFilter.TabIndex = 16;
            this.pnlFilter.TabStop = false;
            this.pnlFilter.Text = "Фильтрация данных";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edt_filter_Address);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.edt_Filter_DogovorType);
            this.panel1.Controls.Add(this.edt_filter_Name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.edt_filter_EMail);
            this.panel1.Controls.Add(this.edt_filter_Inn);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.edt_filter_Fax);
            this.panel1.Controls.Add(this.edt_filter_Phone);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 245);
            this.panel1.TabIndex = 18;
            // 
            // edt_filter_Address
            // 
            this.edt_filter_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_filter_Address.Location = new System.Drawing.Point(70, 73);
            this.edt_filter_Address.Name = "edt_filter_Address";
            this.edt_filter_Address.OldText = null;
            this.edt_filter_Address.Size = new System.Drawing.Size(147, 20);
            this.edt_filter_Address.TabIndex = 26;
            this.edt_filter_Address.Leave += new System.EventHandler(this.edtFilterTextChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(21, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Адрес:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edt_Filter_DogovorType
            // 
            this.edt_Filter_DogovorType.BackColor = System.Drawing.SystemColors.Window;
            this.edt_Filter_DogovorType.Location = new System.Drawing.Point(7, 181);
            this.edt_Filter_DogovorType.Name = "edt_Filter_DogovorType";
            this.edt_Filter_DogovorType.ReadOnly = true;
            this.edt_Filter_DogovorType.Size = new System.Drawing.Size(210, 20);
            this.edt_Filter_DogovorType.TabIndex = 25;
            this.edt_Filter_DogovorType.Click += new System.EventHandler(this.edt_Filter_DogovorType_Click);
            // 
            // edt_filter_Name
            // 
            this.edt_filter_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_filter_Name.Location = new System.Drawing.Point(70, 6);
            this.edt_filter_Name.Name = "edt_filter_Name";
            this.edt_filter_Name.OldText = null;
            this.edt_filter_Name.Size = new System.Drawing.Size(147, 20);
            this.edt_filter_Name.TabIndex = 0;
            this.edt_filter_Name.Leave += new System.EventHandler(this.edtFilterTextChange);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(5, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Название:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Необходимый тип договора;";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(31, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "ИНН:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edt_filter_EMail
            // 
            this.edt_filter_EMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_filter_EMail.Location = new System.Drawing.Point(70, 97);
            this.edt_filter_EMail.Name = "edt_filter_EMail";
            this.edt_filter_EMail.OldText = null;
            this.edt_filter_EMail.Size = new System.Drawing.Size(147, 20);
            this.edt_filter_EMail.TabIndex = 5;
            this.edt_filter_EMail.Leave += new System.EventHandler(this.edtFilterTextChange);
            // 
            // edt_filter_Inn
            // 
            this.edt_filter_Inn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_filter_Inn.Location = new System.Drawing.Point(70, 119);
            this.edt_filter_Inn.Name = "edt_filter_Inn";
            this.edt_filter_Inn.OldText = null;
            this.edt_filter_Inn.Size = new System.Drawing.Size(147, 20);
            this.edt_filter_Inn.TabIndex = 6;
            this.edt_filter_Inn.Leave += new System.EventHandler(this.edtFilterTextChange);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(21, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "E-Mail:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(7, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Телефон:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edt_filter_Fax
            // 
            this.edt_filter_Fax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_filter_Fax.Location = new System.Drawing.Point(70, 50);
            this.edt_filter_Fax.Name = "edt_filter_Fax";
            this.edt_filter_Fax.OldText = null;
            this.edt_filter_Fax.Size = new System.Drawing.Size(147, 20);
            this.edt_filter_Fax.TabIndex = 4;
            this.edt_filter_Fax.Leave += new System.EventHandler(this.edtFilterTextChange);
            // 
            // edt_filter_Phone
            // 
            this.edt_filter_Phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_filter_Phone.Location = new System.Drawing.Point(70, 28);
            this.edt_filter_Phone.Name = "edt_filter_Phone";
            this.edt_filter_Phone.OldText = null;
            this.edt_filter_Phone.Size = new System.Drawing.Size(147, 20);
            this.edt_filter_Phone.TabIndex = 2;
            this.edt_filter_Phone.Leave += new System.EventHandler(this.edtFilterTextChange);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(28, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Факс:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGetNew,
            this.tsBtnGetUsed});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 13);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(229, 73);
            this.toolStrip2.TabIndex = 19;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsBtnGetNew
            // 
            this.tsBtnGetNew.Checked = true;
            this.tsBtnGetNew.CheckOnClick = true;
            this.tsBtnGetNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsBtnGetNew.Image = global::AgencyManager.Properties.Resources.Check;
            this.tsBtnGetNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnGetNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnGetNew.Name = "tsBtnGetNew";
            this.tsBtnGetNew.Size = new System.Drawing.Size(227, 28);
            this.tsBtnGetNew.Text = "Показать новые";
            this.tsBtnGetNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnGetNew.CheckStateChanged += new System.EventHandler(this.tsBtnGetNew_CheckedChanged);
            // 
            // tsBtnGetUsed
            // 
            this.tsBtnGetUsed.CheckOnClick = true;
            this.tsBtnGetUsed.Image = global::AgencyManager.Properties.Resources.UnCheck;
            this.tsBtnGetUsed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnGetUsed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnGetUsed.Name = "tsBtnGetUsed";
            this.tsBtnGetUsed.Size = new System.Drawing.Size(227, 28);
            this.tsBtnGetUsed.Text = "Показать обработанные";
            this.tsBtnGetUsed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsBtnGetUsed.CheckStateChanged += new System.EventHandler(this.tsBtnGetUsed_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssCountRows});
            this.statusStrip1.Location = new System.Drawing.Point(229, 491);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(478, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssCountRows
            // 
            this.tssCountRows.Name = "tssCountRows";
            this.tssCountRows.Size = new System.Drawing.Size(97, 17);
            this.tssCountRows.Text = "Итого на экране";
            // 
            // frmNewRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 513);
            this.Controls.Add(this.NewPartnersDGV);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmNewRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал новых регистраций";
            this.Load += new System.EventHandler(this.frmNewRegistration_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNewRegistration_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.NewPartnersDGV)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView NewPartnersDGV;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox pnlFilter;
        private lwFilterTextBox edt_filter_EMail;
        private System.Windows.Forms.Label label7;
        private lwFilterTextBox edt_filter_Fax;
        private System.Windows.Forms.Label label6;
        private lwFilterTextBox edt_filter_Phone;
        private System.Windows.Forms.Label label4;
        private lwFilterTextBox edt_filter_Inn;
        private lwFilterTextBox edt_filter_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnMoveToMaster;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssCountRows;
        private System.Windows.Forms.ToolStripButton btnReloadData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsBtnGetNew;
        private System.Windows.Forms.ToolStripButton tsBtnGetUsed;
        private System.Windows.Forms.TextBox edt_Filter_DogovorType;
        private lwFilterTextBox edt_filter_Address;
        private System.Windows.Forms.Label label5;
    }
}

