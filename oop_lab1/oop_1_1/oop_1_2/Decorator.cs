using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_1_2
{
    public class Decorator : IDateTimeFormatter
    {
        protected IDateTimeFormatter _dateTimeFormatter;


        public Decorator(IDateTimeFormatter dateTimeFormatter)
        {
            _dateTimeFormatter = dateTimeFormatter;
        }

        public string FormatDateTime(DateTime dateTime)
        {
            return _dateTimeFormatter.FormatDateTime(dateTime);
        }
    }
}