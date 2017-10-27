using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    class Djikstra
    {
        public static void Main()
        {
            var undefined = "UNDEFINED";
            var consoleInp = new string[] { "a b 4", "a c 2", "b d 5", "c d 8", "c e 10", "d e 2", "d z 6", "e z 2" };
            var source = "a";
            var inp = new Dictionary<string, List<Tuple<string, int>>>();
            var dist = new Dictionary<string, int>();
            var prev = new Dictionary<string, string>();
            var queue = new List<string>();

            foreach (var item in consoleInp)
            {
                var token = item.Split(' ');
                var a = token[0];
                var b = token[1];
                var c = int.Parse(token[2]);

                if (inp.ContainsKey(a))
                    inp[a].Add(new Tuple<string, int>(b, c));
                else
                    inp.Add(a, new List<Tuple<string, int>> { new Tuple<string, int>(b, c)});

                if (inp.ContainsKey(b))
                    inp[b].Add(new Tuple<string, int>(a, c));
                else
                    inp.Add(b, new List<Tuple<string, int>> { new Tuple<string, int>(a, c) });
            }

            foreach (var item in inp)
            {
                queue.Add(item.Key);
                dist[item.Key] = int.MaxValue;
                prev[item.Key] = undefined;
            }

            dist[source] = 0;
            //var visited = new Dictionary<string, bool>();
            while (queue.Count > 0)
            {                
                var min = dist.Min(kvp => kvp.Value);
                var u = dist.First(kvp => queue.Contains(kvp.Key) && kvp.Value == min).Key;
                queue.Remove(u);

                foreach (var item in inp[u])
                {
                    var v = item.Item1;
                    var alt = dist[u] + item.Item2;
                    if (alt < dist[v])
                    {
                        dist[v] = alt;
                        prev[v] = u;
                    }                        
                }
            }
        }

    }
}
