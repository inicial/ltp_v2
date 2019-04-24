using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ltp_v2.Framework;
using AgencyManager.ObjectModel;

namespace AgencyManager.FormsForAccess
{
    public partial class frmGenerateLoginPass : Form
    {
        #region Перечисления
        public enum ViewEditTB : int
        {
            Login = 0x00001,
            Pass = 0x00010,
            FIO = 0x00100,
            SuperUser = 0x01000,
            Full = 0x11111
        }
        #endregion

        #region Свойства
        /// <summary>
        /// Идентификатор о наличие ошибки
        /// </summary>
        public bool PresentError
        {
            set
            {
                edtLogin.BackColor = SystemColors.Window;
                btnOK.Enabled = true;
                if (!value)
                {
                    return;
                }
                AddsToUserKey++;
                btnOK.Enabled = false;
                if (!ManualChange)
                {
                    GenerateNewLogin();
                    AddsToUserKey = -2;
                }
                else
                    edtLogin.BackColor = Color.Red;
            }
        }

        private bool ManualChange = false;
        private int PRKey;
        private int AddsToUserKey = -2;
        public string Login
        {
            get { return edtLogin.Text; }
        }
        public string Password
        {
            get { return edtPass.Text; }
        }
        public string ManagerName
        {
            get { return edtFIO.Text; }
        }
        public bool SuperUser
        {
            get { return edtSuperUser.Checked; }
        }
        #endregion

        #region События
        public event EventHandler AfterGeneratePass;
        #endregion

        #region Методы
        private void OnAfterGeneratePass()
        {
            this.PresentError = false;
            AfterGeneratePass(this, null);
        }

        private void GenerateNewLogin()
        {
            ManualChange = false;
            Random random = new Random();
            string NewUKey = PRKey.ToString();
            while (NewUKey.Length < 5)
                NewUKey = "0" + NewUKey;

            this.edtLogin.Text = ltp_v2.Framework.ExtensionMethods.EncriptIntValue('U' + NewUKey) + (
                (this.AddsToUserKey > 0)
                    ? this.AddsToUserKey.ToString()
                    : "");
            this.edtPass.Text = ltp_v2.Framework.ExtensionMethods.EncriptIntValue(random.Next(0x989680, 0x2faf080).ToString());
            this.OnAfterGeneratePass();
        }
        #endregion

        #region Инициализация
        public frmGenerateLoginPass(ViewEditTB vetb, int prKey, string managerName)
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Abort;
            lbLogin.Visible = edtLogin.Visible = ((vetb & ViewEditTB.Login) == ViewEditTB.Login);
            lbPass.Visible = edtPass.Visible = ((vetb & ViewEditTB.Pass) == ViewEditTB.Pass);
            lbFIO.Visible = edtFIO.Visible = ((vetb & ViewEditTB.FIO) == ViewEditTB.FIO);
            edtSuperUser.Visible = ((vetb & ViewEditTB.SuperUser) == ViewEditTB.SuperUser);

            this.PRKey = prKey;
            this.edtFIO.Text = managerName;
        }
        #endregion

        #region Обработка событий

        private void btnGenerateNew_Click(object sender, EventArgs e)
        {
            GenerateNewLogin();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (edtFIO.Visible && edtFIO.Text.Trim() == "")
            {
                MessageBox.Show("Введите ФИО");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void edtLogin_KeyUp(object sender, KeyEventArgs e)
        {
            ManualChange = true;
            if (edtLogin.Text.Length < 5)
                PresentError = true;
            else
                this.OnAfterGeneratePass();
        }

        private void frmGenerateLoginPass_Shown(object sender, EventArgs e)
        {
            GenerateNewLogin();
        }

        private void edtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.KeyChar = 'X';
        }
        #endregion
    }
}
