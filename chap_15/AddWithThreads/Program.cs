using System;
using System.Threading;

namespace AddWithThreads
{
    class Program
    {
        private static AutoResetEvent _waitHandler = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine($"ID of thread in Main(): {Thread.CurrentThread.ManagedThreadId}");

            // Make an AddParams object to pass to the secondary thread.
            AddParams ap = new AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);

            // Force a wait to let other thread finish.
            // Thread.Sleep(5);

            _waitHandler.WaitOne();
            Console.WriteLine("Other thread is done!");

            Console.ReadLine();
        }

        static void Add(object data)
        {
            if (data is AddParams ap)
            {
                Console.WriteLine($"ID of thread in Add(): {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"{ap.a} + {ap.b} is {ap.a + ap.b}");

                _waitHandler.Set();
            }
        }
    }
}
