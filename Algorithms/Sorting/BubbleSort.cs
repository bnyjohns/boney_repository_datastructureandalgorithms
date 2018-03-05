using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Sorting
{
    class BubbleSort
    {
        public static void Sort(int[] input)
        {
            for (int j = 1; j <= input.Length; j++)
            {
                int lastIndex = input.Length - 1;
                for (int i = 0; i < lastIndex; i++)
                {
                    if (i + 1 <= lastIndex && input[i] > input[i + 1])
                    {
                        int temp = input[i];
                        input[i] = input[i + 1];
                        input[i + 1] = temp;
                    }
                }
            }
        }
    }
}
