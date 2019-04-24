using System;
using System.Text;
using System.Drawing;

namespace ltp_v2.Controls.Forms.TBHS.Util
{
    public struct HighlightItem
    {
        public string MatchRegexSyntax;
        public Font Font;
        public Color ForeColor;

        public HighlightItem(string MatchRegexSyntax, Font Font, Color ForeColor)
        {
            this.MatchRegexSyntax = MatchRegexSyntax;
            this.Font = Font;
            this.ForeColor = ForeColor;
        }

        public override string ToString()
        {
            return MatchRegexSyntax;
        }
    }
}
