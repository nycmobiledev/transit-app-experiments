

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Wmt
{
    public class MtaService
    {
        public MtaService()
        {
        }

        public async Task<IList<Station>> GetStations() {

            #if MOCK
            return new List<Station>{
                new Station{
                    Id = "",
                    Name = "Station 1"
                }
            };


            #else
            var response = await BaseService.GetData("http://mtaapi.herokuapp.com/stations");

            var result = response["result"];

            var stations = new List<Station>();

            for (int x = 0; x < result.Count; x++) {
                stations.Add(new Station{
                    Name = result[x]["name"],
                    Id = result[x]["id"]
                });
            }


            return stations;
            #endif
        }

        public async Task<Location> GetStationLocation(Station station) {

            #if MOCK
            return new Location{
                Lat = 18.00000,
                Long = -69.000
            };
    

            #else
            var response = await BaseService.GetData(string.Format("http://mtaapi.herokuapp.com/stop?id={0}",station.Id));

            var result = response["result"];

            var location = new Location { 
                Lat = result["lat"],
                Long = result["lon"],
                Name = result["name"]
            };


            return location;
            #endif
        }

    }
}

