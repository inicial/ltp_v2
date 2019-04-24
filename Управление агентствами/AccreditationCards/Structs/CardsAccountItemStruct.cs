using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccreditationCards
{
    public struct CardsAccountItemStruct
    {
        public string Number { get; set; }
        public double Price { get; set; }
        public double Payed { get; set; }
        public int CardCount { get; set; }
        public int ID { get; set; }
    }
}
