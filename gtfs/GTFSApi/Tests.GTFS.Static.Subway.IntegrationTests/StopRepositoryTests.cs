using System;
using System.Linq;
using NUnit.Framework;
using NYCMobileDev.TransitApp.Infrastructure.GTFS.Static.Subway.FileSystem;

namespace NYCMobileDev.TransitApp.Tests.GTFS.Static.Subway.IntegrationTests
{
    [TestFixture]
    public class StopRepositoryTests
    {
        private const int DataFileRowCountMinusHeader = 1479;
        private const string DataFilePath = "stops.txt";

        [Test]
        public void Should_Return_All_Stops()
        {
            using (var repos = new StopRepository(DataFilePath)) {
                var result = repos.GetAllStops();
                Assert.That(result.Count(t => t != null), Is.EqualTo(DataFileRowCountMinusHeader));
            }
        }

        [Test]
        public void Should_Return_Parent_Stops()
        {
            //493
            using (var repos = new StopRepository(DataFilePath)) {
                var result = repos.GetParentStops();
                Assert.That(result.Count(t => t != null), Is.EqualTo(DataFileRowCountMinusHeader / 3));
            }
        }
    }
}
