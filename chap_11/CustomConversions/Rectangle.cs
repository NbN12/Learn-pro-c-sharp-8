using System;

namespace CustomConversions
{
    public struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle(int w, int h)
        {
            Width = w;
            Height = h;
        }
        public void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        => $"[Width = {Width}; Height = {Height}]";

        public static implicit operator Rectangle(Square square)
        {
            return new Rectangle(square.Length, square.Length * 2); // Assume the length of height is length * 2
        }
    }
}