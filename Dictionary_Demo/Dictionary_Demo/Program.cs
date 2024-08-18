using System;using System.Collections.Generic;

namespace DictionaryDemo
{
    class DictionaryDemo
    {
        public static void Main()
        {
            Dictionary<int, String> mapDemo = new Dictionary<int, String>()
            {
                {1,"MapValue1" },
                {2,"MapValue2" },
                { 3,"MapValue3"}
            };
            foreach(var mapDemo1 in mapDemo)
            {
                KeyValuePair<int, String> newkey = mapDemo1.ElementAt(1);
                Console.WriteLine
            }
        }
    }
}