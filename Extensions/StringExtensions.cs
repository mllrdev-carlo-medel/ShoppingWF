using ShoppingCart.Business.Log;
using System;

namespace ShoppingCart.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string input, int defaultValue = 0)
        {
            return int.TryParse(input, out int value) ? value : defaultValue;
        }

        public static float ToFloat(this string input, int defaultValue = 0)
        {
            return float.TryParse(input, out float value) ? value : defaultValue;
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        public static string FirstCharToUpper(this string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return null;
            }
            else
            {
                try
                {
                    return $"{char.ToUpper(input[0])}{input.Substring(1).ToLower()}";
                }
                catch (Exception ex)
                {
                    Logger.log.Error(ex.ToString());
                    return null;
                }
            }
        }
    }
}
