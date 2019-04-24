using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ltp_v2.Controls.Forms;
using AgencyManager.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace AgencyManager
{
    public static class DefaultValuesControl
    {
        public static Color ChangeColor = Color.FromArgb(192, 255, 255);
        public static Color ErrorColor = Color.Red;
        public static string Required_Message = "Это поле является обязательным";

        public static void SetDefaultMetroStation_Required(this lwComboBox sender, PartnersListDataContext PLDC)
        {
            sender.ChangeBackGroundColor = ChangeColor;
            sender.ErrorBackGroundColor = ErrorColor;
            sender.IsNotNullValue = true;
            sender.MessageInformationError = Required_Message;

            LCC_MetroStation FreeLMS = new LCC_MetroStation();
            FreeLMS.MS_ID = 0;
            FreeLMS.MS_StationName = "Нет станции";
            List<LCC_MetroStation> MSList = new List<LCC_MetroStation>();
            MSList.Add(FreeLMS);
            MSList.AddRange(PLDC.LCC_MetroStations.OrderBy(x => x.MS_StationName));
            
            sender.DataSource = MSList;
            sender.DisplayMember = "MS_StationName";
            sender.ValueMember = "MS_ID";
            sender.DefaultValue = 0;
        }

        public static void SetDefaultPhones_Required(this lwTextBox sender)
        {
            sender.MessageInformationError = Required_Message+ "Формат +74957866860 где +(код страны)(код города)(номер телефона) разделение через ;";
            sender.RegexVerify = "((\\+[0-9]{1,2}|)(\\([0-9]{2,5}\\)|)[0-9]{1,4}(-|)[0-9]{1,4}((-|)[0-9]{1,4}|)(;|$))+";
            sender.VerifyMaxLength = 254;
            sender.MaxLength = 254;
        }

        public static void SetFormForInsertToControl(this Form sender)
        {
            sender.FormBorderStyle = FormBorderStyle.None;
            sender.TopLevel = false;
            sender.Dock = DockStyle.Fill;
        }
    }
}
