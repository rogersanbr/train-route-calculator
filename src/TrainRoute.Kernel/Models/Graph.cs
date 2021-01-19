using System.Collections.Generic;
using TrainRoute.Kernel.Extensions;

namespace TrainRoute.Kernel.Models
{
    public abstract class Graph<T>
    {
        public List<INode<T>> Nodes { get; protected set; }

        public Graph(List<INode<T>> nodes)
        {
            Nodes = nodes;
        }

        public Graph()
        {
            Nodes = new List<INode<T>> { };
        }

        /// <summary>
        /// Método para calcular a próxima menor distância, ignorando as que já tenham sido fechadas
        /// </summary>
        /// <param name="distance">lista de distâncias, considerando que o índice representa um nó no grafo</param>
        /// <param name="shortestPathTreeSet">lista de caminhos abertos, considerando que o índice representa um nó no grafo</param>
        /// <param name="verticesCount">número de nós</param>
        /// <returns></returns>
        private int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int nodesNumber)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < nodesNumber; ++v)
            {
                if (!shortestPathTreeSet[v] && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        /// <summary>
        /// Implementação do algoritmo de Dijkstra, a partir de uma matriz adjacente
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        protected int[] DijkstraAlgorithm(int[,] graph)
        {
            // número de nós que serão analisados
            int nodesNumber = Nodes.Count;
            // distâncias que serão atualizadas conforme um valor menor for encontrado
            var distances = new int[nodesNumber];
            var shortestPathTreeSet = new bool[nodesNumber];

            for (int i = 0; i < nodesNumber; i++)
            {
                /*
                ** as distâncias são inicializadas tendendo ao infinito (neste caso o maior valor de int), 
                ** para serem atualizadas assim que um caminho for encontrado
                */
                distances[i] = int.MaxValue;
                // cada nó começa aberto, e será fechado assim que for considerado o menor caminho atual
                shortestPathTreeSet[i] = false;
            }

            // a distância da origem para ela mesma é igual a zero
            distances[0] = 0;

            for (int count = 0; count < nodesNumber - 1; count++)
            {
                int u = MinimumDistance(distances, shortestPathTreeSet, nodesNumber);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < nodesNumber; v++)
                {
                    if (!shortestPathTreeSet[v] && graph[u, v] != 0 && distances[u] != int.MaxValue && distances[u] + graph[u, v] < distances[v])
                        distances[v] = distances[u] + graph[u, v];
                }
            }

            return distances;
        }

        /// <summary>
        /// Converte o Grafo de classe para uma representação de matriz adjacente
        /// </summary>
        protected int[,] createAdjacencyMatrix()
        {
            // convertendo a classe em uma matriz adjacente
            var graph = new int[Nodes.Count, Nodes.Count];

            foreach (var (n, i) in Nodes.WithIndex())
            {
                foreach (var (n2, i2) in Nodes.WithIndex())
                {
                    if (i == i2)
                    {
                        graph[i, i2] = 0;
                        continue;
                    }

                    var edge = n.SearchEdge(n2);
                    if (edge != null)
                    {
                        graph[i, i2] = edge.Value;
                        continue;
                    }

                    graph[i, i2] = 0;
                }
            }

            return graph;
        }
    }
}