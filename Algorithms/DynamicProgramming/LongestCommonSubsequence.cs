using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    public class LongestCommonSubsequence
    {
        private static Dictionary<string, int> lkup = new Dictionary<string, int>();
        public static int GetLongestCommonSubsequenceUsingMemoization(string sequence1, string sequence2)
        {
            var key = string.Concat(sequence1, "|", sequence2);
            if (lkup.ContainsKey(key))
                return lkup[key];

            var result = 0;
            if (sequence1.Length == 0 || sequence2.Length == 0)
                return result;

            if (sequence1.Last() == sequence2.Last())
            {                
                result += (1 + GetLongestCommonSubsequenceUsingMemoization(sequence1.Substring(0, sequence1.Length - 1), sequence2.Substring(0, sequence2.Length - 1)));
            }                
            else
                result += Math.Max(GetLongestCommonSubsequenceUsingMemoization(sequence1.Substring(0, sequence1.Length), sequence2.Substring(0, sequence2.Length - 1)), GetLongestCommonSubsequenceUsingMemoization(sequence1.Substring(0, sequence1.Length - 1), sequence2.Substring(0, sequence2.Length)));

            lkup.Add(string.Concat(sequence1 + "|" + sequence2), result);
            return result;
        }

        public static int GetLongestSubsequenceUsingTabulation(string sequence1, string sequence2)
        {
            int[,] lcs = new int[sequence1.Length + 1, sequence2.Length + 1];
            for (int i = 0; i <= sequence1.Length; i++)
            {
                for (int j = 0; j <= sequence2.Length; j++)
                {
                    if (i == 0 || j == 0)
                        lcs[i, j] = 0;
                    else if (sequence1[i - 1] == sequence2[j - 1])
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    else
                        lcs[i, j] = Math.Max(lcs[i, j - 1], lcs[i - 1, j]);
                }
            }

            var lcsLength = lcs[sequence1.Length, sequence2.Length];
            var u = sequence1.Length;
            var v = sequence2.Length;

            char[] result = new char[lcsLength];
            var resultIndex = lcsLength - 1;
            while (u > 0 && v > 0)
            {
                if (sequence1[u - 1] == sequence2[v - 1])
                {
                    u--;
                    v--;
                    result[resultIndex] = sequence1[u];
                    resultIndex--;
                }
                else if (lcs[u, v - 1] > lcs[u - 1, v])
                    v--;
                else
                    u--;
            }
            var longestSubSequence = new string(result);
            return lcsLength;
        }
    }
}
