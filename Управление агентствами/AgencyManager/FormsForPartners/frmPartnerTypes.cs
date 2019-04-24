using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;

namespace AgencyManager.FormsForPartners
{
    public partial class frmPartnerTypes : Form
    {
        #region Свойства
        PartnersListDataContext PLDC;
        tbl_Partners PIM;
        public List<PrtType> CheckedList
        {
            get
            {
                List<PrtType> result = new List<PrtType>();
                foreach (object CheckItem in cbTypePartner.CheckedItems)
                {
                    result.Add((PrtType)CheckItem);
                }
                return result;
            }
            set
            {
                if (value == null)
                    return;
                for (int i = 0; i < cbTypePartner.Items.Count; i++)
                {
                    cbTypePartner.SetItemChecked(i, (value.Where(x => x.PT_Id == ((PrtType)cbTypePartner.Items[i]).PT_Id).Count() > 0));
                }
            }
        }
        #endregion

        #region Конструктор
        public frmPartnerTypes(PartnersListDataContext pldc)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.PLDC = pldc;

            cbTypePartner.Items.Clear();
            cbTypePartner.Items.AddRange(pldc.PrtTypes.ToArray());
        }

        public frmPartnerTypes(PartnersListDataContext pldc, tbl_Partners pim)
            :this(pldc)
        {
            this.toolStripPanel.Visible = false;
            this.PIM = pim;
            this.CheckedList = pim.PrtTypesToPartners.Select(x => x.PrtType).ToList();
            this.cbTypePartner.ItemCheck += new ItemCheckEventHandler(cbTypePartner_ItemCheck);
        }
        #endregion

        #region Обработка событий
        private void cbTypePartner_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            PrtTypesToPartner partnerType = null;
            PrtType currentCheckedType = (PrtType)this.cbTypePartner.Items[e.Index];
            var partnerTypes = this.PIM.PrtTypesToPartners.Where(x => x.PTP_PTId == currentCheckedType.PT_Id);
            if (partnerTypes.Count() == 0)
            {
                foreach (var delItem in PLDC.GetChangeSet().Deletes)
                {
                    if (delItem is PrtTypesToPartner)
                    {
                        if ((delItem as PrtTypesToPartner).PTP_PTId == currentCheckedType.PT_Id)
                        {
                            partnerType = (delItem as PrtTypesToPartner);
                            break;
                        }
                    }
                }
            }
            
            if (partnerTypes.Count() > 0)
                partnerType = partnerTypes.First();

            if (partnerType != null && e.NewValue == CheckState.Unchecked)
            {
                PIM.PrtTypesToPartners.Remove(partnerType);
                PLDC.PrtTypesToPartners.DeleteOnSubmit(partnerType);
            }
            else if (partnerType != null && e.NewValue == CheckState.Checked)
            {
                PLDC.PrtTypesToPartners.InsertOnSubmit(partnerType);
                PIM.PrtTypesToPartners.Add(partnerType);
            }
            else
            {
                PrtTypesToPartner newPttp = new PrtTypesToPartner();
                newPttp.PrtType = currentCheckedType;
                PLDC.PrtTypesToPartners.InsertOnSubmit(newPttp);
                PIM.PrtTypesToPartners.Add(newPttp);
            }
        }

        private void tsBtnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion
    }
}
