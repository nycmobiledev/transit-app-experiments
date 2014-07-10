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
        //private const string TestFeedFile2 = "gtfs_L";

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
        public void Should_Return_TripReplacementPeriods()
        {
            var data = File.ReadAllBytes(TestFeedFile1);
            var header = NyctFeedHeader.ParseFrom(data);

            Assert.That(header.TripReplacementPeriodCount, Is.GreaterThan(0));

            foreach (var tripReplacementPeriod in header.TripReplacementPeriodList) {
                Console.WriteLine("Route ID: {0}\treplacement_period: {1}", tripReplacementPeriod.RouteId, tripReplacementPeriod.ReplacementPeriod.ToJson());
            }
        }

        [Test]
        public void Should_Return_Header()
        {
            var data = File.ReadAllBytes(TestFeedFile1);
            var message = FeedMessage.ParseFrom(data);
            
            Assert.That(message.HasHeader, Is.True);
            
            var header = message.Header;
            Assert.That(header.GtfsRealtimeVersion, Is.EqualTo("1.0"));
            Assert.That(header.IsInitialized, Is.True);
            Assert.That(header.HasTimestamp, Is.True);
            Assert.That(header.Timestamp, Is.EqualTo(1404712481));

            Console.WriteLine(header.ToJson());

            Console.WriteLine("Timestamp: {0}", UnixTimeStampToDateTime(header.Timestamp));
        }

        [Test]
        public void Should_Return_Message()
        {
            var data = File.ReadAllBytes(TestFeedFile1);
            var message = FeedMessage.ParseFrom(data);
            
            Assert.That(message.EntityCount, Is.GreaterThan(0));
            
            Console.WriteLine(message.ToJson());
        }

        [Test]
        public void Should_Dump_All_Trip_Update_Messages()
        {
            // Code here to init static constructor;
            var descriptor = SubwayProtos.Descriptor;

            var data = File.ReadAllBytes(TestFeedFile1);
            var message = FeedMessage.ParseFrom(data);
            
            foreach (var feedEntity in message.EntityList) {
                Console.WriteLine("ID: {0}", feedEntity.Id);
                if (feedEntity.HasTripUpdate) {
                    TripDescriptor trip = feedEntity.TripUpdate.Trip;
                    Console.WriteLine("Trip ID: {0}", trip.TripId);
                    Console.WriteLine("Route ID: {0}", trip.RouteId);
                    Console.WriteLine("Start Date: {0}", trip.StartDate);
                    Console.WriteLine("Schedule Relationship: {0}", trip.ScheduleRelationship);

                    //var nyDescriptor = NyctTripDescriptor.ParseFrom(trip.ToByteString());
                    //var nyDescriptor = NyctTripDescriptor.ParseFrom(feedEntity.TripUpdate.ToByteArray());
                    //var nyDescriptor = NyctTripDescriptor.ParseFrom(feedEntity.ToByteArray());
                    var nyDescriptor = trip.GetExtension(SubwayProtos.NyctTripDescriptor);
                    Console.WriteLine("Has Extension: {0}", trip.HasExtension(SubwayProtos.NyctTripDescriptor));
                    
                    if (nyDescriptor != null) {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Direction: {0}", nyDescriptor.Direction);
                        Console.WriteLine("Is Assigned: {0}", nyDescriptor.IsAssigned);
                        Console.WriteLine("Train ID: {0}", nyDescriptor.TrainId);
                    }
                }
                Console.WriteLine("==============================================\n");

            }
            
        }


        private static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        }
    }
}
