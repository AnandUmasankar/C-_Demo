using System;
using System.Globalization;

namespace Number_Formatting
{
    class Number_Formatter
    {
        static void Main()
        {
            double money = -10D / 3D;
            Console.WriteLine(money);
            Console.WriteLine(String.Format("${0:0.00000}", money));
            Console.WriteLine(money.ToString("C", CultureInfo.CreateSpecificCulture("en-IN")));
        }
    }
}