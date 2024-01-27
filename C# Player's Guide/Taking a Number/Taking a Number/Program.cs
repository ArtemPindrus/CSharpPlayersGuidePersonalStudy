namespace Taking_a_Number {
    internal class Program {
        static void Main() {
            string text = "What's your favourite number?";
            //int response = AskForNumber(text);
            int response = AskForNumberInRange(text, 0, 10);
        }

        static int AskForNumber(string text) { 
            Console.Write(text);
            while (true) {
                if (int.TryParse(Console.ReadLine(), out int number)) return number;
                else Console.Write("Erroe, number is expected: ");
            }
        }

        static int AskForNumberInRange(string text, int min, int max) { 
            Console.Write(text+$"\nEnter a number from {min} to {max}: ");
            while (true) {
                if (!int.TryParse(Console.ReadLine(), out int number)) {
                    Console.Write("Erroe, number is expected: ");
                    continue;
                }

                if (number < min || number > max) Console.Write("Error, number is out of range. Try again: ");
                else return number;
            }
        }
    }
}