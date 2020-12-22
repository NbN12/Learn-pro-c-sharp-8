﻿using System;

namespace BasicInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Basic Inheritance *****\n");
            // Make a Car object, set max speed and current speed.
            Car myCar = new Car(80) { Speed = 50 };
            // Print current speed.
            Console.WriteLine("My car is going {0} MPH", myCar.Speed);

            // Now make a MiniVan object.
            MiniVan myVan = new MiniVan { Speed = 10 };
            Console.WriteLine("My van is going {0} MPH", myVan.Speed);

            Console.ReadLine();
        }
    }
}
