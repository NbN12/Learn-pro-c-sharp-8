using System;
using System.Threading;

namespace TimerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Working with Timer type *****\n");

            // Create the delegate for the Timer type.
            TimerCallback timeCB = new TimerCallback(PrintTime);

            Timer t = new Timer(
                timeCB, // The TimerCallback delegate object.
                "Hello From Main", // Any info to pass into the called method (null for no info).
                0, // Amount of time to wait before starting (in milliseconds).
                1000 // Interval of time between calls (in milliseconds).
            );

            Console.WriteLine("Hit Enter key to terminate...");
            Console.ReadLine();
        }

        static void PrintTime(object state)
        {
            Console.WriteLine($"Time is: {DateTime.Now.ToLongTimeString()}, Param is: {state.ToString()}");
        }
    }
}
