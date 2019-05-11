using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainRoute.Domain.Models;

namespace TrainRoute.Test
{
    [TestClass]
    public class RouteTest
    {
        [TestMethod]
        public void ShouldCreate()
        {
            Route route = new Route();

            Assert.IsInstanceOfType(route, typeof(Route));
        }

        [TestMethod]
        public void ShouldAddNode()
        {
            Route route = new Route();
            route.AddNode(new TrainStation('A'));

            Assert.AreEqual(route.Nodes.Count, 1);
        }

        [TestMethod]
        public void ShouldCalculateRoute()
        {
            var stationA = new TrainStation('A');
            var stationB = new TrainStation('B');
            Route route = new Route();

            stationA.AddConnection(new TrainConnection(3, stationA, stationB));

            route.AddNode(stationA);
            route.AddNode(stationB);

            int result = route.CalculateRouteDistance();

            Assert.AreEqual(result, 3);
        }
    }
}
