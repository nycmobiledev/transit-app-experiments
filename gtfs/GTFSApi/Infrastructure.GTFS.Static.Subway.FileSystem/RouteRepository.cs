using System;
using System.Collections.Generic;
using NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Entities;
using NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Interfaces;
using NYCMobileDev.TransitApp.Infrastructure.GTFS.Static.Subway.FileSystem.Mappings;

namespace NYCMobileDev.TransitApp.Infrastructure.GTFS.Static.Subway.FileSystem
{
    public class RouteRepository : GtfsStaticFile<Route, RouteMap>, IRouteRepository
    {
        public RouteRepository(string filePath) : base(filePath)
        {}

        public IEnumerable<Route> GetAllRoutes()
        {
            return GetAllRecords();
        }
    }
}