using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ltp_v2.Controls.Forms
{
    public partial class _frmWaitScreen : Form
    {
        private bool IsBreakClose = true;

        public _frmWaitScreen()
        {
            InitializeComponent();
        }

        internal void SetProgress(int i)
        {
            lblProgress.Visible = true;
            lblProgress.Text = i.ToString() + "%";
        }

        internal void CloseForm()
        {
            IsBreakClose = false;
            lblProgress.Visible = false;
            this.DialogResult = DialogResult.OK;
        }

        private void frmWaitScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsBreakClose)
                e.Cancel = true;
        }
    }
}
