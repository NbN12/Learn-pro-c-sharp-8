using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace FunWithCSharpAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(" Fun With Async ===>");

            // var message = await DoWorkAsync();
            // Console.WriteLine(message);

            // Console.WriteLine(DoWork());

            // await MultipleAwaits();

            // await MultipleAwaits1();

            // Console.WriteLine("Completed");

            // await MethodReturningVoidAsync();
            // Console.WriteLine("Void method complete");

            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine(number);
            }

            Console.ReadLine();
        }

        static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }

        static async Task MethodWithProblemsFixed(int firstParam, int secondParam)
        {
            Console.WriteLine("Enter");
            if (secondParam < 0)
            {
                Console.WriteLine("Bad data");
                return;
            }

            await actualImplementation();

            async Task actualImplementation()
            {
                await Task.Run(() =>
                {
                    //Call long running method
                    Thread.Sleep(4_000);
                    Console.WriteLine("First Complete");
                    //Call another long running method that fails because
                    //the second parameter is out of range
                    Console.WriteLine("Something bad happened");
                });
            }
        }

        static async Task MethodWithProblems(int firstParam, int secondParam)
        {
            Console.WriteLine("Enter");
            await Task.Run(() =>
            {
                //Call long running method
                Thread.Sleep(4_000);
                Console.WriteLine("First Complete");
                //Call another long running method that fails because
                //the second parameter is out of range
                Console.WriteLine("Something bad happened");
            });
        }

        static async Task MultipleAwaits()
        {
            Console.WriteLine($"Inside MultipleAwaits()");
            Console.WriteLine($"Start in thread id: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() =>
            {
                Thread.Sleep(2_000);
                Console.WriteLine($"End in thread id: {Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine("Done with first task!");

            Console.WriteLine($"Start in thread id: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() =>
            {
                Thread.Sleep(2_000);
                Console.WriteLine($"End in thread id: {Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine("Done with second task!");

            Console.WriteLine($"Start in thread id: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() =>
            {
                Thread.Sleep(2_000);
                Console.WriteLine($"End in thread id: {Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine("Done with third task!");
        }
        static async Task MultipleAwaits1()
        {
            var t1 = Task.Run(() =>
            {
                Thread.Sleep(2_000);
                Console.WriteLine("Done with first task!");
            });

            var t2 = Task.Run(() =>
            {
                Thread.Sleep(2_000);
                Console.WriteLine("Done with second task!");
            });

            var t3 = Task.Run(() =>
            {
                Thread.Sleep(2_000);
                Console.WriteLine("Done with third task!");
            });

            // await Task.WhenAll(t1, t2, t3);
            await Task.WhenAny(t1, t2, t3);
        }

        static async Task MethodReturningVoidAsync()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(4_000);
            });

            Console.WriteLine("Void method completed");
        }

        static async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5_000);
                return "Done with work!";
            });
        }

        static string DoWork()
        {
            Thread.Sleep(5_000);
            return "Done with work!";
        }
    }
}
