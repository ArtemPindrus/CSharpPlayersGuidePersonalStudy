namespace Simula_s_Test {
    internal class Program {
        static void Main(string[] args) {
            State current = new State();

            while (true) {
                Console.Write($"Chest is {current.ToString().ToLower()}. What do you want to do? (lock, unlock, close, open): ");

                string choice = Console.ReadLine().ToLower();
                if (string.IsNullOrEmpty(choice)) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please, enter an action.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if (current == State.Locked && choice == "unlock") current = State.Closed;
                else if (current == State.Closed && choice == "open") current = State.Open;
                else if (current == State.Open && choice == "close") current = State.Closed;
                else if (current == State.Closed && choice == "lock") current = State.Locked;
                else { 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Impossible action");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    enum State : byte { 
        Locked, Open, Closed
    }
}