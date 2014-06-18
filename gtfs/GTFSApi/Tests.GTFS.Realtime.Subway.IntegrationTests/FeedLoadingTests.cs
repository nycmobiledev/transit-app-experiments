using System;
using System.IO;
using Google.ProtocolBuffers;
using NUnit.Framework;
using NYCMobileDev.TransitApp.Infrastructure.GTFS.Realtime.Subway.ProtocolBuffers;
using transit_realtime;

namespace NYCMobileDev.TransitApp.Tests.GTFS.Realtime.Subway.IntegrationTests
{
    [TestFixture]
    public class FeedLoadingTests
    {
        private const string TestFeedFile1 = "gtfs_123456S";
        private const string TestFeedFile2 = "gtfs_L";

        [Test]
        public void Should_Verify_Data_File_Exists()
        {
            Assert.That(File.Exists(TestFeedFile1));
        }

        [Test]
        public void Should_Return_NYCHeader()
        {
            var data = File.ReadAllBytes(TestFeedFile1);
            var header = NyctFeedHeader.ParseFrom(data);
            
            Assert.That(header.IsInitialized, Is.True);
            Assert.That(header.HasNyctSubwayVersion, Is.True);
            Assert.That(header.TripReplacementPeriodCount, Is.GreaterThan(0));
            
            Console.WriteLine(header.ToJson());
        }

        [Test]
        public void Should_Return_Message()
        {
            var data = File.ReadAllBytes(TestFeedFile1);
            var message = FeedMessage.ParseFrom(data);
            

            Assert.That(message.HasHeader, Is.True);
            Assert.That(message.Header.GtfsRealtimeVersion, Is.EqualTo("1.0"));
            Assert.That(message.EntityCount, Is.GreaterThan(0));
            
            Console.WriteLine(message.ToJson());
        }
    }
}
