using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;
using ltp_v2.Framework;

namespace AgencyManager.FormsForPartners
{
    public partial class frmSetDogovorTypes : Form
    {
        public List<PrtDogTypes> CheckedList
        {
            get 
            {
                List<PrtDogTypes> result = new List<PrtDogTypes>();
                foreach (object CheckItem in edt_Filter_DogovorType.CheckedItems)
                {
                    result.Add((PrtDogTypes)CheckItem);
                }
                return result;
            }
            set
            {
                if (value == null)
                    return;
                for (int i = 0; i < edt_Filter_DogovorType.Items.Count; i++)
                {
                    edt_Filter_DogovorType.SetItemChecked(i, (value.Where(x => x.PDT_ID == ((PrtDogTypes)edt_Filter_DogovorType.Items[i]).PDT_ID).Count() > 0));
                }
            }
        }

        public frmSetDogovorTypes()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            PartnersListDataContext PLDC = new PartnersListDataContext(SqlConnection.ConnectionData);
            edt_Filter_DogovorType.Items.Clear();
            edt_Filter_DogovorType.Items.AddRange(PLDC.PrtDogTypes.SetPermissionFilter().OrderBy(x => x.PDT_ID).ToArray());
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
    }
}
