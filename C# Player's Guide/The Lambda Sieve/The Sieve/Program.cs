namespace The_Lambda_Sieve {
    internal class Program {
        static void Main() {
            Console.WriteLine(@"Available number filters:
1. Even numbers
2. Positive numbers
3. Multiples of 10
");

            int choice = GetIntFromUser("Enter your choice: ", 1, 3);
            Console.Clear();

            LambdaSieve sieve = choice switch {
                1 => new(x => x % 2 == 0),
                2 => new(x => x >= 0),
                3 => new(x => x % 10 == 0),
                _ => throw new ArgumentException()
            };

            while (true) {
                int number = GetIntFromUser("Enter a number to check in a sieve: ");
                Console.WriteLine(sieve.IsGood(number));
            }
        }

        private static int GetIntFromUser(string prompt, int min = int.MinValue, int max = int.MaxValue) {
            Console.Write(prompt);
            string? response = Console.ReadLine();

            int number = 0;
            while (number == 0) {
                if (!int.TryParse(response, out int intermNumb)) Console.WriteLine("Number is expected!");
                else if (intermNumb < min || intermNumb > max) Console.WriteLine($"Number in the [{min};{max}] range is expected!");
                else {
                    number = intermNumb;
                    break;
                }

                Console.Write(prompt);
                response = Console.ReadLine();
            }

            return number;
        }
    }
}