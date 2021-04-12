using System;
using System.IO;
using System.Runtime.Loader;

namespace ClassLibrary1
{
    class Program
    {
        static void Main(string[] args)
        {
            // LoadAdditionalAssembliesDifferentContexts();
            LoadAdditionalAssembliesSameContext();
            Console.ReadLine();
        }
        static void LoadAdditionalAssembliesSameContext()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClassLibrary1.dll");
            AssemblyLoadContext lc1 = new AssemblyLoadContext(null, false);
            var cl1 = lc1.LoadFromAssemblyPath(path);
            var c1 = cl1.CreateInstance("ClassLibrary1.Car");
            var cl2 = lc1.LoadFromAssemblyPath(path);
            var c2 = cl2.CreateInstance("ClassLibrary1.Car");

            Console.WriteLine("*** Loading Additional Assemblies in Same Context ***");
            Console.WriteLine($"Assembly1.Equals(Assembly2) {cl1.Equals(cl2)}");
            Console.WriteLine($"Assembly1 == Assembly2 {cl1 == cl2}");
            Console.WriteLine($"Class1.Equals(Class2) {c1.Equals(c2)}");
            Console.WriteLine($"Class1 == Class2 {c1 == c2}");
        }

        static void LoadAdditionalAssembliesDifferentContexts()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClassLibrary1.dll");

            AssemblyLoadContext lc1 = new AssemblyLoadContext("NewContext1", false);
            var cl1 = lc1.LoadFromAssemblyPath(path);
            var c1 = cl1.CreateInstance("ClassLibrary1.Car");

            AssemblyLoadContext lc2 = new AssemblyLoadContext("NewContext2", false);
            var cl2 = lc2.LoadFromAssemblyPath(path);
            var c2 = cl2.CreateInstance("ClassLibrary1.Car");

            Console.WriteLine("*** Loading Additional Assemblies in Different Contexts ***");
            Console.WriteLine($"Assembly1 Equals(Assembly2) {cl1.Equals(cl2)}");
            Console.WriteLine($"Assembly1 == Assembly2 {cl1 == cl2}");
            Console.WriteLine($"Class1.Equals(Class2) {c1.Equals(c2)}");
            Console.WriteLine($"Class1 == Class2 {c1 == c2}");
        }
    }
}
