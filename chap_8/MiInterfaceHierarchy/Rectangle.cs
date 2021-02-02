using System;

namespace MiInterfaceHierarchy
{
    class Rectangle : IShape
    {
        public void Draw() => Console.WriteLine("Drawing...");

        public int GetNumberOfSides() => 4;

        public void Print() => Console.WriteLine("Printing...");
    }
}