using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltp_v2.Controls.DialogFroms
{
    public class lwDateTimeDialog
    {
        #region Свойства
        private Dialogs.frmDateTime frmDateTime;

        public DateTime MinValue
        {
            get { return frmDateTime.MinValue; }
            set { frmDateTime.MinValue = value; }
        }
        public DateTime MaxValue
        {
            get { return frmDateTime.MaxValue; }
            set { frmDateTime.MaxValue = value; }
        }
        public DateTime CurrentValue
        {
            get { return frmDateTime.edtDateTime.Value; }
            set { frmDateTime.edtDateTime.Value = value; }
        }
        #endregion

        #region Конструктор
        public lwDateTimeDialog()
        {
            frmDateTime = new Dialogs.frmDateTime();
        }
        #endregion

        #region Методы
        public DateTime? Show(string DialogText)
        {
            frmDateTime.Text = DialogText;
            frmDateTime.lblInfo.Text = DialogText;
            if (frmDateTime.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return CurrentValue;
            else
                return null;
        }
        #endregion
    }
}
