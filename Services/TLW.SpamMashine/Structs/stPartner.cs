using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLW.SpamMashine.Structs
{
    public struct stPartner
    {
        public int PRKey;
        public string MailFrom;
        public string MailTo;
        public string ServiceID;
        public string Subject;

        public stPartner(int PRKey, string MailFrom, string MailTo, string ServiceID, string Subject)
        {
            this.Subject = Subject;
            this.PRKey = PRKey;
            this.MailFrom = MailFrom;
            this.MailTo = MailTo;
            this.ServiceID = ServiceID;
        }
    }
}
