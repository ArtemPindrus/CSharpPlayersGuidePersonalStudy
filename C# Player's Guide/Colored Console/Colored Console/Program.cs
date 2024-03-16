namespace Challenge {
    using Helpers;
    internal class Program {
        static void Main() {
            string name = ColoredConsole.Prompt("What is your name? ");
            ColoredConsole.WriteLine("Hello " + name, ConsoleColor.Green);
        }
    }
}