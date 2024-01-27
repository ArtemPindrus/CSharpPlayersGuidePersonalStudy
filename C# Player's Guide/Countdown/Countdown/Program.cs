namespace Countdown {
    internal class Program {
        static void Main(string[] args) {
            //for (int x = 10; x > 0; x--)
            //    Console.WriteLine(x);
            Countdown(10,11);
        }
        /// <summary>
        /// Outputs numbers into console from startingNumber up to endNumber both including
        /// </summary>
        /// <param name="startingNumber"></param>
        /// <param name="endNumber"></param>
        /// <exception cref="ArgumentException"></exception>
        static void Countdown(int startingNumber, int endNumber) {
            //edgeCases
            if (startingNumber < endNumber) throw new ArgumentException("Starting number cannot be less than end number");

            //the method itself
            Console.WriteLine(startingNumber);
            if (startingNumber > endNumber) Countdown(--startingNumber, endNumber);
        }
    }
}