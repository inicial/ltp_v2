using System;
using System.Collections.Generic;
using System.IO;

namespace ltp_v2.Framework
{
    public class MasterValue
    {
        public static string MasterCatalog
        {
            get
            {
                return global::ltp_v2.Framework.ApplicationConf.MasterPath;
            }
        }

        public static string PathToReports
        {
            get
            {
                return MasterCatalog + @"\Report";
            }
        }

        private static string _pathToOutDoc = "";
        public static string PathToOutDoc
        {
            get
            {
                if (_pathToOutDoc == "")
                {
                    _pathToOutDoc = MasterCatalog + @"\OutDoc\";
                    foreach (string PathFile in System.IO.Directory.GetFiles(_pathToOutDoc, "*.*"))
                    {
                        try
                        {
                            if (new System.IO.FileInfo(PathFile).CreationTime.AddDays(2) < DateTime.Now)
                                System.IO.File.Delete(PathFile);
                        }
                        catch
                        {
                        }
                    }
                }
                return _pathToOutDoc;
            }
        }

        public static string PathToShablon
        {
            get
            {
                return MasterCatalog + @"\Shablon";
            }
        }

        public static string[] ASKData
        {
            get
            {
                string[] result = new string[0];
                try
                {
                    using (StreamReader reader = new StreamReader(MasterCatalog + @"\askdata.ask"))
                    {
                        List<string> rsx = new List<string>();
                        while (!reader.EndOfStream)
                        {
                            rsx.Add(reader.ReadLine());
                        }
                        result = rsx.ToArray();
                        rsx.Clear();
                        rsx = null;
                    }
                }
                catch
                {
                }
                return result;
            }
        }

        public static string DGCodeFromASKData
        {
            get
            {
                string str = "";
                try
                {
                    str = ASKData[1];
                }
                catch
                {
                }
                return str;
            }
        }

    }
}
