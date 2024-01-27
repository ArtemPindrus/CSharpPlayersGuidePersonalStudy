namespace PlayersGuide {
    internal class Program {
        static void Main() {
            while (true) {
                Console.Write("Enter a password to validate: ");
                string? password = Console.ReadLine();
                if (string.IsNullOrEmpty(password)) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Next time enter a password");
                    Console.ForegroundColor = ConsoleColor.White;
                } else {
                    if (PasswordValidator.ValidateThePassword(password)) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Password is valid!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.WriteLine();
            }
        }
    }

    public static class PasswordValidator {
        private static readonly int minLength = 6;
        private static readonly int maxLength = 13;

        public static bool ValidateThePassword(string password) {
            bool valid = true;

            if (!PasswordIsOfValidLength(password)) {
                OutputError($"Password is of invalid length! {password.Length} instead of {minLength}-{maxLength} range.");

                valid = false;
            }
            if (!ContainsUppercaseLetter(password.ToArray())) {
                OutputError("Password doesn't contain at least one uppercase letter!");

                valid = false;
            }
            if (!ContainsLowercaseLetter(password.ToArray())) {
                OutputError("Password doesn't contain at least one lowercase letter!");

                valid = false;
            }
            if (!ContainsNumber(password.ToArray())) {
                OutputError("Password doesn't contain at least one number");

                valid = false;
            }
            if (password.Contains('T')) {
                OutputError("Password musn't contain uppercase T");

                valid = false;
            }
            if (password.Contains('&')) {
                OutputError("Password musn't contain ampersand (&)");

                valid = false;
            }

            return valid;
        }

        private static bool PasswordIsOfValidLength(string password) {
            return password.Length >= minLength && password.Length <= maxLength;
        }

        private static bool ContainsUppercaseLetter(char[] password) {
            foreach (char ch in password) { 
                if (Char.IsUpper(ch)) return true;
            }
            return false;
        }
        private static bool ContainsLowercaseLetter(char[] password) {
            foreach (char ch in password) {
                if (Char.IsLower(ch)) return true;
            }
            return false;
        }
        private static bool ContainsNumber(char[] password) {
            foreach (char ch in password) {
                if (Char.IsDigit(ch)) return true;
            }
            return false;
        }

        private static void OutputError(string prompt) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(prompt);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}