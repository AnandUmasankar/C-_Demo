using System;
using System.Transactions;

namespace loopDemo
{
    class WhileLoopDemo
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Demo");
            Console.Write("Enter the First Number : ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Second Number : ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int answer = 0;
            int peranswer = 0;
            /*while (answer != peranswer)
            {
                Console.WriteLine();
                Console.Write("Enter Your Answer: ");
                peranswer = Convert.ToInt32(Console.ReadLine());
                if (peranswer != answer)
                {
                    Console.WriteLine("Wrong One");
                }
                else
                {
                    Console.WriteLine("Congrats Got that Right");
                }
            }*/

            do
            {
                Console.WriteLine();
                 answer = num1 * num2;
                 peranswer = Convert.ToInt32(Console.ReadLine());
                
                    Console.WriteLine(answer!=peranswer?"Try Again":"Well Done");
               
            } while (answer != peranswer);
        }
    }
}