using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTFS;
using GTFS.IO;

namespace OsmSharpTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new GTFSReader<GTFSFeed>();

            // execute the reader.
            var feed = reader.Read(new GTFSDirectorySource(new DirectoryInfo("c:\\temp\\GTFS Static")));

            var trip = feed.GetTrip("A20131215SAT_000250_2");
            Console.WriteLine(trip.ToString());
        }
    }
}
