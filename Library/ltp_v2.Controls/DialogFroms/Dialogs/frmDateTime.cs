using System;
using System.Windows.Forms;

namespace ltp_v2.Controls.DialogFroms.Dialogs
{
    partial class frmDateTime : Form
    {
        #region Свойства
        private DateTime _MinValue;
        private DateTime _MaxValue;

        public DateTime MinValue
        {
            get { return _MinValue; }
            set
            {
                _MinValue = value;
                OnChangeMinMaxValue();
            }
        }

        public DateTime MaxValue
        {
            get { return _MaxValue; }
            set
            {
                _MaxValue = value;
                OnChangeMinMaxValue();
            }
        }
        #endregion

        #region Конструктор
        public frmDateTime()
        {
            InitializeComponent();
        }
        #endregion

        #region Методы
        private void OnChangeMinMaxValue()
        {
            var min = _MinValue.Date < _MaxValue.Date ? _MinValue.Date : _MaxValue.Date;
            var max = _MinValue.Date > _MaxValue.Date ? _MinValue.Date : _MaxValue.Date;
            _MinValue = min;
            _MaxValue = max;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void edtDateTime_ValueChanged(object sender, EventArgs e)
        {
            if (edtDateTime.Value.Date < MinValue.Date)
                edtDateTime.Value = MinValue.Date;
            if (edtDateTime.Value.Date> MaxValue.Date)
                edtDateTime.Value = MaxValue.Date;
        }
        #endregion
    }
}
