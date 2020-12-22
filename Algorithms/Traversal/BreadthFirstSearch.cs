using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Traversal
{
    public class BreadthFirstSearch
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

            var result = Find(adjList, 1, 12);
        }


        /// <summary>
        /// Returns the shortest distance or -1 if not found
        /// </summary>
        /// <param name="adjList">Graph</param>
        /// <param name="start">Start element</param>
        /// <param name="search">Search for element</param>
        /// <returns></returns>
        private static int Find(Dictionary<int, List<int>> adjList, int start, int search)
        {
            var queue = new Queue<int>();
            var level = new Dictionary<int, int>();
            var parent = new Dictionary<int, int>();

            queue.Enqueue(start);
            level.Add(start, 0);

            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (current == search)
                    return level[current];

                if (adjList.ContainsKey(current))
                {
                    var neighbours = adjList[current];
                    foreach (var item in neighbours)
                    {
                        if (level.ContainsKey(item))
                            continue;

                        queue.Enqueue(item);
                        level.Add(item, level[current] + 1);
                        parent[item] = current;
                    }
                }
            }
            return -1;
        }
    }
}
