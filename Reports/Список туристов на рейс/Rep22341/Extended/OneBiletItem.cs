using System;
using System.ComponentModel;

namespace Rep22341.Extended
{
    public class OneBiletItem
    {
        [DisplayName("№ Брони")]
        public string DGCode { get; set; }

        [DisplayName("Дата заезда")]
        public DateTime BronDate { get; set; }

        [DisplayName("Название рейса")]
        public string ReisName { get; set; }

        [DisplayName("Дата рейса")]
        public DateTime ReisDate { get; set; }
    }
}
