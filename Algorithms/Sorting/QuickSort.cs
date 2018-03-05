using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Sorting
{
    public class QuickSort
    {
        public static void Sort(int[] input)
        {            
            Partition(input, 0, input.Length - 1);
        }

        private static void Partition(int[] input, int lowIndex, int highIndex)
        {
            if (highIndex - lowIndex == 1)
                return;

            int pivotIndex = (lowIndex + highIndex) / 2;
            int pivot = input[pivotIndex];
            int i = lowIndex;
            int j = highIndex;

            while (j > i)
            {
                pivot = input[pivotIndex];
                while (input[i] < pivot)
                    i++;

                while (input[j] > pivot)
                    j--;

                if (input[i] > input[j])
                {
                    Helper.Swap(ref input[i], ref input[j]);
                    i++;
                    j--;
                }
            }

            if (lowIndex < j)
                Partition(input, lowIndex, j);
            if (highIndex > i)
                Partition(input, i, highIndex);
        }
    }
}
