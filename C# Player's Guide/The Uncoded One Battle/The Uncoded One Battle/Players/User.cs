using TheUncodedOneBattle.Actions;
using TheUncodedOneBattle.Characters;
using Extensions;

namespace TheUncodedOneBattle.Players {
    class User : IPlayer {
        public ICharacterAction PickAction(Character performant) {
            if (performant.AttachedGame == null) throw new ArgumentException($"{nameof(performant)} isn't attached to the game!");
            if (performant.AttachedParty == null) throw new ArgumentException($"{nameof(performant)} isn't attached to any party!");

            Console.WriteLine($"It's {performant.Name}'s turn...");

            CharacterActionEnum action = (CharacterActionEnum) ConsoleHelper.GetInt($"User, choose the action for {performant.Name}: ", 1, CharacterActionHelper.ActionAmount)-1;

            if (action == CharacterActionEnum.DoNothing) return new DoNothing(performant);
            else if (action == CharacterActionEnum.Attack) {
                Party oppositeParty = performant.AttachedGame.GetOppositeParty(performant.AttachedParty);

                int target = oppositeParty.Count == 1 ? 0 : ConsoleHelper.GetInt("User, choose the target: ", 1, oppositeParty.Count) - 1;
                return new AttackAction(performant, oppositeParty[target]);
            } else if (action == CharacterActionEnum.UseItem) {
                Party party = performant.AttachedParty;

                if (party.Items.Count == 0) return new UseItem(null, performant);

                int target = party.Items.Count == 1 ? 0 : ConsoleHelper.GetInt("User, choose the item: ", 1, party.Items.Count) - 1;
                return new UseItem(party.Items[target], performant);
            } else throw new Exception("CharacterAction for the choice isn't defined!");
        }
    }
}
