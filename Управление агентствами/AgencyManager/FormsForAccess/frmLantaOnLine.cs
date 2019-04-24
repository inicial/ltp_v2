using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;
using ltp_v2.Controls;

namespace AgencyManager.FormsForAccess
{
    public partial class frmLantaOnLine : Form
    {
        #region Свойства
        private tbl_Partners PIM;
        private PartnersListDataContext PLDC;
        public DUP_USER LastCreatedLoginPass;
        #endregion

        #region Методы
        private void RefreshDataGrid()
        {
            OnLineLoginsDGV.Columns.Clear();
            OnLineLoginsDGV.AutoGenerateColumns = false;
            OnLineLoginsDGV.DataSource = PIM.DUP_USERs.Where(x => x.US_ID != null).ToList();
            OnLineLoginsDGV.Columns.AddColumns("US_Key", "", false);
            OnLineLoginsDGV.Columns.AddColumns("US_ID", "Логин");
            OnLineLoginsDGV.Columns.AddColumns("Active", "Активный", typeof(Boolean));
            if (ltp_v2.Framework.SqlConnection.ConnectionUserName.ToLower() == "sa" ||
                ltp_v2.Framework.SqlConnection.ConnectionUserName.ToLower() == "sysadm")
            {
                OnLineLoginsDGV.Columns.AddColumns("US_PASSWORD_EncryptDecrypt", "Пароль");
            }
            OnLineLoginsDGV.Columns.AddColumns("US_FullName", "ФИО Контактного лица");
            OnLineLoginsDGV.Columns.AddColumns("US_SuperUser", "Основной пароль", typeof(bool));
            //OnLineLoginsDGV.Sort(OnLineLoginsDGV.Columns["US_ID"], ListSortDirection.Ascending);
            OnLineLoginsDGV_DataBindingComplete(OnLineLoginsDGV, null);
        }

        private void MoveValuesToDB(bool SuperUser, string Login, string Password, string ManagerName)
        {
            if (SuperUser)
            {
                foreach (DUP_USER DUItemTmp in PIM.DUP_USERs)
                {
                    if (DUItemTmp.Us_Superuser.Value)
                        DUItemTmp.Us_Superuser = false;
                }
            }

            var q = PIM.LTP_PrtDogs.Where(x =>
                x.PrtDogTypes.LTP_DogType.LDT_IsRoot
                && x.LTPD_PDKey.HasValue
                && x.LTPD_DateEnd.Date >= DateTime.Now.Date);
            int ActiveState = (q.Count() > 0 ? 1 : 0);

            DUP_USER newDU = new DUP_USER();
            newDU.US_TYPE = 0;
            newDU.US_ID = Login.Trim();
            newDU.US_PASSWORD_EncryptDecrypt = Password.Trim();
            newDU.US_PRKEY = PIM.PR_KEY;
            newDU.US_COMPANYNAME = PIM.PR_NAME;
            newDU.US_PHONE = (PIM.PR_PHONES.Length > 50 ? PIM.PR_PHONES.Substring(0, 48) : PIM.PR_PHONES);
            newDU.US_ADDRESS = PIM.PR_ADRESS;
            newDU.US_FAX = PIM.PR_FAX;
            newDU.US_EMAIL = PIM.PR_EMAIL;

            newDU.US_REG = ActiveState;
            newDU.US_TURAGENT = ActiveState;
            newDU.US_AGENT = ActiveState.ToString();

            newDU.US_FULLNAME = ManagerName.Trim();
            newDU.Us_Superuser = SuperUser;
            newDU.US_Attribute = 1;
            PIM.DUP_USERs.Add(newDU);
            LastCreatedLoginPass = newDU;

        }
        #endregion

        #region Конструктор
        public frmLantaOnLine(PartnersListDataContext pldc, tbl_Partners pim, LTP_TempUser TempUser)
            : this(pldc, pim)
        {
            gbCreateLoginPass.Visible = true;
            tsButtonMenu.Visible = false;
            frmGenerateLoginPass fGLP = new frmGenerateLoginPass(frmGenerateLoginPass.ViewEditTB.Full, pim.PR_KEY, TempUser.FullName);
            fGLP.AfterGeneratePass += new EventHandler(fgLP_AfterGeneratePass);
            fGLP.TopLevel = false;
            fGLP.FormBorderStyle = FormBorderStyle.None;
            fGLP.FormClosed += new FormClosedEventHandler(fGLP_FormClosed);
            gbCreateLoginPass.Controls.Add(fGLP);
            fGLP.Show();
            fGLP.Dock = DockStyle.Fill;
        }

        public frmLantaOnLine(PartnersListDataContext pldc, tbl_Partners pim)
        {
            PIM = pim;
            PLDC = pldc;
            InitializeComponent();
            gbCreateLoginPass.Visible = false;
            RefreshDataGrid();
            this.Text += pim.NameForForms;
        }
        #endregion

        #region Обработка событий
        private void frmLantaOnLine_ParentChanged(object sender, EventArgs e)
        {
            if (!this.Disposing && ParentForm.GetType() == typeof(FormsForPartners.frmSendMail))
            {
                tsButtonMenu.Visible = false;
            }
        }

        private void OnLineLoginsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (OnLineLoginsDGV.Rows.Count == 0)
                return;
            if (OnLineLoginsDGV.SelectedRows.Count == 0)
                OnLineLoginsDGV.Rows[0].Selected = true;
            OnLineLoginsDGV_RowEnter(sender, new DataGridViewCellEventArgs(0, OnLineLoginsDGV.Rows.IndexOf(OnLineLoginsDGV.SelectedRows[0])));

            foreach (DataGridViewRow dgvr in OnLineLoginsDGV.Rows)
            {
                Label useLblLegend = lblLegendActive;
                DUP_USER DUItemTmp = (DUP_USER)dgvr.DataBoundItem;
                if (!DUItemTmp.Active)
                    useLblLegend = lblLegendNotActive;
                if (PLDC.GetChangeSet().Inserts.IndexOf(DUItemTmp) >= 0)
                    useLblLegend = lblLegendNew;
                if (PLDC.GetChangeSet().Deletes.IndexOf(DUItemTmp) >= 0)
                    useLblLegend = lblLegendDelete;

                dgvr.DefaultCellStyle.ForeColor = useLblLegend.ForeColor;
                dgvr.DefaultCellStyle.BackColor = useLblLegend.BackColor;
                dgvr.DefaultCellStyle.Font = useLblLegend.Font;
                if (useLblLegend.ForeColor.ToArgb() == OnLineLoginsDGV.DefaultCellStyle.ForeColor.ToArgb())
                    dgvr.DefaultCellStyle.SelectionForeColor = OnLineLoginsDGV.DefaultCellStyle.SelectionForeColor;
                else
                    dgvr.DefaultCellStyle.SelectionForeColor = useLblLegend.ForeColor;
            }
            OnLineLoginsDGV.Refresh();
        }

        private void OnLineLoginsDGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.tsBtnBlock.Enabled = false;
            this.tsBtnSetAdminPass.Enabled = false;

            if (OnLineLoginsDGV.SelectedRows.Count > 0)
            {
                DUP_USER DUItemTmp = (DUP_USER)OnLineLoginsDGV.Rows[e.RowIndex].DataBoundItem;
                tsBtnDelete.Enabled = false;
                tsBtnDelete.Text = "Удалить";

                if (PLDC.GetChangeSet().Deletes.IndexOf(DUItemTmp) >= 0)
                    tsBtnDelete.Text = "Отменить удаление";
                else
                {
                    if (DUItemTmp.Us_Superuser != null && !DUItemTmp.Us_Superuser.Value)
                        this.tsBtnSetAdminPass.Enabled = true;

                    if (PLDC.GetChangeSet().Inserts.IndexOf(DUItemTmp) >= 0)
                        return;

                    this.tsBtnBlock.Enabled = true;

                    if ((bool)DUItemTmp.Active)
                        this.tsBtnBlock.Text = "Блокировать";
                    else
                        this.tsBtnBlock.Text = "Разблокировать";
                }

                tsBtnDelete.Enabled = true;
            }
        }

        private void tsBtnSetAdminPass_Click(object sender, EventArgs e)
        {
            foreach (DUP_USER duItem in PIM.DUP_USERs)
            {
                if (duItem.Us_Superuser.Value)
                    duItem.Us_Superuser = false;
                if (duItem.US_KEY == (int)OnLineLoginsDGV.SelectedRows[0].Cells["US_Key"].Value)
                    duItem.Us_Superuser = true;
            }
        }

        private void tsBtnBlock_Click(object sender, EventArgs e)
        {
            DUP_USER DUItemTmp = (DUP_USER)OnLineLoginsDGV.SelectedRows[0].DataBoundItem;
            DUItemTmp.Active = !DUItemTmp.Active;
            OnLineLoginsDGV_DataBindingComplete(OnLineLoginsDGV, null);
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            DUP_USER duItemTmp = (DUP_USER)OnLineLoginsDGV.SelectedRows[0].DataBoundItem;
            if (tsBtnDelete.Text == "Удалить")
                PLDC.DUP_USERs.DeleteOnSubmit(duItemTmp);
            else
                PLDC.DUP_USERs.InsertOnSubmit(duItemTmp);
            OnLineLoginsDGV_DataBindingComplete(OnLineLoginsDGV, null);
        }

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            string ManagerName = PIM.PR_BOSSNAME;

            frmGenerateLoginPass fgLP = new frmGenerateLoginPass(frmGenerateLoginPass.ViewEditTB.Full, PIM.PR_KEY, ManagerName);

            fgLP.AfterGeneratePass += new EventHandler(fgLP_AfterGeneratePass);
            if (fgLP.ShowDialog() == DialogResult.OK)
            {
                MoveValuesToDB(fgLP.SuperUser, fgLP.Login, fgLP.Password, fgLP.ManagerName);
            }
        }

        public void fgLP_AfterGeneratePass(object sender, EventArgs e)
        {
            if (PIM.DUP_USERs.Any(x => x.US_ID != null && x.US_ID.ToLower().Trim() == ((frmGenerateLoginPass)sender).Login.ToLower().Trim())
                || PLDC.DUP_USERs.Any(x => x.US_ID != null && x.US_ID.ToLower().Trim() == ((frmGenerateLoginPass)sender).Login.ToLower().Trim()))
            {
                ((frmGenerateLoginPass)sender).PresentError = true;
            }
        }

        public void fGLP_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGenerateLoginPass fgLP = (frmGenerateLoginPass)sender;
            if (fgLP.DialogResult == DialogResult.OK)
            {
                MoveValuesToDB(fgLP.SuperUser, fgLP.Login, fgLP.Password, fgLP.ManagerName);
            }
            this.Close();
        }
        #endregion
    }
}
