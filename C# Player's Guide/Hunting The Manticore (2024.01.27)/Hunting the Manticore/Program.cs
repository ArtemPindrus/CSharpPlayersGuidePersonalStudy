namespace Hunting_the_Manticore {
    internal class Program {
        static void Main() {
            int cityHealth = 15;
            int manticoreHealth = 10;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
            Game game = new(cityHealth, manticoreHealth);
#pragma warning restore IDE0059 // Unnecessary assignment of a value
        }

        public class Game {
            private enum GameLoopState { None, Lose, Win }

            private readonly Manticore manticore;
            private readonly Entity city;
            private int currentRound = 1;
            private int CurrentRoundDamage {
                get {
                    if (currentRound % 3 == 0 && currentRound % 5 == 0) return 10;
                    else if (currentRound % 3 == 0 || currentRound % 5 == 0) return 3;
                    else return 1;
                }
            }

            public Game(int cityHealth, int manticoreHealth) {
                Random random = new();

                manticore = new(manticoreHealth, random.Next(101));
                city = new(cityHealth);

                WriteLineColor("The game's started!", ConsoleColor.Green);

                GameLoopState gameLoopState;
                while (!RunGameRound(out gameLoopState)) ;

                if (gameLoopState == GameLoopState.Win)
                    WriteLineColor("The Manticore has been destroyed! The city of Consolas has been saved!", ConsoleColor.Green);
                else if (gameLoopState == GameLoopState.Lose)
                    WriteLineColor("The city of Consolas was destroyed under the ominous thread of the Manticore. The hope is lost...", ConsoleColor.Red);
            }

            /// <summary>
            /// Returns true if game is ended (win/lose)
            /// </summary>
            /// <returns></returns>
            private bool RunGameRound(out GameLoopState gameLoopState) {
                gameLoopState = GameLoopState.None;

                Console.WriteLine($@"-----------------------------------------------------------
STATUS: Round: {currentRound} City: {city.Health}/{city.MaxHealth} Manticore: {manticore.Health}/{manticore.MaxHealth}");

                if (!manticore.IsAlive) {
                    gameLoopState = GameLoopState.Win;
                    return true;
                } else if (!city.IsAlive) {
                    gameLoopState = GameLoopState.Lose;
                    return true;
                }

                Console.Write($@"The cannon is expected to deal {CurrentRoundDamage} damage this round.
Enter desired cannon range: ");
                string? response = Console.ReadLine();


                int cannonRange;
                try {
                    cannonRange = int.Parse(response!);
                    if (cannonRange < 0 || cannonRange > 100) {
                        WriteLineColor("Input must be non-negative integer in [0,100] range.", ConsoleColor.Red);
                        return false;
                    }
                } catch {
                    WriteLineColor("Input must be non-negative integer in [0,100] range.", ConsoleColor.Red);
                    return false;
                }

                if (cannonRange < manticore.DistanceFromTheCity) WriteLineColor("That round FELL SHORT of the target.", ConsoleColor.Red);
                else if (cannonRange > manticore.DistanceFromTheCity) WriteLineColor("That round OVERSHOT the target.", ConsoleColor.Red);
                else if (cannonRange == manticore.DistanceFromTheCity) {
                    WriteLineColor("That round was a DIRECT HIT!", ConsoleColor.Green);
                    manticore.Damage(CurrentRoundDamage);
                }

                if (manticore.IsAlive) city.Damage(1);

                currentRound++;

                return false;
            }


            private static void WriteLineColor(string text, ConsoleColor color) {
                Console.ForegroundColor = color;
                Console.WriteLine(text);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public class Entity {
            public int MaxHealth { get; private set; }
            public int Health { get; private set; }

            public bool IsAlive => Health != 0;

            public Entity(int maxHealth) {
                MaxHealth = maxHealth;
                Health = maxHealth;
            }

            public void Damage(int damage) {
                Health -= damage;
                if (Health < 0) Health = 0;
            }
        }

        public class Manticore : Entity {
            public int DistanceFromTheCity { get; private set; }

            public Manticore(int initialHealth, int distanceFromTheCity) : base(initialHealth) {
                DistanceFromTheCity = distanceFromTheCity;
            }
        }
    }
}