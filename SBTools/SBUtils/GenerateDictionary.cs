using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBUtils
{
    public static class GenerateDictionary
    {
        public delegate bool StrFooBarDelegate(string data);

        //define likely password characters
        static char[] Match =            {'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','g','h','i','j' ,'k','l','m','n','o','p',
                        'q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','C','L','M','N','O','P',
                        'Q','R','S','T','U','V','X','Y','Z','!','?',' ','*','-','+','_','@','.',',',';',':','$','&','#'};

        public static void Recurse(int Lenght, int Position, string BaseString, StrFooBarDelegate Process)
        {
            int Count = 0;
            for (Count = 0; Count < Match.Length; Count++)
            {
                if (Position < Lenght - 1)
                {
                    Recurse(Lenght, Position + 1, BaseString + Match[Count], Process);
                }

                if (Process(BaseString + Match[Count]))
                {
                    break;
                }
            }
        }
    }
}
