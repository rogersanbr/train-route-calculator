using System.Collections.Generic;

namespace TrainRoute.Kernel.Models
{
    public interface INode<T>
    {
        T Data { get; set; }
        List<IEdge<T>> Edges { get; set; }
        IEdge<T> SearchEdge(INode<T> neighbor);
    }
}