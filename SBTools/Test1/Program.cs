using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SBUtils;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int Count = 3; Count <= 15; Count++)
            {
                GenerateDictionary.Recurse(Count, 0, "", (GenerateDictionary.StrFooBarDelegate)WL);
            }
        }

        public static bool WL(string data)
        {
            Console.WriteLine(data);
            return false;
        }
    }
}
