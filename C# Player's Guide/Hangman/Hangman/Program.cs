namespace PlayersGuide {
    internal class Program {
        static void Main() {
            HangmanGame game = new(@"C:\Users\Артем\Downloads\Words.txt", 1000);
            game.StartGame();
            game.StartGame();
        }
    }

    class HangmanGame {
        private readonly List<string> words;
        private readonly int maxWrongGuesses;

        public HangmanGame(string pathToFileWithWords, int maxWrongGuesses = 5) {
            words = new(File.ReadAllLines(pathToFileWithWords));
            this.maxWrongGuesses = maxWrongGuesses;
        }

        public void StartGame() {
            int wrongGuesses = 0;
            string randomWord = PickUpRandomWord().ToLower();

            List<char> charactersToFind = new(randomWord.ToLower().Distinct().ToList());
            List<char> foundCharacters = new();
            List<char> incorrect = new();

            while (true) {
                if (wrongGuesses >= maxWrongGuesses) {
                    Lose(); 
                    break;
                }

                int remaining = charactersToFind.Count;
                
                Console.Write($"Word: {GetWordCompletion(randomWord, foundCharacters)}");
                if (remaining == 0) {
                    Win();
                    break;
                }
                Console.Write($" | Remaining: {remaining} | ");

                Console.Write("Incorrect: ");
                foreach (char ch in incorrect) Console.Write(ch+" ");
                Console.Write("| Guess: ");

                while (true) {
                    char choice = Console.ReadKey().KeyChar;

                    if (incorrect.Contains(choice) || foundCharacters.Contains(choice) || !char.IsLetter(choice)) {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); //ask again
                    } else if (!charactersToFind.Contains(choice)) {
                        incorrect.Add(choice);
                        wrongGuesses++;
                        break;
                    } else if (charactersToFind.Contains(choice)) { 
                        foundCharacters.Add(choice);
                        charactersToFind.Remove(choice);
                        break;
                    }
                }
                Console.WriteLine();
            }
        }

        private static void Lose() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("YOU HAVE LOST!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Win() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nOMG, you have won, congrats!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static string GetWordCompletion(string word, List<char> foundCharacters) { 
            char[] wordCharacters = word.ToCharArray();

            for (int i = 0; i < wordCharacters.Length; i++) {
                if (foundCharacters.Contains(wordCharacters[i])) continue;
                else wordCharacters[i] = '_';
            }
            return new string(wordCharacters);
        }

        private string PickUpRandomWord() { 
            Random random = new();

            int randomIndex = random.Next(words.Count);
            return words[randomIndex];
        }
    }
}