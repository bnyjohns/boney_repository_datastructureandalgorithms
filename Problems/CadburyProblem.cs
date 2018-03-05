using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class CandidateCode
    {
        private static Dictionary<string, int> lookUp = new Dictionary<string, int>();
        public static int cadbury(int m, int n, int p, int q)
        {
            var result = 0;
            for (int i = m; i <= n; i++)
            {
                for (int j = p; j <= q; j++)
                {
                    result += GetNumberOfChildren(i, j);
                }
            }
            return result;
        }

        static int GetNumberOfChildren(int length, int breadth)
        {
            var result = 0;           
            if (length == breadth)
                return 1;
            else
            {
                var key = length.ToString() + "_" + breadth.ToString();
                if (lookUp.ContainsKey(key))
                    return lookUp[key];
                else
                {
                    if(length > breadth)
                    {
                        result += 1 + GetNumberOfChildren(length - breadth, breadth);
                    }
                    else
                    {
                        result += 1 + GetNumberOfChildren(length, breadth - length);
                    }
                }
                lookUp.Add(key, result);
            }
            return result;
        }
    }
}
