using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReversationSystemApplication
{
    public class CustomerBookings
    {
        public int BookingID { get; set; }
        public int AirlineID { get; set; }
        public int CustomerUserID { get; set; }
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string FlightNo { get; set; }
        public string Dates { get; set; }
        public string OriginCity { get; set; }
        public string DestinationCity { get; set; }
        public string AirLineName { get; set; }
        public string Arrivaltime { get; set; }
        public string Departuretime { get; set; }
        public string ClassType { get; set; }
        public int Passenger { get; set; }
        public int Price { get; set; }
        public string CardDetails { get; set; }
        public string CVV { get; set; }
        public string Month { get; set; }
        public int Seats { get; set; }
    }
}
