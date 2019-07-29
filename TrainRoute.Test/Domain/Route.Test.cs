using System.Collections.Generic;
using TrainRoute.Domain.Models;
using Xunit;

namespace TrainRoute.Test
{
    public class RouteTest
    {
        [Fact]
        public void ShouldCreate()
        {
            Route route = new Route();

            Assert.IsType<Route>(route);
        }

        [Fact]
        public void ShouldAddNode()
        {
            Route route = new Route();
            route.AddNode(new TrainStation('A'));

            Assert.Equal(route.Nodes.Count, 1);
        }

        [Fact]
        public void ShouldCalculateRoute()
        {
            var stationA = new TrainStation('A');
            var stationB = new TrainStation('B');
            Route route = new Route();

            stationA.AddConnection(new TrainConnection(3, stationA, stationB));

            route.AddNode(stationA);
            route.AddNode(stationB);

            int result = route.CalculateRouteDistance();

            Assert.Equal(result, 3);
        }
    }
}
