namespace Buying_Inventory {
    internal class Program {
        static void Main() {
            while (true) {
                Console.WriteLine(@"==========
The following items are available:
1 – Rope
2 – Torches
3 – Climbing Equipment
4 – Clean Water
5 – Machete
6 – Canoe
7 – Food Supplies");

                Console.Write("What number do you want to see the price of?: ");
                int choice = GetNumber();

                double price = choice switch {
                    1 => 10,
                    2 => 15,
                    3 => 25,
                    4 => 1,
                    5 => 20,
                    6 => 200,
                    7 => 1,
                    _ => 0
                };
                if (price == 0) {
                    Console.WriteLine("Wrong input\n");
                    continue;
                }

                string name = GetName();
                if (name == "Artem") price /= 2;

                Console.WriteLine($"The price is: {price}");
                Console.WriteLine();
            }
        }

        static string GetName() {
            string? name = null;
            while (string.IsNullOrEmpty(name)) {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();
            }
            return name;
        }

        static int GetNumber() {
            while (true) {
                if (int.TryParse(Console.ReadLine(), out int number)) return number;
                else Console.Write("Error! Number is expected: ");
            }
        }
    }
}