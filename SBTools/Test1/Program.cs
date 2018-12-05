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

        static ulong counter;

        static long counterf;
        static ulong totalPass;

        static ulong totalBytes;

        private static Mutex mut = new Mutex();
        private static List<Mutex> Threadmut = new List<Mutex>();

        static void Main(string[] args)
        {
            int linit = 5, lend = 6;
            counterf = 0;

            GenerateDictionary dict = new GenerateDictionary();
            counter = 0;

            Console.WriteLine("Init GenList");

            Console.WriteLine("Calculated Pass: " + SuperPow(SBStaticData.MatchAlphaNumericMin, linit, lend).ToString());

            Console.WriteLine("Calculated Gigas: " + (((totalBytes / 1000) / 1000) / 1000).ToString());
            

            Console.ReadLine();

            file = new System.IO.StreamWriter(@"D:\GenList" + counterf.ToString() + ".txt", true);

            for (int Count = linit; Count <= lend; Count++)
            {
                Console.WriteLine("GenList Length: " + Count.ToString());

                new ActionDelegateThreadsRecurse().ActionDelegate(new FooBarDelegateRecurse(Recurse), null, new WLData() { Length = Count, Position = 0, InitialCount = 0, BaseString = "", Process = WL, Match = SBStaticData.MatchAlphaNumericMin });
            }

            bool ok = true;
            while(ok)
            {
                if (Threadmut.Count >= 1)
                {
                    for(int i = 0; i <= Threadmut.Count; i++)
                    {
                        if (i >= Threadmut.Count)
                        {
                            ok = false;
                            break;
                        }

                        if (Threadmut[i] != null)
                        {
                            Threadmut[i].WaitOne();
                            Threadmut[i].ReleaseMutex();
                            Threadmut[i].Close();
                        }
                    }
                }
                else
                {
                    Thread.Sleep(10);

                }
            }


            file.Flush();
            file.Close();
            Console.WriteLine("End GenList - Total Pass: " + totalPass.ToString());
            Console.ReadLine();
        }

        public static ulong SuperPow(char[] Match, int LengthInit, int LengthEnd)
        {
            ulong totalPassCalc = 0, PassCalc = 0;
            int chars = Match.Length;
            totalBytes = 0;

            for (int i = LengthInit; i <= LengthEnd; i++)
            {
                PassCalc = (ulong)chars;
                for (int j = 2; j <= i; j++)
                {
                    PassCalc *= (ulong)chars;
                }

                totalBytes += PassCalc * (ulong)i;
                totalPassCalc += PassCalc;
            }
                return totalPassCalc;
        }

        public static  void Recurse(WLData WordListData)
        {
            Mutex ThreadMx = new Mutex();
            ThreadMx.WaitOne();
            Threadmut.Add(ThreadMx);
            GenerateDictionary dict = new GenerateDictionary();
            dict.Recurse(WordListData);
            ThreadMx.ReleaseMutex();  
        }
        public static bool WL(string data)
        {
            mut.WaitOne();
            counter++;

            if (counter > 1000000000)
            {
                counter = 0;
                counterf++;
                file.Flush();
                file.Close();
                file = new System.IO.StreamWriter(@"D:\GenList" + counterf.ToString() + ".txt", true);

            }

            totalPass++;
            file.Flush();
            file.WriteLine(data);

            mut.ReleaseMutex();
            return false;
        }
    }
}
