using System;

namespace FindingPrimeNumbers
{
	public class FindingPrimeNumbers
	{
	public long FindSumOfPrimeNumbers(int num)
	{
            
            long sum = 0;
            int j;
            j = 1;
            int count = 0;
            int k;
            while (count != num)
            {
                k = 0;
                for (int i = 1; i <= j; i++)
                {
                    if (j % i == 0)
                    {
                        k++;
                    }
                }
                if (k == 2)
                {
                    Console.WriteLine("This is a prime number {0}", j);
                    count = count + 1;
                    sum = sum + j;
                }
                else
                {
                    Console.WriteLine("This is not a prime number {0}", j);
                }
                j++;
            }
            Console.WriteLine("sum =  {0}", sum);

            Console.ReadLine();
            return sum;
	    }
	}
}
