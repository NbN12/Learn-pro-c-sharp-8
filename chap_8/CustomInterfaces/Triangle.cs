using System;

namespace CustomInterfaces
{
    class Triangle : Shape, IPointy
    {
        public Triangle() { }
        public Triangle(string name) : base(name) { }
        public byte Points => 3;

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Triangle", PetName);
        }

    }
}