using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    //https://www.geeksforgeeks.org/dynamic-programming-set-5-edit-distance/
    public class NumberOfEditsToConvertStringAToB
    {
        public static int GetMinimumNumberOfEdits(string a, string b)
        {
            return GetMinimumNumberOfEdits(a, b, a.Length, b.Length);
        }
        private static int GetMinimumNumberOfEdits(string a, string b, int aLength, int bLength)
        {
            if (aLength == 0)
                return bLength;

            if (bLength == 0)
                return aLength;

            if (a[aLength - 1] == b[bLength - 1])
                return GetMinimumNumberOfEdits(a, b, aLength - 1, bLength - 1);

            else
            {
                var x = GetMinimumNumberOfEdits(a, b, aLength - 1, bLength - 1); //Replace
                var y = GetMinimumNumberOfEdits(a, b, aLength, bLength - 1); //Insert
                var z = GetMinimumNumberOfEdits(a, b, aLength - 1, bLength); //Delete
                var returnValue = 1 + GetMinimum(x, y, z);
                return returnValue;
            }

        }

        private static int GetMinimum(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), c);
        }
    }
}
