using System;

// Now list any assembly- or module-level attributes.
// Enforce CLS compliance for all public types in this
// assembly.
[assembly: CLSCompliant(true)]

namespace AttributedCarLibrary
{
    [VehicleDescription("A very long, slow, but feature-rich auto")]
    public class Winnebago
    {
        public ulong notCompliant;
        // [VehicleDescription("My rocking CD player")]
        // public void PlayMusic(bool On)
        // {
        //     // ...
        // }
    }
}