using System;

namespace MethodOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Method Overloading *****\n");
            // Calls int version of Add()
            Console.WriteLine(Add(10, 10));
            // Calls long version of Add()
            Console.WriteLine(Add(900_000_000_000, 900_000_000_000));
            // Calls double version of Add()
            Console.WriteLine(Add(4.3, 4.4));

            Console.ReadLine();
        }

        static int Add(int x, int y, int z = 0)
        {
            return x + (y * z);
        }

        // Overloaded Add() method.
        static int Add(int x, int y)
        { return x + y; }
        static double Add(double x, double y)
        { return x + y; }
        static long Add(long x, long y)
        { return x + y; }
    }
}
