using System;
using CsvHelper.Configuration;
using NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Entities;

namespace NYCMobileDev.TransitApp.Infrastructure.GTFS.Static.Subway.FileSystem.Mappings
{
    public sealed class TripMap : CsvClassMap<Trip>
    {
        public TripMap()
        {
            Map(t => t.RouteId).Index(0);
            Map(t => t.TripId).Index(1);
            Map(t => t.ServiceId).Index(2);
            Map(t => t.TripHeadsign).Index(3);
            Map(t => t.DirectionId).Index(4);
            Map(t => t.ShapeId).Index(5);
        }
    }
}