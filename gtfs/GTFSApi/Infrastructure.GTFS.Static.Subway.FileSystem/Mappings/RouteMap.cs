using System;
using CsvHelper.Configuration;
using NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Entities;

namespace NYCMobileDev.TransitApp.Infrastructure.GTFS.Static.Subway.FileSystem.Mappings
{
    public sealed class RouteMap : CsvClassMap<Route>
    {
        public RouteMap()
        {
            Map(r => r.AgencyId).Index(0);
            Map(r => r.RouteId).Index(1);
            Map(r => r.RouteShortName).Index(2);
            Map(r => r.RouteLongName).Index(3);
            Map(r => r.RouteType).Index(4);
            Map(r => r.RouteDesc).Index(5);
            Map(r => r.RouteUrl).Index(6);
            Map(r => r.RouteColor).Index(7);
            Map(r => r.RouteTextColor).Index(8);
        }
    }
}