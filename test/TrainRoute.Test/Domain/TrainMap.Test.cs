using System.Collections.Generic;
using TrainRoute.Domain.Models;
using Xunit;

namespace TrainRoute.Test
{
    public class TrainMapTest
    {
        [Fact]
        public void ShouldCreate()
        {
            var stations = new List<TrainStation> { new TrainStation('A'), new TrainStation('B') };

            TrainMap trainMap = new TrainMap(stations);

            Assert.IsType<TrainMap>(trainMap);
        }

        [Fact]
        public void ShouldFindShortestPath()
        {
            var stationA = new TrainStation('A');
            var stationB = new TrainStation('B');
            var stationC = new TrainStation('C');

            stationA.AddConnection(new TrainConnection(3, stationA, stationB));
            stationB.AddConnection(new TrainConnection(5, stationB, stationC));
            stationA.AddConnection(new TrainConnection(7, stationA, stationC));

            var stations = new List<TrainStation> { stationA, stationB, stationC };

            var trainMap = new TrainMap(stations);

            int shortestPath = trainMap.FindShortestPathDistance('A', 'C');

            Assert.Equal(shortestPath, 7);
        }
    }
}
