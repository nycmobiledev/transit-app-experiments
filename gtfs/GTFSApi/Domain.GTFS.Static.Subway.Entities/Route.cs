using System;

namespace NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Entities
{
    public class Route
    {
        public string AgencyId { get; set; }
        public string RouteId { get; set; }
        public string RouteShortName { get; set; }
        public string RouteLongName { get; set; }
        public string RouteType { get; set; }
        public string RouteDesc { get; set; }
        public string RouteUrl { get; set; }
        public string RouteColor { get; set; }
        public string RouteTextColor { get; set; }
    }
}