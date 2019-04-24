namespace rep25991.Controls.Forms.Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ResultListDGV = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnApply = new System.Windows.Forms.ToolStripButton();
            this.tsBtnShowExample = new System.Windows.Forms.ToolStripButton();
            this.tsBtnShowCity = new System.Windows.Forms.ToolStripButton();
            this.tsBtnTourShow = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAllTours = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEditPartners = new System.Windows.Forms.ToolStripButton();
            this.tsSetBaseTour = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fltBaseTour = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fltShablon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fltTour = new System.Windows.Forms.ComboBox();
            this.fltCity = new System.Windows.Forms.ComboBox();
            this.fltCountry = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listPresentShablonService = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtTourName = new System.Windows.Forms.TextBox();
            this.pnlTourName = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlTourName.SuspendLayout();
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
            this.ResultListDGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.ResultListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultListDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultListDGV.Location = new System.Drawing.Point(0, 113);
            this.ResultListDGV.MultiSelect = false;
            this.ResultListDGV.Name = "ResultListDGV";
            this.ResultListDGV.RowHeadersVisible = false;
            this.ResultListDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultListDGV.Size = new System.Drawing.Size(638, 195);
            this.ResultListDGV.TabIndex = 7;
            this.ResultListDGV.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ResultListDGV_CellMouseUp);
            this.ResultListDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ResultListDGV_DataBindingComplete);
            this.ResultListDGV.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ResultListDGV_KeyUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnApply,
            this.tsBtnShowExample,
            this.tsBtnShowCity,
            this.tsBtnTourShow,
            this.tsBtnAllTours,
            this.tsBtnEditPartners,
            this.tsSetBaseTour});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(897, 31);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnApply
            // 
            this.tsBtnApply.Image = global::rep25991.Properties.Resources.Apply_Check;
            this.tsBtnApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnApply.Name = "tsBtnApply";
            this.tsBtnApply.Size = new System.Drawing.Size(98, 28);
            this.tsBtnApply.Text = "Применить";
            this.tsBtnApply.Click += new System.EventHandler(this.tsBtnApply_Click);
            // 
            // tsBtnShowExample
            // 
            this.tsBtnShowExample.Image = global::rep25991.Properties.Resources.Search;
            this.tsBtnShowExample.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnShowExample.Name = "tsBtnShowExample";
            this.tsBtnShowExample.Size = new System.Drawing.Size(131, 28);
            this.tsBtnShowExample.Text = "Показать пример";
            this.tsBtnShowExample.Click += new System.EventHandler(this.tsBtnShowExample_Click);
            // 
            // tsBtnShowCity
            // 
            this.tsBtnShowCity.Image = global::rep25991.Properties.Resources.direction_right;
            this.tsBtnShowCity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnShowCity.Name = "tsBtnShowCity";
            this.tsBtnShowCity.Size = new System.Drawing.Size(163, 28);
            this.tsBtnShowCity.Text = "Показать город/курорт";
            this.tsBtnShowCity.Click += new System.EventHandler(this.tsBtnShowCity_Click);
            // 
            // tsBtnTourShow
            // 
            this.tsBtnTourShow.Image = global::rep25991.Properties.Resources.direction_right;
            this.tsBtnTourShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnTourShow.Name = "tsBtnTourShow";
            this.tsBtnTourShow.Size = new System.Drawing.Size(106, 28);
            this.tsBtnTourShow.Text = "Показать тур";
            this.tsBtnTourShow.Click += new System.EventHandler(this.tsBtnTourShow_Click);
            // 
            // tsBtnAllTours
            // 
            this.tsBtnAllTours.Image = global::rep25991.Properties.Resources.Search;
            this.tsBtnAllTours.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAllTours.Name = "tsBtnAllTours";
            this.tsBtnAllTours.Size = new System.Drawing.Size(84, 28);
            this.tsBtnAllTours.Text = "Все туры";
            this.tsBtnAllTours.Click += new System.EventHandler(this.tsBtnAllTours_Click);
            // 
            // tsBtnEditPartners
            // 
            this.tsBtnEditPartners.Image = global::rep25991.Properties.Resources.Contact;
            this.tsBtnEditPartners.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEditPartners.Name = "tsBtnEditPartners";
            this.tsBtnEditPartners.Size = new System.Drawing.Size(150, 28);
            this.tsBtnEditPartners.Text = "Изменить партнеров";
            this.tsBtnEditPartners.Click += new System.EventHandler(this.tsBtnEditPartners_Click);
            // 
            // tsSetBaseTour
            // 
            this.tsSetBaseTour.Image = ((System.Drawing.Image)(resources.GetObject("tsSetBaseTour.Image")));
            this.tsSetBaseTour.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSetBaseTour.Name = "tsSetBaseTour";
            this.tsSetBaseTour.Size = new System.Drawing.Size(119, 28);
            this.tsSetBaseTour.Text = "Разметка туров";
            this.tsSetBaseTour.Click += new System.EventHandler(this.tsSetBaseTour_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fltBaseTour);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.fltShablon);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.fltTour);
            this.panel1.Controls.Add(this.fltCity);
            this.panel1.Controls.Add(this.fltCountry);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 49);
            this.panel1.TabIndex = 8;
            // 
            // fltBaseTour
            // 
            this.fltBaseTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fltBaseTour.DropDownWidth = 400;
            this.fltBaseTour.Location = new System.Drawing.Point(449, 15);
            this.fltBaseTour.Name = "fltBaseTour";
            this.fltBaseTour.Size = new System.Drawing.Size(200, 21);
            this.fltBaseTour.TabIndex = 9;
            this.fltBaseTour.SelectedIndexChanged += new System.EventHandler(this.fltBaseTour_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(446, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Шаблон/название тура для ваучера";
            // 
            // fltShablon
            // 
            this.fltShablon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fltShablon.Location = new System.Drawing.Point(655, 15);
            this.fltShablon.Name = "fltShablon";
            this.fltShablon.Size = new System.Drawing.Size(239, 21);
            this.fltShablon.TabIndex = 7;
            this.fltShablon.SelectedIndexChanged += new System.EventHandler(this.fltShablon_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(655, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Группа услуг для ваучера";
            // 
            // fltTour
            // 
            this.fltTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fltTour.DropDownWidth = 350;
            this.fltTour.Location = new System.Drawing.Point(266, 15);
            this.fltTour.Name = "fltTour";
            this.fltTour.Size = new System.Drawing.Size(177, 21);
            this.fltTour.TabIndex = 5;
            this.fltTour.SelectedIndexChanged += new System.EventHandler(this.fltTour_SelectedIndexChanged);
            // 
            // fltCity
            // 
            this.fltCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fltCity.Location = new System.Drawing.Point(139, 15);
            this.fltCity.Name = "fltCity";
            this.fltCity.Size = new System.Drawing.Size(121, 21);
            this.fltCity.TabIndex = 4;
            this.fltCity.SelectedIndexChanged += new System.EventHandler(this.fltCity_SelectedIndexChanged);
            // 
            // fltCountry
            // 
            this.fltCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fltCountry.Location = new System.Drawing.Point(12, 15);
            this.fltCountry.Name = "fltCountry";
            this.fltCountry.Size = new System.Drawing.Size(121, 21);
            this.fltCountry.TabIndex = 3;
            this.fltCountry.SelectedIndexChanged += new System.EventHandler(this.fltCountry_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тур";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Город";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Страна";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listPresentShablonService);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(638, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 228);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Услуги по шаблону";
            // 
            // listPresentShablonService
            // 
            this.listPresentShablonService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPresentShablonService.FormattingEnabled = true;
            this.listPresentShablonService.Location = new System.Drawing.Point(3, 16);
            this.listPresentShablonService.Name = "listPresentShablonService";
            this.listPresentShablonService.Size = new System.Drawing.Size(253, 209);
            this.listPresentShablonService.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Название тура для ваучеров:";
            // 
            // edtTourName
            // 
            this.edtTourName.Location = new System.Drawing.Point(173, 6);
            this.edtTourName.Name = "edtTourName";
            this.edtTourName.Size = new System.Drawing.Size(429, 20);
            this.edtTourName.TabIndex = 9;
            // 
            // pnlTourName
            // 
            this.pnlTourName.Controls.Add(this.edtTourName);
            this.pnlTourName.Controls.Add(this.label5);
            this.pnlTourName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTourName.Location = new System.Drawing.Point(0, 80);
            this.pnlTourName.Name = "pnlTourName";
            this.pnlTourName.Size = new System.Drawing.Size(638, 33);
            this.pnlTourName.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 308);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(897, 182);
            this.panel2.TabIndex = 11;
            this.panel2.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 490);
            this.Controls.Add(this.ResultListDGV);
            this.Controls.Add(this.pnlTourName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "frmMain";
            this.Text = "Конструктор ваучеров";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResultListDGV)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.pnlTourName.ResumeLayout(false);
            this.pnlTourName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ResultListDGV;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox fltTour;
        private System.Windows.Forms.ComboBox fltCity;
        private System.Windows.Forms.ComboBox fltCountry;
        private System.Windows.Forms.ToolStripButton tsBtnApply;
        private System.Windows.Forms.ToolStripButton tsBtnEditPartners;
        private System.Windows.Forms.ComboBox fltShablon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listPresentShablonService;
        private System.Windows.Forms.ToolStripButton tsBtnTourShow;
        private System.Windows.Forms.TextBox edtTourName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlTourName;
        private System.Windows.Forms.ToolStripButton tsBtnShowExample;
        private System.Windows.Forms.ToolStripButton tsBtnAllTours;
        private System.Windows.Forms.ComboBox fltBaseTour;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripButton tsSetBaseTour;
        private System.Windows.Forms.ToolStripButton tsBtnShowCity;
        private System.Windows.Forms.Panel panel2;
    }
}

