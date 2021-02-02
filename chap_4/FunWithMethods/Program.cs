using System;

namespace FunWithMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Methods *****\n");
            // Pass two variables in by value.
            int x = 9, y = 10;
            Console.WriteLine("Before call: X: {0}, Y: {1}", x, y);
            Console.WriteLine("Answer is: {0}", Add(x, y));
            Console.WriteLine("After call: X: {0}, Y: {1}", x, y);

            // No need to assign initial value to local variables
            // used as output parameters, provided the first time
            // you use them is as output arguments.
            // C# 7 allows for out parameters to be declared in the method call
            Console.WriteLine("==============================================");
            Add(90, 90, out int ans);
            Console.WriteLine("90 + 90 = {0}", ans);

            Console.WriteLine("==============================================");
            FillTheseValues(out int i, out string str, out bool b);
            Console.WriteLine("Int is: {0}", i);
            Console.WriteLine("String is: {0}", str);
            Console.WriteLine("Boolean is: {0}", b);
            // This only gets the value for a, and ignores the other two parameters
            FillTheseValues(out int a, out _, out _);
            Console.WriteLine("==============================================");
            string str1 = "Flip";
            string str2 = "Flop";
            Console.WriteLine("Before: {0}, {1} ", str1, str2);
            SwapStrings(ref str1, ref str2);
            Console.WriteLine("After: {0}, {1} ", str1, str2);
            Console.WriteLine("==============================================");
            // Pass in a comma-delimited list of doubles...
            double average;
            average = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            Console.WriteLine("Average of data is: {0}", average);
            Console.WriteLine("==============================================");
            // ...or pass an array of doubles.
            double[] data = { 4.0, 3.2, 5.7 };
            average = CalculateAverage(data);
            Console.WriteLine("Average of data is: {0}", average);
            Console.WriteLine("==============================================");
            // Average of 0 is 0!
            Console.WriteLine("Average of data is: {0}", CalculateAverage());
            Console.WriteLine("==============================================");
            EnterLogData("Oh no! Grid can't find data");
            EnterLogData("Oh no! I can't find the payroll data", "CFO");
            Console.WriteLine("==============================================");
            DisplayFancyMessage(message: "Wow! Very Fancy indeed!", textColor: ConsoleColor.DarkRed, backgroundColor: ConsoleColor.White);
            DisplayFancyMessage(backgroundColor: ConsoleColor.Green, message: "Testing...", textColor: ConsoleColor.DarkBlue);
            // // This is an ERROR, as positional args are listed after named args.
            // DisplayFancyMessage(message: "Testing...",
            // backgroundColor: ConsoleColor.White,
            // ConsoleColor.Blue);
            DisplayFancyMessage(message: "Hello!");
            DisplayFancyMessage(textColor: ConsoleColor.Red);
            Console.WriteLine("==============================================");

            Console.ReadLine();
        }

        static void DisplayFancyMessage(ConsoleColor textColor = ConsoleColor.Blue, ConsoleColor backgroundColor = ConsoleColor.White, string message = "Test Message")
        {
            // Store old colors to restore after message is printed.
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldbackgroundColor = Console.BackgroundColor;
            // Set new colors and print message.
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);
            // Restore previous colors.
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldbackgroundColor;
        }
        // Error! The default value for an optional arg must be known
        // at compile time!
        // static void EnterLogData(string message, string owner = "Programmer", DateTime timeStamp =
        // DateTime.Now)
        // {
        //     Console.Beep();
        //     Console.WriteLine("Error: {0}", message);
        //     Console.WriteLine("Owner of Error: {0}", owner);
        //     Console.WriteLine("Time of Error: {0}", timeStamp);
        // }

        static void EnterLogData(string message, string owner = "Programmer")
        {
            Console.Beep();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }

        static int Add2(int x, int y)
        {
            x = 10000;
            y = 88888;
            int ans = x + y;
            return ans;
        }

        // Return average of "some number" of doubles.
        static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("You sent me {0} doubles.", values.Length);
            double sum = 0;
            if (values.Length == 0)
            {
                return sum;
            }
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return (sum / values.Length);
        }

        static int AddReadOnly(in int x, in int y)
        {
            //Error CS8331 Cannot assign to variable 'in int' because it is a readonly variable
            // x = 10000;
            // y = 88888;
            int ans = x + y;
            return ans;
        }

        // Reference parameters.
        public static void SwapStrings(ref string s1, ref string s2)
        {
            string tempStr = s1;
            s1 = s2;
            s2 = tempStr;
        }

        // static void ThisWontCompile(out int a)
        // {
        //     Console.WriteLine("Error! Forgot to assign output arg!");
        // }

        // //This only gets the value for a, and ignores the other two parameters
        // FillTheseValues(out int a, out _, out _);
        // Returning multiple output parameters.
        static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Enjoy your string.";
            c = true;
        }

        static void Add(int x, int y, out int ans)
        {
            ans = x + y;
        }

        // Value type arguments are passed by value by default.
        static int Add(int x, int y)
        {
            int ans = x + y;
            // Caller will not see these changes
            // as you are modifying a copy of the
            // original data.
            x = 10000;
            y = 88888;
            return ans;
        }
    }
}
