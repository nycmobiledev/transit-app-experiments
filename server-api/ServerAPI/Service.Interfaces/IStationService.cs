using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NYCMobileDev.TransitApp.Domain.Entities;

namespace NYCMobileDev.TransitApp.Service.Interfaces
{
    public interface IStationService
    {
        IList<Station> GetAllStations();
        IList<Station> GetStationsFromLocation(long lat, long lng);
        IList<Station> GetStationsFromName(string nameSearch);
    }
}
