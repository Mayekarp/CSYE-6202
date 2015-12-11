using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReversationSystemApplication
{
    public class ShowFlightDetails
    {
       public int AirlineID { get; set; }
       public string FlightNo { get; set; }
       public string Dates { get; set; }
       public string OriginCity { get; set; }
       public string DestinationCity { get; set; }
       public string AirLineName { get; set; }
       public string Arrivaltime { get; set; }
       public string Departuretime { get; set; }
       public int Seats { get; set; }
       public int EconomyClassPrice { get; set; } 
       public int EconomyPlusClassPrice { get; set; }
       public int BusinessClassPrice { get; set; }
    }
}
