using System;

namespace FunWithAutomaticProperties
{
    public class Car
    {
        public string PetName { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }
        public void DisplayStats()
        {
            Console.WriteLine("Car Name: {0}", PetName);
            Console.WriteLine("Speed: {0}", Speed);
            Console.WriteLine("Color: {0}", Color);
        }
    }
}