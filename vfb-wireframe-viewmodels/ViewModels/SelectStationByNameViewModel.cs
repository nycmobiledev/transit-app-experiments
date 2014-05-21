using System;
using System.Collections.Generic;

namespace ViewModels
{
    public class SelectStationByNameViewModel
    {
        public string StationSearch { get; set; }
        public IList<Station> Results { get; set; }
    }
}