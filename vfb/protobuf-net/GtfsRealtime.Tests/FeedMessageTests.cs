using System;
using System.IO;
using NUnit.Framework;
using ProtoBuf;
using transit_realtime;

namespace GtfsRealtime.Tests
{
    [TestFixture]
    public class FeedMessageTests
    {
        private FeedMessage _feedMessage;
        private const string TestFeedFile1 = "gtfs_123456S";
        //private const string TestFeedFile2 = "gtfs_L";

        [Test]
        public void Should_Verify_Data_File_Exists()
        {
            Assert.That(File.Exists(TestFeedFile1));
        }

        [SetUp]
        public void SetupTest()
        {
            using (Stream file = File.OpenRead(TestFeedFile1)) {
                _feedMessage = Serializer.Deserialize<FeedMessage>(file);
            }
        }

        [Test]
        public void Should_Return_NYCHeader_With_Subway_Version()
        {
            var nycHeader = _feedMessage.header.nyct_feed_header;

            Assert.That(nycHeader.nyct_subway_version, Is.EqualTo("1.0"));
        }

        [Test]
        public void Should_Return_TripReplacementPeriods()
        {
            var nycHeader = _feedMessage.header.nyct_feed_header;

            Assert.That(nycHeader.trip_replacement_period.Count, Is.GreaterThan(0));

            foreach (var tripReplacementPeriod in nycHeader.trip_replacement_period) {
                Console.WriteLine("Route ID: {0}\treplacement_period start: {1}\treplacement_period end: {2}", tripReplacementPeriod.route_id,
                    tripReplacementPeriod.replacement_period.start, UnixTimeStampToDateTime(tripReplacementPeriod.replacement_period.end));
            }
        }

        [Test]
        public void Should_Return_Header()
        {
            var header = _feedMessage.header;
            Assert.That(header.gtfs_realtime_version, Is.EqualTo("1.0"));
            Assert.That(header.timestamp, Is.EqualTo(1404712481));

            Console.WriteLine("Timestamp: {0}", UnixTimeStampToDateTime(header.timestamp));
        }

        [Test]
        public void Should_Return_Message()
        {
            Assert.That(_feedMessage.entity.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Should_Dump_All_Trip_Update_Messages()
        {
            foreach (var feedEntity in _feedMessage.entity) {
                Console.WriteLine("ID: {0}", feedEntity.id);
                PrintTripUpdate(feedEntity);
                PrintVehiclePosition(feedEntity);
                PrintAlert(feedEntity);
                Console.WriteLine("==============================================\n");
            }
        }

        private void PrintAlert(FeedEntity feedEntity)
        {
            if (feedEntity.alert != null) {
                Console.WriteLine("header_text: {0}", feedEntity.alert.header_text.translation[0].text);
            }
        }

        private void PrintVehiclePosition(FeedEntity feedEntity)
        {
            if (feedEntity.vehicle != null) {
                PrintTripDescriptor(feedEntity.vehicle.trip);
                Console.WriteLine(feedEntity.vehicle.congestion_level);
                Console.WriteLine(feedEntity.vehicle.current_status);
                Console.WriteLine(feedEntity.vehicle.current_stop_sequence);
                //Console.WriteLine(feedEntity.vehicle.position.ToString() ?? "");
                Console.WriteLine(feedEntity.vehicle.stop_id);
                Console.WriteLine(UnixTimeStampToDateTime(feedEntity.vehicle.timestamp));
                Console.WriteLine(feedEntity.vehicle.trip);
            }
        }

        private static void PrintTripUpdate(FeedEntity feedEntity)
        {
            if (feedEntity.trip_update != null) {
                PrintTripDescriptor(feedEntity.trip_update.trip);
                foreach (var stopTimeUpdate in feedEntity.trip_update.stop_time_update) {
                    if (stopTimeUpdate.arrival != null) {
                        Console.WriteLine("Arrival: {0}\t{1}\t{2}", UnixTimeStampToDateTime((ulong) stopTimeUpdate.arrival.time),
                            stopTimeUpdate.arrival.delay, stopTimeUpdate.arrival.uncertainty);
                    }
                    if (stopTimeUpdate.departure != null) {
                        Console.WriteLine("Departure: {0}\t{1}\t{2}", UnixTimeStampToDateTime((ulong) stopTimeUpdate.departure.time),
                            stopTimeUpdate.departure.delay, stopTimeUpdate.departure.uncertainty);
                    }
                    Console.WriteLine("Schedule Relationship: {0}", stopTimeUpdate.schedule_relationship);
                    Console.WriteLine("Stop ID: {0}", stopTimeUpdate.stop_id);
                    Console.WriteLine("Stop Sequence: {0}", stopTimeUpdate.stop_sequence);
                    //TODO: Implement NyctStopTimeUpdate
                    Console.WriteLine("-----------------------------------------------");
                }
            }
        }

        private static void PrintTripDescriptor(TripDescriptor trip)
        {
            Console.WriteLine("Trip ID: {0}", trip.trip_id);
            Console.WriteLine("Route ID: {0}", trip.route_id);
            Console.WriteLine("Start Date: {0}", trip.start_date);
            Console.WriteLine("Schedule Relationship: {0}", trip.schedule_relationship);

            if (trip.nyct_trip_descriptor != null) {
                Console.WriteLine("Direction: {0}", trip.nyct_trip_descriptor.direction);
                Console.WriteLine("Is Assigned: {0}", trip.nyct_trip_descriptor.is_assigned);
                Console.WriteLine("Train ID: {0}", trip.nyct_trip_descriptor.train_id);
            }
            Console.WriteLine("-----------------------------------------------");
        }

        private static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        }
    }
}