using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using rep25991.ExtendedMethods.AutoWrappingText;
using rep25991.ExtendedMethods.Convertation;
using rep25991.References;

namespace rep25991.Controls.Forms
{
    public partial class frmConfigPartner : Form
    {
        #region Свойства
        private LT_V_MappingPartner _MappingPartner;
        private byte[] _ImageArray;
        private byte[] ImageArray
        {
            get
            {
                if (_ImageArray != null)
                    return _ImageArray;
                byte[] result;
                using (Bitmap bmp = ExtendedMethods.LogoCreater.CreateLogo((byte[])null, edtName.Text.RemoveSpace()))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bmp.Save(ms, ImageFormat.Jpeg);
                        result = ms.ToArray();
                    }
                }
                return result;
            }
            set
            {
                _ImageArray = value;
                edtPartnerLogo.Image = ExtendedMethods.LogoCreater.CreateLogo(ImageArray, edtName.Text.RemoveSpace());
            }
        }

        public tbl_Partner Partner
        {
            set
            {
                this.MappingPartner = value.LT_V_MappingPartner;
            }
        }

        public LT_V_MappingPartner MappingPartner
        {
            get
            {
                return _MappingPartner;
            }
            set
            {
                _MappingPartner = value;
                edtName.Text = value.tbl_Partner.PR_NAME;
                edtAddress.Text = value.tbl_Partner.PR_ADRESS;
                edtContactPerson.Text = value.VMP_ContactPerson;
                edtFormat.Text = value.VMP_TuristFormat;
                edtOutAvia.Checked = value.VMP_ReisOut;
                ImageArray = value.VMP_Image == null ? null : value.VMP_Image.ToArray();
                edtFormatDate.Items.AddRange(exDateTime.VariantsDateTime);
                edtFormatDate.SelectedItem = edtFormatDate.Items.OfType<structDateFormat>().FirstOrDefault(x => x.FormatDate == value.VMP_DateFormat);
            }
        }
        #endregion

        #region Конструктор
        public frmConfigPartner(bool ShowCancelButton)
        {
            InitializeComponent();
            this.tsBtnCancel.Visible = ShowCancelButton;
            edtFormat.SetVariants(Tourist.htVariants);
        }

        public frmConfigPartner(tbl_Partner value, bool ShowCancelButton)
            : this(ShowCancelButton)
        {
            this.Partner = value;
        }

        public frmConfigPartner(LT_V_MappingPartner value, bool ShowCancelButton)
            : this(ShowCancelButton)
        {
            this.MappingPartner = value;
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MappingPartner == null)
                MappingPartner = new LT_V_MappingPartner();

            MappingPartner.VMP_Image = ImageArray;  
            MappingPartner.VMP_TuristFormat = edtFormat.Text.RemoveSpace();
            MappingPartner.VMP_ContactPerson = edtContactPerson.Text.RemoveSpace();
            MappingPartner.VMP_DateFormat = ((structDateFormat)edtFormatDate.SelectedItem).FormatDate;
            MappingPartner.VMP_ReisOut = edtOutAvia.Checked;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void edtName_Leave(object sender, EventArgs e)
        {
            if (MappingPartner == null || MappingPartner.VMP_Image == null)
            {
                ImageArray = null;
            }
        }

        private void btnDeleteLogo_Click(object sender, EventArgs e)
        {
            ImageArray = null;
        }

        private void btnCreateLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(Все файлы изображения)|*.jpg;*.bmp;*.gif";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var t = ofd.FileName;
                using (Stream stream = new StreamReader(ofd.FileName).BaseStream)
                {
                    using (Bitmap bmp = new Bitmap(stream))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bmp.Save(ms, ImageFormat.Jpeg);
                            ImageArray = ms.ToArray();
                        }
                    }
                }
            }
        }

        private void btnGetFromMT_Click(object sender, EventArgs e)
        {
            var partner = _MappingPartner.tbl_Partner;
            edtName.Text = partner.GetName();
            edtAddress.Text = partner.GetAddress();
        }

        private void edtFormat_TextChange(object sender, EventArgs e)
        {
            if (edtFormatDate.SelectedItem != null && edtFormat.Text != "")
            {
                edtFormat.ExampleText = PersonAW.Wordwrap(
                    Tourist.TestConvert(
                        edtFormat.Text,
                        ((structDateFormat)edtFormatDate.SelectedItem).FormatDate));
            }
            else
            {
                edtFormat.ExampleText = "";
            }
        }
    }
}
