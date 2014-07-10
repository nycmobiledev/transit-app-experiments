using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using transit_realtime;

namespace protobuf_net_tests
{
    class Program
    {
        static void Main(string[] args)
        {
            FeedMessage msg;
            using (Stream file = File.OpenRead("gtfs_123456S"))
            {
                msg = Serializer.Deserialize<FeedMessage>(file);
            }

            Console.WriteLine(UnixTimeStampToDateTime(msg.header.timestamp));
        }

        private static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        }
    }
}
