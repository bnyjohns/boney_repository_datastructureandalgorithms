using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs.EarthQuake_In_Africa
{
    class Solution
    {
        class Vertice
        {
            public Vertice(int value, int weight)
            {
                Value = value;
                Weight = weight;
            }
            public int Weight { get; set; }
            public int Value { get; set; }
        }

        static Dictionary<int, List<Vertice>> adjacentList;
        static List<int> affectedCities;
        static void Start(string[] args)
        {
            adjacentList = new Dictionary<int, List<Vertice>>();
            affectedCities = new List<int>();
            var inp1 = Array.ConvertAll(Console.ReadLine().Split(' '), inp => int.Parse(inp));
            var cityCount = inp1[0];
            var roadCount = inp1[1];
            var affectedCityCount = inp1[2];
            for (int i = 0; i < affectedCityCount; i++)
                affectedCities.Add(int.Parse(Console.ReadLine()));

            for (int i = 0; i < roadCount; i++)
            {
                var token = Array.ConvertAll(Console.ReadLine().Split(' '), inp => int.Parse(inp));
                var u = token[0];
                var v = token[1];
                var w = token[2];

                if (adjacentList.ContainsKey(u))
                    adjacentList[u].Add(new Vertice(v, w));
                else
                    adjacentList.Add(u, new List<Vertice> { new Vertice(v, w) });

                if (adjacentList.ContainsKey(v))
                    adjacentList[v].Add(new Vertice(u, w));
                else
                    adjacentList.Add(v, new List<Vertice> { new Vertice(u, w) });
            }
            var nonAffectedCities = adjacentList.Keys.Except(affectedCities).ToList();
            var distMap = new Dictionary<int, int>();

            for (int i = 0; i < nonAffectedCities.Count; i++)
            {
                var baseCity = nonAffectedCities[i];
                var visited = "" + baseCity;
                var distance = 2 * GetDistance(baseCity, visited, 0);
                distMap.Add(baseCity, distance);
            }

            var min = int.MaxValue;
            foreach (var item in distMap)
            {
                if (item.Value < min)
                    min = item.Value;
            }
            Console.WriteLine(min);
        }

        private static int GetDistance(int vertex, string visited, int accumulator)
        {
            var startingVertex = int.Parse(visited.Substring(0, 1));
            var edges = adjacentList[vertex];
            if (affectedCities.All(c => Array.ConvertAll(visited.Split('_'), v => int.Parse(v)).Contains(c)))
            {
                return accumulator;
            }

            var distList = new List<int>();
            for (int i = 0; i < edges.Count; i++)
            {
                var edge = edges[i];
                var v = edge.Value;
                var w = edge.Weight;
                if (visited.Contains(v.ToString()))
                    continue;
                var dist = GetDistance(v, visited + "_" + v, accumulator + w);
                if (dist != int.MaxValue)
                    distList.Add(dist);
            }
            if (distList.Count == 0)
                return int.MaxValue;
            return distList.Min();
        }
    }
}
