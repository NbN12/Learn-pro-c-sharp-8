using System;

namespace CloneablePoint
{
    public class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointDescription desc = new PointDescription();

        public Point(int xPos, int yPos, string petName)
        {
            X = xPos;
            Y = yPos;
            desc.PetName = petName;
        }
        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }
        public Point() { }

        public override string ToString() => $"X = {X}; Y = {Y}; Name = {desc.PetName};\nID = {desc.PointID}\n";

        // public object Clone() => new Point(this.X, this.Y);
        // or
        public object Clone()
        {
            // Get shallow copy of current object
            Point point = (Point)this.MemberwiseClone();

            // create PointDescription to store current value of this object.
            PointDescription currentDesc = new PointDescription();
            currentDesc.PetName = point.desc.PetName;
            point.desc = currentDesc;
            return point;
        }
    }
}