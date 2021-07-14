using System;
using System.Reflection;
using Microsoft.CSharp.RuntimeBinder;

namespace LateBindingWithDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            AddWithReflection();
        }

        private static void AddWithReflection()
        {
            var asm = Assembly.LoadFrom($"{AppDomain.CurrentDomain.BaseDirectory}MathLibrary");
            try
            {
                // Get metadata for the SimpleMath type.
                var math = asm.GetType("MathLibrary.SimpleMath");

                // // Create a SimpleMath on the fly.
                // var obj = Activator.CreateInstance(math);

                // // Get info for Add.
                // var mi = math.GetMethod("Add");

                // // Invoke method (with parameters).
                // object[] args = { 10, 70 };

                // Console.WriteLine($"Result is: {mi.Invoke(mi, args)}");

                // using dynamic

                // Create a SimpleMath on the fly.
                dynamic obj = Activator.CreateInstance(math);

                // Note how easily we can now call Add().
                Console.WriteLine($"Result is: {obj.Add(10, 70)}");
            }
            // catch (Exception ex)
            // {
            //     Console.WriteLine(ex.Message);
            // }
            catch (RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
