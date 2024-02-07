namespace Exepti_s_Game.Extensions {
    internal static class ConsoleExtensions {
        public static void WriteLineColor(string text, ConsoleColor color) { 
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
