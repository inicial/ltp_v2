using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Arhivarius
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new frmPacket().ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            new frmInformation().ShowDialog();
        }

        private void tsBtnListNewRegistration_Click(object sender, EventArgs e)
        {

        }
    }
}
