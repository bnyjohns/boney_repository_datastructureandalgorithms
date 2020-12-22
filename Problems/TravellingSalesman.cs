using DataStructures.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    /*
    w--6-----x
    | \   /  |
   1|   \/   |3
    |  4/  \3|
    | /     \|
    y---2----z
         */

    public class TravellingSalesman
    {
        static WeightedGraph graph = null;
        public static void Start()
        {
            graph = new WeightedGraph(false);
            graph.Add('w', 'x', 6);
            graph.Add('w', 'y', 1);
            graph.Add('w', 'z', 3);
            graph.Add('x', 'y', 4);
            graph.Add('x', 'z', 3);
            graph.Add('y', 'z', 2);

            int min = int.MaxValue;
            for (int i = 0; i < graph.VerticeCount; i++)
            {
                var vertex = graph.Vertices[i];
                var visited = "" + vertex;
                var distance = GetDistance(vertex, graph.VerticeCount - 1, visited, 0);
                if (distance < min)
                    min = distance;
            }
            Console.WriteLine(min);
        }

        private static int GetDistance(char vertex, int remainingVerticeCount, string visited, int accumulator)
        {
            var startingVertex = char.Parse(visited.Substring(0, 1));
            var edges = graph.Edges(vertex);
            if(remainingVerticeCount == 0)
            {
                var edge = edges.Find(e => e.Item1 == startingVertex);
                if (edge != null)
                    return accumulator + edge.Item2;
                else
                    return int.MaxValue;
            }

            var distList = new List<int>();
            for (int i = 0; i < edges.Count; i++)
            {
                var edge = edges[i];
                var v = edge.Item1;
                var w = edge.Item2;
                if (visited.Contains(v))
                    continue;
                var dist = GetDistance(v, remainingVerticeCount - 1, visited + "_" + v, accumulator + w);
                if(dist != int.MaxValue)
                    distList.Add(dist);
            }
            if (distList.Count == 0)
                return int.MaxValue;
            return distList.Min();
        }
    }
}
