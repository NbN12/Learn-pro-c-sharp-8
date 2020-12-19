using System;

namespace FunWithTuples
{
    class Program
    {

        struct Point
        {
            // Fields of the structure.
            public int X;
            public int Y;
            // A custom constructor.
            public Point(int XPos, int YPos)
            {
                X = XPos;
                Y = YPos;
            }
            public (int XPos, int YPos) Deconstruct1() => (X, Y);
            public void Deconstruct(out int XPos, out int YPos) => (XPos, YPos) = (X, Y);
        }

        static void Main(string[] args)
        {
            // (string, int, string) values = ("a", 5, "c");
            // // or
            // // var values = ("a", 5, "c");

            // Console.WriteLine($"First item: {values.Item1}");
            // Console.WriteLine($"Second item: {values.Item2}");
            // Console.WriteLine($"Third item: {values.Item3}");

            // (string FirstLetter, int TheNumber, string SecondLetter) valuesWithNames = ("a", 5, "C");
            // // or
            // var valuesWithNames2 = (FirstLetter: "a", TheNumber: 5, SecondLetter: "c");
            // Console.WriteLine($"First item: {valuesWithNames.FirstLetter}");
            // Console.WriteLine($"Second item: {valuesWithNames.TheNumber}");
            // Console.WriteLine($"Third item: {valuesWithNames.SecondLetter}");

            // // or
            // Console.WriteLine($"First item: {valuesWithNames2.FirstLetter}");
            // Console.WriteLine($"Second item: {valuesWithNames2.TheNumber}");
            // Console.WriteLine($"Third item: {valuesWithNames2.SecondLetter}");

            // //Using the item notation still works!
            // Console.WriteLine($"First item: {valuesWithNames.Item1}");
            // Console.WriteLine($"Second item: {valuesWithNames.Item2}");
            // Console.WriteLine($"Third item: {valuesWithNames.Item3}");

            Console.WriteLine("=> Inferred Tuple Names");
            var foo = new { Prop1 = "first", Prop2 = "second" };
            var bar = (foo.Prop1, foo.Prop2);
            Console.WriteLine($"{bar.Prop1};{bar.Prop2}");

            Console.WriteLine("=> Tuples Equality/Inequality");
            // lifted conversions
            var left = (a: 5, b: 10);
            (int? a, int? b) nullableMembers = (5, 10);
            Console.WriteLine(left == nullableMembers); // Also true

            // converted type of left is (long, long)
            (long a, long b) longTuple = (5, 10);
            Console.WriteLine(left == longTuple); // Also true

            // comparisons performed on (long, long) tuples
            (long a, int b) longFirst = (5, 10);
            (int a, long b) longSecond = (5, 10);
            Console.WriteLine(longFirst == longSecond); // Also true

            var samples = FillTheseValues();
            Console.WriteLine($"Int is: {samples.a}");
            Console.WriteLine($"String is: {samples.b}");
            Console.WriteLine($"Boolean is: {samples.c}");

            var (first, _, last) = SplitNames("Philip F Japikse");
            Console.WriteLine($"{first}:{last}");

            Point p = new Point(7, 5);
            var pointValues = p.Deconstruct1();
            Console.WriteLine($"X is: {pointValues.XPos}");
            Console.WriteLine($"Y is: {pointValues.YPos}");

            Console.WriteLine($"GetQuadrant2 return value:{GetQuadrant2(p)}");
            Console.WriteLine($"GetQuadrant1 return value:{GetQuadrant1(p)}");
        }

        static string GetQuadrant2(Point p)
        {
            return p switch
            {
                (0, 0) => "Origin",
                var (x, y) when x > 0 && y > 0 => "One",
                var (x, y) when x < 0 && y > 0 => "Two",
                var (x, y) when x < 0 && y < 0 => "Three",
                var (x, y) when x > 0 && y < 0 => "Four",
                var (_, _) => "Border",
            };
        }

        static string GetQuadrant1(Point p)
        {
            return p.Deconstruct1() switch
            {
                (0, 0) => "Origin",
                var (x, y) when x > 0 && y > 0 => "One",
                var (x, y) when x < 0 && y > 0 => "Two",
                var (x, y) when x < 0 && y < 0 => "Three",
                var (x, y) when x > 0 && y < 0 => "Four",
                var (_, _) => "Border",
            };
        }

        //Switch expression with Tuples
        static string RockPaperScissors(string first, string second)
        {
            return (first, second) switch
            {
                ("rock", "paper") => "Paper wins.",
                ("rock", "scissors") => "Rock wins.",
                ("paper", "rock") => "Paper wins.",
                ("paper", "scissors") => "Scissors wins.",
                ("scissors", "rock") => "Rock wins.",
                ("scissors", "paper") => "Scissors wins.",
                (_, _) => "Tie.",
            };
        }

        // verion 2
        static string RockPaperScissors2((string, string) values)
        {
            return values switch
            {
                ("rock", "paper") => "Paper wins.",
                ("rock", "scissors") => "Rock wins.",
                ("paper", "rock") => "Paper wins.",
                ("paper", "scissors") => "Scissors wins.",
                ("scissors", "rock") => "Rock wins.",
                ("scissors", "paper") => "Scissors wins.",
                (_, _) => "Tie.",
            };
        }

        static (int a, string b, bool c) FillTheseValues()
        {
            return (9, "Enjoy your string.", true);
        }

        static (string first, string middle, string last) SplitNames(string fullName)
        {
            //do what is needed to split the name apart
            return ("Philip", "F", "Japikse");
        }
    }
}
