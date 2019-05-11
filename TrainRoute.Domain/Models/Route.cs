
using System.Collections.Generic;
using System.Linq;
using TrainRoute.Kernel.Models;

namespace TrainRoute.Domain.Models
{
    public class Route : IRoute<char>
    {
        public List<INode<char>> Nodes { get; private set; }
        public int Stops
        {
            get
            {
                return Nodes.Count - 1;
            }
        }

        public Route(List<INode<char>> nodes)
        {
            Nodes = nodes;
        }

        public Route()
        {
            Nodes = new List<INode<char>> { };
        }

        public void AddNode(INode<char> node)
        {
            Nodes.Add(node);
        }

        public override string ToString()
        {
            return string.Join("", Nodes
                .Select(s => s.Data)
                .ToArray());
        }

        public int CalculateRouteDistance()
        {
            int distance = 0;

            for (var x = 0; x < Nodes.Count - 1; x++)
            {
                // ligando a parada atual com a próxima a partir das arestas
                var nextConnection = Nodes[x].Edges.Find(e => e.Destination == Nodes[x + 1]);
                // caso a próxima parada não seja encontrada, será devolvido código -1 de erro
                if (nextConnection == null) return -1;

                distance += nextConnection.Value;
            }

            return distance;
        }
    }
}