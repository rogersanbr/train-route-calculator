using System.Collections.Generic;
using TrainRoute.Kernel.Models;

namespace TrainRoute.Domain.Models
{
    public sealed class TrainStation : INode<char>
    {

        public char Data { get; set; }
        public List<IEdge<char>> Edges { get; set; }
        public TrainStation(char name) : base()
        {
            Data = name;
            Edges = new List<IEdge<char>> { };
        }

        public void AddConnection(TrainConnection connection)
        {
            Edges.Add(connection);
        }

        public void AddConnections(List<TrainConnection> connections)
        {
            Edges.AddRange(connections);
        }

        public IEdge<char> SearchEdge(INode<char> neighbor)
        {
            return Edges.Find(e => e.Destination == neighbor);
        }
    }
}