using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rep22341
{
    public class CharterItem
    {
        public bool SelectedItem { get; set; }
        public int CharterKey { get; set; }
        public string CharterName { get; set; }
        public string CityRoute { get; set; }

        public CharterItem(Charter charter)
        {
            SelectedItem = false;
            CharterKey = charter.CH_KEY;
            CharterName = charter.CH_AIRLINECODE + charter.CH_FLIGHT;
            if (charter.AirportFrom != null && charter.AirportTo != null)
                CityRoute = charter.AirportFrom.CityDictionary.CT_NAME + " - " + charter.AirportTo.CityDictionary.CT_NAME;

            if (charter.AirportFrom == null)
            {
                System.Windows.Forms.MessageBox.Show("Нет аэропорта вылета для: " + charter.ToString());
            }
            else if (charter.AirportTo == null)
            {
                System.Windows.Forms.MessageBox.Show("Нет аэропорта прилета для: " + charter.ToString());
            }
        }
    }
}
