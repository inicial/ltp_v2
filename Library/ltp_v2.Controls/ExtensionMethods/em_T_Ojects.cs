using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ltp_v2.Controls
{
    public static class em_T_Ojects
    {
        /// <summary>
        /// Поиск индекса элемента по его свойству
        /// </summary>
        /// <param name="FindValue">Значение свойства</param>
        /// <param name="FindInPropertyName">Название своиства</param>
        /// <returns>-1 если не найден, в противном от 0 и выше</returns>
        public static int IndexOf<T>(this List<T> sender, object FindValue, string FindInPropertyName)
        {
            if (sender == null)
                return -1;

            foreach (T item in sender)
            {
                if (FindValue != null && item.GetValueFromProperty(FindInPropertyName).ToString() == FindValue.ToString())
                {
                    return sender.IndexOf(item);
                }
            }
            return -1;
        }

        /// <summary>
        /// Получить значение свойства у элимента
        /// </summary>
        /// <param name="PropertyName">Название свойства</param>
        /// <returns>Значение свойства</returns>
        public static object GetValueFromProperty<T>(this T sender, string PropertyName)
        {
            PropertyDescriptor PD = TypeDescriptor.GetProperties(sender).Find(PropertyName, true);

            if (PD == null)
                throw new Exception("Неправильно указан ключ свойства");

            return PD.GetValue(sender);
        }

        /// <summary>
        /// Получение списка разницы значений для текущего
        /// </summary>
        /// <typeparam name="T">Тип этого списка</typeparam>
        /// <typeparam name="CL">Тип эталонного списка</typeparam>
        /// <typeparam name="ResultType">Тип результата</typeparam>
        /// <param name="SenderPropertyName">Название свойства элемента в этом списке</param>
        /// <param name="ComparisonList">Эталонный список - с которым будет проводиться сравнение</param>
        /// <param name="ComparisonListPropertyName">Название свойства элемента в эталонном списке</param>
        /// <returns>Выводит списоок отсутствующих элементов в эталонном списке</returns>
        public static List<ResultType> NotPartInList<T, CL, ResultType>(this List<T> sender, string SenderPropertyName, List<CL> ComparisonList, string ComparisonListPropertyName)
        {
            List<ResultType> Result = new List<ResultType>();
            foreach (T itemT in sender)
            {
                ResultType SenderID = (ResultType)itemT.GetValueFromProperty(SenderPropertyName);
                bool NotSearch = true;
                foreach (object itemCL in ComparisonList)
                {
                    ResultType ComparisonID = (ResultType)itemCL.GetValueFromProperty(ComparisonListPropertyName);
                    if (SenderID == null && ComparisonID == null || SenderID.ToString() == ComparisonID.ToString())
                    {
                        NotSearch = false;
                        break;
                    }
                }
                if (NotSearch)
                    Result.Add((ResultType)SenderID);
            }
            return Result;
        }
    }
}
