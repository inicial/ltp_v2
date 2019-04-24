using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltp_v2.Controls.Forms
{
    public class VisibleColumns : Attribute 
    {
        public bool Visible { get; set; }

        public VisibleColumns(bool visible)
        {
            this.Visible = visible;
        }
    }
}
