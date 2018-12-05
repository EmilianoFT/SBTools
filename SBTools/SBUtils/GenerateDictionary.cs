using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBUtils
{
    public class GenerateDictionary
    {
        
        public void Recurse(int Length, int Position, string BaseString, StrFooBarDelegate Process, char[] Match)
        {
            Recurse(new WLData() { Length = Length, Position = Position, InitialCount = 0, BaseString = BaseString, Process = Process, Match = Match });
        }

        public void Recurse(WLData WordListData)
        {
            char[] match;
            int Count = 0;
            match = WordListData.Match;
            if (match == null)
                match = SBStaticData.MatchFull;

            for (Count = WordListData.InitialCount; Count < match.Length; Count++)
            {
                if (WordListData.Position < WordListData.Length - 1)
                {
                    Recurse(new WLData() { Length = WordListData.Length, Position = WordListData.Position + 1, InitialCount = WordListData.InitialCount, BaseString = String.Copy(WordListData.BaseString + match[Count]), Process = WordListData.Process, Match = WordListData.Match });
                }

                if (WordListData.BaseString.Length == WordListData.Length - 1)
                {
                    if (WordListData.Process(WordListData.BaseString + match[Count]))
                        break;
                }
            }
        }
    }
}
