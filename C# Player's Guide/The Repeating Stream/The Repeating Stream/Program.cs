using Extensions;

namespace The_Repeating_Stream {
    internal class Program {
        static void Main() {
            RecentNumbers recents = new();
            Thread fountain = new(AssignRandomValues);
            fountain.Start(recents);

            while (true) { 
                Console.ReadKey(true);

                if (recents.NumbersAreEqual) ConsoleExtensions.WriteLineColor("Report is correct!", ConsoleColor.Green);
                else ConsoleExtensions.WriteLineColor("Report is incorrect", ConsoleColor.Red);
            }
        }

        private static void AssignRandomValues(object? recentNumbers) {
            if (recentNumbers == null) throw new ArgumentNullException(nameof(recentNumbers));
            else if (recentNumbers is not RecentNumbers) throw new ArgumentException("recentNumbers must be of RecentNumbers type!");

            RecentNumbers recents = (RecentNumbers)recentNumbers;
            Random random = new();

            while (true) {
                int number = random.Next(10);
                recents.AddNumber(number);
                Console.WriteLine(number);

                Thread.Sleep(1000);
            }
        }
    }
}