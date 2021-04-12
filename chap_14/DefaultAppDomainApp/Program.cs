using System;
using System.Reflection;
using System.Linq;

namespace DefaultAppDomainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the default AppDomain *****\n");
            // DisplayDADStats();
            ListAllAssembliesInAppDomain();
            Console.ReadLine();
        }

        private static void ListAllAssembliesInAppDomain()
        {
            // Get access to the AppDomain for the current thread.
            AppDomain defaultAD = AppDomain.CurrentDomain;

            // Now get all loaded assemblies in the default AppDomain.
            Assembly[] loadedAssemblies = defaultAD.GetAssemblies().OrderBy(x => x.GetName().Name).ToArray();
            Console.WriteLine("***** Here are the assemblies loaded in {0} *****\n", defaultAD.FriendlyName);
            foreach (Assembly a in loadedAssemblies)
            {
                Console.WriteLine($"-> Name, Version: {a.GetName().Name}:{a.GetName().Version}");
            }
        }

        private static void DisplayDADStats()
        {
            // Get access to the AppDomain for the current thread.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            // Print out various stats about this domain.
            Console.WriteLine("Name of this domain: {0}", defaultAD.FriendlyName);
            Console.WriteLine("ID of domain in this process: {0}", defaultAD.Id);
            Console.WriteLine("Is this the default domain?: {0}", defaultAD.IsDefaultAppDomain());
            Console.WriteLine("Base directory of this domain: {0}", defaultAD.BaseDirectory);
            Console.WriteLine("Setup Information for this domain:");
            Console.WriteLine("\t Application Base: {0}", defaultAD.SetupInformation.ApplicationBase);
            Console.WriteLine("\t Target Framework: {0}", defaultAD.SetupInformation.TargetFrameworkName);
        }
    }
}
