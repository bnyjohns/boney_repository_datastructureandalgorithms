using System;
using System.Collections.Generic;
using System.Linq;

class DFSClass
{
    static void AddToAdjacencyList(Dictionary<int, List<int>> ob, int node1, int node2)
    {
        if (ob.ContainsKey(node1))
            ob[node1].Add(node2);
        else
            ob.Add(node1, new List<int> { node2 });


        if (ob.ContainsKey(node2))
            ob[node2].Add(node1);
        else
            ob.Add(node2, new List<int> { node1 });
    }

    static void EntryPoint(string[] args)
    {
        int tcNumber = int.Parse(Console.ReadLine());
        for (int i = 1; i <= tcNumber; i++)
        {
            var adjList = new Dictionary<int, List<int>>();
            int[] token0 = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
            var toSearchNode = token0[0];
            var numberOfEdges = token0[1];

            for (int j = 1; j <= numberOfEdges; j++)
            {
                int[] token1 = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
                AddToAdjacencyList(adjList, token1[0], token1[1]);
            }

            var rootNode = 1;
            bool[] visited = new bool[toSearchNode + 1];
            Stack<int> vertices = new Stack<int>();
            int[] previous = new int[toSearchNode + 1];
            vertices.Push(rootNode);
            previous[rootNode] = -1;

            while (vertices.Any())
            {
                var currentNode = vertices.Pop();
                visited[currentNode] = true;
                if (currentNode == toSearchNode)
                {
                    break;
                }
                var edges = adjList[currentNode];
                for (int e = edges.Count() - 1; e >= 0; e--)
                {
                    var item = edges[e];
                    if (!visited[item] && !vertices.Contains(item))
                    {
                        previous[item] = currentNode;
                        vertices.Push(item);
                    }

                }
                //foreach (var item in edges)
                //{
                //    if (!visited[item] && !vertices.Contains(item))
                //    {
                //        previous[item] = currentNode;
                //        vertices.Push(item);
                //    }
                //}
            }

            int count = 0;
            Console.WriteLine($"Path: {toSearchNode} ->");
            while (true)
            {
                var pre = previous[toSearchNode];
                if (pre == -1)
                    break;
                else
                    toSearchNode = pre;
                Console.WriteLine($"{toSearchNode} ->");
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
