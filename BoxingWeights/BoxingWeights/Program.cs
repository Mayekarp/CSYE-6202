using System;

namespace BoxingWeights
{
	class Program
	{
		static void Main(string[] args)
		{
            while (true)
            {
                Console.WriteLine("Enter a Number");
                int weightInPounds;
                weightInPounds = Convert.ToInt32(Console.ReadLine());
                BoxingWeightClassifier Bw = new BoxingWeightClassifier();
                string b = Bw.ClassifyBoxingWeight(weightInPounds);

                Console.WriteLine();
            }

            }
        }
}
