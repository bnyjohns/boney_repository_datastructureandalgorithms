using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DynamicProgramming
{
    public class LongestIncreasingSubSequence
    {
        public static List<int> GetResult(int[] input)
        {
            var result = new List<int>();
            var dp = new Dictionary<int, List<int>>();
            dp.Add(0, new List<int> { input[0] });
            var globalMax = dp[0].Count;
            result = dp[0];


            for (int i = 1; i < input.Length; i++)
            {
                var currentMax = 0;
                var maxIndex = -1;
                for (int j = 0; j < i; j++)
                {
                    if(input[j] < input[i])
                    {
                        if (dp[j].Count > currentMax)
                        {
                            currentMax = dp[j].Count;
                            maxIndex = j;
                        }                            
                    }
                }
                if(maxIndex == -1)
                {
                    dp.Add(i, new List<int> { input[i] });
                    //dp[i] = 1;
                }
                else
                {
                    var val = new List<int>();
                    foreach (var item in dp[maxIndex])
                    {
                        val.Add(item);
                    }
                    val.Add(input[i]);
                    dp.Add(i, val);
                    //dp[i] = dp[maxIndex] + 1;
                }

                if(dp[i].Count > globalMax)
                {
                    result = dp[i];
                    globalMax = dp[i].Count;
                }
            }
            //var result = dp[0];
            //for (int i = 1; i < dp.Length; i++)
            //{
            //    if (dp[i] > result)
            //        result = dp[i];
            //}
            return result;
        }
    }
}
