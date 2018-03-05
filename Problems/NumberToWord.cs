using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class NumberToWord
    {
        private static string[] ones = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private static string[] tens = { "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static string[] elevenToNinteen = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

        internal static string ConvertToWord(int number)
        {
            var digitCount = 0;
            var result = "";
            var temp = number;
            var unit = 0;
            var ten = 0;
            var hundred = 0;
            while (temp > 0)
            {
                digitCount++;
                var digit = temp % 10;
                if (digitCount == 1)
                    unit = digit;
                if (digitCount == 2)
                    ten = digit;
                if (digitCount == 3)
                    hundred = digit;
                temp /= 10;
            }
            if (digitCount == 1)
            {
                result = ones[unit - 1];
            }
            else if (digitCount == 2)
            {
                result = GetTens(unit, ten);
            }
            else if (digitCount == 3)
            {
                result = ones[hundred - 1] + " hundred";
                if (ten == 0)
                {
                    if (unit != 0)
                        result += " and " + ones[unit - 1];
                }
                else
                {
                    result += " " + GetTens(unit, ten);
                }
            }
            return result;
        }

        private static string GetTens(int unit, int ten)
        {
            string result;
            if (ten == 1)
            {
                if (unit == 0)
                    result = tens[0];
                else
                    result = elevenToNinteen[unit - 1];
            }
            else
            {
                result = tens[ten - 1];
                if (unit != 0)
                    result += " " + ones[unit - 1];
            }
            return result;
        }
    }
}
