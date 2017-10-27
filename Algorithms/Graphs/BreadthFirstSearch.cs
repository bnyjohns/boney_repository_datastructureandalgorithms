using System;
using System.Collections.Generic;
using System.Linq;

//Answer to: https://www.hackerearth.com/practice/algorithms/graphs/breadth-first-search/practice-problems/algorithm/monk-and-the-islands/
class MyClass
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
            Queue<int> vertices = new Queue<int>();
            int[] previous = new int[toSearchNode + 1];
            vertices.Enqueue(rootNode);
            previous[rootNode] = -1;

            while (vertices.Any())
            {
                var currentNode = vertices.Dequeue();
                visited[currentNode] = true;
                if (currentNode == toSearchNode)
                {
                    break;
                }
                var edges = adjList[currentNode];
                foreach (var item in edges)
                {
                    if (!visited[item] && !vertices.Contains(item))
                    {
                        previous[item] = currentNode;
                        vertices.Enqueue(item);
                    }
                }
            }

            int count = 0;
            while (true)
            {
                var pre = previous[toSearchNode];
                if (pre == -1)
                    break;
                else
                    toSearchNode = pre;
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
