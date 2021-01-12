using System;

namespace FinalizableDisposableClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Dispose() / Destructor Combo Platter *****");
            // Call Dispose() manually. This will not call the finalizer.
            MyResourceWrapper rw = new MyResourceWrapper();
            rw.Dispose();

            // Don't call Dispose(). This will trigger the finalizer when the object gets garbage collected.
            MyResourceWrapper rw2 = new MyResourceWrapper();

            Console.ReadLine();
        }
    }
}
