namespace Repairing_the_Clocktower {
    internal class Program {
        static void Main(string[] args) {
            while (true) {
                int number = GetNumber();
                Console.WriteLine(number % 2 == 0 ? "Tick" : "Tock");
                Console.WriteLine();
            }
        }

        static int GetNumber() {
            while (true) {
                Console.Write("Enter the number: ");
                if (int.TryParse(Console.ReadLine(), out int number)) return number;
                else Console.WriteLine("Error! Number expected");
            }
        }
    }
}