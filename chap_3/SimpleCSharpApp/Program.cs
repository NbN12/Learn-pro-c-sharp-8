using System;

namespace SimpleCSharpApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display a simple message to the user.
            Console.WriteLine("***** My First C# App *****");
            Console.WriteLine("Hello World!");
            Console.WriteLine();
            // // Process any incoming args.
            // for (int i = 0; i < args.Length; i++)
            // {
            //     Console.WriteLine("Arg: {0}", args[i]);
            // }
            // // Wait for Enter key to be pressed before shutting down.
            // Console.ReadLine();
            // Return an arbitrary error code.
            // return -1;
            // Return an arbitrary non-error code.
            // return 0;

            // Helper method within the Program class
            ShowEnvironmentDetails();
        }

        static void ShowEnvironmentDetails()
        {
            // Print out the drives on this machine,
            // and other interesting details.
            foreach (string drive in Environment.GetLogicalDrives())
            {
                Console.WriteLine("Drive: {0}", drive);
            }
            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processor: {0}", Environment.ProcessorCount);
            Console.WriteLine(".NET Core Version: {0}", Environment.Version);
        }
    }
}
