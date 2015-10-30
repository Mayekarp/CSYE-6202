using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonFootPrint
{
        public class Building : InterfaceCarbonFootPrint
    {
            private int squareFoot;
            public Building(int squareFoot)
            {
                this.squareFoot = squareFoot;
            }

            public string BuildingName { get; set; }

            public int CalculateCarbonFootprint()
        {
           int total = 50 * squareFoot;
                return total;
            }
        }
    
}
