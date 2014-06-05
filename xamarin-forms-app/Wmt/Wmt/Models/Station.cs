using System;

namespace Wmt
{
    public class Station
    {
        public Station()
        {
        }


        public Location Location {
            get; set;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

