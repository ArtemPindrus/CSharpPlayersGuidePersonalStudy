using Extensions;

namespace TheUncodedOneBattle
{
    using Characters;
    using Players;
    using Items;

    internal class Program {
        static void Main() {
            Console.WriteLine(@"Choose the gamemode:
1. User vs Computer
2. Computer vs Computer
3. User vs User");
            int choice = ConsoleExtensions.GetInt("Enter you choice: ", 1, 3);

            IPlayer[] players = choice switch {
                1 => new IPlayer[] { new User(), new Computer() },
                2 => new IPlayer[] { new Computer(), new Computer() },
                3 => new IPlayer[] { new User(), new User() },
                _ => throw new Exception("Gamemode isn't defined for given number!"),
            };

            string name = ConsoleExtensions.GetNotNullOrEmptyString("Enter your name, hero: ");

            Party heroes = new(
                new Character[] { new TrueProgrammer(name) },
                players[0],
                new IItem[] { new HealingPotion(), new HealingPotion() }
            );
            Party[] monsters = {
                new(
                    new Character[] { new Skeleton(), new Skeleton() }, 
                    players[1],
                    new IItem[] { new HealingPotion() }
                ),
                new(
                    new Character[] { new Skeleton(), new Skeleton() },
                    players[1],
                    new IItem[] { new HealingPotion() }
                ),
                new(
                    new Character[] { new TheUncodedOne() },
                    players[1],
                    new IItem[] { new HealingPotion(), new HealingPotion() }
                ),
            };

            Console.Clear();

            Game _ = new(heroes, monsters);
        }
    }
}