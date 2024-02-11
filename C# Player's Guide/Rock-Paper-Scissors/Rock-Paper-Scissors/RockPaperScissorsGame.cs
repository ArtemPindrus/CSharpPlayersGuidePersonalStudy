using Extensions;

namespace PlayersGuide {
    public enum GameObject {
        Rock, Paper, Scissors
    }

    public class RockPaperScissorsGame {
        private readonly Player player1;
        private readonly Player player2;


        public RockPaperScissorsGame(Player player1, Player player2) {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void PlayRound() {
            GameObject choice1 = GetChoice(player1);
            GameObject choice2 = GetChoice(player2);

            Console.WriteLine(@$"The choices are:
{player1.Name}: {choice1}
{player2.Name}: {choice2}");

            Player? winner = EvaluateWinner(choice1, choice2);
            if (winner == null) ConsoleExtensions.WriteLineColor("Draw!", ConsoleColor.Yellow);
            else ConsoleExtensions.WriteLineColor($"The winner is {winner.Name}!", ConsoleColor.Green);
        }

        private static GameObject GetChoice(Player player) {
            Console.WriteLine(@"Available choices:
1. Rock
2. Paper
3. Scissors");

            int choice = ConsoleExtensions.GetInt($"{player.Name} make your choice: ", 1, 3);
            Console.Clear();

            return (GameObject) choice-1;
        }

        private Player? EvaluateWinner(GameObject choice1, GameObject choice2) {
            return (choice1, choice2) switch {
                (GameObject.Rock, GameObject.Scissors) => player1,
                (GameObject.Scissors, GameObject.Paper) => player1,
                (GameObject.Paper, GameObject.Rock) => player1,
                (GameObject first, GameObject second) when first == second => null,
                _ => player2
            };
        }
    }
}