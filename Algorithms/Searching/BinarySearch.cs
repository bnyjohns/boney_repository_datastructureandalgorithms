using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Searching
{
    class BinarySearch
    {
        //public static bool Search(int[] arr, int input)
        //{
        //    int left = 0;
        //    int right = arr.Length - 1;

        //    while (true)
        //    {
        //        int middle = (left + right) / 2;
        //        var currentElement = arr[middle];
        //        if (currentElement == input)
        //            return true;
        //        else
        //        {
        //            if (left == right)
        //                return false;

        //            if (currentElement > input)
        //                right = middle;
        //            else
        //                left = middle + 1; //Because we have floor when calculating middle
        //        }                
        //    }
        //}

        public static bool Search(int[] arr, int input)
        {
            return PartitionSearch(arr, input, 0, arr.Length - 1);
        }

        private static bool PartitionSearch(int[] arr, int input, int left, int right)
        {
            var middle = (left + right) / 2;
            if (input == arr[middle])
                return true;
            if (left == right)
                return false;
            else if (input > arr[middle])
                return PartitionSearch(arr, input, middle + 1, right);
            else
                return PartitionSearch(arr, input, left, middle);
        }
    }
}
