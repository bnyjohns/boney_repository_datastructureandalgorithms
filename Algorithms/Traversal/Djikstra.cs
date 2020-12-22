using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Traversal
{
    class Node
    {
        public Node(string name, int distance)
        {
            Name = name;
            Distance = distance;
        }
        public string Name { get; set; }
        public int Distance { get; set; }
    }

    public class Djikstra
    {
        public static int GetShortestPath()
        {
            var consoleInp = new string[] { "a b 4", "a c 2", "b d 5", "c d 8", "c e 10", "d e 2", "d z 6", "e z 2" };
            var source = "a";
            var target = "z";
            var inp = new Dictionary<string, List<Node>>();
            var dist = new Dictionary<string, int>();
            var prev = new Dictionary<string, string>();
            var visited = new HashSet<string>();
            var queue = new PriorityQueue<Node>((p, c) => p.Distance > c.Distance);

            foreach (var item in consoleInp)
            {
                var token = item.Split(' ');
                var a = token[0];
                var b = token[1];
                var c = int.Parse(token[2]);

                if (inp.ContainsKey(a))
                    inp[a].Add(new Node(b, c));
                else
                    inp.Add(a, new List<Node> { new Node(b, c)});

                if (inp.ContainsKey(b))
                    inp[b].Add(new Node(a, c));
                else
                    inp.Add(b, new List<Node> { new Node(a, c) });
            }

            foreach (var item in inp)
            {
                dist[item.Key] = int.MaxValue;
            }

            dist[source] = 0;
            prev[source] = "";
            queue.Enqueue(new Node(source, 0));
            visited.Add(source);

            while (queue.Any())
            {
                var current = queue.Dequeue();
                visited.Add(current.Name);

                if(current.Name == target)
                    return dist[current.Name];

                var neighbours = inp[current.Name];
                foreach (var neighbour in neighbours)
                {
                    if (visited.Contains(neighbour.Name))
                        continue;

                    prev[neighbour.Name] = current.Name;
                    if (dist[current.Name] + neighbour.Distance < dist[neighbour.Name])
                        dist[neighbour.Name] = dist[current.Name] + neighbour.Distance;
                        
                    queue.Enqueue(neighbour);
                }
            }
            return int.MaxValue;
        }

    }
}
