using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NYCMobileDev.TransitApp.Infrastructure.GTFS.Static.Subway.FileSystem;

namespace NYCMobileDev.TransitApp.Tests.GTFS.Static.Subway.IntegrationTests
{
    [TestFixture]
    class TripRepositoryTests
    {
        private const int DataFileRowCountMinusHeader = 21193;
        private const string DataFilePath = "trips.txt";

        [Test]
        public void Should_Return_All_Trips()
        {
            using (var repos = new TripRepository(DataFilePath)) {
                var result = repos.GetAllTrips();
                Assert.That(result.Count(t => t!=null), Is.EqualTo(DataFileRowCountMinusHeader));
            }
        }
    }
}
