using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonFootPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            InterfaceCarbonFootPrint[] list = new InterfaceCarbonFootPrint[3];

            list[0] = new Bicycle();
            list[1] = new Building(1200);
            list[2] = new Car(20);

           
            Console.WriteLine("The Carbon FootPrint for Bicycle: " + list[0].CalculateCarbonFootprint());
            Console.WriteLine("The Carbon FootPrint for Building: " + list[1].CalculateCarbonFootprint());
            Console.WriteLine("The Carbon FootPrint for Car: " + list[2].CalculateCarbonFootprint());

            Console.ReadLine();
        }

    }
}
