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
    public partial class frmCardCount : Form
    {
        #region Свойства
        /// <summary>
        /// Кол-во выбранных единиц
        /// </summary>
        public int CountEnterItems
        {
            get
            {
                return (int)this.CountItems.Value;
            }
        }
        #endregion

        #region Конструктор
        public frmCardCount(string DialogName, int MaxCount, int CurrentCount)
        {
            InitializeComponent();
            this.Text = DialogName;
            this.CountItems.Maximum = MaxCount;
            this.CountItems.Value = CurrentCount;
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CountItems_ValueChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = (CountItems.Value != 0);
        }
    }
}
