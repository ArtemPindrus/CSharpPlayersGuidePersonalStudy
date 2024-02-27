using Extensions;

namespace TheUncodedOneBattle {
    using Characters;
    using Characters.Items;
    using Players;

    internal class Program {
        static void Main() {
            Console.WriteLine(@"Choose the gamemode:
1. User vs Computer
2. Computer vs Computer
3. User vs User");
            int choice = ConsoleExtensions.GetInt("Enter you choice: ", 1, 3);

            Player[] players = choice switch {
                1 => new Player[] { new User(), new Computer() },
                2 => new Player[] { new Computer(), new Computer() },
                3 => new Player[] { new User(), new User() },
                _ => throw new Exception("Gamemode isn't defined for given number!"),
            };

            string name = ConsoleExtensions.GetNotNullOrEmptyString("Enter your name, hero: ");

            Party heroes = new(
                new Character[] { new TrueProgrammer(name), new Skeleton() },
                new Item[] { new HealingPotion(), new HealingPotion(), new HealingPotion() }
            );
            Party[] monsters = {
                new(
                    new Character[] { new Skeleton() }, 
                    new Item[] { new HealingPotion() }
                ),
                new(
                    new Character[] { new Skeleton(), new Skeleton() },
                    new Item[] { new HealingPotion() }
                ),
                new(
                    new Character[] { new TheUncodedOne() },
                    new Item[] { new HealingPotion() }
                ),
            };

            Console.Clear();

            Game _ = new(heroes, monsters, players[0], players[1]);
        }
    }
}