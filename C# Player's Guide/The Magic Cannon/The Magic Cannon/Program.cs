namespace The_Magic_Cannon {
    internal class Program {
        static void Main(string[] args) {
            for (int i = 1; i <= 100; i++) {
                bool dividedByThree = i % 3 == 0;
                bool dividedByFive = i % 5 == 0;

                if (dividedByFive && dividedByThree) {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{i}. Electrifire");
                } else if (dividedByThree) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{i}. Fire");
                } else if (dividedByFive) {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{i}. Electrical");
                } else {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{i}. Normal");
                }
            }
            Console.ReadKey();
        }
    }
}