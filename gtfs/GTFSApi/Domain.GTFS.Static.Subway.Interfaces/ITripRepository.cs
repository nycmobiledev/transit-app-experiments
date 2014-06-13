using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Entities;

namespace NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Interfaces
{
    public interface ITripRepository
    {
        IEnumerable<Trip> GetAllTrips();
    }
}
