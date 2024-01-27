using My;

namespace Vin_Fletcher_s_Arrows {
    internal class Program {
        readonly static Dictionary<string, Arrow.ArrowheadType> arrowHeadMapping = new() {
            ["steel"] = Arrow.ArrowheadType.Steel,
            ["wood"] = Arrow.ArrowheadType.Wood,
            ["obsidian"] = Arrow.ArrowheadType.Obsidian
        };

        readonly static Dictionary<string, Arrow.FletchingType> fletchingMapping = new() {
            ["plastic"] = Arrow.FletchingType.Plastic,
            ["turkey feathers"] = Arrow.FletchingType.TurkeyFeathers,
            ["goose feathers"] = Arrow.FletchingType.TurkeyFeathers
        };

        static void Main() {
            Console.WriteLine("==========");
            ConsolePlus.WriteLineInColor(ConsoleColor.Yellow, "You're choosing what arrow to buy...");

            Arrow.ArrowheadType myArrowHead = GetUserChoiceEnum("Available arrowhead types: Steel, Wood, Obsidian.", arrowHeadMapping);
            Arrow.FletchingType myFletching = GetUserChoiceEnum("Available fletching types: Plastic, Turkey feathers, Goose feathers.", fletchingMapping);
            int myShaftLength = GetUserChoiceNumber("Available shaft length is in range of 60-100 both including.");

            Arrow myArrow = new(myArrowHead, myFletching, myShaftLength);
            Console.WriteLine("\n"+myArrow.ToString()+"\n==========");
        }

        static int GetUserChoiceNumber(string prompt) {
            while (true) {
                Console.Write(prompt + "\nEnter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int number)) {
                    if (number < 60 || number > 100) {
                        ConsolePlus.WriteLineInColor(ConsoleColor.Red, "Enter a value in a 60-100 range.");
                    } else {
                        ConsolePlus.WriteLineInColor(ConsoleColor.Green, "Great choice.");
                        return number;
                    }
                } else ConsolePlus.WriteLineInColor(ConsoleColor.Red, "Please enter a value.");
            }
        }

        static T GetUserChoiceEnum<T>(string prompt, Dictionary<string, T> mapping) {
            while (true) {
                Console.Write(prompt + "\nEnter your choice: ");

                string? choice = Console.ReadLine()?.ToLower();
                if (String.IsNullOrEmpty(choice)) {
                    ConsolePlus.WriteLineInColor(ConsoleColor.Red, "Please enter a choice.");
                    continue;
                }

                if (mapping.TryGetValue(choice, out T? result)) {
                    ConsolePlus.WriteLineInColor(ConsoleColor.Green, "Great choice.");
                    return result;
                }

                ConsolePlus.WriteLineInColor(ConsoleColor.Red, "Please enter a possible value.");
            }
        }
    }
}