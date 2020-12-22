using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DynamicProgramming
{
    public class MaximumSubArray
    {
        public static void Start()
        {
            var tcNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < tcNumber; i++)
            {
                var numberOfElements = long.Parse(Console.ReadLine());
                var elements = Array.ConvertAll(Console.ReadLine().Split(' '), a => long.Parse(a));
                //var elements = new int[] { 2,- 1, 2, 3, 4, - 5 };
                var arr = GetResult(elements);
                Console.WriteLine($"{arr[0]} {arr[1]}");
            }
            
        }

        private static long[] GetResult(long[] elements)
        {
            var dp = new long[elements.Length];
            dp[0] = elements[0];
            var subSetMax = dp[0];
            var subSeqMax = dp[0];
            for (long i = 1; i < elements.Length; i++)
            {
                var temp = dp[i - 1] + elements[i];
                if (elements[i] >= temp)
                    dp[i] = elements[i];
                else
                    dp[i] = temp;

                if (subSeqMax + elements[i] > subSeqMax)
                {
                    subSeqMax += elements[i];
                }
                else if (elements[i] > subSeqMax)
                    subSeqMax = elements[i];

                if (dp[i] > subSetMax)
                    subSetMax = dp[i];
            }

            return new long[] { subSetMax, subSeqMax };
        }
    }
}
