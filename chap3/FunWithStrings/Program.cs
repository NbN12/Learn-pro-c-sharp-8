using System;
using System.Text;

namespace FunWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            // BasicStringFunctionality();
            // StringConcatenation();
            // EscapeChars();
            // StringInterpolation();
            // StringEquality();
            // StringEqualitySpecifyingCompareRules();
            // StringsAreImmutable();
            FunWithStringBuilder();
        }

        static void FunWithStringBuilder()
        {
            Console.WriteLine("=> Using the StringBuilder:");
            StringBuilder sb = new StringBuilder("**** Fantastic Games ****");
            // // Make a StringBuilder with an initial size of 256.
            // StringBuilder sb = new StringBuilder("**** Fantastic Games ****", 256);
            sb.Append("\n");
            sb.Append("Half Life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex" + "2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());
            sb.Replace("2", "Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);
            Console.WriteLine();
        }

        static void StringsAreImmutable2()
        {
            string s2 = "My other string";
            s2 = "New string value";
        }

        static void StringsAreImmutable()
        {
            // Set initial string value.
            string s1 = "This is my string.";
            Console.WriteLine("s1 = {0}", s1);
            // Uppercase s1?
            string upperString = s1.ToUpper();
            Console.WriteLine("upperString = {0}", upperString);
            // Nope! s1 is in the same format!
            Console.WriteLine("s1 = {0}", s1);
        }

        static void StringEqualitySpecifyingCompareRules()
        {
            Console.WriteLine("=> String equality (Case Insensitive:");
            string s1 = "Hello!";
            string s2 = "HELLO!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();
            // Check the results of changing the default compare rules.
            Console.WriteLine("Default rules: s1={0},s2={1}s1.Equals(s2): {2}", s1, s2, s1.Equals(s2));
            Console.WriteLine("Ignore case: s1.Equals(s2, StringComparison.OrdinalIgnoreCase): {0}", s1.Equals(s2, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Ignore case, Invariant Culture: s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase): {0}", s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine();
            Console.WriteLine("Default rules: s1={0},s2={1} s1.IndexOf(\"E\"): {2}", s1, s2, s1.IndexOf("E"));
            Console.WriteLine("Ignore case: s1.IndexOf(\"E\", StringComparison.OrdinalIgnoreCase):{0}", s1.IndexOf("E", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Ignore case, Invariant Culture: s1.IndexOf(\"E\", StringComparison.InvariantCultureIgnoreCase): {0}", s1.IndexOf("E", StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine();
        }

        static void StringEquality()
        {
            Console.WriteLine("=> String equality:");
            string s1 = "Hello!";
            string s2 = "Yo!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();
            // Test these strings for equality.
            Console.WriteLine("s1 == s2: {0}", s1 == s2);
            Console.WriteLine("s1 == Hello!: {0}", s1 == "Hello!");
            Console.WriteLine("s1 == HELLO!: {0}", s1 == "HELLO!");
            Console.WriteLine("s1 == hello!: {0}", s1 == "hello!");
            Console.WriteLine("s1.Equals(s2): {0}", s1.Equals(s2));
            Console.WriteLine("Yo.Equals(s2): {0}", "Yo!".Equals(s2));
            Console.WriteLine();
        }

        static void StringInterpolation()
        {
            // Some local variables we will plug into our larger string
            int age = 4;
            string name = "Soren";
            // Using curly-bracket syntax.
            string greeting = string.Format("Hello {0} you are {1} years old.", name, age);
            // Using string interpolation
            string greeting2 = $"Hello {name} you are {age} years old.";
            // string greeting = string.Format("Hello {0} you are {1} years old.", name.ToUpper(), age);
            // string greeting2 = $"Hello {name.ToUpper()} you are {age} years old.";
            // string greeting = string.Format("\tHello {0} you are {1} years old.", name.ToUpper(), age);
            // string greeting2 = $"\tHello {name.ToUpper()} you are {age} years old.";
            // The following string is printed verbatim,
            // thus all escape characters are displayed.
            Console.WriteLine(@"C:\MyApp\bin\Debug");
            // Whitespace is preserved with verbatim strings.
            string myLongString = @"This is a very
              very
                  very
                      long string";
            Console.WriteLine(myLongString);
            Console.WriteLine(@"Cerebus said ""Darrr! Pret-ty sun-sets""");
            string interp = "interpolation";
            string myLongString2 = $@"This is a very
              very
                  long string with {interp}";
            Console.WriteLine(myLongString2);
        }

        static void EscapeChars()
        {
            Console.WriteLine("=> Escape characters:\a");
            string strWithTabs = "Model\tColor\tSpeed\tPet Name\a ";
            Console.WriteLine(strWithTabs);
            Console.WriteLine("Everyone loves \"Hello World\"\a ");
            Console.WriteLine("C:\\MyApp\\bin\\Debug\a ");
            // Adds a total of 4 blank lines (then beep again!).
            Console.WriteLine("All finished.\n\n\n\a ");
            Console.WriteLine();
        }

        static void BasicStringFunctionality()
        {
            Console.WriteLine("=> Basic String functionality:");
            string firstName = "Freddy";
            Console.WriteLine("Value of firstName: {0}", firstName);
            Console.WriteLine("firstName has {0} characters.", firstName.Length);
            Console.WriteLine("firstName in uppercase: {0}", firstName.ToUpper());
            Console.WriteLine("firstName in lowercase: {0}", firstName.ToLower());
            Console.WriteLine("firstName contains the letter y?: {0}", firstName.Contains("y"));
            Console.WriteLine("firstName after replace: {0}", firstName.Replace("dy", ""));
            Console.WriteLine();
        }

        static void StringConcatenation()
        {
            Console.WriteLine("=> String concatenation:");
            string s1 = "Programming the ";
            string s2 = "PsychoDrill (PTP)";
            string s3 = s1 + s2; // aka String.Concat(s1, s2);
            Console.WriteLine(s3);
            Console.WriteLine();
        }
    }
}
