using System;

namespace ConstData
{
    // class MyMathClass
    // {
    //     // Try to set PI in ctor?
    //     public const double PI;
    //     public MyMathClass()
    //     {
    //         // Not possible- must assign at time of declaration.
    //         PI = 3.14;
    //     }
    // }
    // class MyMathClass
    // {
    //     public const double PI = 3.14;
    // }
    // class MyMathClass
    // {
    //     // Read-only fields can be assigned in ctors,
    //     // but nowhere else.
    //     public readonly double PI;
    //     public MyMathClass()
    //     {
    //         PI = 3.14;
    //     }
    //     // Error!
    //     // public void ChangePI()
    //     // { PI = 3.14444; }
    // }

    class MyMathClass
    {
        public static readonly double PI;
        static MyMathClass()
        { PI = 3.14; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Const *****\n");
            Console.WriteLine("The value of PI is: {0}", MyMathClass.PI);
            // Error! Can't change a constant!
            // MyMathClass.PI = 3.1444;
            Console.ReadLine();
        }

        static void LocalConstStringVariable()
        {
            // A local constant data point can be directly accessed.
            const string fixedStr = "Fixed string Data";
            Console.WriteLine(fixedStr);
            // Error!
            // fixedStr = "This will not work!";
        }
    }
}
