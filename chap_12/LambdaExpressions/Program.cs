using System;
using System.Collections.Generic;

namespace LambdaExpressions
{
    public delegate string VerySimpleDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Lambdas *****\n");
            // TraditionalDelegateSyntax();
            // LambdaExpressionSyntax();

            // Register with delegate as a lambda expression.
            SimpleMath m = new SimpleMath();
            m.SetMathHandler((msg, result) => { Console.WriteLine("Message: {0}, Result: {1}", msg, result); });
            m.Add(10, 10);
            // VerySimpleDelegate d = new VerySimpleDelegate(() => { return "Enjoy your string!"; });
            // VerySimpleDelegate d = new VerySimpleDelegate(() => "Enjoy your string!");
            VerySimpleDelegate d = () => "Enjoy your string!";
            Console.WriteLine(d());

            Console.ReadLine();
        }

        static void LambdaExpressionSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Now process each argument within a group of
            // code statements.
            List<int> evenNumbers = list.FindAll(i =>
            {
                Console.WriteLine("value of i is currently: {0}", i);
                bool isEven = (i % 2) == 0;
                return isEven;
            });

            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        static void TraditionalDelegateSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Call FindAll() using traditional delegate syntax.
            // Predicate<int> callback = IsEvenNumber;
            // List<int> evenNumbers = list.FindAll(callback);
            // List<int> evenNumbers = list.FindAll(delegate (int i)
            // {
            //     return (i % 2) == 0;
            // });
            List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);

            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        static bool IsEvenNumber(int i)
        {
            return (i % 2) == 0;
        }
    }
}
