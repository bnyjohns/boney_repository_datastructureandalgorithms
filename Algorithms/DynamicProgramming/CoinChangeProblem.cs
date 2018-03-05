using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    public class CoinChangeProblem
    {
        static long[] coinValues = null;
        static Dictionary<string, long> lkup;
        static int lookUpCount = 0;
        public static void Solve()
        {
            var token_0 = Array.ConvertAll(Console.ReadLine().Split(' '), t => long.Parse(t));
            coinValues = Array.ConvertAll(Console.ReadLine().Split(' '), t => long.Parse(t));
            var number = token_0[0];
            lkup = new Dictionary<string, long>();
            //var number = 4;
            //coinValues = new long[] { 1,2,3 };
            lookUpCount = 0;
            var result = FindNumberOfChanges(coinValues, coinValues.Length, number);
            Console.WriteLine(result);
        }

        private static long FindNumberOfChanges(long[] coinValues, long m, long n)
        {
            if (n == 0)
                return 1;

            if (n < 0)
                return 0;

            if (m <= 0 && n > 0)
                return 0;

            var key = GetKey(m - 1, n);
            var includingM = 0L;
            var excludingM = 0L;
            if (lkup.ContainsKey(key))
            {
                lookUpCount++;
                includingM = lkup[key];
            }                
            else
            {
                includingM = FindNumberOfChanges(coinValues, m - 1, n);
                lkup.Add(GetKey(m - 1, n), includingM);
            }

            key = GetKey(m, n - coinValues[m - 1]);
            if (lkup.ContainsKey(key))
            {
                lookUpCount++;
                excludingM = lkup[key];
            }                
            else
            {
                excludingM = FindNumberOfChanges(coinValues, m, n - coinValues[m - 1]);
                lkup.Add(key, excludingM);
            }
            
            return includingM + excludingM;
        }



        private static string GetKey(long m, long n)
        {
            return m.ToString() + "_" + n.ToString();
        }
    }
}
