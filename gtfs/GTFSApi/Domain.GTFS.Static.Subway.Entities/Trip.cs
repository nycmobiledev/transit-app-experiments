using System;

namespace NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Entities
{
    public class Trip
    {
        public string RouteId { get; set; }
        public string TripId { get; set; }
        public string ServiceId { get; set; }
        public string TripHeadsign { get; set; }
        public string DirectionId { get; set; }
        public string ShapeId { get; set; }
    }
}