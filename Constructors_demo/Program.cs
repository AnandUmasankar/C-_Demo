using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors_demo
{
    internal class ConstructorDemo
    { int y;
        //Default Constructor Which can be written Explicitly or initialized by compiler Explicitly but only called Explicity during object creation.
        public ConstructorDemo()
        {
            Console.WriteLine("Hey Creating a Object for class ConstructorDemo");
        }
        //Normal Default parameterized Constructor
        public ConstructorDemo(int x)
        {
            y = x;
            Console.WriteLine("The value of Y is initialized as "+y);
        }
        //Copy Constructor helps to replicate object of the same values easily
        public ConstructorDemo(ConstructorDemo obj)
        {
            y = obj.y;
            Console.WriteLine("Hi the value of Y is " + y);
        }
        //Static Constructor
        // If a class contains a static constructor any static variables then only implicit static constructors will be present or else we need to define them e
        //explicity where as non-static constructors will be defined implicitly by the compiler (except static class ) provided we did not define them Explicitly
        static void Main(string[] args)
        {
            ConstructorDemo conDemo = new ConstructorDemo();
            ConstructorDemo conparamDemo = new ConstructorDemo(10);
            ConstructorDemo conCopyDemo = new ConstructorDemo(conDemo);
        }
    }
}
