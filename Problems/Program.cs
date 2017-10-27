using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class Program
    {        
        static void Main(string[] args)
        {
            var tcNumber = int.Parse(Console.ReadLine());
            while(tcNumber > 0)
            {
                List<int> bottleCapacities = null;
                var inp1 = Console.ReadLine();
                var inp1Split = inp1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var bottleCount = int.Parse(inp1Split[0]);
                var containerCapacity = int.Parse(inp1Split[1]);
                bottleCapacities = new List<int>(bottleCount);

                var inp2 = Console.ReadLine();
                var inp2Split = inp2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in inp2Split)
                {
                    bottleCapacities.Add(int.Parse(item));
                }
                ExecuteLogic(containerCapacity, bottleCount, bottleCapacities);

                tcNumber--;
            }
        }

        private static void ExecuteLogic(int containerCapacity, int bottleCount, List<int> bottleCapacities)
        {
            bottleCapacities.Sort((a, b) =>
            {
                if (a > b)
                    return 1;
                else if (a < b)
                    return -1;
                return 0;
            });

            var sum = 0;
            var result = new List<int>();
            foreach (var item in bottleCapacities)
            {
                sum += item;
                if (sum > 10)
                    break;

                result.Add(item);
            }
            Console.WriteLine(result.Count);         
        }
    }
}
