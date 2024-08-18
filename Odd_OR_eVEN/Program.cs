using System;

namespace BasicInputOutput
{
    class inputOutput
    {
        static void Main()
        {
            Console.Write("Enter Your Name: ");
            String name= Console.ReadLine();
            Console.Write("Enter Your Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your name is " + name + " and your age is " + age);
        }
    }
}