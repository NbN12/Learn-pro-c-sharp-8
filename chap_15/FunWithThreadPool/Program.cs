using System;
using System.Threading;

namespace FunWithThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the CoreCLR Thread Pool *****\n");

            Console.WriteLine($"Main thread started. ThreadID = {Thread.CurrentThread.ManagedThreadId}");

            Printer p = new Printer();

            WaitCallback workItem = new WaitCallback(PrintTheNumbers);

            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, p);
            }
            Console.WriteLine("All tasks queued");
            Console.ReadLine();
        }

        static void PrintTheNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }
    }
}
