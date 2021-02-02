using System;
using System.IO;

namespace SimpleFinalize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Finalizers *****\n");
            Console.WriteLine("Hit return to create the objects ");
            Console.WriteLine("then force the GC to invoke Finalize()");

            //Depending on the power of your system,
            //you might need to increase these values
            // CreateObjects(1_000_000);

            //Artificially inflate the memory pressure
            // GC.AddMemoryPressure(2147483647);
            // GC.Collect(0, GCCollectionMode.Forced);
            // GC.WaitForPendingFinalizers();

            // Create a disposable object and call Dispose()
            // to free any internal resources.

            MyResourceWrapper rw = new MyResourceWrapper();
            if (rw is IDisposable)
            {
                rw.Dispose();
            }

            // or use using keyword
            // using (MyResourceWrapper myResource = new MyResourceWrapper(), rw2 = new MyResourceWrapper())
            // {

            // }
            Console.WriteLine("Demonstrate using declarations");
            UsingDeclaration();

            Console.ReadLine();
        }

        private static void UsingDeclaration()
        {
            //This variable will be in scope until the end of the method
            using var rw = new MyResourceWrapper();
            //Do something here
            Console.WriteLine("About to dispose.");
            //Variable is disposed at this point.
        }

        static void DisposeFileStream()
        {
            FileStream fs = new FileStream("myFile.txt", FileMode.OpenOrCreate);
            fs.Close();
            fs.DisposeAsync();

            // or use using keyword
            // using (FileStream file = new FileStream("myFile.txt", FileMode.OpenOrCreate))
            // {

            // }

        }

        private static void CreateObjects(int count)
        {
            MyResourceWrapper[] tonsOfObjects = new MyResourceWrapper[count];
            for (int i = 0; i < count; i++)
            {
                tonsOfObjects[i] = new MyResourceWrapper();
            }
            tonsOfObjects = null;
        }
    }
}
