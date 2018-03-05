using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Sorting
{
    public class HeapSort
    {
        public static void Sort(int[] input) 
        {            
            Heapify(input, input.Length);            
            int end = input.Length - 1;
            while (end > 0)
            {
                Helper.Swap(ref input[end], ref input[0]);
                SiftDown(input, 0, end - 1);
                end--;
            }
        }

        private static void Heapify(int[] input, int length)
        {
            int lastParentIndex = (length - 2) / 2;
            while(lastParentIndex >= 0)
            {
                SiftDown(input, lastParentIndex, length - 1);
                lastParentIndex--;
            }        
        }

        private static void SiftDown(int[] input, int startIndex, int endIndex)
        {
            int rootIndex = startIndex;            
            while (rootIndex * 2 + 1 <= endIndex)
            {
                int swapIndex = rootIndex;
                if (input[rootIndex] < input[rootIndex * 2 + 1])
                    swapIndex = rootIndex * 2 + 1;
                if (rootIndex * 2 + 2 <= endIndex && input[swapIndex] < input[rootIndex * 2 + 2])
                    swapIndex = rootIndex * 2 + 2;
                if (rootIndex != swapIndex)
                {
                    Helper.Swap(ref input[rootIndex], ref input[swapIndex]);
                    rootIndex = swapIndex;
                }
                else
                {
                    rootIndex++;
                }
            }
        }
    }
}
