using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DynamicProgramming
{
    //https://www.hackerrank.com/challenges/sherlock-and-cost
    public class SherlockAndCost
    {
        public static int GetMaxCost(int[] B)
        {
            int n = B.Length;
            var low = 0;
            var hi = 0;

            for (int i = 1; i < n; i++)
            {
                var high_to_low_diff = Math.Abs(B[i - 1] - 1);
                var low_to_high_diff = Math.Abs(B[i] - 1);
                var high_to_high_diff = Math.Abs(B[i] - B[i - 1]);

                var low_next = Math.Max(low, hi + high_to_low_diff);
                var hi_next = Math.Max(hi + high_to_high_diff, low + low_to_high_diff);

                low = low_next;
                hi = hi_next;
            }
            return Math.Max(low, hi);
        }
    }
}
