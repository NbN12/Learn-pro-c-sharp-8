using System;

namespace AttributedCarLibrary
{
    // All classes in one file for simplicity
    // Assign description using a "named property."
    [Serializable]
    [VehicleDescription(Description = "My rocking Harley")]
    public class Motorcycle
    {

    }
}