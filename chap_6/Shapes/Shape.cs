using System;

namespace Shapes
{
    abstract class Shape
    {
        public string PetName { get; set; }

        protected Shape(string name = "NoName")
        {
            PetName = name;
        }

        // public virtual void Draw()
        // {
        //     Console.WriteLine("Inside Shape.Draw()");
        // }
        public abstract void Draw();
    }
}