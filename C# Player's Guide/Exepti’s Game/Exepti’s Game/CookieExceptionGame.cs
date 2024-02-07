using Exepti_s_Game.Extensions;

namespace Exepti_s_Game {
    class CookieExceptionGame {
        private readonly Player player1;
        private readonly Player player2;

        private readonly int numberOfCookies;
        private readonly int oatmealRaisinCookieI;

        private readonly List<int> selectedNumbers = new();

        public CookieExceptionGame(Player player1, Player player2, int numberOfCookies = 10) { 
            this.player1 = player1;
            this.player2 = player2;

            this.numberOfCookies = numberOfCookies;
            Random random = new();
            oatmealRaisinCookieI = random.Next(numberOfCookies);

            StartGame();
        }

        private void StartGame() {
            ConsoleExtensions.WriteLineColor("Game has started!", ConsoleColor.Yellow);

            while (true) {
                try {
                    RunGameLoop();
                } catch (CookieException ex) {
                    Console.WriteLine("------------------------------");
                    ConsoleExtensions.WriteLineColor($"{ex.PlayerThatInvoked.Name} has eaten the Oatmeal Raisin Cookie!", ConsoleColor.Red);

                    if (ex.PlayerThatInvoked == player1) ConsoleExtensions.WriteLineColor($"{player2.Name} has won", ConsoleColor.Green);
                    else ConsoleExtensions.WriteLineColor($"{player1.Name} has won", ConsoleColor.Green);

                    break;
                }
            }
        }

        private void RunGameLoop() {
            Console.WriteLine("------------------------------");

            PlayerMove(player1);
            PlayerMove(player2);

            //fncs
            void PlayerMove(Player currentPlayer) {
                int number = GetCookieNumberFromUser($"{currentPlayer.Name}, pick your cookie number: ");
                selectedNumbers.Add(number);

                if (number == oatmealRaisinCookieI) throw new CookieException(currentPlayer, "Player took an Oatmeal Raisin Cookie");
                else ConsoleExtensions.WriteLineColor("Mmmm, this cookie was so delicious!", ConsoleColor.Green);
            }
        }

        private int GetCookieNumberFromUser(string prompt) {
            Console.Write(prompt);
            string? response = Console.ReadLine();

            int number = 0;
            while (number == 0) {
                if (!int.TryParse(response, out int intermNumber)) ConsoleExtensions.WriteLineColor("Error! Number is expected!", ConsoleColor.Red);
                else if (intermNumber < 0 || intermNumber > numberOfCookies - 1)
                    ConsoleExtensions.WriteLineColor($"Number between [0;{numberOfCookies - 1}] is expected!", ConsoleColor.Red);
                else if (selectedNumbers.Contains(intermNumber)) ConsoleExtensions.WriteLineColor("Number has been chosen already!", ConsoleColor.Red);
                else {
                    number = intermNumber;
                    break;
                }

                Console.Write(prompt);
                response = Console.ReadLine();
            }

            return number;
        }
    }
}