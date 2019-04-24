using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccreditationCards
{
    public partial class frmActivate : Form
    {
        private ltsDataContext Lts;
        public frmActivate(ltsDataContext lts, LTP_AccreditationCard accCard)
        {
            this.Lts = lts;
            InitializeComponent();
            clbCardForActivation.Items.Clear();
            foreach (var accItem in lts.LTP_AccreditationCards.Where(x =>
                x.LTPA_NumberZakaz == accCard.LTPA_NumberZakaz
                && x.LTPA_PrintedDate.HasValue
                && !x.LTPA_ActivationDate.HasValue).OrderBy(x => x.LTPA_CardNum))
            {
                clbCardForActivation.Items.Add(accItem);
            }
        }

        private void edtFindCardNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool isFind = false;
                for (int itemIndex = 0; itemIndex<clbCardForActivation.Items.Count; itemIndex ++)
                {
                    LTP_AccreditationCard accItem = (LTP_AccreditationCard)clbCardForActivation.Items[itemIndex];
                    if (accItem.LTPA_CardNum.ToUpper() == edtFindCardNum.Text.Trim().ToUpper())
                    {
                        clbCardForActivation.SetItemChecked(itemIndex, true);
                        isFind = true;   
                    }
                }
                edtFindCardNum.Text = "";
                if (!isFind)
                {
                    edtFindCardNum.Text = "ЗАПРАШИВАЕМЫЙ НОМЕР НЕ НАЙДЕН";
                    edtFindCardNum.SelectAll();
                }
            }
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (edtCurierName.Text.Trim() == "")
            {
                MessageBox.Show("Введите имя представителя компании получившего карты");
                return;
            }
            if (clbCardForActivation.CheckedItems.Count == 0)
            {
                MessageBox.Show("Вы невыбрали карты которые надо активировать");
                return;
            }
            for (int accItemIndex = 0; accItemIndex < clbCardForActivation.CheckedItems.Count; accItemIndex++)
            {
                LTP_AccreditationCard accItem = (LTP_AccreditationCard)clbCardForActivation.CheckedItems[accItemIndex];
                accItem.ActiveCard();
                accItem.LTPA_WhoTookCard = edtCurierName.Text.Trim();
            }
            Lts.SubmitChanges();
            this.Close();
        }
    }
}
