using System;
using System.Collections.Generic;
using NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Entities;

namespace NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Interfaces
{
    public interface IStopRepository
    {
        IEnumerable<Stop> GetAllStops();
    }
}
