using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLW.SpamMashine.Structs
{
    public struct stMatchValue
    {
        public string FullLine;
        public string Code;

        public stMatchValue(string FullLine, string Code)
        {
            this.FullLine = FullLine;
            this.Code = Code;
        }
    }

    public class ListMatchValue : List<stMatchValue>
    {
        public void Add(string FullLine, string Code)
        {
            this.Add(new stMatchValue(FullLine, Code));
        }
    }
}
