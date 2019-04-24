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
    public partial class frmAviaOnLine : Form
    {
        #region Свойства
        private tbl_Partners PIM;
        private PartnersListDataContext PLDC;
        #endregion

        #region Методы
        private void RefreshDataGrid()
        {
            AviaLoginsDGV.Columns.Clear();
            AviaLoginsDGV.AutoGenerateColumns = false;
            AviaLoginsDGV.DataSource = PIM.LTP_AviaAccount_IBindingList;
            AviaLoginsDGV.Columns.AddColumns("LTPA_Id", "", false);
            AviaLoginsDGV.Columns.AddColumns("LTPA_User", "Логин");
            //AviaLoginsDGV.Columns.AddColumns("LTPA_Pass", "Пароль");
            AviaLoginsDGV.Sort(AviaLoginsDGV.Columns["LTPA_User"], ListSortDirection.Ascending);
        }
        #endregion

        #region Конструктор
        public frmAviaOnLine(PartnersListDataContext pldc, tbl_Partners pim)
        {
            PIM = pim;
            PLDC = pldc;
            InitializeComponent();
            RefreshDataGrid();
        }
        #endregion

        #region Оботка событий
        void frmAviaOnLine_ParentChanged(object sender, EventArgs e)
        {
            if (!this.Disposing && ParentForm.GetType() == typeof(FormsForPartners.frmSendMail))
            {
                tsButtonMenu.Visible = false;
            }
        }

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            frmGenerateLoginPass fgLP = new frmGenerateLoginPass(frmGenerateLoginPass.ViewEditTB.Login, PIM.PR_KEY, "");
            fgLP.AfterGeneratePass += new EventHandler(fgLP_AfterGeneratePass);
            if (fgLP.ShowDialog() == DialogResult.OK)
            {
                LTP_AviaAccount newAA = new LTP_AviaAccount();
                newAA.LTPA_Pass = fgLP.Login;
                newAA.LTPA_User = fgLP.Login;
                PIM.LTP_AviaAccount_IBindingList.Add(newAA);
            }
        }

        public void fgLP_AfterGeneratePass(object sender, EventArgs e)
        {
            if (PIM.LTP_AviaAccounts.Where(x => x.LTPA_User.ToLower().Trim() == ((frmGenerateLoginPass)sender).Login.ToLower().Trim()).Count() > 0
                || PLDC.LTP_AviaAccounts.Where(x => x.LTPA_User.ToLower().Trim() == ((frmGenerateLoginPass)sender).Login.ToLower().Trim()).Count() > 0)
            {
                ((frmGenerateLoginPass)sender).PresentError = true;
            }
        }
        #endregion
    }
}
