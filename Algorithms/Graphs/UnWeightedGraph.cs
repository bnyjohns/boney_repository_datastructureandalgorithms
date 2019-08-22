using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    //Using Adjacency List
    class UnweightedGraph
    {
        private Dictionary<int, List<int>> _graph = null;
        private bool _directed = false;
        public UnweightedGraph(bool directed)
        {
            _graph = new Dictionary<int, List<int>>();
            _directed = directed;
        }

        public void Add(int source, int dest)
        {
            if (_graph.ContainsKey(source))
                _graph[source].Add(dest);
            else
                _graph.Add(source, new List<int> { dest });

            if (!_directed)
            {
                if (_graph.ContainsKey(dest))
                    _graph[dest].Add(source);
                else
                    _graph.Add(dest, new List<int> { source });
            }
        }

        public List<int> Edges(int vertex)
        {
            return _graph[vertex];
        }

        public int VerticeCount {get { return _graph.Count; } }
    }
}
