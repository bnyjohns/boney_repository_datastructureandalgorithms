using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class WeightedGraph
    {
        private bool _directed = false;
        private Dictionary<char, List<Tuple<char,int>>> _graph = null;

        public WeightedGraph(bool directed)
        {
            _directed = directed;
            _graph = new Dictionary<char, List<Tuple<char, int>>>();
        }

        public void Add(char source, char dest, int weight)
        {
            if (_graph.ContainsKey(source))
                _graph[source].Add(new Tuple<char, int>(dest, weight));
            else
                _graph.Add(source, new List<Tuple<char, int>>{ new Tuple<char, int>(dest, weight) });

            if (!_directed)
            {
                if (_graph.ContainsKey(dest))
                    _graph[dest].Add(new Tuple<char, int>(source, weight));
                else
                    _graph.Add(dest, new List<Tuple<char, int>> { new Tuple<char, int>(source, weight) });
            }
        }

        public List<Tuple<char, int>> Edges(char vertex)
        {
            return _graph[vertex];
        }

        public List<char> Vertices
        {
            get
            {
                return _graph.Keys.ToList();
            }
        }

        public int VerticeCount { get { return _graph.Count; } }
    }
}
