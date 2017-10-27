using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    class FibonacciSeries
    {
        static Dictionary<int, int> lkup = new Dictionary<int, int>();
        static FibonacciSeries()
        {
            lkup.Add(0, 0);
            lkup.Add(1, 1);
        }

        //Recursion with Memoization(DP)
        public static int GetFibonacci(int n)
        {
            if (lkup.ContainsKey(n))
                return lkup[n];            

            var a = GetFibonacci(n - 1);
            lkup.Add(n - 1, a);
            var b = GetFibonacci(n - 2);
            lkup.Add(n - 2, b);
            return a + b;
        }

        public static int GetFibonacciIteration(int n)
        {
            var a = 0;
            var b = 1;
            if (n == 1)
                return a;
            if (n == 2)
                return 0;

            while (true)
            {

            }
        }
    }
}
