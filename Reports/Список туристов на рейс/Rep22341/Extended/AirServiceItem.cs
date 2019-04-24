using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rep22341
{
    public class AirServiceItem
    {
        public bool SelectedItem { get; set; }
        public int AirServiceKey { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }

        public AirServiceItem(AirService airService)
        {
            SelectedItem = false;
            AirServiceKey = airService.AS_KEY;
            Code = airService.AS_CODE;
            Text = airService.AS_NAMERUS;
        }
    }
}
