using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml;

namespace ltp_v2.Framework
{
    public static class ApplicationConf
    {
        public static string LantaSqlConnection
        {
            get { return Get_Value("connectionStrings", "lanta"); }
        }
        public static string CourierMySqlConnection
        {
            get { return Get_Value("connectionStrings", "couriermydb"); }
        }
        public static string CompanyName
        {
            get { return Get_Value("appSettings", "CompanyName"); }
        }
        public static string Logo
        {
            get { return Get_Value("appSettings", "logo"); }
        }

        public static string MasterPath
        {
            get { return Get_Value("appSettings", "path"); }
        }

        public struct Section_Key
        {
            public string Key;
            public string Value;
        }

        private static Dictionary<Section_Key, string> section_key_value;

        private static void ReadFileConfig()
        {
            section_key_value = new Dictionary<Section_Key, string>();

            Assembly asm = Assembly.GetExecutingAssembly();
            string dir = new System.IO.FileInfo(asm.Location).Directory.ToString();
            string location_assembly_config = dir + "\\lanta.sqlconfig.dll.config";

            StreamReader sr = File.OpenText(location_assembly_config);
            XmlReader xmlr = XmlReader.Create(sr);
            Section_Key input_temp;
            input_temp.Value = "";
            input_temp.Key = "";
            while (xmlr.Read())
            {
                if (xmlr.NodeType == XmlNodeType.Element)
                {
                    if (xmlr.Depth == 1)
                        input_temp.Value = xmlr.Name;
                    if (xmlr.Depth == 2 && xmlr.HasAttributes)
                    {
                        if (xmlr.AttributeCount > 1)
                        {
                            input_temp.Key = xmlr.GetAttribute(0);
                            try
                            {
                                section_key_value.Add(input_temp, xmlr.GetAttribute(1));
                            }
                            catch { }
                        }
                        xmlr.MoveToElement();
                    }
                }
            }
            xmlr.Close();
            sr.Close();
        }

        public static string Get_Value(string section, string key_value)
        {
            ReadFileConfig();
            if (section_key_value.Count > 0)
            {
                foreach (KeyValuePair<Section_Key, string> skv in section_key_value)
                {
                    if (((Section_Key)skv.Key).Value.ToLower() == section.ToLower() &&
                        ((Section_Key)skv.Key).Key.ToLower() == key_value.ToLower())
                    {
                        return skv.Value;
                    }
                }
            }
            System.Windows.Forms.MessageBox.Show("Нет параметра в файле конфигурации " + key_value);
            System.Windows.Forms.Application.Exit();
            return null;
        }
    }
}