namespace Helpers {
    public class ColoredConsole {
        public static string Prompt(string question) {
            string? response;

            while (true) {
                Console.Write(question);
                Console.ForegroundColor = ConsoleColor.Cyan;
                response = Console.ReadLine();
                if (string.IsNullOrEmpty(response)) WriteLine("Error, response is expected!", ConsoleColor.Red);
                else break;
            }

            Console.ForegroundColor = ConsoleColor.White;

            return response;
        }

        public static void WriteLine(string text, ConsoleColor color) {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Write(string text, ConsoleColor color) {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}