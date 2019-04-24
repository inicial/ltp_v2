namespace rep25991.Controls.Forms.Configuration
{
    partial class frmConfigureShablons
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fltCountry = new System.Windows.Forms.ComboBox();
            this.fltVTour = new System.Windows.Forms.ComboBox();
            this.fltShablons = new System.Windows.Forms.ComboBox();
            this.fltShablonServices = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fltServices = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtMany = new System.Windows.Forms.CheckBox();
            this.edtComment = new System.Windows.Forms.CheckBox();
            this.edtGroup = new System.Windows.Forms.CheckBox();
            this.edtLine = new System.Windows.Forms.TextBox();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnSetShablonToTour = new System.Windows.Forms.Button();
            this.fltFormat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFormatOut = new System.Windows.Forms.Label();
            this.lblListUsedShablons = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(499, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Страна:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Тур (ваучера):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Шаблон:";
            // 
            // fltCountry
            // 
            this.fltCountry.FormattingEnabled = true;
            this.fltCountry.Location = new System.Drawing.Point(551, 5);
            this.fltCountry.Name = "fltCountry";
            this.fltCountry.Size = new System.Drawing.Size(232, 21);
            this.fltCountry.TabIndex = 3;
            this.fltCountry.SelectedIndexChanged += new System.EventHandler(this.fltCountry_SelectedIndexChanged);
            // 
            // fltVTour
            // 
            this.fltVTour.FormattingEnabled = true;
            this.fltVTour.Location = new System.Drawing.Point(582, 39);
            this.fltVTour.Name = "fltVTour";
            this.fltVTour.Size = new System.Drawing.Size(201, 21);
            this.fltVTour.TabIndex = 4;
            this.fltVTour.SelectedIndexChanged += new System.EventHandler(this.fltVTour_SelectedIndexChanged);
            // 
            // fltShablons
            // 
            this.fltShablons.FormattingEnabled = true;
            this.fltShablons.Location = new System.Drawing.Point(76, 5);
            this.fltShablons.Name = "fltShablons";
            this.fltShablons.Size = new System.Drawing.Size(232, 21);
            this.fltShablons.TabIndex = 5;
            this.fltShablons.SelectedIndexChanged += new System.EventHandler(this.fltShablons_SelectedIndexChanged);
            // 
            // fltShablonServices
            // 
            this.fltShablonServices.FormattingEnabled = true;
            this.fltShablonServices.Location = new System.Drawing.Point(24, 37);
            this.fltShablonServices.Name = "fltShablonServices";
            this.fltShablonServices.Size = new System.Drawing.Size(283, 264);
            this.fltShablonServices.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Шаблон:";
            // 
            // fltServices
            // 
            this.fltServices.FormattingEnabled = true;
            this.fltServices.Location = new System.Drawing.Point(75, 311);
            this.fltServices.Name = "fltServices";
            this.fltServices.Size = new System.Drawing.Size(232, 21);
            this.fltServices.TabIndex = 8;
            this.fltServices.SelectedIndexChanged += new System.EventHandler(this.fltServices_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Линия:";
            // 
            // edtMany
            // 
            this.edtMany.AutoSize = true;
            this.edtMany.Location = new System.Drawing.Point(118, 340);
            this.edtMany.Name = "edtMany";
            this.edtMany.Size = new System.Drawing.Size(44, 17);
            this.edtMany.TabIndex = 10;
            this.edtMany.Text = "1/X";
            this.edtMany.UseVisualStyleBackColor = true;
            // 
            // edtComment
            // 
            this.edtComment.AutoSize = true;
            this.edtComment.Location = new System.Drawing.Point(168, 340);
            this.edtComment.Name = "edtComment";
            this.edtComment.Size = new System.Drawing.Size(70, 17);
            this.edtComment.TabIndex = 11;
            this.edtComment.Text = "Comment";
            this.edtComment.UseVisualStyleBackColor = true;
            // 
            // edtGroup
            // 
            this.edtGroup.AutoSize = true;
            this.edtGroup.Location = new System.Drawing.Point(238, 340);
            this.edtGroup.Name = "edtGroup";
            this.edtGroup.Size = new System.Drawing.Size(55, 17);
            this.edtGroup.TabIndex = 12;
            this.edtGroup.Text = "Group";
            this.edtGroup.UseVisualStyleBackColor = true;
            // 
            // edtLine
            // 
            this.edtLine.Location = new System.Drawing.Point(62, 337);
            this.edtLine.Name = "edtLine";
            this.edtLine.Size = new System.Drawing.Size(50, 20);
            this.edtLine.TabIndex = 13;
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(128, 390);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(82, 23);
            this.btnAddService.TabIndex = 14;
            this.btnAddService.Text = "Добавить";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnSetShablonToTour
            // 
            this.btnSetShablonToTour.Location = new System.Drawing.Point(313, 69);
            this.btnSetShablonToTour.Name = "btnSetShablonToTour";
            this.btnSetShablonToTour.Size = new System.Drawing.Size(181, 23);
            this.btnSetShablonToTour.TabIndex = 15;
            this.btnSetShablonToTour.Text = "Привязать шаблон к туру";
            this.btnSetShablonToTour.UseVisualStyleBackColor = true;
            this.btnSetShablonToTour.Click += new System.EventHandler(this.btnSetShablonToTour_Click);
            // 
            // fltFormat
            // 
            this.fltFormat.FormattingEnabled = true;
            this.fltFormat.Location = new System.Drawing.Point(76, 363);
            this.fltFormat.Name = "fltFormat";
            this.fltFormat.Size = new System.Drawing.Size(232, 21);
            this.fltFormat.TabIndex = 17;
            this.fltFormat.SelectedIndexChanged += new System.EventHandler(this.fltFormat_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 366);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Формат:";
            // 
            // lblFormatOut
            // 
            this.lblFormatOut.AutoSize = true;
            this.lblFormatOut.Location = new System.Drawing.Point(341, 311);
            this.lblFormatOut.Name = "lblFormatOut";
            this.lblFormatOut.Size = new System.Drawing.Size(35, 13);
            this.lblFormatOut.TabIndex = 18;
            this.lblFormatOut.Text = "label7";
            // 
            // lblListUsedShablons
            // 
            this.lblListUsedShablons.FormattingEnabled = true;
            this.lblListUsedShablons.Location = new System.Drawing.Point(500, 69);
            this.lblListUsedShablons.Name = "lblListUsedShablons";
            this.lblListUsedShablons.Size = new System.Drawing.Size(283, 160);
            this.lblListUsedShablons.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(874, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 51);
            this.button1.TabIndex = 20;
            this.button1.Text = "Выписка ваучеров";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(789, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "< Удалить выбранное";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmConfigureShablons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 435);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblListUsedShablons);
            this.Controls.Add(this.lblFormatOut);
            this.Controls.Add(this.fltFormat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSetShablonToTour);
            this.Controls.Add(this.btnAddService);
            this.Controls.Add(this.edtLine);
            this.Controls.Add(this.edtGroup);
            this.Controls.Add(this.edtComment);
            this.Controls.Add(this.edtMany);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fltServices);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fltShablonServices);
            this.Controls.Add(this.fltShablons);
            this.Controls.Add(this.fltVTour);
            this.Controls.Add(this.fltCountry);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmConfigureShablons";
            this.Text = "frmConfigureShablons";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox fltCountry;
        private System.Windows.Forms.ComboBox fltVTour;
        private System.Windows.Forms.ComboBox fltShablons;
        private System.Windows.Forms.ListBox fltShablonServices;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox fltServices;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox edtMany;
        private System.Windows.Forms.CheckBox edtComment;
        private System.Windows.Forms.CheckBox edtGroup;
        private System.Windows.Forms.TextBox edtLine;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnSetShablonToTour;
        private System.Windows.Forms.ComboBox fltFormat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFormatOut;
        private System.Windows.Forms.ListBox lblListUsedShablons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}