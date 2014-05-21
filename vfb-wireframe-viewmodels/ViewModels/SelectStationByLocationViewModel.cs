using System;
using System.Collections.Generic;
using System.Device.Location;

namespace ViewModels
{
    public class SelectStationByLocationViewModel
    {
        private GeoCoordinate _currentLocation;

        public string StationSearch { get; set; }

        public IList<Station> Results { get; set; }
    }
}