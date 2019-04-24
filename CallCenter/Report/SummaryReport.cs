using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallCenter.Report
{
    public class SummaryReport
    {
        /// <summary>
        /// Дата подключения
        /// </summary>
        public DateTime ConnectionDate { get; set; }
        /// <summary>
        /// Название агенства
        /// </summary>
        public string PartnerName { get; set; }
        /// <summary>
        /// Название агенства
        /// </summary>
        public string PartnerFullName { get; set; }
        /// <summary>
        /// Код агентства
        /// </summary>
        public string PartnerCode { get; set; }
        /// <summary>
        /// Метро
        /// </summary>
        public string MetroStationName { get; set; } 
        /// <summary>
        /// Неподняли трубку
        /// </summary>
        public int cntNotCall { get; set; }
        /// <summary>
        /// Переведенных звонков
        /// </summary>
        public int cntAnswer { get; set; }
        /// <summary>
        /// Не переведенных звонков
        /// </summary>
        public int cntNotAnswer { get; set; }
        /// <summary>
        /// Итого броней
        /// </summary>
        public int BronCount { get; set; }
        /// <summary>
        /// Номер счета за услуги
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        /// % не переведенных звонков
        /// </summary>
        public int PercentNotSend
        {
            get
            {
                return (int)((double)(cntNotCall + cntNotAnswer) / (double)(cntAnswer == 0 ? 1 : cntAnswer) * 100);
            }
        }
        /// <summary>
        /// % броней от переведенных звонков
        /// </summary>
        public int PercentBron
        {
            get
            {
                return (int)((double)BronCount / (double)(cntAnswer == 0 ? 1 : cntAnswer) * 100);
            }
        }

        public int BronByCountry { get; set; }
        /// <summary>
        /// % броней от переведенных звонков по направлениям
        /// </summary>
        public int PercentBronByCountry
        {
            get
            {
                return (int)((double)BronByCountry / (double)(cntAnswer == 0 ? 1 : cntAnswer) * 100);
            }
        }
        
        public int cntNotSends
        {
            get { return cntNotCall + this.cntNotAnswer; }
        }

        public string CountryName { get; set; }

        public int PartnerKey { get; set; }
        public int CountryKey { get; set; }
    }
}
