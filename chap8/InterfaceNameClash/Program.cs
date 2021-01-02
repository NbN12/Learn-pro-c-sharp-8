﻿using System;

namespace InterfaceNameClash
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Interface Name Clashes *****\n");
            // All of these invocations call the
            // same Draw() method!
            Octagon oct = new Octagon();

            // We now must use casting to access the Draw()
            // members.
            IDrawToForm itfForm = (IDrawToForm)oct;
            itfForm.Draw();

            // Shorthand notation if you don't need
            // the interface variable for later use.
            ((IDrawToPrinter)oct).Draw();

            // Could also use the "is" keyword.
            if (oct is IDrawToMemory dtm)
            {
                dtm.Draw();
            }

            Console.ReadLine();
        }
    }
}