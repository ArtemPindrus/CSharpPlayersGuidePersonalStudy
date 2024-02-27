using TheUncodedOneBattle.Characters;
using Extensions;
using TheUncodedOneBattle.Characters.Items;

namespace TheUncodedOneBattle.Players {
    class User : Player {
        public override void PickAction(Character character) {
            CharacterAction action = 
                (CharacterAction) 
                    ConsoleExtensions.GetInt($"User, choose the action for {character.Name}: ", 1, CharacterActionHelper.NumberOfValues) -1;

            character.PerformAction(action, this);
        }

        public override Character PickAttackTarget() {
            string prompt = "User, choose the target: ";

            if (AttachedGame == null) throw new Exception("Character isn't attached to any game!");
            Party party = AttachedGame.GetOppositeParty(this);

            int target = ConsoleExtensions.GetInt(prompt, 1, AttachedGame.CurrentMonsterParty.Count) - 1;
            return party[target];
        }

        public override Item PickItem() {
            string prompt = "User, choose the item: ";

            if (AttachedGame == null) throw new Exception("Character isn't attached to any game!");
            Party party = AttachedGame.GetPartyOf(this);

            int target = ConsoleExtensions.GetInt(prompt, 1, party.Items.Count) - 1;
            return party.Items[target];
        }
    }
}
