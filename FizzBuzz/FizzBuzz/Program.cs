using System;
namespace FizzBuzz
{
	class Program
	{
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a Number:");
                int num;
                num = Convert.ToInt32(Console.ReadLine());
                FizzBuzz fb = new FizzBuzz();
                String f = fb.RunFizzBuzz(num);

                Console.WriteLine(f);
                Console.ReadLine();
            }
        }
	}
}
