using oop_1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_1_2
{
    public class CustomDecorator : Decorator
    {
        private string _symbol;
        private DateTime _date;

        public CustomDecorator(IDateTimeFormatter dateTimeFormatter, string symbol, DateTime date) : base(dateTimeFormatter)
        {
            _symbol = symbol;
            _date = date;
        }

        public string Append()
        {
            return _dateTimeFormatter.FormatDateTime(_date) + _symbol;
        }

    }
}
