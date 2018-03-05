using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class ChocolateDistributionProblem
    {
        public static void Solve()
        {
            var tcNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < tcNumber; i++)
            {
                var number = int.Parse(Console.ReadLine());
                var chocs = Array.ConvertAll(Console.ReadLine().Split(' '), t => int.Parse(t));
                var output = ComputeOutput(chocs, 0, number);
            }
        }

        private static int ComputeOutput(int[] chocs, int m, int n)
        {
            if (m - 1 == n)
                return 0;

            if (n == 0)
                return 0;

            //Math.Abs(chocs[i] - chocs[i - 1]);
            //return Math.Max(ComputeOutput(chocs,0, 
            return 1;
        }
    }
}
