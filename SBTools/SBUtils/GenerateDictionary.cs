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

        public static char[] MatchAlpha =            {'a','b','c','d','e','f','g','h','i','j' ,'k','l','m','n','o','p',
                        'q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','C','L','M','N','O','P',
                        'Q','R','S','T','U','V','X','Y','Z'};

        public static char[] MatchNumeric =            {'0','1','2','3','4','5','6','7','8','9'};

        public static char[] MatchAlphaNumericMin =            {'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','g','h','i','j' ,'k','l','m','n','o','p',
                        'q','r','s','t','u','v','w','x','y','z'};

        public static char[] MatchAlphaNumeric =            {'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','g','h','i','j' ,'k','l','m','n','o','p',
                        'q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','C','L','M','N','O','P',
                        'Q','R','S','T','U','V','X','Y','Z'};

        public static char[] MatchFull =            {'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','g','h','i','j' ,'k','l','m','n','o','p',
                        'q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','C','L','M','N','O','P',
                        'Q','R','S','T','U','V','X','Y','Z','!','?',' ','*','-','+','_','@','.',',',';',':','$','&','#','<','>','/','\\'};

        public static void Recurse(int Lenght, int Position, string BaseString, StrFooBarDelegate Process, char[] Match )
        {
            char[] match;
            int Count = 0;
            match = Match;
            if (match == null)
                match = MatchFull;

            for (Count = 0; Count < match.Length; Count++)
            {
                if (Position < Lenght - 1)
                {
                    Recurse(Lenght, Position + 1, BaseString + match[Count], Process, match);
                }

                if (BaseString.Length == Lenght - 1)
                {
                    if (Process(BaseString + match[Count]))
                        break;
                }
            }
        }
    }
}
