using AlgoTraining._01_Graphs.Core;

using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTraining._01_Graphs.Implementations
{
    public class IterativeGraphRelationshipValidator<TVertex> : IGraphRelationshipValidator<TVertex>
    {
        private readonly Graph<TVertex> _graph;

        public IterativeGraphRelationshipValidator(Graph<TVertex> graph)
        {
            _graph = graph;
        }

        [Obsolete]
        public bool BidirectionalRelationshipExists(TVertex src, TVertex dest)
        {
            throw new NotImplementedException();
        }

        public bool RelationshipExists(TVertex src, TVertex dest)
        {
            // Keep track of higher-layer vertices when drilling down.
            var verticesQueue = new Queue<TVertex>();

            // Track visited vertices to avoid cyclic search.
            var visitedVertices = new List<TVertex>();

            TVertex current = src;

            verticesQueue.Enqueue(current);
            visitedVertices.Add(current);

            while (verticesQueue.Count > 0)
            {
                current = verticesQueue.Dequeue();

                foreach (TVertex vertex in _graph[current])
                {
                    if (!visitedVertices.Contains(vertex))
                    {
                        verticesQueue.Enqueue(vertex);
                        visitedVertices.Add(vertex);
                    }

                    if (vertex.Equals(dest))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
