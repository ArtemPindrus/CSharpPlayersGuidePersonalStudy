namespace PlayersGuide {
    public class Program {
        static void Main() {
            string? name1 = GetName(1);
            string? name2 = GetName(2);
            if (name1 == name2) name2 += "2";

            Console.Clear();
            RockPaperScissorsGame game = new(new(name1), new(name2));
            game.PlayRound();
        }

        private static string GetName(int number) {
            Console.Write($"Player {number}, enter your name: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name)) name = "Anonymous";

            return name;
        }
    }
}