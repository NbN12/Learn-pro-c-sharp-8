using System;
using System.Threading;

namespace MultiThreadedPrinting
{
    public class Printer
    {
        // Lock token
        private object threadLock = new object();
        public void PrintNumbers()
        {
            // Use the private object lock token.
            lock (threadLock)
            {
                // Display Thread info.
                Console.WriteLine("-> {0} is executing PrintNumbers()",
                Thread.CurrentThread.Name);

                // Print out numbers.
                Console.Write("Your numbers: ");

                for (var i = 0; i < 10; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write($"{i}, ");
                }

                Console.WriteLine();
            }
        }
    }
}