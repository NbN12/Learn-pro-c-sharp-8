using System;
using System.Linq;

namespace IterationsAndDecisions
{
    class Program
    {
        static void Main(string[] args)
        {
            // ForLoopExample();
            // ForEachLoopExample();
            // WhileLoopExample();
            // DoWhileLoopExample();
            // IfElseExample();
            // IfElsePatternMatching();
            // ExecuteIfElseUsingConditionalOperator();
            // ConditionalRefExample();
            // SwitchExample();
            // SwitchOnStringExample();
            // SwitchOnEnumExample();
            // SwitchWithGoto();
            // ExecutePatternMatchingSwitch();
            // ExecutePatternMatchingSwitchWithWhen();
            Console.WriteLine(RockPaperScissors("paper", "rock"));
            Console.WriteLine(RockPaperScissors("scissors", "rock"));
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

        // C# 8 or above
        static string FromRainbow(string colorBand)
        {
            return colorBand switch
            {
                "Red" => "#FF0000",
                "Orange" => "#FF7F00",
                "Yellow" => "#FFFF00",
                "Green" => "#00FF00",
                "Blue" => "#0000FF",
                "Indigo" => "#4B0082",
                "Violet" => "#9400D3",
                _ => "#FFFFFF"
            };
        }

        // C# 7 or below
        static string FromRainbowClassic(string colorBand)
        {
            switch (colorBand)
            {
                case "Red":
                    return "#FF0000";
                case "Orange":
                    return "#FF7F00";
                case "Yellow":
                    return "#FFFF00";
                case "Green":
                    return "#00FF00";
                case "Blue":
                    return "#0000FF";
                case "Indigo":
                    return "#4B0082";
                case "Violet":
                    return "#9400D3";
                default:
                    return "#FFFFFF";
            };
        }

        static void ExecutePatternMatchingSwitchWithWhen()
        {
            Console.WriteLine("1 [C#], 2 [VB]");
            Console.Write("Please pick your language preference: ");
            object langChoice = Console.ReadLine();
            var choice = int.TryParse(langChoice.ToString(), out int c) ? c : langChoice;

            switch (choice)
            {
                case int i when i == 2:
                case string s when s.Equals("VB", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine("VB: OOP, multithreading, and more!");
                    break;
                case int i when i == 1:
                case string s when s.Equals("C#", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine("Good choice, C# is a fine language.");
                    break;
                default:
                    Console.WriteLine("Well...good luck with that!");
                    break;
            }
        }

        static void ExecutePatternMatchingSwitch()
        {
            Console.WriteLine("1 [Integer (5)], 2 [String (\"Hi\")], 3 [Decimal (2.5)]");
            Console.Write("Please choose an option: ");
            string userChoice = Console.ReadLine();
            object choice;
            //This is a standard constant pattern switch statement to set up the example
            switch (userChoice)
            {
                case "1":
                    choice = 5;
                    break;
                case "2":
                    choice = "Hi";
                    break;
                case "3":
                    choice = 2.5M;
                    break;
                default:
                    choice = 5;
                    break;
            }

            //This is new the pattern matching switch statement
            switch (choice)
            {
                case int i:
                    Console.WriteLine("Your choice is an integer {0}.", i);
                    break;
                case string s:
                    Console.WriteLine("Your choice is a string. {0}", s);
                    break;
                case decimal d:
                    Console.WriteLine("Your choice is a decimal. {0}", d);
                    break;
                default:
                    Console.WriteLine("Your choice is something else");
                    break;
            }
            Console.WriteLine();
        }

        public static void SwitchWithGoto()
        {
            var foo = 5;
            switch (foo)
            {
                case 1:
                    //do something
                    Console.WriteLine("XYZ");
                    goto case 2;
                case 2:
                    //do something else
                    Console.WriteLine("ABC");
                    break;
                case 3:
                    //yet another action
                    Console.WriteLine("DEF");
                    goto default;
                default:
                    //default action
                    Console.WriteLine("PHUC");
                    break;
            }
        }

        static void SwitchOnEnumExample()
        {
            Console.Write("Enter your favorite day of the week: ");
            DayOfWeek favDay;
            try
            {
                favDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Bad input!");
                return;
            }
            switch (favDay)
            {
                // multiple case statments
                // case DayOfWeek.Saturday:
                // case DayOfWeek.Sunday:
                //     Console.WriteLine("It’s the weekend!");
                //     break;
                case DayOfWeek.Sunday:
                    Console.WriteLine("Football!!");
                    break;
                case DayOfWeek.Monday:
                    Console.WriteLine("Another day, another dollar");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("At least it is not Monday");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("A fine day.");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("Almost Friday...");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("Yes, Friday rules!");
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("Great day indeed.");
                    break;
            }
            Console.WriteLine();
        }

        static void SwitchOnStringExample()
        {
            Console.WriteLine("C# or VB");
            Console.Write("Please pick your language preference: ");
            string langChoice = Console.ReadLine();
            switch (langChoice.ToUpper())
            {
                case "C#":
                    Console.WriteLine("Good choice, C# is a fine language.");
                    break;
                case "VB":
                    Console.WriteLine("VB: OOP, multithreading and more!");
                    break;
                default:
                    Console.WriteLine("Well...good luck with that!");
                    break;
            }
        }

        // Switch on a numerical value.
        static void SwitchExample()
        {
            Console.WriteLine("1 [C#], 2 [VB]");
            Console.Write("Please pick your language preference: ");
            string langChoice = Console.ReadLine();
            int n = int.Parse(langChoice);
            switch (n)
            {
                case 1:
                    Console.WriteLine("Good choice, C# is a fine language.");
                    break;
                case 2:
                    Console.WriteLine("VB: OOP, multithreading, and more!");
                    break;
                default:
                    Console.WriteLine("Well...good luck with that!");
                    break;
            }
        }

        private static void ConditionalRefExample()
        {
            var smallArray = new int[] { 1, 2, 3, 4, 5 };
            var largeArray = new int[] { 10, 20, 30, 40, 50 };

            int index = 7;
            ref int refValue = ref ((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]);

            refValue = 0;

            index = 2;
            (index < 5 ? ref smallArray[index] : ref largeArray[index - 5]) = 100;
            Console.WriteLine(string.Join(" ", smallArray));
            Console.WriteLine(string.Join(" ", largeArray));
        }

        private static void ExecuteIfElseUsingConditionalOperator()
        {
            string stringData = "My textual data";
            Console.WriteLine(stringData.Length > 0
            ? "string is greater than 0 characters"
            : "string is not greater than 0 characters");
            Console.WriteLine();
        }

        static void IfElsePatternMatching()
        {
            Console.WriteLine("===If Else Pattern Matching ===/n");
            object testItem1 = 123;
            object testItem2 = "Hello";
            if (testItem1 is string myStringValue1)
            {
                Console.WriteLine($"{myStringValue1} is a string");
            }

            if (testItem1 is int myValue1)
            {
                Console.WriteLine($"{myValue1} is an int");
            }

            if (testItem2 is string myStringValue2)
            {
                Console.WriteLine($"{myStringValue2} is a string");
            }
            if (testItem2 is int myValue2)
            {
                Console.WriteLine($"{myValue2} is an int");
            }
            Console.WriteLine();
        }

        static void IfElseExample()
        {
            // This is illegal, given that Length returns an int, not a bool.
            string stringData = "My textual data";
            // if (stringData.Length) // This will not work
            // Legal, as this resolves to either true or false.
            if (stringData.Length > 0)
            {
                Console.WriteLine("string is greater than 0 characters");
            }
            else
            {
                Console.WriteLine("string is not greater than 0 characters");
            }
            Console.WriteLine();
        }

        static void DoWhileLoopExample()
        {
            string userIsDone = "";
            do
            {
                Console.WriteLine("In do/while loop");
                Console.Write("Are you done? [yes] [no]: ");
                userIsDone = Console.ReadLine();
            } while (userIsDone.ToLower() != "yes"); // Note the semicolon!
        }

        static void WhileLoopExample()
        {
            string userIsDone = "";
            // Test on a lower-class copy of the string.
            while (userIsDone.ToLower() != "yes")  // or userIsDone.Equals("yes",StringComparison.OrdinalIgnoreCase)
            {
                Console.WriteLine("In while loop");
                Console.Write("Are you done? [yes] [no]: ");
                userIsDone = Console.ReadLine();
            }
        }

        static void LinqQueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // LINQ query!
            var subset = from i in numbers where i < 10 select i;
            Console.Write("Values in subset: ");
            foreach (var i in subset)
            {
                Console.Write("{0} ", i);
            }
        }

        // Iterate array items using foreach.
        static void ForEachLoopExample()
        {
            string[] carTypes = { "Ford", "BMW", "Yugo", "Honda" };
            foreach (string c in carTypes)
            {
                Console.WriteLine(c);
            }
            int[] myInts = { 10, 20, 30, 40 };
            foreach (int i in myInts)
            {
                Console.WriteLine(i);
            }
        }

        // A basic for loop.
        static void ForLoopExample()
        {
            // Note! "i" is only visible within the scope of the for loop.
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Number is: {0} ", i);
            }
            // "i" is not visible here.
        }
    }
}
