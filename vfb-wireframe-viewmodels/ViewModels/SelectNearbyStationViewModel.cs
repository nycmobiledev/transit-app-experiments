using System;
using System.Collections.Generic;
using System.Device.Location;

namespace ViewModels
{
    public class SelectNearbyStationViewModel
    {
        public GeoCoordinate CurrentLocation { get; set; }

        public IList<Station> NearbyStations { get; set; }
    }
}