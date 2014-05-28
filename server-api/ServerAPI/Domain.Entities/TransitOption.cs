using System;

namespace NYCMobileDev.TransitApp.Domain.Entities
{
    public class TransitOption
    {
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string Destination { get; set; }
        public double MinutesAway { get; set; }
    }
}