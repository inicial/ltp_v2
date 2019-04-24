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

namespace AgencyManager.FormsForAccounts
{
    public partial class frmBanks : Form
    {
        #region Свойства
        public Bank SelectedBank;
        PartnersListDataContext CurrentUsePLDC;
        #endregion

        public frmBanks(PartnersListDataContext currentUsePLDC, Bank FindBank)
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Abort;

            this.CurrentUsePLDC = currentUsePLDC;

            BanksDGV.AutoGenerateColumns = false;
            BanksDGV.Columns.Clear();
            BanksDGV.Columns.AddColumns("BN_Name", "Название банка");
            BanksDGV.DataSource = currentUsePLDC.Banks.Where(x => x.BN_Name != "").OrderBy(x => x.BN_Name);

            edtFindBankName.Text = FindBank.BN_Name;
            edtFindKS.Text = FindBank.BN_CorAccount;
            edtFindBIK.Text = FindBank.BN_BIK;
            edtFltBankName.Text = FindBank.BN_Name;
        }

        private void dgBanks_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedBank = (Bank)BanksDGV.Rows[e.RowIndex].DataBoundItem;
            edtBankName.Text = SelectedBank.BN_Name;
            edtBIK.DefaultText = SelectedBank.BN_BIK;
            edtKS.DefaultText = SelectedBank.BN_CorAccount;

            edtFindBankName.Font = new Font(edtFindBankName.Font, (edtFindBankName.Text != edtBankName.Text) ? FontStyle.Bold : FontStyle.Regular);
            edtFindKS.Font = new Font(edtFindKS.Font, (edtFindKS.Text != edtKS.Text) ? FontStyle.Bold : FontStyle.Regular);
            edtFindBIK.Font = new Font(edtFindBIK.Font, (edtFindBIK.Text != edtBIK.Text) ? FontStyle.Bold : FontStyle.Regular);
        }

        private void edtFltBankName_TextChanged(object sender, EventArgs e)
        {
            BanksDGV.DataSource = CurrentUsePLDC.Banks
                .Where(x => (edtFindBIK.Text == "" || x.BN_BIK.Contains(edtFindBIK.Text))
                && (edtFindKS.Text == "" || x.BN_CorAccount.Contains(edtFindKS.Text))
                && (edtFltBankName.Text == "" || x.BN_Name.Contains(edtFltBankName.Text)))
                .OrderBy(x=>x.BN_Name);
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            if (SelectedBank != null)
                this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Bank newBank = new Bank();
            newBank.BN_Name = edtFindBankName.Text;
            newBank.BN_BIK = edtFindBIK.Text;
            newBank.BN_CorAccount = edtFindKS.Text;
            CurrentUsePLDC.Banks.InsertOnSubmit(newBank);
            SelectedBank = newBank;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
