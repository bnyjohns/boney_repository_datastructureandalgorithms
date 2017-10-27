using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Solution
{

    static void Main1(String[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        var numberOfSubsets = Math.Pow(2, n);
        var subsets = new List<List<int>>();
        for (int i = 0; i < numberOfSubsets; i++)
        {
            var binary = Convert.ToString(i, 2).PadLeft(3, '0');
            subsets.Add(GetSubSet(binary, arr));
        }

    }

    private static List<int> GetSubSet(string binary, int[] arr)
    {
        var result = new List<int>();
        for (int i = 0; i < binary.Length; i++)
        {
            if (binary[i] == '1')
                result.Add(arr[i]);
        }
        return result;
    }
}