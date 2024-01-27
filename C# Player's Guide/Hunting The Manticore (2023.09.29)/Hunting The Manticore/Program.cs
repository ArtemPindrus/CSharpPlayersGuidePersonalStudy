namespace Hunting_the_Manticore {
    internal class Program {
        static void Main() {
            int cityHP = 15;
            int manticoreHP = 10;

            Console.Write("Player 1, how far away from the city do you want to station the Manticore?: ");
            int distanceManticore = GetNumber();
            Console.Clear();

            int estimatedDamage;
            int quessedRange;
            int turn = 1;
            while (true) {
                estimatedDamage = CalculateDamage(turn);
                Console.Write(@$"-----------------------------------------------------------
STATUS: Turn: {turn} City: {cityHP}/15 Manticore: {manticoreHP}/10
The cannon is expected to deal {estimatedDamage} damage this round.
Enter desired cannon range: ");
                quessedRange = GetNumber();

                EvaluateDistanceAndDamage();

                if (manticoreHP >= 0) cityHP--;

                if (EvaluateVictory()) break;

                turn++;
            }

            void EvaluateDistanceAndDamage() {
                if (quessedRange > distanceManticore) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That round OVERSHOT the target.");
                    Console.ForegroundColor = ConsoleColor.White;
                } else if (quessedRange < distanceManticore) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That round FELL SHORT the target.");
                    Console.ForegroundColor = ConsoleColor.White;
                } else {
                    manticoreHP -= estimatedDamage;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("That round was a DIRECT HIT!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            bool EvaluateVictory() {
                bool victoryAchived = false;
                if (cityHP <= 0) {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"-----------------------------------------------------------
The city of Consolas has been destroyed! The hope is gone.
-----------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    victoryAchived = true;
                }
                if (manticoreHP <= 0) {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(@"-----------------------------------------------------------
The Manticore has been destroyed! The city of Consolas has been saved!
-----------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    victoryAchived = true;
                }
                return victoryAchived;
            }
        }

        static int CalculateDamage(int turn) {
            bool multipleOf3 = turn % 3 == 0;
            bool multipleOf5 = turn % 5 == 0;
            if (multipleOf5 && multipleOf3) return 10;
            else if (multipleOf5 || multipleOf3) return 3;
            else return 1;
        }

        static int GetNumber() {
            while (true) {
                if (!int.TryParse(Console.ReadLine(), out int number)) {
                    Console.Write("Error, number is expected: ");
                    continue;
                }
                if (number < 0 || number > 100) Console.Write("Error, number must be in 0 to 100 range: ");
                else return number;
            }
        }
    }

    public class Game {
        private readonly Manticore manticore;
        private readonly Entity city;

        public Game(int cityHealth, int manticoreHealth) {
            Random random = new();

            manticore = new(manticoreHealth, random.Next(101));
            city = new(cityHealth);
        }
    }

    public class Entity {
        public int Health { get; private set; }

        public Entity(int initialHealth) {
            Health = initialHealth;
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