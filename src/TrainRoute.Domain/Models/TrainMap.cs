using System;
using System.Collections.Generic;
using System.Linq;
using TrainRoute.Kernel.Models;

namespace TrainRoute.Domain.Models
{
    public sealed class TrainMap : Graph<char>
    {
        public List<Route> Routes { get; set; }
        public TrainMap(List<TrainStation> stations) : base()
        {
            Nodes.AddRange(stations);
            Routes = new List<Route> { };
        }

        /// <summary>
        /// Método overload para facilitar o uso da função
        /// </summary>
        public int FindShortestPathDistance(char from, char to)
        {
            var origin = Nodes.Find(n => n.Data == from);
            var destination = Nodes.Find(n => n.Data == to);

            return FindShortestPathDistance(origin, destination);
        }

        public int FindShortestPathDistance(INode<char> origin, INode<char> destination)
        {
            // ordenando a lista de nós começando da origem
            Nodes = Nodes.OrderBy(node => node != origin).ToList();
            // criando a representação do grafo em matriz adjacente
            var graphMatrix = createAdjacencyMatrix();
            // armazenando o indice do nó de destino
            var destinationIndex = Nodes.FindIndex(node => node == destination);
            // obtendo a menor distância possível para todos os nós partindo do nó de origem
            var minimumDistances = DijkstraAlgorithm(graphMatrix);
            // retornando somente a distância mínima para o nó de origem

            // caso a origem e destino dejam iguais, será calculado o menor caminho saindo da origem e voltando
            if (origin == destination)
            {
                minimumDistances[destinationIndex] = int.MaxValue;
                var lowestValueIndex = Array.FindIndex(minimumDistances, d => d == minimumDistances.Min());
                return FindShortestPathDistance(Nodes[lowestValueIndex], destination) + minimumDistances.Min();
            }

            return minimumDistances[destinationIndex];
        }

        /// <summary>
        /// calcula a distância da rota para um conjunto de nós 
        /// </summary>
        public int CalculateRouteDistance(char[] stationLetters)
        {
            var nodes = new List<INode<char>> { };

            foreach (var letter in stationLetters)
            {
                var foundStation = Nodes.Find(s => s.Data == letter);

                if (foundStation != null) nodes.Add(foundStation);
            }

            return new Route(nodes).CalculateRouteDistance();
        }

        /// <summary>
        /// Adiciona uma rota conhecida ao Mapa de Trem
        /// </summary>
        /// <param name="stops"></param>
        public void AddRoute(char[] stops)
        {
            var route = new Route();

            foreach (var letter in stops)
            {
                var node = Nodes.Find(n => n.Data == letter);
                route.AddNode(node);
            }

            Routes.Add(route);
        }

        public int DiscoverRoutesByStops(char from, char to, int stops, ComparisonOperations.ComparisonType type)
        {
            var origin = Nodes.Find(n => n.Data == from);
            var destination = Nodes.Find(n => n.Data == to);

            return DiscoverRoutesByStops(origin, destination, stops, type);
        }

        public int DiscoverRoutesByStops(INode<char> from, INode<char> to, int stops, ComparisonOperations.ComparisonType type)
        {
            Func<int, int, bool> op = ComparisonOperations.FindOperation(type);

            List<Route> foundRoutes = Routes
            .Where(route =>
                route.Nodes.First().Data == from.Data &&
                route.Nodes.Last().Data == to.Data &&
                op(route.Stops, stops))
            .ToList();

            return foundRoutes.Count;
        }

        public int DiscoverRoutesByDistance(char from, char to, int distance, ComparisonOperations.ComparisonType type)
        {
            var origin = Nodes.Find(n => n.Data == from);
            var destination = Nodes.Find(n => n.Data == to);

            return DiscoverRoutesByDistance(origin, destination, distance, type);
        }

        public int DiscoverRoutesByDistance(INode<char> from, INode<char> to, int distance, ComparisonOperations.ComparisonType type)
        {
            Func<int, int, bool> op = ComparisonOperations.FindOperation(type);

            List<Route> foundRoutes = Routes
            .Where(route =>
                route.Nodes.First().Data == from.Data &&
                route.Nodes.Last().Data == to.Data &&
                op(route.CalculateRouteDistance(), distance))
            .ToList();

            return foundRoutes.Count;
        }
    }
}