using System.Collections.Generic;
using TrainRoute.Kernel.Models;

namespace TrainRoute.Domain.Models
{
    public sealed class TrainConnection : IEdge<char>
    {
        public int Value { get; set; }
        public INode<char> Origin { get; set; }
        public INode<char> Destination { get; set; }
        public TrainConnection(int distance, INode<char> origin, INode<char> destination)
        {
            Value = distance;
            Origin = origin;
            Destination = destination;
        }
    }
}