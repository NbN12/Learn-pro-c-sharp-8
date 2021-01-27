using System;

namespace UnsafeCode
{
    partial class Program
    {
        static unsafe void Main(string[] args)
        {
            // unsafe
            // {
            //     var myInt = 10;
            //     SquareIntPointer(&myInt);
            //     Console.WriteLine("myInt: {0}", myInt);

            // }
            // int myInt2 = 5;
            // // Compiler error! Must be in unsafe context!
            // SquareIntPointer(&myInt2);
            // Console.WriteLine("myInt: {0}", myInt2);\

            int myInt2 = 5;
            SquareIntPointer(&myInt2);
            Console.WriteLine("myInt: {0}", myInt2);

            Console.WriteLine("**** Print Value And Address ****");
            PrintValueAndAddress();

            Console.WriteLine("***** Calling method with unsafe code *****");
            // Values for swap.
            int i = 10, j = 20;
            // Swap values "safely."
            Console.WriteLine("\n***** Safe swap *****");
            Console.WriteLine("Values before safe swap: i = {0}, j = {1}", i, j);
            SafeSwap(ref i, ref j);
            Console.WriteLine("Values after safe swap: i = {0}, j = {1}", i, j);

            // Swap values "unsafely."
            Console.WriteLine("\n***** Unsafe swap *****");
            Console.WriteLine("Values before unsafe swap: i = {0}, j = {1}", i, j);
            unsafe
            {
                UnsafeSwap(&i, &j);
            }

            Console.WriteLine("Values after unsafe swap: i = {0}, j = {1}", i, j);

            UsePointerToPoint();
            UseSizeOfOperator();

            Console.ReadLine();
        }
    }
}
