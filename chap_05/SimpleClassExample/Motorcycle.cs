using System;

namespace SimpleClassExample
{
    public class Motorcycle
    {
        // public int driverIntensity;
        // // Put back the default constructor, which will
        // // set all data members to default values.
        // public Motorcycle() { }

        // // Our custom constructor.
        // public Motorcycle(int intensity)
        // {
        //     driverIntensity = intensity;
        // }

        public int driverIntensity;
        public string driverName;
        // public Motorcycle() { }
        // Redundant constructor logic!
        // public Motorcycle(int intensity)
        // {
        //     if (intensity > 10)
        //     {
        //         intensity = 10;
        //     }
        //     driverIntensity = intensity;
        // }
        // public Motorcycle(int intensity, string name)
        // {
        //     if (intensity > 10)
        //     {
        //         intensity = 10;
        //     }
        //     driverIntensity = intensity;
        //     driverName = name;
        // }

        // public Motorcycle(int intensity)
        // {
        //     SetIntensity(intensity);
        // }
        // public Motorcycle(int intensity, string name)
        // {
        //     SetIntensity(intensity);
        //     driverName = name;
        // }
        // public void SetIntensity(int intensity)
        // {
        //     if (intensity > 10)
        //     {
        //         intensity = 10;
        //     }
        //     driverIntensity = intensity;
        // }

        // Constructor chaining.
        public Motorcycle() { Console.WriteLine("In default ctor"); }
        public Motorcycle(int intensity) : this(intensity, "") { Console.WriteLine("In ctor taking an int"); }

        public Motorcycle(string name) : this(0, name)
        {
            Console.WriteLine("In ctor taking an int");
        }
        // public Motorcycle(int intensity, string name)
        // {
        //     Console.WriteLine("In master ctor ");
        //     if (intensity > 10)
        //     {
        //         intensity = 10;
        //     }
        //     driverIntensity = intensity;
        //     driverName = name;
        // }

        // Single constructor using optional args.
        public Motorcycle(int intensity = 0, string name = "")
        {
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
            driverName = name;
        }

        // // New members to represent the name of the driver.
        // public string name;
        // public void SetDriverName(string name) => name = name;
        public void SetDriverName(string name) => this.driverName = name;

        public void PopAWheely()
        {
            for (int i = 0; i <= driverIntensity; i++)
            {
                Console.WriteLine("Yeeeeeee Haaaaaeewww!");
            }
        }
    }


}