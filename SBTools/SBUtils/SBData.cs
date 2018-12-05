using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBUtils
{
    public delegate bool StrFooBarDelegate(string data);

    public class WLData
    {
        public char[] Match { set; get; }
        public int Length { set; get; }
        public int InitialCount { set; get; }
        public int Position { set; get; }
        public string BaseString { set; get; }
        public StrFooBarDelegate Process { set; get; }
    }
}
