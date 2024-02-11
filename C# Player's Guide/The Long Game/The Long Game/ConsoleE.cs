namespace The_Long_Game {
    internal static class ConsoleE {
        internal static void WriteLineColor(string text, ConsoleColor color) { 
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
