using System;

namespace MiInterfaceHierarchy
{
    class Square : IShape
    {
        void IDrawable.Draw()
        {
            Console.WriteLine("Drawing to screen ...");
        }

        void IPrintable.Draw()
        {
            Console.WriteLine("Drawing to printer ...");
        }

        public int GetNumberOfSides() => 4;

        public void Print()
        {
            Console.WriteLine("Printing ....");
        }
    }
}