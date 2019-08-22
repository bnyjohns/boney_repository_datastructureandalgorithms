using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public class Graph
    {
        Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();
        public Graph(bool directed)
        {
            IsDirected = directed;
        }
        public bool IsDirected { get; set; }
        private int Root { get; set; }

        public void AddEdge(int e1, int e2)
        {
            if (edges.Count == 0)
                Root = e1;

            if (edges.ContainsKey(e1))
                edges[e1].Add(e2);
            else
                edges.Add(e1, new List<int>() { e2 });

            if (!IsDirected)
            {
                if (edges.ContainsKey(e2))
                    edges[e2].Add(e1);
                else
                    edges.Add(e2, new List<int>() { e1 });
            }
        }

        public List<int> Edges(int vertice)
        {
            return edges[vertice];
        }

        public bool BFS(int value)
        {
            if (Root == value)
                return true;

            Dictionary<int, bool> visited = new Dictionary<int, bool>();
            Console.WriteLine($"Visited {Root}");
            visited.Add(Root, true);
            Queue<int> queue = new Queue<int>();
            edges[Root].ForEach(vertice => queue.Enqueue(vertice));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (visited.ContainsKey(current))
                {
                    Console.WriteLine($"Visiting {current}, but already visited and hence ignoring");
                    continue;
                }

                Console.WriteLine($"Visited {current}");
                if (current == value)
                    return true;
                else
                {
                    visited.Add(current, true);
                    edges[current].ForEach(vertice => queue.Enqueue(vertice));
                }
            }
            return false;
        }

        //public bool DFS(int value)
        //{
        //    if (Root == value)
        //        return true;

        //    Stack<int> stack = new Stack<int>();
        //    Dictionary<int, bool> visited = new Dictionary<int, bool>();
        //    visited.Add(Root, true);
        //    Console.WriteLine($"Visited {Root}");

        //    for (int i = edges[Root].Count - 1; i >= 0; i--)
        //        stack.Push(edges[Root][i]);

        //    while(stack.Count > 0)
        //    {
        //        var current = stack.Pop();
        //        if (visited.ContainsKey(current))
        //        {
        //            Console.WriteLine($"Visiting {current}, but already visited and hence ignoring");
        //            continue;
        //        }

        //        Console.WriteLine($"Visited {current}");
        //        if (current == value)
        //            return true;

        //        for (int i = edges[current].Count - 1; i >= 0; i--)
        //            stack.Push(edges[current][i]);
        //    }
        //    return false;
        //}

        public bool DFS(int value)
        {
            if (Root == value)
                return true;

            var visited = new Dictionary<int, bool>();
            visited.Add(Root, true);
            Console.WriteLine($"Visited {Root}");

            return DFSRecursive(Root, value, visited);
        }

        private bool DFSRecursive(int currentVertice, int value, Dictionary<int, bool> visited)
        {
            for (int i = 0; i < edges[currentVertice].Count; i++)
            {
                var current = edges[currentVertice][i];
                if (visited.ContainsKey(current))
                {
                    Console.WriteLine($"Visiting {current}, but already visited and hence ignoring");
                    continue;
                }
                if (current == value)
                    return true;

                visited.Add(current, true);
                Console.WriteLine($"Visited {current}");
                var result = DFSRecursive(current, value, visited);
                if (result)
                    return true;
            }
            return false;
        }
    }
}
