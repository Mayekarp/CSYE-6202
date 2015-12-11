using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReversationSystemApplication
{
    public class Customer : Person
    {
        public string Dates { get; set; }
        public string OriginCity { get; set; }
        public string DestinationCity { get; set; }
        public string AirLineName { get; set; }
        public string ClassType { get; set; }
        public int Passengers { get; set; }
        public int Price { get; set; }
    }
}
