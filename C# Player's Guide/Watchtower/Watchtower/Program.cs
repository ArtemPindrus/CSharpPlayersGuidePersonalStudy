namespace Watchtower {
    internal class Program {
        static void Main() {
            while (true) {
                Console.Write("==========\nEnter the x value: ");
                int x = GetNumber();
                Console.Write("Enter the y value: ");
                int y = GetNumber();

                Console.Write("The enemy is to the ");
                if (y > 0) {
                    if (x < 0) Console.WriteLine("NorthWest");
                    if (x == 0) Console.WriteLine("North");
                    if (x > 0) Console.WriteLine("NorthEast");
                }
                if (y == 0) {
                    if (x < 0) Console.WriteLine("West");
                    if (x == 0) Console.WriteLine("Middel");
                    if (x > 0) Console.WriteLine("East");
                }
                if (y < 0) {
                    if (x < 0) Console.WriteLine("SouthWest");
                    if (x == 0) Console.WriteLine("South");
                    if (x > 0) Console.WriteLine("SouthEast");
                }
            }
        }
        static int GetNumber() {
            while (true) { 
                if (int.TryParse(Console.ReadLine(), out int number)) return number;
            }
        }
    }
}