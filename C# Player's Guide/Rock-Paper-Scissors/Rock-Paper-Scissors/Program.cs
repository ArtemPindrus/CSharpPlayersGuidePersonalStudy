namespace PlayersGuide {
    internal class Program {
        static void Main() {
            Player player1 = InitializeThePlayer(1);
            Player player2 = InitializeThePlayer(2);

            Console.Clear();
            GameRound firstGame = new(new Player[] { player1, player2 });

            Console.WriteLine(@"
Start?:
1. Yes
2. No");
            int choice = GetIntValueFromUserInRange(1,2, "Error, please provide the available option by number: ");
            if (choice == 1) {
                Console.Clear();

                firstGame.Start();
                Player? winner = firstGame.EvaluateWinner();

                if (winner != null) {
                    Console.WriteLine($"Congratulations {winner.Name}! You have won!");
                }
            }
        }

        private static Player InitializeThePlayer(int number) {
            Console.Write($"Player {number}, enter your name: ");
            string name = Console.ReadLine()!;

            if (string.IsNullOrEmpty(name)) name = "Anonymous";
            return new Player(name);
        }

        static private int GetIntValueFromUserInRange(int min, int max, string errorPrompt) {
            int value;

            while (!int.TryParse(Console.ReadLine(), out value) || (value < min || value > max)) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(errorPrompt);
                Console.ForegroundColor = ConsoleColor.White;
            }

            return value;
        }
    }

    internal class GameRound {
        public bool RoundIsFinished { get; private set; }

        internal Player[] Players { get; private set; }
        private readonly Dictionary<Player, GameObjects> playersChoices = new(2);

        internal enum GameObjects { 
            Rock, Paper, Scissors
        }

        internal GameRound(Player[] newPlayers) {
            if (newPlayers == null) throw new ArgumentNullException(nameof(newPlayers));
            foreach (var player in newPlayers) { 
                if (newPlayers == null) throw new ArgumentNullException(nameof(newPlayers));
            }
            if (newPlayers.Length != 2) throw new ArgumentException("The game should contain two players!");

            Players = newPlayers;

            Console.WriteLine(@$"The game is initialized with the following players:
1. {Players[0].Name}
2. {Players[1].Name}");
        }

        internal void Start() {
            if (RoundIsFinished) throw new Exception("Cannot start the game round that has been finished!");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Let's begin!");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i<2; i++) {
                Console.WriteLine(@"Available choices:
1. Rock
2. Paper
3. Scissors");
                Console.Write($"{Players[i].Name}, please enter you choice by number: ");

                int choice = GetIntValueFromUserInRange(1, 3, "Error, please enter the available option: ");
                playersChoices.Add(Players[i], (GameObjects) choice-1);
                Console.Clear();
            }

            Console.WriteLine("Players choices:");
            foreach (var kvp in playersChoices) Console.WriteLine($"{kvp.Key.Name} - {kvp.Value}");
            RoundIsFinished = true;
        }

        internal Player? EvaluateWinner() {
            if (!RoundIsFinished) throw new Exception("Cannot evaluate the winner. Round isn't finished!");

            //loading text...
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Evaluating the winner");
            Thread.Sleep(1000);
            Console.Write('.');
            Thread.Sleep(1000);
            Console.Write('.');
            Thread.Sleep(1000);
            Console.WriteLine('.');
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.White;

            //divide
            Player[] players = new Player[playersChoices.Count];
            GameObjects[] choices = new GameObjects[playersChoices.Count];

            int index = 0;
            foreach (var kvp in playersChoices) { 
                players[index] = kvp.Key; 
                choices[index] = kvp.Value;
                index++;
            }

            if (choices[0] == GameObjects.Rock) {
                if (choices[1] == GameObjects.Scissors) return players[0];
                else if (choices[1] == GameObjects.Paper) return players[1];
                else if (choices[1] == GameObjects.Rock) return null;
            } else if (choices[0] == GameObjects.Scissors) {
                if (choices[1] == GameObjects.Paper) return players[0];
                else if (choices[1] == GameObjects.Rock) return players[1];
                else if (choices[1] == GameObjects.Scissors) return null;
            } else if (choices[0] == GameObjects.Paper) {
                if (choices[1] == GameObjects.Rock) return players[0];
                else if (choices[1] == GameObjects.Scissors) return players[1];
                else if (choices[1] == GameObjects.Paper) return null;
            }

            return null;
        }

        static private int GetIntValueFromUserInRange(int min, int max, string errorPrompt) {
            int value;

            while (!int.TryParse(Console.ReadLine(), out value) || (value < min || value > max)) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(errorPrompt);
                Console.ForegroundColor = ConsoleColor.White;
            }

            return value;
        }
    }

    internal class Player {
        internal string Name { get; private set; }

        internal Player(string name) {
            Name = name;
        }
    }
}