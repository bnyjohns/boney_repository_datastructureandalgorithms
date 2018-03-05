using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Sorting
{
    class SelectionSort
    {
        public static void Sort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int iMin = i;
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[iMin] > input[j])
                        iMin = j;
                }
                if (i != iMin)
                {
                    int temp = input[i];
                    input[i] = input[iMin];
                    input[iMin] = temp;
                }
            }
        }
    }
}
