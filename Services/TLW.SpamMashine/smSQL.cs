namespace TLW.SpamMashine
{
    using System;
    using System.Linq;
    using ltp_v2.Controls;

    public struct ResulDTInterval
    {
        public DateTime BegInterval;
        public DateTime EndInterval;
    }

    partial class smSQLDataContext
    {
        public ResulDTInterval GetNextUsePerriod(string ServiceName, int WorkIntervalInMinutes)
        {
            var q = from lts in this.LTS_SpamServers
                    where lts.LSS_ServiceSend == ServiceName
                    && lts.LSS_DTEndPeriod != null
                    select lts.LSS_DTEndPeriod;

            if (q.Count() == 0)
            {
                // ≈сли сервис ранее не использовалс€
                return new ResulDTInterval
                {
                    BegInterval = Utilites.Consts.ServerDateTime.Date.AddMinutes(-1 * WorkIntervalInMinutes),
                    EndInterval = Utilites.Consts.ServerDateTime.AddSeconds(-1)
                };
            }
            else
            {
                // получение максимальной даты/времени конечного использовани€
                var qLastUse = q.Max().Value.AddMilliseconds(1);
                
                // ≈сли сервис неиспользовалс€ более двух дней
                if (Math.Abs(qLastUse.Subtract(Utilites.Consts.ServerDateTime).Days) >= 2)
                    qLastUse = Utilites.Consts.ServerDateTime.AddDays(-1);

                return new ResulDTInterval { 
                    BegInterval = qLastUse,
                    EndInterval = Utilites.Consts.ServerDateTime.AddSeconds(-1)
                };
            }
        }

        public void Insert(LTS_SpamServer value)
        {
            this.LTS_SpamServers.InsertOnSubmit(value);
            this.SubmitChanges();
        }

        public void UpdateSend(LTS_SpamServer value)
        {
            value.LSS_DTSend = Utilites.Consts.ServerDateTime;
            this.SubmitChanges();
        }

        public IQueryable<LTS_SpamServer> GetNotSend()
        {
            return this.LTS_SpamServers.Where(x => x.LSS_DTSend == null);
        }
    }
}
