using System;

namespace SimpleDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Delegate Example *****\n");

            SimpleMath m = new SimpleMath();

            // Create a BinaryOp delegate object that
            // "points to" SimpleMath.Add()
            // BinaryOp b = new BinaryOp(SimpleMath.Add);
            BinaryOp b = new BinaryOp(m.Add);
            DisplayDelegateInfo(b);

            // Invoke Add() method indirectly using delegate object.
            Console.WriteLine("10 + 10 is {0}", b(10, 10));
            Console.WriteLine();

            // Invoke Substract() method indirectly using delegate object.
            // b += SimpleMath.Subtract;
            b += m.Subtract;
            DisplayDelegateInfo(b);
            Console.WriteLine("10 - 10 is {0}", b(10, 10));

            // Compiler error! Method does not match delegate pattern!
            // BinaryOp b2 = new BinaryOp(SimpleMath.SquareNumber);

            Console.ReadLine();
        }

        static void DisplayDelegateInfo(Delegate delObj)
        {
            // Print the names of each member in the
            // delegate's invocation list.
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}", d.Target);
            }
        }
    }
}
