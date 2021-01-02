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
            try
            {
                //Error at this time
                var carEnumerator = carLot.GetEnumerator();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occurred on GetEnumerator");
            }
            Console.ReadLine();
        }
    }
}
