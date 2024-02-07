namespace Exepti_s_Game {
    internal class Program {
        static void Main() {
            string player1name = GetStringFromUser("Player 1, enter your name: ");
            string player2name = GetStringFromUser("Player 2, enter your name: ");
            if (player2name == player1name) player2name += "2";

            Console.Clear();

            Player player1 = new(player1name);
            Player player2 = new(player2name);
            _ = new CookieExceptionGame(player1, player2);
        }

        private static string GetStringFromUser(string prompt) {
            string? response = string.Empty;

            while (string.IsNullOrEmpty(response)) { 
                Console.Write(prompt);
                response = Console.ReadLine();
            }

            return response;
        }
    }
}