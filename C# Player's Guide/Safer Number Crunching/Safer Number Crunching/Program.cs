namespace Safer_Number_Crunching {
    internal class Program {
        static void Main() {
            int number = GetTypeFromUser<int>("Enter an integer: ", "Error! An int is expected");
            bool boolean = GetTypeFromUser<bool>("Enter a boolean: ", "Error! A boolean is expected");
            double doub = GetTypeFromUser<double>("Enter a double: ", "Error! A double is expected");
        }

        private static T GetTypeFromUser<T>(string prompt, string errorText) {
            Console.Write(prompt);
            string? response = Console.ReadLine();

            T? type = default;
            bool valid = false;

            while (!valid) {
                try {
                    type = (T)Convert.ChangeType(response, typeof(T))!;
                    if (type != null) valid = true;
                } catch {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errorText);
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(prompt);
                    response = Console.ReadLine();
                }
            }

            return type!;
        }
    }
}