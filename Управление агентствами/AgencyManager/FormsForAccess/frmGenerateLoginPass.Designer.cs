namespace AgencyManager.FormsForAccess
{
    partial class frmGenerateLoginPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerateLoginPass));
            this.lbLogin = new System.Windows.Forms.Label();
            this.lbPass = new System.Windows.Forms.Label();
            this.edtLogin = new System.Windows.Forms.TextBox();
            this.edtPass = new System.Windows.Forms.TextBox();
            this.edtFIO = new System.Windows.Forms.TextBox();
            this.lbFIO = new System.Windows.Forms.Label();
            this.edtSuperUser = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tsButtonMenu = new System.Windows.Forms.ToolStrip();
            this.btnGenerateNew = new System.Windows.Forms.ToolStripButton();
            this.btnOK = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            this.tsButtonMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Location = new System.Drawing.Point(23, 7);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(41, 13);
            this.lbLogin.TabIndex = 0;
            this.lbLogin.Text = "Логин:";
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Location = new System.Drawing.Point(16, 31);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(48, 13);
            this.lbPass.TabIndex = 1;
            this.lbPass.Text = "Пароль:";
            // 
            // edtLogin
            // 
            this.edtLogin.Location = new System.Drawing.Point(70, 4);
            this.edtLogin.Name = "edtLogin";
            this.edtLogin.Size = new System.Drawing.Size(265, 20);
            this.edtLogin.TabIndex = 0;
            this.edtLogin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtLogin_KeyUp);
            this.edtLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtLogin_KeyPress);
            // 
            // edtPass
            // 
            this.edtPass.Location = new System.Drawing.Point(70, 27);
            this.edtPass.Name = "edtPass";
            this.edtPass.ReadOnly = true;
            this.edtPass.Size = new System.Drawing.Size(265, 20);
            this.edtPass.TabIndex = 1;
            // 
            // edtFIO
            // 
            this.edtFIO.Location = new System.Drawing.Point(70, 50);
            this.edtFIO.Name = "edtFIO";
            this.edtFIO.Size = new System.Drawing.Size(265, 20);
            this.edtFIO.TabIndex = 2;
            // 
            // lbFIO
            // 
            this.lbFIO.AutoSize = true;
            this.lbFIO.Location = new System.Drawing.Point(27, 54);
            this.lbFIO.Name = "lbFIO";
            this.lbFIO.Size = new System.Drawing.Size(37, 13);
            this.lbFIO.TabIndex = 7;
            this.lbFIO.Text = "ФИО:";
            // 
            // edtSuperUser
            // 
            this.edtSuperUser.AutoSize = true;
            this.edtSuperUser.Location = new System.Drawing.Point(70, 80);
            this.edtSuperUser.Name = "edtSuperUser";
            this.edtSuperUser.Size = new System.Drawing.Size(109, 17);
            this.edtSuperUser.TabIndex = 8;
            this.edtSuperUser.Text = "Главный пароль";
            this.edtSuperUser.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.lbLogin);
            this.panel2.Controls.Add(this.lbPass);
            this.panel2.Controls.Add(this.edtLogin);
            this.panel2.Controls.Add(this.edtSuperUser);
            this.panel2.Controls.Add(this.edtPass);
            this.panel2.Controls.Add(this.edtFIO);
            this.panel2.Controls.Add(this.lbFIO);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 100);
            this.panel2.TabIndex = 11;
            // 
            // tsButtonMenu
            // 
            this.tsButtonMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsButtonMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGenerateNew,
            this.btnCancel,
            this.btnOK});
            this.tsButtonMenu.Location = new System.Drawing.Point(0, 0);
            this.tsButtonMenu.Name = "tsButtonMenu";
            this.tsButtonMenu.Size = new System.Drawing.Size(358, 31);
            this.tsButtonMenu.TabIndex = 14;
            this.tsButtonMenu.Text = "toolStrip1";
            // 
            // btnGenerateNew
            // 
            this.btnGenerateNew.Image = global::AgencyManager.Properties.Resources.Refresh;
            this.btnGenerateNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenerateNew.Name = "btnGenerateNew";
            this.btnGenerateNew.Size = new System.Drawing.Size(72, 28);
            this.btnGenerateNew.Text = "Другой";
            this.btnGenerateNew.Click += new System.EventHandler(this.btnGenerateNew_Click);
            // 
            // btnOK
            // 
            this.btnOK.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnOK.Image = global::AgencyManager.Properties.Resources.Save2;
            this.btnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 28);
            this.btnOK.Text = "Создать";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 28);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmGenerateLoginPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(358, 208);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tsButtonMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGenerateLoginPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генерация пароля:";
            this.Shown += new System.EventHandler(this.frmGenerateLoginPass_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tsButtonMenu.ResumeLayout(false);
            this.tsButtonMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.TextBox edtLogin;
        private System.Windows.Forms.TextBox edtPass;
        private System.Windows.Forms.TextBox edtFIO;
        private System.Windows.Forms.Label lbFIO;
        private System.Windows.Forms.CheckBox edtSuperUser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip tsButtonMenu;
        private System.Windows.Forms.ToolStripButton btnGenerateNew;
        private System.Windows.Forms.ToolStripButton btnOK;
        private System.Windows.Forms.ToolStripButton btnCancel;
    }
}