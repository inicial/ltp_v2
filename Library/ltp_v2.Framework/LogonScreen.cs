using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ltp_v2.Framework
{
    public partial class LogonScreen : Form
    {
        public LogonScreen(string User, string Pass, string ApplicationName)
        {
            this.components = null;
            this.InitializeComponent();
            this.logonName.Text = User;
            this.logonPass.Text = Pass;
            SqlConnection.ConnectionProgram = ApplicationName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            this.StartAuth();
        }

        private void logonName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.StartAuth();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.StartAuth();
        }

        new public DialogResult Show()
        {
            return base.ShowDialog();
        }

        private void StartAuth()
        {
            SqlConnection.ConnectionUserName = logonName.Text;
            SqlConnection.ConnectionPassword = logonPass.Text;

            if (logonPass.Text != "")
            {
                if (SqlConnection.CheckConnectionValid())
                    base.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show(@"Не верно введен логин/пароль");
            }
            else
            {

            }
        }
    }
}

