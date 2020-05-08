using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Helper
{
    public static class StringExtensions
    {
        public static int ToInt(this string input, int defaultValue = 0)
        {
            return int.TryParse(input, out int value) ? value : defaultValue;
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}
