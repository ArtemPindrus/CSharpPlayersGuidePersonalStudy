namespace The_Long_Game {
    internal class Program {
        static void Main() {
            string? name = null;

            while (string.IsNullOrEmpty(name)) {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();
            }

            Console.Clear();

            TheLongGame game = new(name);
            game.StartGame();
        }
    }
}