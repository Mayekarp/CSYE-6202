using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReversationSystemApplication
{
    public abstract class AlirlineClassType
    {
        public string Percentage { get; set; }

        public abstract string calculateseat(String seats);
    }
}
