using System;

namespace GasPump
{
	public class Program
	{
		public enum GasType
		{
			None,
			RegularGas,
			MidgradeGas,
			PremiumGas,
			DieselFuel				
		}

		static void Main(string[] args)
		{
            Console.WriteLine("\nEnter purchase gas type");
            string userInput = Console.ReadLine();

            
            if (UserEnteredSentinelValue(userInput))
            {
                Console.WriteLine("\nApplication Terminated");
                Console.ReadLine();

                System.Environment.Exit(1);
            }

            if (!UserEnteredValidGasType(userInput))
            {
                
                Console.Write("\nInvalid input for gas type.");
                System.Environment.Exit(1);


            }
           
            Console.WriteLine("\nPlease enter purchased gas amount");
            String gasAmount = Console.ReadLine();

            if (UserEnteredSentinelValue(gasAmount))
            {
                Console.WriteLine("\nApplication Terminated");
                Console.ReadLine();

                System.Environment.Exit(1);
            }
            
            if (UserEnteredValidAmount(gasAmount))
            {

                Console.WriteLine("\nThe valued entered is:" +gasAmount);
                //Console.ReadLine();

                GasType gas = GasTypeMapper(userInput[0]);
                Console.ReadLine();

                double totalCost = 0.0;
                CalculateTotalCost(gas,Convert.ToInt32(gasAmount), ref totalCost);
                Console.WriteLine("\nTotalCost:" + totalCost);
                Console.ReadLine();
                if (UserEnteredSentinelValue(gasAmount))
                {
                    Console.WriteLine("\nApplication Terminated");
                    Console.ReadLine();

                    System.Environment.Exit(1);
                }

            }

            else
            {
                Console.WriteLine("\nEntered Input is invalid");
                System.Environment.Exit(1);
                Console.ReadLine();
            }
            
            
        
    }

		// use this method to check and see if sentinel value is entered
		public static bool UserEnteredSentinelValue(string userInput)
		{
			var result = false;

            if (userInput.Equals("Q") || userInput.Equals("q"))
            {
                result = true;
            }
            else
                result = false;
			return result;
		}

		// use this method to parse and check the characters entered
		// this does not conform 
		public static bool UserEnteredValidGasType(string userInput)
		{
			var result = false;

			if( userInput.Equals("R") || userInput.Equals("r"))
            {
                Console.Write("The entered type is Regular Gas");
                result = true;
            }

            else if ( userInput.Equals("M") || userInput.Equals("m"))
            {
                Console.Write("The entered type is MidGrade Gas");
                result = true;
            }

            else if (userInput.Equals("P") || userInput.Equals("p"))
            {
                Console.Write("The entered type is Premium Gas");
                result = true;
            }

            else if (userInput.Equals("D") || userInput.Equals("d"))
            {
                Console.Write("The entered type is Diesel Gas");
                result = true;
            }

            
			return result;
		}

		// use this method to parse and check the double type entered
		// please use Double.TryParse() method 
		public static bool UserEnteredValidAmount(string userInput)
		{
            var result = false;
            
                double value;
                result = double.TryParse(userInput, out value);

            return result;

        }

		// use this method to map a valid char entry to its enum representation
		// e.g. User enters 'R' or 'r' --> this should be mapped to GasType.RegularGas
		// this mapping "must" be used within CalculateTotalCost() method later on
		public static GasType GasTypeMapper(char c)
		{
            GasType gasType_RegularGas = GasType.RegularGas;
            GasType gasType_MidGradeGas = GasType.MidgradeGas;
            GasType gasType_PremiumGas = GasType.PremiumGas;
            GasType gasType_DieselFuel = GasType.DieselFuel;
            GasType gasType_None = GasType.None;

            switch (c)
            {
                case 'R':
                case 'r':
                    {
                        //GasType gasType = GasType.RegularGas;
                        return gasType_RegularGas;

                    }
                   case 'M':
                    case 'm':
                    {
                        //GasType gasType = GasType.MidgradeGas;
                        return gasType_MidGradeGas;
                    }

                    case 'P':
                    case 'p':
                    {
                        //GasType gasType = GasType.PremiumGas;
                        return gasType_PremiumGas;

                    }

                    case 'D':
                    case 'd':
                    {
                        //GasType gasType = GasType.DieselFuel;
                        return gasType_DieselFuel;
                    }      

            }

            //GasType gasType = GasType.None;
                return gasType_None;
            
        }

		public static double GasPriceMapper(GasType gasType)
		{
			var result = 0.0;
            switch (gasType)
            {
                case GasType.None:
                    {
                        result = 0;
                        break;
                    }
                        
                case GasType.RegularGas:
                    {
                        result = 1.94;
                        break;
                    }
                case GasType.MidgradeGas:
                    {
                        result = 2.00;
                        break;
                    }
                    
                case GasType.PremiumGas:
                    {
                        result = 2.24;
                        break;
                    }
                    
                case GasType.DieselFuel:
                    {
                        result = 2.17;
                        break;
                    }
                    
            }

            return result;
	}

		public static void CalculateTotalCost(GasType gasType, int gasAmount, ref double totalCost)
		{

            double price;
            price = GasPriceMapper(gasType);
            Console.WriteLine("The price for gas is: " + price);
            Console.ReadLine();
            totalCost = gasAmount * price;
            
		}

        
	}
}
