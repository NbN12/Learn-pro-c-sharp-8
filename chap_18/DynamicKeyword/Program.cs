using System;
using System.Collections.Generic;
using Microsoft.CSharp.RuntimeBinder;

namespace DynamicKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintThreeStrings();
            ChangeDynamicDataType();
            InvokeMembersOnDynamicData();
        }

        static void InvokeMembersOnDynamicData()
        {
            dynamic textData1 = "Hello";
            try
            {
                Console.WriteLine(textData1.ToUpper());

                // You would expect compiler errors here!
                // But they compile just fine.
                Console.WriteLine(textData1.toupper());
                Console.WriteLine(textData1.Foo(10, "ee", DateTime.Now));
            }
            catch (RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ChangeDynamicDataType()
        {
            // Declare a single dynamic data point
            // named "t".
            dynamic t = "Hello!";
            Console.WriteLine($"t is of type {t.GetType()}");

            t = false;
            Console.WriteLine($"t is of type {t.GetType()}");

            t = new List<int>();
            Console.WriteLine($"t is of type {t.GetType()}");
        }

        static void PrintThreeStrings()
        {
            var s1 = "Greetings";
            object s2 = "From";
            dynamic s3 = "Minneapolis";

            Console.WriteLine("s1 is of type: {0}", s1.GetType());
            Console.WriteLine("s2 is of type: {0}", s2.GetType());
            Console.WriteLine("s3 is of type: {0}", s3.GetType());
        }

        static void UseObjectVariable()
        {
            // Assume we have a class named Person
            object o = new Person() { FirstName = "Mike", LastName = "Larson" };

            // Must cast object as Person to gain access 
            // to the person Properties
            Console.WriteLine($"Person's first name is {(o as Person).FirstName}");
        }

        static void ImplicitlyTypedVariable()
        {
            // a is of type List<int>
            var a = new List<int> { 90 };

            // This would be a compile-time error!
            // a = "Hello";
        }
    }
}
