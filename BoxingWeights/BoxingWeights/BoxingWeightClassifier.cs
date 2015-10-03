using System;
namespace BoxingWeights
{
	public class BoxingWeightClassifier
	{
		public string ClassifyBoxingWeight(int weightInPounds)
		{
			string result = weightInPounds.ToString();

           

                if (weightInPounds >= 0 && weightInPounds <= 105)
                {
                    return("Strawweight and Heavyweight");
                }

                else if (weightInPounds >= 106 && weightInPounds <= 108)
                {
                    return("JuniorFlyweight and Heavyweight");
                }

                else if (weightInPounds >= 109 && weightInPounds <= 112)
                {
                    return("Flyweight and Heavyweight");
                }

                else if (weightInPounds >= 113 && weightInPounds <= 115)
                {
                    return("Bantamweight and Heavyweight");
                }

                else if (weightInPounds >= 116 && weightInPounds <= 118)
                {
                    return("Bantamweight and Heavyweight");
                }

                else if (weightInPounds >= 119 && weightInPounds <= 122)
                {
                    return("JuniorFeatherweight and Heavyweight");
                }

                else if (weightInPounds >= 123 && weightInPounds <= 126)
                {
                    return("Featherweight and Heavyweight");
                }

                else if (weightInPounds >= 127 && weightInPounds <= 130)
                {
                    return("JuniorLightweight and Heavyweight");
                }

                else if (weightInPounds >= 131 && weightInPounds <= 135)
                {
                    return("Lightweight and Heavyweight");
                }

                else if (weightInPounds >= 136 && weightInPounds <= 140)
                {
                    return("JuniorWelterweight and Heavyweight");
                }

                else if (weightInPounds >= 141 && weightInPounds <= 147)
                {
                    return("Welterweight and Heavyweight");
                }

                else if (weightInPounds >= 148 && weightInPounds <= 154)
                {
                    return("JuniorMiddleweight and Heavyweight");
                }

                else if (weightInPounds >= 155 && weightInPounds <= 160)
                {
                    return("Middleweight and Heavyweight");
                }

                else if (weightInPounds >= 161 && weightInPounds <= 168)
                {
                    return("SuperMiddleweight and Heavyweight");
                }

                else if (weightInPounds >= 169 && weightInPounds <= 175)
                {
                    return("LightHeavyweight and Heavyweight");
                }

                else if (weightInPounds >= 176 && weightInPounds <= 200)
                {
                    return("Cruiserweight and Heavyweight");
                }

                else if (weightInPounds > 200)
                {
                    return("Heavyweight");
                }
 

            return result;
		}
	}
}
