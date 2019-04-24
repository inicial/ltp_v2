namespace Rep22341
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fltChartes = new System.Windows.Forms.DataGridView();
            this.fltAirService = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.fltDateStartAir = new System.Windows.Forms.ToolStripComboBox();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.tsBtnOneReis = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fltChartes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fltAirService)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fltChartes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fltAirService);
            this.splitContainer1.Size = new System.Drawing.Size(692, 356);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.TabIndex = 2;
            // 
            // fltChartes
            // 
            this.fltChartes.AllowUserToAddRows = false;
            this.fltChartes.AllowUserToDeleteRows = false;
            this.fltChartes.AllowUserToResizeRows = false;
            this.fltChartes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fltChartes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.fltChartes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fltChartes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fltChartes.EnableHeadersVisualStyles = false;
            this.fltChartes.Location = new System.Drawing.Point(0, 0);
            this.fltChartes.MultiSelect = false;
            this.fltChartes.Name = "fltChartes";
            this.fltChartes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fltChartes.Size = new System.Drawing.Size(317, 356);
            this.fltChartes.TabIndex = 2;
            // 
            // fltAirService
            // 
            this.fltAirService.AllowUserToAddRows = false;
            this.fltAirService.AllowUserToDeleteRows = false;
            this.fltAirService.AllowUserToResizeRows = false;
            this.fltAirService.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fltAirService.BackgroundColor = System.Drawing.SystemColors.Control;
            this.fltAirService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fltAirService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fltAirService.EnableHeadersVisualStyles = false;
            this.fltAirService.Location = new System.Drawing.Point(0, 0);
            this.fltAirService.MultiSelect = false;
            this.fltAirService.Name = "fltAirService";
            this.fltAirService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fltAirService.Size = new System.Drawing.Size(371, 356);
            this.fltAirService.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.fltDateStartAir,
            this.tsBtnRefresh,
            this.tsBtnPrint,
            this.tsBtnOneReis});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(692, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(67, 28);
            this.toolStripLabel1.Text = "Дата рейса";
            // 
            // fltDateStartAir
            // 
            this.fltDateStartAir.Name = "fltDateStartAir";
            this.fltDateStartAir.Size = new System.Drawing.Size(121, 31);
            this.fltDateStartAir.SelectedIndexChanged += new System.EventHandler(this.fltDateStartAir_SelectedIndexChanged_1);
            // 
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.Image = global::Rep22341.Properties.Resources.Refresh;
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(132, 28);
            this.tsBtnRefresh.Text = "Обновить классы";
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsBtnRefresh_Click);
            // 
            // tsBtnPrint
            // 
            this.tsBtnPrint.Image = global::Rep22341.Properties.Resources.Print;
            this.tsBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrint.Name = "tsBtnPrint";
            this.tsBtnPrint.Size = new System.Drawing.Size(74, 28);
            this.tsBtnPrint.Text = "Печать";
            this.tsBtnPrint.Click += new System.EventHandler(this.tsBtnPrint_Click);
            // 
            // tsBtnOneReis
            // 
            this.tsBtnOneReis.Image = global::Rep22341.Properties.Resources.Contract;
            this.tsBtnOneReis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOneReis.Name = "tsBtnOneReis";
            this.tsBtnOneReis.Size = new System.Drawing.Size(162, 28);
            this.tsBtnOneReis.Text = "Билеты в одну сторону";
            this.tsBtnOneReis.Click += new System.EventHandler(this.tsBtnOneReis_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 387);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "Список туристов на рейс";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fltChartes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fltAirService)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView fltChartes;
        private System.Windows.Forms.DataGridView fltAirService;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox fltDateStartAir;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private System.Windows.Forms.ToolStripButton tsBtnPrint;
        private System.Windows.Forms.ToolStripButton tsBtnOneReis;

    }
}

