namespace Simula_s_Soup {
    internal class Program {
        static void Main() {
            var typeMapping = new Dictionary<string, Food.Type> {
                ["soup"] = Food.Type.Soup,
                ["gumbo"] = Food.Type.Gumbo,
                ["stew"] = Food.Type.Stew
            };
            var ingredientMapping = new Dictionary<string, Food.MainIngredient> {
                ["mushrooms"] = Food.MainIngredient.Mushrooms,
                ["potatoes"] = Food.MainIngredient.Potatoes,
                ["carrots"] = Food.MainIngredient.Carrots,
                ["chicken"] = Food.MainIngredient.Chicken,
            };
            var seasoningMapping = new Dictionary<string, Food.Seasoning> {
                ["salty"] = Food.Seasoning.Salty,
                ["spicy"] = Food.Seasoning.Spicy,
                ["sweet"] = Food.Seasoning.Sweet,
            };

            Food.Type myType = MakeChoice("Types of food: Soup, Stew, Gumbo", typeMapping);
            Food.MainIngredient myIngredient = MakeChoice("Main ingredients: Mushrooms, Chicken, Carrots, Potatoes", ingredientMapping);
            Food.Seasoning mySeasoning = MakeChoice("Food seasoning: Spicy, Salty, Sweet", seasoningMapping);

            Food myFood = new(myType, myIngredient, mySeasoning);
            Console.WriteLine("Thanks for you order: " + myFood.ToString());
        }

        static T MakeChoice<T>(string prompt, Dictionary<string, T> mapping) {
            while (true) {
                Console.Write($"{prompt}\nEnter your choice: ");

                string? choice = Console.ReadLine()?.ToLower();

                if (string.IsNullOrEmpty(choice)) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please, enter your choice.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if (mapping.TryGetValue(choice, out T? result)) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Good choice.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return result;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please, enter a valid choice.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
    class Food {
        private readonly Type type;
        private readonly MainIngredient mainIngredient;
        private readonly Seasoning seasoning;

        public enum Type {
            Soup, Stew, Gumbo
        }
        public enum MainIngredient {
            Mushrooms, Chicken, Carrots, Potatoes
        }
        public enum Seasoning {
            Spicy, Salty, Sweet
        }

        public Food(Type type, MainIngredient mainIngredient, Seasoning seasoning) { 
            this.type = type;
            this.mainIngredient = mainIngredient;
            this.seasoning = seasoning;
        }

        public override string ToString() {
            return $"{seasoning} {mainIngredient} {type}";
        }
    }
}