using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs.Hare_And_Tortoise_Race
{
    class Solution
    {
        static Dictionary<int, List<Vertice>> adjacentList;
        static void Main(string[] args)
        {
            adjacentList = new Dictionary<int, List<Vertice>>();
            var inp1 = Array.ConvertAll(Console.ReadLine().Split(' '), inp => int.Parse(inp));
            var hillCount = inp1[0];
            var roadCount = inp1[1];

            for (int i = 0; i < roadCount; i++)
            {
                var token = Array.ConvertAll(Console.ReadLine().Split(' '), inp => int.Parse(inp));
                var u = token[0];
                var v = token[1];
                var t = token[2];
                var h = token[3];

                if (!adjacentList.ContainsKey(u))
                    adjacentList.Add(u, new List<Vertice>());
                adjacentList[u].Add(new Vertice(v, t, h));
            }
            var cities = adjacentList.Keys.ToList();
            var resultMap = new Dictionary<int, Tuple<int, int>>();

            for (int i = 0; i < cities.Count; i++)
            {
                var baseCity = cities[i];
                var visited = "" + baseCity;
                var result = GetResult(baseCity, cities.Count - 1, visited, 0);
                resultMap.Add(baseCity, result);
            }

            var min = new Tuple<int, int>(int.MaxValue, int.MinValue);
            foreach (var result in resultMap)
            {
                if (result.Value.Item1 < min.Item1)
                    min = result.Value;
                else if (result.Value.Item1 == min.Item1)
                {
                    if (result.Value.Item2 > min.Item2)
                        min = result.Value;
                }
            }
            Console.WriteLine(min);
        }

        private static Tuple<int, int> GetResult(int vertex, int remainingVertexCount, string visited, int accumulator)
        {
            var startingVertex = int.Parse(visited.Substring(0, 1));
            var edges = adjacentList[vertex];

            var finalEdge = edges.Find(e => e.Value == startingVertex);
            if (finalEdge != null)
                return new Tuple<int, int>(visited.Split('_').Count(), accumulator + (finalEdge.HareTime - finalEdge.TortoiseTime));

            if (finalEdge == null && remainingVertexCount == 0)
                return new Tuple<int, int>(int.MaxValue, int.MinValue);

            var distList = new List<Tuple<int, int>>();
            for (int i = 0; i < edges.Count; i++)
            {
                var edge = edges[i];
                var v = edge.Value;
                var t = edge.TortoiseTime;
                var h = edge.HareTime;
                if (visited.Contains(v.ToString()))
                    continue;
                var result = GetResult(v, remainingVertexCount - 1, visited + "_" + v, accumulator + (h - t));
                if (result.Item1 != int.MaxValue)
                    distList.Add(result);
            }
            var min = new Tuple<int, int>(int.MaxValue, int.MinValue);
            if (distList.Count == 0)
                return min;

            foreach (var result in distList)
            {
                if (result.Item1 < min.Item1)
                    min = result;
                else if (result.Item1 == min.Item1)
                {
                    if (result.Item2 > min.Item2)
                        min = result;
                }
            }
            return min;
        }
    }

    public class Vertice
    {
        public Vertice(int value, int tortoiseTime, int hareTime)
        {
            Value = value;
            TortoiseTime = tortoiseTime;
            HareTime = hareTime;
        }
        public int Value { get; set; }
        public int TortoiseTime { get; set; }
        public int HareTime { get; set; }
    }
}
