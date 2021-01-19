using System.Collections.Generic;

namespace TrainRoute.Kernel.Models
{
    public interface IEdge<T>
    {
        int Value { get; set; }
        INode<T> Origin { get; set; }
        INode<T> Destination { get; set; }
    }
}