using System;

namespace CarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****\n");
            Car c1 = new Car("SlugBug", 100, 10);

            // Register event handlers.
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;

            // Car.CarEngineHandler d = CarExploded;
            // c1.Exploded += d;
            EventHandler<CarEventArgs> d = CarExploded;
            c1.Exploded += d;

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            c1.Exploded -= d;
            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
            Console.ReadLine();
        }

        private static void CarExploded(object sender, CarEventArgs e)
        {
            Console.WriteLine(e._msg);
        }

        private static void CarAboutToBlow(object sender, CarEventArgs e)
        {
            if (sender is Car c)
            {
                Console.WriteLine($"Critical Message from {c.PetName}: {e._msg}");
            }
        }

        private static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        {
            Console.WriteLine("=> Critical Message from Car: {0}", e._msg);
        }
    }
}
