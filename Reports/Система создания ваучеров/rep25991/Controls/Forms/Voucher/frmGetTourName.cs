using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rep25991.Controls.Forms.Voucher
{
    public partial class frmGetTourName : Form
    {
        public string TourName
        {
            get
            {
                return edtFltTourName.Text.RemoveSpace();
            }
        }

        public frmGetTourName(sqlDataContext sqlDC, int TRId)
        {
            InitializeComponent();
            edtFltTourName.DataSource = sqlDC.tbl_TurLists
                .Where(x => x.TL_KEY == TRId)
                .Select(x => x.TL_NAME)
                .Union(
                    sqlDC.tbl_TurLists
                        .Where(x => x.TL_KEY == TRId)
                        .Select(x => x.TL_NameLat)
                ).Union(
                    sqlDC.LT_V_Vouchers
                        .Where(x => x.V_TRKey == TRId)
                        .Select(x => x.V_TourName)
                ).Distinct();

            var currTourName = sqlDC.tbl_TurLists.FirstOrDefault(xTL => xTL.TL_KEY == TRId).TL_NAME.ToLower();

            edtFltTourName.SelectedItem = ((IQueryable<string>)edtFltTourName.DataSource).FirstOrDefault(x => x.ToLower().Contains(currTourName));
        }

        private void tsBtnCreate_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
