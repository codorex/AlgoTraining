using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTraining._01_Graphs.Core
{
    public class Graph<TVertex>
    {
        private readonly Dictionary<TVertex, List<TVertex>> _map;

        public Graph()
        {
            _map = new Dictionary<TVertex, List<TVertex>>();
        }

        public List<TVertex> this[TVertex vertex]
        {
            get
            {
                List<TVertex> edges;
                _map.TryGetValue(vertex, out edges);

                return edges;
            }
        }

        public List<TVertex> Vertices
        {
            get
            {
                return _map.Keys?.ToList();
            }
        }

        public void Connect(TVertex src, TVertex dest)
        {
            if (!_map.ContainsKey(src))
                _map.Add(src, new List<TVertex>());

            if (!_map.ContainsKey(dest))
                _map.Add(dest, new List<TVertex>());

            if (!this[src].Contains(dest))
            {
                this[src].Add(dest);
            }
        }

        public void Disconnect(TVertex src, TVertex dest)
        {
            if (!_map.ContainsKey(src)
                || !_map.ContainsKey(dest))
            {
                throw new ArgumentOutOfRangeException();
            }

            List<TVertex> adjacentVertices = this[src];

            if (adjacentVertices.Count <= 1)
            {
                _map.Remove(src);
                return;
            }

            // Do we want to throw an exception here?
            TVertex vertexToRemove = adjacentVertices.First(v => v.Equals(dest));

            adjacentVertices.Remove(vertexToRemove);
        }
    }
}
