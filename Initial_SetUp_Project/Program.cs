using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Initial_SetUp_Project
{
    class Program
    {
        int count;
        public Program()
        {
            count = count + 1;
            Console.WriteLine("Time Program Constructor called "+count);
            
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Program p2 = new Program();
            Program p3 = new Program();
            Program p4 = new Program();
            String s=Console.ReadLine();
            Console.WriteLine("Written Statement" + s);

        }
    }
}
