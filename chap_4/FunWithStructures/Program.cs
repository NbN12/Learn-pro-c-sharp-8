using System;

namespace FunWithStructures
{
    struct Point
    {
        // Fields of the structure.
        public int X;
        public int Y;

        // Add 1 to the (X, Y) position.
        public void Increment()
        {
            X++; Y++;
        }

        // Subtract 1 from the (X, Y) position.
        public void Decrement()
        {
            X--; Y--;
        }

        // Display the current position.
        public void Display()
        {
            Console.WriteLine("X = {0}, Y = {1}", X, Y);
        }

        // A custom constructor.
        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }
    }

    readonly struct ReadOnlyPoint
    {
        // Fields of the structure.
        public int X { get; }
        public int Y { get; }

        // Display the current position and name.
        public void Display()
        {
            Console.WriteLine($"X = {X}, Y = {Y}");
        }

        public ReadOnlyPoint(int xPos, int yPos, string name)
        {
            X = xPos;
            Y = yPos;
        }
    }

    struct PointWithReadOnly
    {
        // Fields of the structure.
        public int X;
        public readonly int Y;
        public readonly string Name;

        // Display the current position and name.
        public readonly void Display()
        {
            Console.WriteLine($"X = {X}, Y = {Y}, Name = {Name}");
        }

        // A custom constructor.
        public PointWithReadOnly(int xPos, int yPos, string name)
        {
            X = xPos;
            Y = yPos;
            Name = name;
        }
    }

    ref struct DisposableRefStruct
    {
        public int X;
        public readonly int Y;
        public readonly void Display()
        {
            Console.WriteLine($"X = {X}, Y = {Y}");
        }

        // A custom constructor
        public DisposableRefStruct(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
            Console.WriteLine("Created!");
        }

        public void Dispose()
        {
            // clean up any resources here
            Console.WriteLine("Disposed!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** A First Look at Structures *****\n");
            // Create an initial Point.
            Point myPoint;
            myPoint.X = 349;
            myPoint.Y = 76;
            myPoint.Display();
            // Adjust the X and Y values.
            myPoint.Increment();
            myPoint.Display();

            // Error! Did not assign Y value.
            // Point p1;
            // p1.X = 10;
            // p1.Display();

            // OK! Both fields assigned before use.
            Point p2;
            p2.X = 10;
            p2.Y = 10;
            p2.Display();

            // Set all fields to default values
            // using the default constructor.
            Point p1 = new Point();

            // Prints X=0,Y=0.
            p1.Display();

            // Call custom constructor.
            Point p3 = new Point(50, 60);

            // Prints X=50,Y=60.
            p2.Display();


            PointWithReadOnly p4 = new PointWithReadOnly(50, 60, "Point x/R0");
            p4.Display();

            var s = new DisposableRefStruct(50, 60);
            s.Display();
            s.Dispose();

            Console.ReadLine();
        }

    }
}
