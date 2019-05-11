
using System.Collections.Generic;
using System.Linq;

namespace TrainRoute.Kernel.Models
{
    public interface IRoute<T>
    {
        List<INode<T>> Nodes { get; }
    }
}