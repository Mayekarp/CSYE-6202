
using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace TrianglePatterns
{
    class Program
    {
        const String STAR = "*";
        const String SPACE = " ";
        const int counter = 10;

        static void Main(string[] args)
        {
            DisplayPatternA();
            DisplayPatternB();
            DisplayPatternC();
            DisplayPatternD();

            Console.ReadLine();
        }

        static void DisplayPatternA()
        {
            for (int r = 0; r < counter; r++)
            {
                for (int c = 0; c <= r; c++)
                {
                    Console.Write(STAR);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

        }

        static void DisplayPatternB()
        {
            for (int r = 0; r < counter; r++)
            {
                
                for (int k = 0; k < counter - r; k++)
                    Console.Write(STAR);

                Console.WriteLine();

            }
            Console.WriteLine();
        }
        static void DisplayPatternC()
        {
            for (int r = counter; r >= 1; r--)

            {
                for (int c = 1; c <= counter - r; c++)
                {
                    Console.Write(SPACE);
                }

                for (int k = 1; k <= r; k++)
                {
                    Console.Write(STAR);
                }

                Console.WriteLine();
            }
        }

        static void DisplayPatternD()
        {
                for (int r = counter; r >= 0; r--)
                {
                    for (int c = 0; c < r; c++)
                        Console.Write(SPACE);
                    for (int c = 0; c < counter - r; c++)
                        Console.Write(STAR);
                    Console.WriteLine();

                }
                Console.WriteLine();
            }
        
        }
    
}
    