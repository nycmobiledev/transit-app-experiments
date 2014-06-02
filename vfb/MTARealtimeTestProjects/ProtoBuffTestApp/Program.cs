using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.ProtocolBuffers;
using transit_realtime;
using XPlatform.WheresMyTrain.MTA.Subway;

namespace ProtoBuffTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bytes = File.ReadAllBytes(@"C:\temp\123456S-gtfs");
            var message = FeedMessage.CreateBuilder().MergeFrom(bytes).Build();

            var sw = new StreamWriter(@"c:\temp\FeedMessage.xml");
            sw.Write(message.ToXml());
            sw.Close();

            sw = new StreamWriter(@"c:\temp\FeedMessage.json");
            sw.Write(message.ToJson());
            sw.Close();
        }
    }
}
