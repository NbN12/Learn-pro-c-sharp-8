using System;
using System.Threading;

namespace SimpleMultiThreadApp
{
    public class Printer
    {
        public void PrintNumbers()
        {
            // Display Thread info.
            Console.WriteLine($"-> {Thread.CurrentThread.Name} is executing PrintNumbers()");

            // Print out numbers
            Console.Write("Your numbers: ");
            for (var i = 0; i < 10; i++)
            {
                Console.Write($"{i}, ");
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
}