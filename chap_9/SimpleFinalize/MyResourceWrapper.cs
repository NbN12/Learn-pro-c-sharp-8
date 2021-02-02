using System;

namespace SimpleFinalize
{
    class MyResourceWrapper : IDisposable
    {
        // protected override void Finalize(){}
        ~MyResourceWrapper() => Console.Beep();

        public void Dispose()
        {
            // Clean up unmanaged resources...
            // Dispose other contained disposable objects...
            // Just for a test.
            Console.WriteLine("***** In Dispose! *****");
        }
    }
}