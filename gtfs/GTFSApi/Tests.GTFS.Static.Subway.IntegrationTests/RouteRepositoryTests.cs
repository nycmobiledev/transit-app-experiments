using System;
using System.Linq;
using NUnit.Framework;
using NYCMobileDev.TransitApp.Infrastructure.GTFS.Static.Subway.FileSystem;

namespace NYCMobileDev.TransitApp.Tests.GTFS.Static.Subway.IntegrationTests
{
    [TestFixture]
    public class RouteRepositoryTests
    {
        private const int DataFileRowCountMinusHeader = 28;
        private const string DataFilePath = "routes.txt";

        [Test]
        public void Should_Return_All_Routes()
        {
            using (var repos = new RouteRepository(DataFilePath)) {
                var result = repos.GetAllRoutes();
                Assert.That(result.Count(t => t != null), Is.EqualTo(DataFileRowCountMinusHeader));
            }
        }
    }
}