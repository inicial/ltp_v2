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
    public partial class frmGetDogovor : Form
    {
        #region Свойства
        public int? SelectedDogovorID
        {
            get
            {
                return (int?)cbDogovors.SelectedValue;                    
            }
        }
        #endregion

        #region Конструктор
        public frmGetDogovor(int prKey)
        {
            this.DialogResult = DialogResult.No;
            InitializeComponent();

            ltsDataContext lts = new ltsDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);

            var q = lts.LTP_PrtDogs.Where(x =>
                x.LTPD_PRKey == prKey
                && x.LTPD_PDKey != null
                && x.LTP_DogType.LDT_IsRoot
                && x.LTP_AccreditationCards.Count() < CardsAccountControl.MaximumCanUsedCard).OrderByDescending(x => x.LTPD_DateStart).Select(x => new { x.LTPD_DogNum, x.LTPD_Key });
            
            cbDogovors.DataSource = q;
            cbDogovors.DisplayMember = "LTPD_DogNum";
            cbDogovors.ValueMember = "LTPD_Key";

            if (q.Count() == 0)
            {
                btnOK.Enabled = false;
            }
            else
            {
                btnOK.Enabled = true;
                cbDogovors.SelectedIndex = 0;
            }
        }
        #endregion



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
