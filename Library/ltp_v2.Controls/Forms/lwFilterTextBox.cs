using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ltp_v2.Controls.Forms
{
    public class lwFilterTextBox : TextBox
    {
        public string OldText { get; set; }
        public bool IsChangeText
        {
            get { return OldText != this.Text; }
        }
        public lwFilterTextBox()
            : base()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        protected override void OnEnter(EventArgs e)
        {
            this.OldText = Text;
            base.OnEnter(e);
        }
    }
}
