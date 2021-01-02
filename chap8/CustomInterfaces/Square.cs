using System;

namespace CustomInterfaces
{
    class Square : Shape, IRegularPointy
    {
        public Square() { }
        public Square(string name) : base(name) { }
        //These come from the IRegularPointy interface
        public int SideLength { get; set; }
        public int NumberOfSides { get; set; }

        //This comes from the IPointy interface
        public byte Points => 4;

        //Draw comes from the Shape base class
        public override void Draw()
        {
            Console.WriteLine("Drawing a square");
        }
    }
}