using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rep6043
{
    public static class ErrorMessages
    {
        public static string ErrCountNotTripUse(string turistName)
        {
            return String.Format("У туриста {0} используется страхование от невыезда более 1-го раза", turistName);
        }
        public static string ErrCountMedUse(string turistName, short numberDay, int countUse, double countNeedUse)
        {
            return String.Format("У туриста {0} на {1}дн. мед. страхования используется неправильный повышающию коефициент в мастер туре {2}услуга(и), а должно быть {3}услуга(и) мед страхования.", turistName, numberDay, countUse, countNeedUse);
        }
        public static string ErrNoMedIfUseTrip(string turistName)
        {
            return String.Format("У туриста {0}, для невыезда нет соответстующего мед. страхования по дню начала", turistName);
        }

        public static string ErrPersBirthday(string turistName)
        {
            return String.Format("У туриста {0}, проблеммы в дате. рождения", turistName);
        }
        public static string ErrPersName(string turistName)
        {
            return String.Format("У туриста {0}, фамилия отсутствует или содержит символы отличные от лат. или - или пробела", turistName);
        }
        public static string ErrPersFName(string turistName)
        {
            return String.Format("У туриста {0}, имя отсутствует или содержит символы отличные от лат. или - или пробела", turistName);
        }
        public static string ErrDLDay(string dgCode)
        {
            return String.Format("В броне {0}, у услуги срахования нет дня начала или продолжительности использования", dgCode.Trim());
        }
        public static string ErrDLNMens(string dgCode)
        {
            return String.Format("В броне {0}, туристов на услуге страхования меньше чем заявленно", dgCode.Trim());
        }

        public static string ErrTerretoryUse(string terretory)
        {
            return String.Format("Территория {0}, не может использоваться совместно с другими территориями в одном полисе", terretory);
        }

        public static string ErrMinContitions(decimal minPremium)
        {
            return String.Format("Минимальное покрытие для выбранных территорий должно быть = {0}", minPremium.ToString(".##"));
        }

        public static string ErrOutDayBeforeCreate(string dgCod, int days)
        {
            return String.Format("Создание невозможно, так как до начала тура по броне № {0} осталось: {1} дн.", dgCod, days);
        }

        public static string ErrPresentCrossMedService(string dgCod)
        {
            return String.Format("В броне {0} есть пересечение мед. страхования", dgCod.Trim());
        }

        public static readonly string AnyErrorCountMedUse = "У вас что то не так, так как в полисе две услуги мед страхования";
        public static readonly string AnyErrorNotMedUse = "У вас что то не так, так как в полисе нет услуг мед страхования";
        public static readonly string AnyErrorCountBServUse = "У вас что то не так, так как в полисе две услуги страхования несч. сл.";
        public static readonly string AnyErrorNotBServUse = "У вас что то не так, так как в полисе нет услуг страхования несч. сл.";
        public static readonly string AnyErrorCountDServUse = "У вас что то не так, так как в полисе две услуги страхования от невыезда";

        public static readonly string ErrNotUseSpecialTarriff = "Для выбранных территорий существуют специальные тарифы, проверьте данные в МТ";
        public static readonly string ErrRateUse = "Выписка страховок не предусмотренна для валюты данного тура";
        public static readonly string ErrNotTariffForDuration = "Нет тарифов для данной продолжительности страхования";
        public static readonly string ErrNoTerretories = "Нет территорий страхования, добавьте необходимые территории страхования";
        public static readonly string ErrNoConditions = "Нет условий страхования";
        public static readonly string ErrNoTurist = "Нет лиц которых необходимо застраховать";
        public static readonly string ErrNotAutomaticGetNumber = "Не удалось автоматически определить номер полиса";
        public static readonly string ErrNotAutomaticGetTarrif = "Не удалось найти тарифы для выбранных страховых случаев";
        public static readonly string ErrIsNullInsuredSumm = "Сумма страхования = 0, обратитесь в тех. отдел";
        public static readonly string ErrAutomaticGetMoreTarrif = "Найдено слишком много тарифов для выбранных страховых случаев";
        public static readonly string ErrCreateNotCurrentMonth = "Вы не можете воспользоваться страховкой созданной в прошлом месяце";
        public static readonly string UpdatePersonInformationNotRequired = "Обновлять данные по туристу не требуется";
        public static readonly string ErrUpdatePersonInfoDifferentAges = "Разные возврастные тарифы, необходимо создавать новый полис, а этот анулировать";
        public static readonly string ErrCrossTuristData = "Связь данных туриста в полисе с Мастер тур была удалена, видимо был удален турист из БД МТ, Необходимо создавать новый полис, а этот анулировать";
        public static readonly string DataUpdatedSuccessfully = "Данные обновлены успешно";
        public static readonly string ErrUpdatePersonInfoByLostDate = "Вы не можете обновить данные, так как создание полиса было в прошлом месяце";
    }
}