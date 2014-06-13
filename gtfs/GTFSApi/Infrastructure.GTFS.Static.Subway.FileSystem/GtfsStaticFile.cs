using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace NYCMobileDev.TransitApp.Infrastructure.GTFS.Static.Subway.FileSystem
{
    public abstract class GtfsStaticFile<T, TMap> : IDisposable where TMap : CsvClassMap
    {
        protected CsvReader CsvFile;
        private bool _disposed;

        protected GtfsStaticFile(string filePath)
        {
            CsvFile = new CsvReader(File.OpenText(filePath));
            CsvFile.Configuration.RegisterClassMap<TMap>();
            CsvFile.Configuration.HasHeaderRecord = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected IEnumerable<T> GetAllRecords()
        {
            return CsvFile.GetRecords<T>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) {
                return;
            }

            if (disposing) {
                // free other managed objects that implement
                // IDisposable only
                CsvFile.Dispose();
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }

        ~GtfsStaticFile()
        {
            Dispose(false);
        }
    }
}