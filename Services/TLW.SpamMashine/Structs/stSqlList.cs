using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLW.SpamMashine.Structs
{
    public class stSqlList : List<stSQL>
    {
        public stSQL GetByID(string ID)
        {
            foreach (stSQL lSQL in this)
            {
                if (lSQL.SqlID == ID)
                {
                    return lSQL;
                }
            }
            return new stSQL();
        }


        public bool ContainsID(string ID)
        {
            foreach (stSQL lSQL in this)
            {
                if (lSQL.SqlID == ID)
                {
                    return true;
                }
            }
            return false;
        }

        public void Remove(string ID)
        {
            stSQL stSQLForRemove = this.GetByID(ID);
            this.Remove(stSQLForRemove);
        }
    }
}
