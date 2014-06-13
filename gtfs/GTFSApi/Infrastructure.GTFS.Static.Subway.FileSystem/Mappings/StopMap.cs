using System;
using CsvHelper.Configuration;
using NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Entities;

namespace NYCMobileDev.TransitApp.Infrastructure.GTFS.Static.Subway.FileSystem.Mappings
{
    public sealed class StopMap : CsvClassMap<Stop>
    {
        public StopMap()
        {
            Map(m => m.StopId).Index(0);
            Map(m => m.StopName).Index(1);
            Map(m => m.StopLat).Index(2);
            Map(m => m.StopLng).Index(3);
            Map(m => m.LocationType).Index(4);
            Map(m => m.ParentStationId).Index(5);
        }
    }
}