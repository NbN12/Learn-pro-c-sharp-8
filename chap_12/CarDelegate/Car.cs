using System;

namespace CarDelegate
{
    public class Car
    {
        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }

        // Is the car alive or dead ?
        private bool _carIsDead;

        // Class contructors.
        public Car() { }

        public Car(string petName, int maxSpeed, int currentSpeed)
        {
            CurrentSpeed = currentSpeed;
            MaxSpeed = maxSpeed;
            PetName = petName;
        }
        // Define a delegate type
        public delegate void CarEngineHandler(string msgForCaller);
        // Define a member variable of this delegate.
        private CarEngineHandler _listOfHandlers;

        // Now with multicasting support!
        // Note we are now using the += operator, not
        // the assignment operator (=).
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            _listOfHandlers += methodToCall;
            // OR
            // if (_listOfHandlers == null)
            // {
            //     _listOfHandlers = methodToCall;
            // }
            // else
            // {
            //     _listOfHandlers = Delegate.Combine(_listOfHandlers, methodToCall) as CarEngineHandler;
            // }
        }
        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            _listOfHandlers -= methodToCall;
        }

        //  Implement the Accelerate() method to invoke the delegate's
        // invocation list under the correct circumstances.
        public void Accelerate(int delta)
        {
            if (_carIsDead)
            {
                _listOfHandlers?.Invoke("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                // Is this car "almost dead"?
                if (10 == (MaxSpeed - CurrentSpeed))
                {
                    _listOfHandlers?.Invoke("Careful buddy! Gonna blow!");
                }
                if (CurrentSpeed >= MaxSpeed)
                {
                    _carIsDead = true;
                }
                else
                {
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }
    }
}