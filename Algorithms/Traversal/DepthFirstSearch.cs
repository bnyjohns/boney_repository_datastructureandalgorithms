using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Traversal
{
    class DFS
    {
        public static void Execute()
        {
            //Refer graph.PNG
            var adjList = new Dictionary<int, List<int>>();
            adjList.Add(1, new List<int> { 2, 3, 4 });
            adjList.Add(2, new List<int> { 5, 6 });
            adjList.Add(4, new List<int> { 7, 8 });
            adjList.Add(5, new List<int> { 9, 10 });
            adjList.Add(7, new List<int> { 11, 12 });

            var result = FindUsingIteration(adjList, 1, 12);
        }

        private static bool FindUsingRecursion(Dictionary<int, List<int>> adjList, int current, int search, HashSet<int> visited)
        {
            visited.Add(current);
            Console.WriteLine("Visited: " + current);
            if (current == search)
                return true;

            if (adjList.ContainsKey(current))
            {
                var neighbours = adjList[current];
                foreach (var item in neighbours)
                {
                    if (visited.Contains(item))
                        continue;

                    if (FindUsingRecursion(adjList, item, search, visited))
                        return true;
                }
            }
            return false;
        }


        private static bool FindUsingIteration(Dictionary<int, List<int>> adjList, int start, int search)
        {
            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> parent = new Dictionary<int, int>();
            Dictionary<int, int> level = new Dictionary<int, int>();
            stack.Push(start);
            level.Add(start, 0);
            while (stack.Any())
            {
                var current = stack.Pop();
                Console.WriteLine("Visited: " + current);
                if (current == search)
                    return true;

                if (adjList.ContainsKey(current))
                {
                    var neighbours = adjList[current];
                    neighbours.Reverse();
                    foreach (var item in neighbours)
                    {
                        if (level.ContainsKey(item))
                            continue;

                        level.Add(item, level[current] + 1);
                        parent[item] = current;
                        stack.Push(item);
                    }
                }
            }
            return false;
        }
    }
}
