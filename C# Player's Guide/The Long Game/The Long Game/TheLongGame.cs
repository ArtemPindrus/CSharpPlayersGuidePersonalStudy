namespace The_Long_Game {
    internal class TheLongGame {
        private readonly string playerName;
        private int currentScore;

        public TheLongGame(string playerName) { 
            this.playerName = playerName;

            string file = $"{playerName}.txt";
            if (File.Exists(file)) {
                string content = File.ReadAllText(file);

                try {
                    currentScore = int.Parse(content);
                } catch {
                    ConsoleE.WriteLineColor($"{playerName} score file is corrupted. Current score is set to 0.", ConsoleColor.Red);
                }
            }
        }

        public void StartGame() {
            ConsoleE.WriteLineColor($"The game has started! {playerName} is gaming!", ConsoleColor.Green);
            Console.WriteLine($@"Enter keys to gain points. 
Press Enter to save the score.");

            while (!RunGameLoop());

            //fncs
            bool RunGameLoop() { //bool - whether game is finished
                Console.WriteLine($"Score: {currentScore}");

                if (Console.ReadKey(true).Key == ConsoleKey.Enter) {
                    SaveScore();
                    return true;
                } else {
                    currentScore++;
                    return false;
                }
            }
        }

        private void SaveScore() {
            File.WriteAllText($"{playerName}.txt", $"{currentScore}");

            ConsoleE.WriteLineColor("Score has been saved!", ConsoleColor.Green);
        }
    }
}