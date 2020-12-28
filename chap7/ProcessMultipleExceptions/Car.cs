using System;

namespace ProcessMultipleExceptions
{
    class Car
    {
        // Constant for maximum speed.
        public const int MaxSpeed = 100;

        // Car properties.
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";

        // Is the car still operational?
        private bool _carIsDead;

        // A car has-a radio.
        private readonly Radio _theMusicBox = new Radio();

        // Constructors.
        public Car() { }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }
        public void CrankTunes(bool state)
        {
            // Delegate request to inner object.
            _theMusicBox.TurnOn(state);
        }

        // See if Car has overheated.
        public void Accelerate(int delta)
        {

            if (delta < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(delta), "Speed must be greater than zero");
            }
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

                    // // Use the "throw" keyword to raise an exception.
                    // throw new Exception($"{PetName} has overheated!")
                    // {
                    //     HelpLink = "https://www.google.com",
                    //     Data = {
                    //         {"TimeStamp", $"The car exploded at {DateTime.Now}"},
                    //         {"Cause", "You have a lead foot."}
                    //     }
                    // };
                    throw new CarIsDeadException("You have a lead foot", DateTime.Now, $"{PetName} has overheated!")
                    {
                        HelpLink = "https://www.google.com"
                    };
                }
                Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }
}