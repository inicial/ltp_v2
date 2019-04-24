using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace TLW.SpamMashine.Utilites
{
    public class ProcessFiles
    {
        /// <summary>
        /// Получение списка процессов из системной папки
        /// </summary>
        /// <returns>список процессов</returns>
        public List<Structs.stProcess> getServices()
        {
            string CurrentDir = new System.IO.FileInfo(Application.ExecutablePath).Directory.FullName;
            DataSet DS;
            List<Structs.stProcess> Result = new List<Structs.stProcess>();
            String[] Files = System.IO.Directory.GetFiles(CurrentDir+"/Services/", "*.xml");
            foreach (string currentReadFromFilePath in Files)
            {
                DS = new DataSet();
                DS.ReadXmlSchema(CurrentDir + "/Services/Configuration.xsd");
                DS.ReadXml(currentReadFromFilePath);

                if (DS.Tables.IndexOf("Service") >= 0
                    && DS.Tables["Service"].Rows.Count > 0
                    && DS.Tables["Service"].Columns.IndexOf("ServiceID") >= 0
                    && DS.Tables["Service"].Rows[0]["ServiceID"].GetType() != typeof(DBNull))
                {
                    Structs.stProcess SRV = Structs.stProcess.getFromDataSet(currentReadFromFilePath, DS);
                    Result.Add(SRV);
                }
            }
            return Result;
        }

        /// <summary>
        /// Сохранение настроек процесса
        /// </summary>
        public void SaveXML(Structs.stProcess value)
        {
            value.ConvertedToDataSet.WriteXml(value.FilePath);
        }
    }
}
