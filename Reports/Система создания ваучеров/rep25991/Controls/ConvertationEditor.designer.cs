using System;
using System.Windows.Forms;

namespace rep25991.Controls
{
    partial class ConvertationEditor
    {
        private Label lblTextBox;
        private Label lblCombobox;
        private Label lblExample;
        private TextBox edtFormat;
        private ComboBox edtVariants;
        private Button btnAddVariants;


        private void InitializeComponents()
        {
            lblTextBox = new Label();
            lblTextBox.Location = new System.Drawing.Point(48, 6);
            lblTextBox.AutoSize = true;
            lblTextBox.Text = "Формат вывода: ";

            lblCombobox = new Label();
            lblCombobox.AutoSize = true;
            lblCombobox.Location = new System.Drawing.Point(27, 67);
            lblCombobox.Text = "Возможные варианты полей:";

            lblExample = new Label();
            lblExample.AutoSize = true;
            lblExample.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            lblExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            lblExample.Location = new System.Drawing.Point(20, 88);
            lblExample.Text = "...";

            edtFormat = new TextBox();
            edtFormat.TabIndex = 1;
            edtFormat.Location = new System.Drawing.Point(189, 3);
            edtFormat.Multiline = true;
            edtFormat.Size = new System.Drawing.Size(320, 55);
            edtFormat.Leave += new EventHandler(edtFormat_Leave);
            edtFormat.KeyPress += new KeyPressEventHandler(edtFormat_KeyPress);
            edtFormat.KeyUp += new KeyEventHandler(edtFormat_KeyUp);
            edtFormat.MouseUp += new MouseEventHandler(edtFormat_MouseUp);
            edtFormat.TextChanged += new EventHandler(edtFormat_TextChanged);

            edtVariants = new ComboBox();
            edtVariants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            edtVariants.FormattingEnabled = true;
            edtVariants.Location = new System.Drawing.Point(189, 64);
            edtVariants.Size = new System.Drawing.Size(214, 21);
            edtVariants.TabIndex = 2;

            btnAddVariants = new Button();
            btnAddVariants.Location = new System.Drawing.Point(407, 64);
            btnAddVariants.Text = "Добавить";
            btnAddVariants.TabIndex = 3;
            btnAddVariants.Click += new EventHandler(btnAddVariants_Click);

            this.MinimumSize = new System.Drawing.Size(513, 179);
            this.Controls.Add(lblExample);
            this.Controls.Add(lblCombobox);
            this.Controls.Add(lblTextBox);
            this.Controls.Add(edtFormat);
            this.Controls.Add(edtVariants);
            this.Controls.Add(btnAddVariants);
        }
    }
}
