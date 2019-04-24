using System;
using System.Windows.Forms;

namespace Rep22341
{
    public class DateTimeItem
    {
        public DateTime Value;

        public DateTimeItem(DateTime value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value.ToString("dd.MM.yyyy");
        }
    }
}
