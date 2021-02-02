using System;

namespace CustomInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Interfaces *****\n");
            // CloneableExample();
            // Call Points property defined by IPointy.
            Hexagon hex = new Hexagon();
            Console.WriteLine("Points: {0}", hex.Points);

            // Catch a possible InvalidCastException.
            Circle c = new Circle("Lisa");
            IPointy itfPt = null;
            try
            {
                itfPt = (IPointy)c;
                Console.WriteLine(itfPt.Points);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

            // Can we treat hex2 as IPointy?
            Hexagon hex2 = new Hexagon("Peter");
            IPointy itfPt2 = hex2 as IPointy;
            if (itfPt2 != null)
            {
                Console.WriteLine("Points: {0}", itfPt2.Points);
            }
            else
            {
                Console.WriteLine("OOPS! Not pointy...");
            }

            if (hex2 is IPointy itfPt3)
            {
                Console.WriteLine("Points: {0}", itfPt3.Points);
            }
            else
            {
                Console.WriteLine("OOPS! Not pointy...");

            }

            var sq = new Square("Boxy") { NumberOfSides = 4, SideLength = 4 };
            sq.Draw();
            // This won’t compile if sq is Square is not casted to IRegularPointy
            Console.WriteLine($"{sq.PetName} has {sq.NumberOfSides} of length {sq.SideLength} and a perimeter of {((IRegularPointy)sq).Perimeter}");

            Console.WriteLine($"Example property: {IRegularPointy.ExampleProperty}");
            IRegularPointy.ExampleProperty = "Updated";
            Console.WriteLine($"Example property: {IRegularPointy.ExampleProperty}");

            Shape[] myShapes = { new Hexagon(), new Circle(), new Triangle("Joe"), new Circle("JoJo") };
            foreach (var shape in myShapes)
            {
                if (shape is IDraw3D s)
                {
                    DrawIn3D(s);
                }
                // This is bad code
                // DrawIn3D((IDraw3D)shape);
            }

            // Get first pointy item.
            var firstPointyItem = FindFirstPointyShape(myShapes);
            // To be safe, use the null conditional operator.
            Console.WriteLine("The item has {0} points", firstPointyItem?.Points);

            // This array can only contain types that
            // implement the IPointy interface.
            IPointy[] myPointyObjs = { new Hexagon(), new Knife(), new Triangle(), new Fork(), new PitchFork() };
            foreach (var pointy in myPointyObjs)
            {
                Console.WriteLine($"{pointy.ToString()} has {pointy.Points} points.");
            }

            Console.ReadLine();
        }

        static IPointy FindFirstPointyShape(Shape[] shapes)
        {
            foreach (var shape in shapes)
            {
                if (shape is IPointy ip)
                {
                    return ip;
                }
            }
            return null;
        }

        static void DrawIn3D(IDraw3D itf3d)
        {
            Console.WriteLine("-> Drawing IDraw3D compatible type");
            itf3d.Draw3D();
        }

        static void CloneableExample()
        {
            // All of these classes support the ICloneable interface.
            string myStr = "Hello";
            OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());

            CloneMe(myStr);
            CloneMe(unixOS);

            static void CloneMe(ICloneable c)
            {
                object theClone = c.Clone();
                Console.WriteLine("Your clone is a: {0}", theClone.GetType().Name);
            }
        }
    }
}
