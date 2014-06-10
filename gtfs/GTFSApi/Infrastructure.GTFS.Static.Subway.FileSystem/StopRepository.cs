using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Entities;
using NYCMobileDev.TransitApp.Domain.GTFS.Static.Subway.Interfaces;

namespace NYCMobileDev.TransitApp.Infrastructure.GTFS.Static.Subway.FileSystem
{
    public class StopRepository : IStopRepository
    {
        private readonly string _stopFilePath;

        public StopRepository(string stopFilePath)
        {
            _stopFilePath = stopFilePath;
        }

        public IEnumerable<Stop> GetAllStops()
        {
            var csv = new CsvReader(File.Op)
        }
    }
}
