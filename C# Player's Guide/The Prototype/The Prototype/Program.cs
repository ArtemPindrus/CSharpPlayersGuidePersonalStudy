namespace The_Prototype {
    internal class Program {
        static void Main() {
            int guessNumber;

            Console.Write("Pilot, enter the number between 0 and 100!: ");
            guessNumber = GetNumber();
            Console.Clear();

            int hunterGuess;
            do {
                Console.Write("Hunter, guess a number: ");
                hunterGuess = GetNumber();
                if (hunterGuess > guessNumber) Console.WriteLine("Number is too high, try again");
                if (hunterGuess < guessNumber) Console.WriteLine("Number is too low, try again");
                if (hunterGuess == guessNumber) Console.WriteLine("You guessed the number correctly!");
            } while (hunterGuess != guessNumber);
        }

        static int GetNumber() {
            while (true) {
                if (!int.TryParse(Console.ReadLine(), out int number)) {
                    Console.Write("Error, number is expected: ");
                    continue;
                }
                if (number < 0 || number > 100) Console.Write("Error, the number is outside of the range: ");
                else { 
                    return number;
                }
            }
        }
    }
}