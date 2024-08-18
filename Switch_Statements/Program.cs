using System;

namespace switchDemo
{
     class SwitchDemo
    {
        static void Main()
        {
            Console.Write("Enter a Number ");
            int number =Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Console.WriteLine("Mon");
                    break;
                case 2:
                    Console.WriteLine("Tue");
                    break;
                case 3:
                    Console.WriteLine("Wed");
                    break;
                case 4:
                    Console.WriteLine("Thu");
                    break;
                case 5:
                    Console.WriteLine("Fri");
                    break;
                case 6:
                    Console.WriteLine("Sat");
                    break;
                case 7:
                    Console.WriteLine("Sun");
                    break;
                default:
                    Console.WriteLine("Enter between 1 and 7");
                    break;
            }
        }
    }
}