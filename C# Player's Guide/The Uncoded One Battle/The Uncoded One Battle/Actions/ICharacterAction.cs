using TheUncodedOneBattle.Characters;

namespace TheUncodedOneBattle.Actions
{
    internal interface ICharacterAction {
        public Character Performant { get; }

        public void Perform();
    }
}
