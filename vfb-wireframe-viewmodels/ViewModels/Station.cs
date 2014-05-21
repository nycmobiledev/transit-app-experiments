using System;
using System.Device.Location;
using System.Drawing;

namespace ViewModels
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GeoCoordinate Location { get; set; }
        public string TrainLines { get; set; }
        public Color StationColor { get; set; }
    }
}