using AlgoTraining._01_Graphs.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTraining._01_Graphs.Implementations
{
    public class RecursiveGraphRelationshipValidator<TVertex> : IGraphRelationshipValidator<TVertex>
    {
        private readonly Graph<TVertex> _graph;

        public RecursiveGraphRelationshipValidator(Graph<TVertex> graph)
        {
            _graph = graph;
        }

        public bool BidirectionalRelationshipExists(TVertex src, TVertex dest)
        {
            if (_graph[dest] == null)
            {
                return false;
            }

            var visited = new List<TVertex>();

            return RelationshipExistsRecurse(src, dest, visited)
                || RelationshipExistsRecurse(dest, src, visited);
        }

        public bool RelationshipExists(TVertex src, TVertex dest)
        {
            // The looked for vertex does not exist in the graph.
            if (_graph[dest] == null)
            {
                return false;
            }

            var visited = new List<TVertex>();

            return RelationshipExistsRecurse(src, dest, visited);
        }

        private bool RelationshipExistsRecurse(TVertex src, TVertex dest, List<TVertex> visited)
        {
            if (visited.Contains(src))
            {
                return false;
            }

            visited.Add(src);

            bool areRelated = false;

            foreach (var edgeVertex in _graph[src])
            {
                if (edgeVertex.Equals(dest))
                {
                    return true;
                }

                areRelated = RelationshipExistsRecurse(edgeVertex, dest, visited);
            }

            return areRelated;
        }
    }
}
