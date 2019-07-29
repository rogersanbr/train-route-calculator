// using System;
// using System.Collections.Generic;
// using TrainRoute.Domain;
// using TrainRoute.Domain.Models;
// using static TrainRoute.Domain.Models.TrainMap;

// namespace TrainRoute.Application
// {
//     class ProgramOld
//     {
//         static void Main(string[] args)
//         {
//             TrainMap trainMap = InitializeProgram();
//             ProcessAnswers(trainMap);
//         }

//         static TrainMap InitializeProgram()
//         {
//             #region InitializeProgram
//             // inicializando o grafo com estações e rotas pré definidas
//             var stationA = new TrainStation('A');
//             var stationB = new TrainStation('B');
//             var stationC = new TrainStation('C');
//             var stationD = new TrainStation('D');
//             var stationE = new TrainStation('E');

//             var edgeAB = new TrainConnection(5, stationA, stationB);
//             var edgeBC = new TrainConnection(4, stationB, stationC);
//             var edgeCD = new TrainConnection(8, stationC, stationD);
//             var edgeDC = new TrainConnection(8, stationD, stationC);
//             var edgeDE = new TrainConnection(6, stationD, stationE);
//             var edgeAD = new TrainConnection(5, stationA, stationD);
//             var edgeCE = new TrainConnection(2, stationC, stationE);
//             var edgeEB = new TrainConnection(3, stationE, stationB);
//             var edgeAE = new TrainConnection(7, stationA, stationE);

//             stationA.AddConnections(new List<TrainConnection> { edgeAB, edgeAD, edgeAE });
//             stationB.AddConnection(edgeBC);
//             stationC.AddConnections(new List<TrainConnection> { edgeCD, edgeCE });
//             stationD.AddConnections(new List<TrainConnection> { edgeDC, edgeDE });
//             stationE.AddConnection(edgeEB);

//             var trainMap = new TrainMap(new List<TrainStation> { stationA, stationB, stationC, stationD, stationE });

//             trainMap.AddRoute("CDC".ToCharArray());
//             trainMap.AddRoute("CEBC".ToCharArray());
//             trainMap.AddRoute("ABCDC".ToCharArray());
//             trainMap.AddRoute("ADCDC".ToCharArray());
//             trainMap.AddRoute("ADEBC".ToCharArray());
//             trainMap.AddRoute("CEBCDC".ToCharArray());
//             trainMap.AddRoute("CDCEBC".ToCharArray());
//             trainMap.AddRoute("CDEBC".ToCharArray());
//             trainMap.AddRoute("CEBCEBC".ToCharArray());
//             trainMap.AddRoute("CEBCEBCEBC".ToCharArray());

//             return trainMap;
//             #endregion
//         }

//         static void ProcessAnswers(TrainMap trainMap)
//         {
//             #region Processing
//             // processango as respostas para o grafo
//             var answer1 = trainMap.CalculateRouteDistance("ABC".ToCharArray());
//             var answer2 = trainMap.CalculateRouteDistance("AD".ToCharArray());
//             var answer3 = trainMap.CalculateRouteDistance("ADC".ToCharArray());
//             var answer4 = trainMap.CalculateRouteDistance("AEBCD".ToCharArray());
//             var result = trainMap.CalculateRouteDistance("AED".ToCharArray());
//             var answer5 = result == -1 ? "NO SUCH ROUTE" : result.ToString();
//             var answer6 = trainMap.DiscoverRoutesByStops('C', 'C', 3, ComparisonOperations.ComparisonType.LessOrEqualThan);
//             var answer7 = trainMap.DiscoverRoutesByStops('A', 'C', 4, ComparisonOperations.ComparisonType.EqualTo);
//             var answer8 = trainMap.FindShortestPathDistance('A', 'C');
//             var answer9 = trainMap.FindShortestPathDistance('B', 'B');
//             var answer10 = trainMap.DiscoverRoutesByDistance('C', 'C', 30, ComparisonOperations.ComparisonType.LessThan);

//             Console.WriteLine("Problem one - Trains");

//             Console.WriteLine("Routes: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");

//             Console.WriteLine($"1. The distance of the route A-B-C = {answer1}");
//             Console.WriteLine($"2. The distance of the route A-D = {answer2}");
//             Console.WriteLine($"3. The distance of the route A-D-C {answer3}");
//             Console.WriteLine($"4. The distance of the route A-E-B-C-D {answer4}");
//             Console.WriteLine($"5. The distance of the route A-E-D {answer5}");
//             Console.WriteLine($"6. The number of trips starting at C and ending at C with a maximum of 3 stops = {answer6}");
//             Console.WriteLine($"7. The number of trips starting at A and ending at C with exactly 4 stops = {answer7}");
//             Console.WriteLine($"8. The length of the shortest route (in terms of distance to travel) from A to C = {answer8}");
//             Console.WriteLine($"9. The length of the shortest route (in terms of distance to travel) from B to B = {answer9}");
//             Console.WriteLine($"10. The number of different routes from C to C with a distance of less than 30 = {answer10}");
//             #endregion
//         }
//     }
// }