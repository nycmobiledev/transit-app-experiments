using System;
using System.Collections.Generic;
using System.Linq;
using NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Entities;
using NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Interfaces;
using NYCMobileDev.TransitApp.Infrastructure.GTFS.Static.Subway.FileSystem.Mappings;

namespace NYCMobileDev.TransitApp.Infrastructure.GTFS.Static.Subway.FileSystem
{
    public class StopRepository : GtfsStaticFile<Stop, StopMap>, IStopRepository
    {
        public StopRepository(string filePath) : base(filePath)
        {}

        public IEnumerable<Stop> GetAllStops()
        {
            return GetAllRecords();
        }

        public IEnumerable<Stop> GetParentStops()
        {
            return GetAllRecords().Where(s => s.LocationType == "1");
        }
    }
}