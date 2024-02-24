namespace Extensions
{
    public static class ConsoleExtensions
    {
        public static void WriteLineColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static int GetInt(string prompt, int min = int.MinValue, int max = int.MaxValue) {
            string errorPrompt = $"Error! Number in [{min}, {max}] range is expected!";

            while (true) {
                Console.Write(prompt);

                string? response = Console.ReadLine();

                try {
                    if (string.IsNullOrEmpty(response)) {
                        WriteLineColor(errorPrompt, ConsoleColor.Red);
                        continue;
                    }
                    int number = int.Parse(response);


                    if (number < min || number > max) WriteLineColor(errorPrompt, ConsoleColor.Red);
                    else return number;
                } catch (FormatException) {
                    WriteLineColor(errorPrompt, ConsoleColor.Red);
                } catch (OverflowException) {
                    WriteLineColor(errorPrompt, ConsoleColor.Red);
                }
            }
        }
        public static string GetAllowedString(string prompt, params string[] allowed) {
            for (int i = 0; i < allowed.Length; i++) allowed[i] = allowed[i].ToLower();


            while (true) {
                Console.Write(prompt);
                string? response = Console.ReadLine()?.ToLower();

                if (string.IsNullOrEmpty(response) || !allowed.Contains(response)) {
                    WriteLineColor($"Error, ({string.Join('/', allowed)}) is expected!", ConsoleColor.Red);
                    continue;
                }

                return response;
            }        
        }
        public static bool AskForConfirmation(string? prompt = null) {
            if (prompt != null) Console.WriteLine(prompt);

            string response = GetAllowedString("Y/N: ", "Y", "N");
            return response == "y";
        } 
    }
}
