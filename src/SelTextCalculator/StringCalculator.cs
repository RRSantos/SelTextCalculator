using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelTextCalculator
{
    static class StringCalculator
    {
        static List<decimal> allNumbers = new List<decimal>();
        private static void indentifyAllNumbers(string text)
        {
            
            string[] tokens = text.Split(new char[] { ' ', '\r','\n' }, StringSplitOptions.RemoveEmptyEntries);
            allNumbers.Clear();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (decimal.TryParse(tokens[i], out decimal number))
                {
                    allNumbers.Add(number);
                }
            }
            
        }
        public static decimal Sum(string text)
        {
            indentifyAllNumbers(text);
            return allNumbers.Sum();            
        }

        public static decimal Multiply(string text)
        {
            indentifyAllNumbers(text);
            return allNumbers.Aggregate( (a,d) => a *= d);
        }
    }
}
