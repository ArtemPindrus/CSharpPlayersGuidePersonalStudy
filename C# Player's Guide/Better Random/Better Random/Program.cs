using Better_Random.Extensions;

namespace Better_Random {
    internal class Program {
        static void Main() {
            string[] strings = new string[] { "a", "b", "bob", "car", "mesh" };

            Random random = new();

            Console.WriteLine("10 random doubles with max of 10:");
            for (int i = 0; i < 10; i++) Console.WriteLine(random.NextDouble(10));

            Console.WriteLine(@"
2 random strings from a set:");
            for (int i = 0; i < 2; i++) Console.WriteLine(random.NextString(strings));

            Console.WriteLine("10 coin flips (50/50)");
            for (int i = 0; i < 10; i++) Console.WriteLine(random.CoinFlip());

            Console.WriteLine("10 coin flips (80/20)");
            for (int i = 0; i < 10; i++) Console.WriteLine(random.CoinFlip(0.8f));

            Console.WriteLine("10 coin flips (100/0)");
            for (int i = 0; i < 10; i++) Console.WriteLine(random.CoinFlip(1));

            Console.WriteLine("10 coin flips (0/50)");
            for (int i = 0; i < 10; i++) Console.WriteLine(random.CoinFlip(0));
        }
    }
}