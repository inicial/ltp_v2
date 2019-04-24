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

namespace AgencyManager.FormsForDogovor
{
    public partial class frmSigningDogovors : Form
    {
        #region Свойства
        private LTP_PrtDog CurrentDogovorUse = null;
        private string LastDogNum = "";
        private static string messageDogNum = "Введите № договора, нажмите Enter";
        private bool IsNeedSave = false;
        private PartnersListDataContext _PLDC;
        private PartnersListDataContext PLDC
        {
            get { return _PLDC; }
            set
            {
                if (_PLDC != null)
                    _PLDC.Dispose();
                _PLDC = value;
            }
        }
        #endregion
         
        public frmSigningDogovors(PartnersListDataContext currentUsePLDC)
        {
            this.PLDC = currentUsePLDC;
            IsNeedSave = false;
            InitializeComponent();
            this.edtDogovorNum.Text = messageDogNum;
        }

        public frmSigningDogovors()
            : this(new PartnersListDataContext(SqlConnection.ConnectionData))
        {
            IsNeedSave = true;
        }

        private void edtDogovorNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (edtDogovorNum.Text == messageDogNum)
            {
                edtDogovorNum.SelectAll();
            }
        }

        private void edtDogovorNum_TextChanged(object sender, EventArgs e)
        {
            if (edtDogovorNum.Text == messageDogNum)
                edtDogovorNum.ForeColor = Color.Gray;
            else
                edtDogovorNum.ForeColor = SystemColors.ControlText;
        }

        private void edtDogovorNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (edtDogovorNum.Text.Trim() == "")
            {
                edtDogovorNum.Text = messageDogNum;
                return;
            }

            if (LastDogNum != edtDogovorNum.Text)
            {
                tsBtnActivate.Enabled = false;
                wbPrtInfo.DocumentText = "";
                LastDogNum = edtDogovorNum.Text;
            }

            if (e.KeyCode != Keys.Enter || edtDogovorNum.Text.Length < 9 || edtDogovorNum.Text == messageDogNum)
                return;

            if (edtDogovorNum.Text.Length < 9)
                return;
            string errorMessage = "";
            CurrentDogovorUse = PLDC.GetDogovorFromRootAgency(edtDogovorNum.Text, out errorMessage);

            if (CurrentDogovorUse == null)
            {
                MessageBox.Show(errorMessage);
                edtDogovorNum.Text = messageDogNum;
                return;
            }

            if (CurrentDogovorUse.LTPD_Signing != null)
            {
                MessageBox.Show("Выбранный вами договор №" + edtDogovorNum.Text + " уже подписан");
                edtDogovorNum.Text = messageDogNum;
                return;
            }

            if (CurrentDogovorUse.LTPD_PDKey == null)
            {
                MessageBox.Show("Выбранный вами договор №" + edtDogovorNum.Text + "должен быть сначала активирован");
                return;
            }

            EdtComment.Text = CurrentDogovorUse.LTPD_Comment;

            // Активируем тип и кнопку если текущий договор не подписан
            tsBtnActivate.Enabled = !CurrentDogovorUse.LTPD_Signing.HasValue;

            string docText = "";
            string errorMsg = "";
            var officesOnSuchINN = PLDC.GetTheOfficesOnSuchAnINN(CurrentDogovorUse.tbl_Partners, out errorMsg);
            if (officesOnSuchINN == null)
            {
                docText += "<b>Суб. агентств</b><font color=#FF0000> : " + errorMsg + "</font><br>";
            }
            else
            {
                int CountSubAgancy = officesOnSuchINN.Count();
                docText += (CountSubAgancy > 1 ? "<b>Суб. агентств</b> : " + CountSubAgancy.ToString() + "<br>" : "") +
                    CurrentDogovorUse.GetDogovorInformationInHTML();
            }
            wbPrtInfo.DocumentText = "<html><body>" + docText + "</body></html>";
        }

        private void tsBtnActivate_Click(object sender, EventArgs e)
        {
            foreach (var dog in PLDC.LTP_PrtDogs.Where(x => x.LTPD_DogNum == edtDogovorNum.Text))
            {
                dog.Signing(EdtComment.Text);
            }

            edtDogovorNum.Text = messageDogNum;

            if (this.IsNeedSave)
            {
                PLDC.SubmitChanges();
            }
            else
                this.DialogResult = DialogResult.OK;
        }

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EdtComment_TextChanged(object sender, EventArgs e)
        {
            tsBtnActivate.Enabled = (CurrentDogovorUse != null);
        }
    }
}
