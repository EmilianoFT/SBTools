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
        static System.IO.StreamWriter file;

        static long counter;

        static void Main(string[] args)
        {
            file = new System.IO.StreamWriter(@"D:\GenList.txt", true);
            counter = 0;

            Console.WriteLine("Init GenList");
            for (int Count = 0; Count <= 4; Count++)
            {
                Console.WriteLine("GenList Length: " + Count.ToString());
                GenerateDictionary.Recurse(Count, 0, "", (GenerateDictionary.StrFooBarDelegate)WL, GenerateDictionary.MatchAlphaNumericMin);
            }
            file.Flush();
            file.Close();
            Console.WriteLine("End GenList");
        }

        public static bool WL(string data)
        {
            counter++;

            if (counter > 100000)
            {
                counter = 0;
                Console.WriteLine("GenList: " + data);
            }

            file.WriteLine(data);
            return false;
        }
    }
}
