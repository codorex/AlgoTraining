using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTraining._01_Graphs.Core
{
    public interface IGraphRelationshipValidator<TVertex>
    {
        /// <summary>
        /// Determines whether any path exists from the first to the second node.
        /// </summary>
        /// <param name="src">The starting node.</param>
        /// <param name="dest">The looked for node.</param>
        bool RelationshipExists(TVertex src, TVertex dest);

        /// <summary>
        /// Determines whether any path exists from the first to the second node, indifferent to direction.
        /// </summary>
        /// <param name="src">The starting node.</param>
        /// <param name="dest">The looked for node.</param>
        /// <returns></returns>
        bool BidirectionalRelationshipExists(TVertex src, TVertex dest);
    }
}
