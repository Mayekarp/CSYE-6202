using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReversationSystemApplication
{
    public class BusinessClass : AlirlineClassType
    {
       
        public int Price { get; set; }
        public BusinessClass()
        {
            
        }
        public string calculatepricedelegate()
        {
            return "3000";
        }
        public override string calculateseat(String seat)
        {
            int seats = Convert.ToInt32(seat);
            return Convert.ToString(seats * 0.1);
        }

        
        
    }
}
