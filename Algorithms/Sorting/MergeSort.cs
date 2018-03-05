using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Sorting
{
    public class MergeSort
    {
        public static void Sort(ref int[] input)
        {
            input = Sort(input.ToList()).ToArray();
        }

        private static List<int> Sort(List<int> input)
        {
            List<int> result = new List<int>();
            if (input.Count <= 1)
                return input;

            int inputCount = input.Count;
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middleIndex = inputCount / 2;           
            for (int i = 0; i < inputCount; i++)
            {
                if (i < middleIndex)
                {
                    left.Add(input[i]);                 
                }
                else
                {
                    right.Add(input[i]);                    
                }
            }

            left = Sort(left);
            right = Sort(right);

            return Merge(left,right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0] < right[0])
                    {
                        result.Add(left[0]);
                        left.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.RemoveAt(0);
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else if (right.Count > 0)
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            return result;
        }
    }
}
