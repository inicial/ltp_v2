namespace TLW.SpamMashine.Forms
{
    partial class frmSQLEditor
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.edtExtBody = new ltp_v2.Controls.Forms.lwTextBoxHighlightSyntex();
            this.edtSQLCommand = new ltp_v2.Controls.Forms.lwTextBoxHighlightSyntex();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edtSqlID = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteSQL = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edtRequiredPresent = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.edtExtBody, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.edtSQLCommand, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.edtSqlID, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 307);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // edtExtBody
            // 
            this.edtExtBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtExtBody.Location = new System.Drawing.Point(153, 169);
            this.edtExtBody.Name = "edtExtBody";
            this.edtExtBody.Size = new System.Drawing.Size(336, 135);
            this.edtExtBody.TabIndex = 6;
            this.edtExtBody.Text = "";
            // 
            // edtSQLCommand
            // 
            this.edtSQLCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtSQLCommand.Location = new System.Drawing.Point(153, 29);
            this.edtSQLCommand.Name = "edtSQLCommand";
            this.edtSQLCommand.Size = new System.Drawing.Size(336, 134);
            this.edtSQLCommand.TabIndex = 5;
            this.edtSQLCommand.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(52, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Код SQL запроса %SQL#....%";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(79, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 140);
            this.label2.TabIndex = 2;
            this.label2.Text = "SQL Запрос";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(59, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 141);
            this.label3.TabIndex = 3;
            this.label3.Text = "Тело обработки";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtSqlID
            // 
            this.edtSqlID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtSqlID.Location = new System.Drawing.Point(153, 3);
            this.edtSqlID.Name = "edtSqlID";
            this.edtSqlID.Size = new System.Drawing.Size(336, 20);
            this.edtSqlID.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(104, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleteSQL
            // 
            this.btnDeleteSQL.Location = new System.Drawing.Point(12, 12);
            this.btnDeleteSQL.Name = "btnDeleteSQL";
            this.btnDeleteSQL.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSQL.TabIndex = 24;
            this.btnDeleteSQL.Text = "Удалить";
            this.btnDeleteSQL.UseVisualStyleBackColor = true;
            this.btnDeleteSQL.Click += new System.EventHandler(this.btnDeleteSQL_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edtRequiredPresent);
            this.panel1.Controls.Add(this.btnDeleteSQL);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 307);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 47);
            this.panel1.TabIndex = 25;
            // 
            // edtRequiredPresent
            // 
            this.edtRequiredPresent.AutoSize = true;
            this.edtRequiredPresent.Location = new System.Drawing.Point(212, 16);
            this.edtRequiredPresent.Name = "edtRequiredPresent";
            this.edtRequiredPresent.Size = new System.Drawing.Size(140, 17);
            this.edtRequiredPresent.TabIndex = 25;
            this.edtRequiredPresent.Text = "Обязательный запрос";
            this.edtRequiredPresent.UseVisualStyleBackColor = true;
            // 
            // frmSQLEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 354);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "frmSQLEditor";
            this.Text = "frmSQLEditor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ltp_v2.Controls.Forms.lwTextBoxHighlightSyntex edtExtBody;
        private ltp_v2.Controls.Forms.lwTextBoxHighlightSyntex edtSQLCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtSqlID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeleteSQL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox edtRequiredPresent;
    }
}