using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DynamicProgramming
{
    public class MaxSumOfSubSet
    {
        public static int GetResult(int[] input)
        {
            int[] dp = new int[input.Length];
            dp[0] = input[0];
            int max = dp[0];
            for (int i = 1; i < input.Length; i++)
            {
                var current = input[i];
                if (current > current + dp[i - 1])
                    dp[i] = current;
                else
                    dp[i] = current + dp[i - 1];

                if (dp[i] > max)
                    max = dp[i];
            }
            return max;
            
        }
    }
}
