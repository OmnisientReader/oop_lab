using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_1_2
{
    public class EuropeanDateTimeFormatter : IDateTimeFormatter
    {
        public string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.GetCultureInfo("ru-RU"));
        }
    }
}
