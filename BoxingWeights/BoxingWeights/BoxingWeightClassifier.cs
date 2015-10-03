using System;
namespace BoxingWeights
{
	public class BoxingWeightClassifier
	{
		public string ClassifyBoxingWeight(int weightInPounds)
		{
			string result = weightInPounds.ToString();

            
                if (weightInPounds < 100)
                {
                    Console.WriteLine("Not Eligible");
                }

                if (weightInPounds >= 100 && weightInPounds <= 105)
                {
                    Console.WriteLine("Straw Weight");
                }

                else if (weightInPounds >= 106 && weightInPounds <= 108)
                {
                    Console.WriteLine("Junior FlyWieght");
                }

                else if (weightInPounds >= 109 && weightInPounds <= 112)
                {
                    Console.WriteLine("FlyWeight");
                }

                else if (weightInPounds >= 113 && weightInPounds <= 115)
                {
                    Console.WriteLine("Junior BantamWeight");
                }

                else if (weightInPounds >= 116 && weightInPounds <= 118)
                {
                    Console.WriteLine("BantamWeight");
                }

                else if (weightInPounds >= 119 && weightInPounds <= 122)
                {
                    Console.WriteLine("Junior FeatherWeight");
                }

                else if (weightInPounds >= 123 && weightInPounds <= 126)
                {
                    Console.WriteLine("FeatherWeight");
                }

                else if (weightInPounds >= 127 && weightInPounds <= 130)
                {
                    Console.WriteLine("Junior LightWeight");
                }

                else if (weightInPounds >= 131 && weightInPounds <= 135)
                {
                    Console.WriteLine("LightWeight");
                }

                else if (weightInPounds >= 136 && weightInPounds <= 140)
                {
                    Console.WriteLine("Junior WelterWeight");
                }

                else if (weightInPounds >= 141 && weightInPounds <= 147)
                {
                    Console.WriteLine("WelterWeight");
                }

                else if (weightInPounds >= 148 && weightInPounds <= 154)
                {
                    Console.WriteLine("Junior MiddleWeight");
                }

                else if (weightInPounds >= 155 && weightInPounds <= 160)
                {
                    Console.WriteLine("MiddleWeight");
                }

                else if (weightInPounds >= 161 && weightInPounds <= 168)
                {
                    Console.WriteLine("Super MiddleWeight");
                }

                else if (weightInPounds >= 169 && weightInPounds <= 175)
                {
                    Console.WriteLine("Light HeavyWeight");
                }

                else if (weightInPounds >= 176 && weightInPounds <= 200)
                {
                    Console.WriteLine("CruiserWeight");
                }

                else if (weightInPounds > 200)
                {
                    Console.WriteLine("HeavyWeight");
                }
 

            return result;
		}
	}
}
