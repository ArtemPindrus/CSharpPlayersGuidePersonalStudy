namespace TheUncodedOneBattle.Players
{
    using TheUncodedOneBattle.Actions;
    using TheUncodedOneBattle.Characters;

    internal interface IPlayer {
        public ICharacterAction PickAction(Character character);
    }
}
