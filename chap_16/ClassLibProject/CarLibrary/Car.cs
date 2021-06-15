// using System.Runtime.CompilerServices;

// [assembly: InternalsVisibleTo("CSharpCarClient")]
namespace CarLibrary
{

    public enum EngineState
    {
        EngineAlive,
        EngineDead
    }
    public abstract class Car
    {
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }

        protected EngineState State = EngineState.EngineAlive;
        public EngineState EngineState => State;
        public abstract void TurboBoost();

        public Car() { }
        public Car(string name, int maxSpeed, int currentSpeed)
        {
            PetName = name;
            MaxSpeed = maxSpeed;
            CurrentSpeed = currentSpeed;
        }
    }
}