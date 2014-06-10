using System;

namespace NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Entities
{
    public class Stop
    {
        public string StopId { get; set; }
        public string StopName { get; set; }
        public double StopLat { get; set; }
        public double StopLng { get; set; }
        public string LocationType { get; set; }
        public string ParentStationId { get; set; }
    }
}
