using System;

namespace FinalizableDisposableClass
{
    // A sophisticated resource wrapper.
    public class MyResourceWrapper : IDisposable
    {
        // Used to determine if Dispose() has already been called.
        private bool disposed = false;
        // The garbage collector will call this method if the object user forgets to call Dispose().
        ~MyResourceWrapper()
        {
            // Clean up any internal unmanaged resources.
            // Do **not** call Dispose() on any managed objects.

            // Call our helper method.
            // Specifying "false" signifies that the GC triggered the cleanup.
            CleanUp(false);
        }

        // The object user will call this method to clean up resources ASAP.
        public void Dispose()
        {
            // Call our helper method.
            // Specifying "true" signifies that the object user triggered the cleanup.
            CleanUp(true);
            // Now suppress finalization.
            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool disposing)
        {
            // Be sure we have not already been disposed!
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    Console.WriteLine("Dispose managed resources.");
                }
                // Clean up unmanaged resources here.
                Console.WriteLine("Clean up unmanaged resources here.");
            }
            this.disposed = true;
        }
    }
}