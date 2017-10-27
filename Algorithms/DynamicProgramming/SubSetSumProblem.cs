using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class SubSetSumProblem
    {
        //static List<List<int>> subsets = new List<List<int>>();
        //public static int GetNumberOfSubSets(int[] array)
        //{
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        subsets.Add(new List<int> { array[i] });
        //        for (int j = i + 1; j < array.Length; j++)
        //        {

        //        }
        //    }
        //}

        public static int GetmNumberOfSubsets(int[] numbers, int sum)
        {
            int[] dp = new int[sum + 1];
            dp[0] = 1;
            int currentSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                currentSum += numbers[i];
                for (int j = Math.Min(sum, currentSum); j >= numbers[i]; j--)
                    dp[j] += dp[j - numbers[i]];
            }

            return dp[sum];
        }
    }
}
