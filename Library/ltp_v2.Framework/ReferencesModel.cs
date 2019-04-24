namespace ltp_v2.Framework
{
    using System;
    using System.Linq;
    using System.Data.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;

    partial class AccessForAgency
    {
        public bool LTP_AC_Dog_Full
        {
            get
            {
                return (this.LTP_AC_Dog_Agency && this.LTP_AC_Dog_AviaZD && this.LTP_AC_Dog_Cruize && this.LTP_AC_Dog_FIT);
            }
        }
    }
}
