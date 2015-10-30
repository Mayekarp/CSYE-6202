using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonFootPrint
{
    public class Car : InterfaceCarbonFootPrint
    {
        private int gasinGallons;
        public Car(int gasinGallons)
        {
            this.gasinGallons = gasinGallons;
        }

        public string CarName { get; set; }
        public string CarBrand { get; set; }

        public int CalculateCarbonFootprint()
        {
            int total = 20 * gasinGallons;
            return total;
        }
    }
}
