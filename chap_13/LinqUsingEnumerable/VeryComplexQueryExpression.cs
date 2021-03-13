using System;

namespace LinqUsingEnumerable
{
    public class VeryComplexQueryExpression
    {
        public static void QueryStringsWithRawDelegates()
        {
            Console.WriteLine("***** Using Raw Delegates *****");
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // Build the necessary Func<> delegates.
            Func<string, bool> searchFilter = new Func<string, bool>(Filter);
            Func<string, string> itemToProcess = new Func<string, string>(ProcessItem);
        }

        public static string ProcessItem(string game)
        {
            return game;
        }

        public static bool Filter(string game)
        {
            return game.Contains(" ");
        }
    }
}