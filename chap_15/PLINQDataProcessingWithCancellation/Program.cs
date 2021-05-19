using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PLINQDataProcessingWithCancellation
{
    class Program
    {
        static CancellationTokenSource _cancelToken = new CancellationTokenSource();

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Start any key to start processing");
                Console.ReadKey();
                Console.WriteLine("Processing");
                Task.Factory.StartNew(ProcessIntData);
                Console.Write("Enter Q to quit: ");
                var answer = Console.ReadLine();
                if (answer.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    _cancelToken.Cancel();
                    break;
                }
            } while (true);
            Console.ReadLine();
        }

        static void ProcessIntData()
        {
            // Get a very large array of integers.
            var source = Enumerable.Range(1, 10_000_000).ToArray();

            // Find the numbers where num % 3 == 0 is true, returned
            // in descending order.
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            int[] modThreeIsZero = source.Where(num => num % 3 == 0).OrderByDescending(x => x).ToArray();
            stopwatch.Stop();
            Console.WriteLine($"Non-parallel version took: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Found { modThreeIsZero.Count()} numbers that match query! (non-parallel version)");

            try
            {
                stopwatch.Reset();
                stopwatch.Start();
                modThreeIsZero = source.AsParallel().WithCancellation(_cancelToken.Token).Where(num => num % 3 == 0).OrderByDescending(x => x).ToArray();
                stopwatch.Stop();
                Console.WriteLine($"Parallel version took: {stopwatch.ElapsedMilliseconds} ms");

                Console.WriteLine($"Found { modThreeIsZero.Count()} numbers that match query! (parallel version)");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
