using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallCenter.Report
{
    public class HistoryDetail
    {
        public string PhoneNumber { get; set; }
        public DateTime HistoryDate { get; set; }
        public string CountryName { get; set; }
        public string CallTypeSend { get; set; }
        public string ManagerName { get; set; }
        
        public string AgencyName { get; set; }
        public string MetroStationName { get; set; }

        public string ReclameSource { get; set; }
        /// <summary>
        /// Неподняли трубку
        /// </summary>
        public int NotCall { get; set; }
        /// <summary>
        /// Переведенных звонков
        /// </summary>
        public int Answer { get; set; }
        /// <summary>
        /// Не переведенных звонков
        /// </summary>
        public int NotAnswer { get; set; }
    }
}
