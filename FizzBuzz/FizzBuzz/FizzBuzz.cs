using System;
namespace FizzBuzz
{
	public class FizzBuzz
	{
		public string RunFizzBuzz(int num)
		{
			string result = num.ToString();
     

                if (num % 3 == 0 && num % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz {0}", num);
                }

                else if (num % 3 == 0)
                {
                    Console.WriteLine("Fizz {0}", num);
                }

                else if (num % 5 == 0)
                {
                    Console.WriteLine("Buzz {0}", num);
                }

                else if (num % 3 != 0 && num % 5 != 0)
            {
                Console.WriteLine("Not on the list");
            }

                
            return result;
		}
	}
}
