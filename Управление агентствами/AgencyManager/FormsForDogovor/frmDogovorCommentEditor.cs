using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;

namespace AgencyManager.FormsForDogovor
{
    public partial class frmDogovorCommentEditor : Form
    {
        #region Свойства
        LTP_PrtDog LtpPrtDog;
        #endregion

        public frmDogovorCommentEditor(LTP_PrtDog ltpPrtDog)
        {
            InitializeComponent();
            LtpPrtDog = ltpPrtDog;
            this.Text = "Изменение коментария у договора №" + ltpPrtDog.LTPD_DogNum;
            edtComment.Text = LtpPrtDog.LTPD_Comment;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            LtpPrtDog.LTPD_Comment = edtComment.Text;
            this.Close();
        }
    }
}
