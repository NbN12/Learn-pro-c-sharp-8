using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyEBookReader
{
    class Program
    {
        private static string _theEbook = "";

        static void Main(string[] args)
        {
            GetBook();
            Console.WriteLine("Downloading book...");
            Console.ReadLine();
        }

        static void GetBook()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) =>
            {
                _theEbook = eArgs.Result;
                Console.WriteLine("Download complete.");
                GetStats();
            };

            // The Project Gutenberg EBook of A Tale of Two Cities, by Charles Dickens
            // You might have to run it twice if you’ve never visited the site before, since the first
            // time you visit there is a message box that pops up, and breaks this code.
            wc.DownloadStringAsync(new Uri("https://www.gutenberg.org/files/98/98-0.txt"));
        }

        static void GetStats()
        {
            // Get the words from the ebook.
            var words = _theEbook.Split(new char[]
            {
                 ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/'
            }, StringSplitOptions.RemoveEmptyEntries);

            // Now, find the ten most common words.
            // var tenMostCommon = FindTenMostCommon(words);
            // Get the longest word.
            // var longestWord = FindLongestWord(words);

            // Parallel version
            string[] tenMostCommon = null;
            string longestWord = string.Empty;

            Parallel.Invoke(() =>
            {
                // Now, find the ten most common words.
                tenMostCommon = FindTenMostCommon(words);
            },
            () =>
            {
                // Get the longest word.
                longestWord = FindLongestWord(words);
            });



            // Now that all tasks are complete, build a string to show all stats.
            StringBuilder bookStats = new StringBuilder("Ten Most Common Words are:\n");
            foreach (var s in tenMostCommon)
            {
                bookStats.AppendLine(s);
            }

            bookStats.AppendFormat($"Longest word is: {longestWord}");
            bookStats.AppendLine();
            Console.WriteLine("Book info:");
            Console.Write(bookStats.ToString());
        }

        private static string FindLongestWord(string[] words)
        {
            return words.OrderByDescending(word => word.Length).FirstOrDefault();
        }

        private static string[] FindTenMostCommon(string[] words)
        {
            var frequencyOrder = words
                                      .Where(word => word.Length > 6)
                                      .GroupBy(word => word)
                                      .OrderByDescending(g => g.Count())
                                      .Take(10).Select(g => g.Key).ToArray();
            return frequencyOrder;
        }
    }
}
