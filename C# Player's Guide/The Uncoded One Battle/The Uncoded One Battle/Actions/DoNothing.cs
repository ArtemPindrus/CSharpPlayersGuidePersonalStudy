using Extensions;
using System.Xml.Linq;
using TheUncodedOneBattle.Characters;

namespace TheUncodedOneBattle.Actions
{
    internal class DoNothing : ICharacterAction {
        public Character Performant { get; }

        public DoNothing(Character performant) { 
            Performant = performant;
        }

        public void Perform() {
            ConsoleExtensions.WriteLineColor($"{Performant.Name} did nothing...", ConsoleColor.Red);
        }
    }
}
