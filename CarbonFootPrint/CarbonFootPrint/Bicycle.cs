using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonFootPrint
{
    public class Bicycle : InterfaceCarbonFootPrint
    {
        public string BicycleName { get; set; }
        public string BicycleBrand { get; set; }

        //public Bicycle()
        //{
        //    BicycleName = "Bicycle";
        //}

        public int CalculateCarbonFootprint()
        {
            return 0;
        }
    }
}
