using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NYCMobileDev.TransitApp.Domain.Entities;

namespace NYCMobileDev.TransitApp.Service.Interfaces
{
    public interface INearestTransitService
    {
        IList<TransitOption> GetUpcomingTransitOptions(IEnumerable<string> stationIds, int resultCount);
    }
}
