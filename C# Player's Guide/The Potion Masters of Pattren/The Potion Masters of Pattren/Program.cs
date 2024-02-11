using Extensions;

namespace The_Potion_Masters_of_Pattren {
    internal class Program {
        static void Main() {
            Potion potion = new();

            while (true) {
                Console.WriteLine(@$"Currently you have a {potion.Type} Potion.
Do you want to add an ingridient?");
                if (!ConsoleExtensions.AskForConfirmation()) break;
                Console.Clear();

                Console.WriteLine(@$"Currently you have a {potion.Type} Potion.
Available ingridients:
1. Stardust
2. SnakeVenom
3. DragonBreath
4. ShadowGlass
5. EyeshineGem");
                int choice = ConsoleExtensions.GetInt("Enter you choice: ", 1, 5);
                Ingridient ingridient = (Ingridient) choice-1;
                Console.Clear();


                Console.WriteLine($"You've chosen {ingridient}. Continue?");
                if (!ConsoleExtensions.AskForConfirmation()) {
                    Console.Clear();
                    continue;
                }
                Console.Clear();


                potion.AddIngridient(ingridient);
                if (potion.Type == PotionType.Ruined) {
                    ConsoleExtensions.WriteLineColor("You've ruined potion! Start over with water.", ConsoleColor.Red);
                    potion = new();
                }
            }

            Console.Clear();
            Console.WriteLine($"Your final potion: {potion.Type} Potion");
        }
    }
}