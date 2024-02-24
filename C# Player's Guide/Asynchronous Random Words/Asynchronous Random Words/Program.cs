using System.Text;
using Extensions;

namespace Asynchronous_Random_Words {
    internal class Program {
        static void Main() {
            Console.WriteLine("Enter the desired words: ");

            while (true) {
                string? word = Console.ReadLine();

                if (string.IsNullOrEmpty(word)) ConsoleExtensions.WriteLineColor("Error, no word was entered!", ConsoleColor.Red);
                else RandomlyRecreateAsync(word);
            }
        }

        private static async void RandomlyRecreateAsync(string word) {
            int initialCursorTop = Console.CursorTop-1;

            DateTime before = DateTime.Now;
            int tries = await Task.Run(() => RandomlyRecreate(word));

            ConsoleExtensions.WriteLineColor(@$"Tries to randomly generate {word}: {tries}
Time elapsed: {DateTime.Now - before}", ConsoleColor.Green);
        }

        private static int RandomlyRecreate(string word) {
            int tries = 0;

            word = word.ToLower();
            Random rn = new();
            StringBuilder result = new();

            while (true) {
                while (result.Length < word.Length) result.Append((char)('a' + rn.Next(26)));

                if (result.ToString() != word) {
                    result.Clear();
                    tries++;
                } else break;
            }

            return tries;
        }
    }
}