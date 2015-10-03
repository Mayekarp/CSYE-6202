using System; 

namespace FindingPrimeNumbers
{
	class Program
	{
     public static void Main(string[] args)
{
            Console.Write("Enter a Number:");
            int num;
            num = Convert.ToInt32(Console.ReadLine());


            FindingPrimeNumbers fp = new FindingPrimeNumbers();
            long sum = fp.FindSumOfPrimeNumbers(num);
             

            Console.WriteLine(+sum);

           
}
	}
}
	