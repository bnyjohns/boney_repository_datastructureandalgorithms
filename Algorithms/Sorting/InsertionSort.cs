using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Sorting
{
    public class InsertionSort
    {
        public static void Sort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int j = i + 1;
                while (j > 0 && j < input.Length)
                {
                    if (input[j] < input[j - 1])
                    {
                        Helper.Swap(ref input[j], ref input[j - 1]);
                    }
                    j--;
                }
            }
        }
    }
}
