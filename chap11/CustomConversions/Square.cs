using System;

namespace CustomConversions
{
    public struct Square
    {
        public int Length { get; set; }
        public Square(int l) : this()
        {
            Length = l;
        }

        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString() => $"[Length = {Length}]";
        // Rectangles can be explicitly converted into Squares.
        public static explicit operator Square(Rectangle rectangle)
        {
            Square square = new Square { Length = rectangle.Height };
            return square;
        }

        public static explicit operator Square(int sideLength)
        {
            return new Square(sideLength);
        }

        public static explicit operator int(Square square)
        {
            return square.Length;
        }
    }
}