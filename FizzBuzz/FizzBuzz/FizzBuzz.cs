using System;
namespace FizzBuzz
{
	public class FizzBuzz
	{
		public string RunFizzBuzz(int num)
		{
            string result = num.ToString();

            if (num == 0)
            {
                return (result);
            }
            else if (num % 3 == 0 && num % 5 == 0)
            {
                return ("FizzBuzz");

            }

            else if (num % 3 == 0)
            {
                return ("Fizz");
            }

            else if (num % 5 == 0)
            {
                return ("Buzz");
            }

            else 
                {
                return(result);
                }

                

		}
	}
}
