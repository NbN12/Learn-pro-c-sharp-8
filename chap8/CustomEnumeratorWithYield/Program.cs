using System;
using System.Collections;

namespace CustomEnumeratorWithYield
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the Yield Keyword *****\n");
            Garage carLot = new Garage();
            // foreach (var car in carLot)
            // {
            //     Console.WriteLine($"{car.GetType()}");
            // }
            IEnumerator carEnumerator = carLot.GetEnumerator();
            Console.ReadLine();
        }
    }
}
