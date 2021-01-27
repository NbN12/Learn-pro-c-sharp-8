using System;

namespace UnsafeCode
{
    partial class Program
    {
        static void UseSizeOfOperator()
        {
            Console.WriteLine("The size of short is {0}.", sizeof(short));
            Console.WriteLine("The size of int is {0}.", sizeof(int));
            Console.WriteLine("The size of long is {0}.", sizeof(long));
            unsafe
            {
                Console.WriteLine("The size of Point is {0}.", sizeof(Point));
            }
        }
        static unsafe void UseAndPinPoint()
        {
            PointRef pt = new PointRef { x = 5, y = 6 };

            // Pin pt in place so it will not
            // be moved or GC-ed.
            fixed (int* p = &pt.x)
            {
                // Use int* variable here!
            }
            // pt is now unpinned, and ready to be GC-ed once
            // the method completes.
            Console.WriteLine("Point is: {0}", pt);
        }
        static unsafe void UnsafeStackAlloc()
        {
            char* p = stackalloc char[256];
            for (int k = 0; k < 256; k++)
            {
                p[k] = (char)k;
            }
        }
        static unsafe void UsePointerToPoint()
        {
            // Access members via pointer.
            Point point;
            Point* p = &point;
            p->x = 100;
            p->y = 200;
            Console.WriteLine(p->ToString());
            Console.WriteLine(*p);

            // Access members via pointer indirection.
            Point point2;
            Point* p2 = &point2;
            (*p2).x = 100;
            (*p2).y = 200;
            Console.WriteLine((*p2).ToString());
        }

        public unsafe static void UnsafeSwap(int* i, int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }

        public static void SafeSwap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

        static unsafe void SquareIntPointer(int* myIntPointer)
        {
            *myIntPointer *= *myIntPointer;
        }

        static unsafe void PrintValueAndAddress()
        {
            int myInt;

            // Define an int pointer, and 
            // assign it the address of myInt.
            int* ptrToMyInt = &myInt;

            // Assign value of myInt using pointer indirection.
            *ptrToMyInt = 123;

            // Print some stats.
            Console.WriteLine("Value of myInt {0}", myInt);
            Console.WriteLine("Address of myInt {0:X}", (int)&ptrToMyInt);
        }
    }
}