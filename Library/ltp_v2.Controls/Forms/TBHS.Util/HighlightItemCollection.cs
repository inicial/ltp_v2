using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ltp_v2.Controls.Forms.TBHS.Util
{
    public class HighlightItemCollection : List<HighlightItem>
    {
        public new void Add(HighlightItem Item)
        {
            base.Add(Item);
            if (AfterAddHL != null)
                this.AfterAddHL(this, null);
        }
        public void Add(string MatchRegexSyntax, Font Font, Color ForeColor)
        {
            this.Add(new HighlightItem(MatchRegexSyntax, Font, ForeColor));
        }

        public event EventHandler AfterAddHL;
    }
}
