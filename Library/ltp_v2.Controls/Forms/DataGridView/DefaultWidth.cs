using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltp_v2.Controls.Forms
{
    public class DefaultWidth : Attribute 
    {
        public int Width { get; set; }

        public DefaultWidth(int width)
        {
            this.Width = width;
        }
    }
}
