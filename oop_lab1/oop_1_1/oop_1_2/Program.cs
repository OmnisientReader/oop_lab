using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace oop_1_2
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime current_date = DateTime.Now;
            AmericanDateTimeFormatter american_formatter = new AmericanDateTimeFormatter();
            string american_date = american_formatter.FormatDateTime(current_date);
            Decorator dateFormatter = new Decorator(american_formatter);
            string date = dateFormatter.FormatDateTime(current_date);
            string to_add = ":59";
            CustomDecorator add = new CustomDecorator(dateFormatter, to_add, current_date);
            string final_string = add.Append();
            Console.WriteLine(date);
            Console.WriteLine(final_string);


        }
    }
}

