using System;
using System.Collections;

namespace ComparableCar
{
    class Car : IComparable
    {
        // Constant for maximum speed.
        public const int MaxSpeed = 100;

        // Car properties.
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";
        public int CarID { get; set; }

        // Is the car still operational?
        private bool _carIsDead;

        // A car has-a radio.
        private readonly Radio _theMusicBox = new Radio();

        public static IComparer SortByPetName => (IComparer)new PetNameComparer();

        // Constructors.
        public Car() { }
        public Car(string name, int speed, int id)
        {
            CurrentSpeed = speed;
            PetName = name;
            CarID = id;
        }
        public Car(string name, int speed) : this(name, speed, new Random().Next()) { }
        public void CrankTunes(bool state)
        {
            // Delegate request to inner object.
            _theMusicBox.TurnOn(state);
        }

        // See if Car has overheated.
        public void Accelerate(int delta)
        {
            if (_carIsDead)
            {
                Console.WriteLine("{0} is out of order...", PetName);
            }
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    CurrentSpeed = 0;
                    _carIsDead = true;

                    // Use the "throw" keyword to raise an exception.
                    throw new Exception($"{PetName} has overheated!")
                    {
                        HelpLink = "https://www.google.com",
                        Data = {
                            {"TimeStamp", $"The car exploded at {DateTime.Now}"},
                            {"Cause", "You have a lead foot."}
                        }
                    };
                }
                Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            }
        }
        public override string ToString()
        {
            return $"Id: {this.CarID} with car's name {this.PetName} has current speed {this.CurrentSpeed}";
        }

        public int CompareTo(object obj)
        {
            if (obj is Car c)
            {
                return this.CarID.CompareTo(c.CarID);
            }
            throw new ArgumentException("Parameter is not a Car!!!!");
        }
    }
}