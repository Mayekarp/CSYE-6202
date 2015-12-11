using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReversationSystemApplication
{
    public class Economy : AlirlineClassType
    {
       
        public int Price { get; set; }
        public Economy()
        {
           
        }

        public string calculatepricedelegate()
        {
            return "1000";
        }

        public override string calculateseat(String seat)
        {
            int seats = Convert.ToInt32(seat);
            Console.WriteLine("Seat" + seats);
            return Convert.ToString(seats * 0.5);

        }

        
    }
}
