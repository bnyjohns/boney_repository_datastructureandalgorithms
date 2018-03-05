using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    //Problem Statement: On a positive integer, you can perform any one of the following 3 steps.  
    //1.) Subtract 1 from it. (n = n - 1)  , 2.) If its divisible by 2, divide by 2. ( if n % 2 == 0 , then n = n / 2  )  , 
    //3.) If its divisible by 3, divide by 3. ( if n % 3 == 0 , then n = n / 3  ). Now the question is, given a positive integer n, find the minimum number of steps that takes n to
    public class MinimumStepsToOne
    {
        static Dictionary<int, int> lkup = new Dictionary<int, int>();
        public static int GetMinimumStepsToOne(int n)
        {
            if (n == 1 || n == 0)
                return 0;
            if (lkup.ContainsKey(n))
                return lkup[n];

            var result = 1 + GetMinimumStepsToOne(n - 1);
            if (n % 2 == 0)
                result = Math.Min(result, 1 + GetMinimumStepsToOne(n / 2));
            if (n % 3 == 0)
                result = Math.Min(result, 1 + GetMinimumStepsToOne(n / 3));
            lkup.Add(n, result);
            return result;
            
        }

        private static int Min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }
}
