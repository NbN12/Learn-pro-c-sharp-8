using System;

namespace InterfaceNameClash
{
    public class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        // public void Draw()
        // {
        //     // Shared drawing logic.
        //     Console.WriteLine("Drawing the Octagon...");
        // }
        // Explicitly bind Draw() implementations
        // to a given interface.
        void IDrawToForm.Draw()
        {
            Console.WriteLine("Drawing to form...");
        }

        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Drawing to memory...");
        }

        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Drawing to a printer...");
        }
    }
}