using TheUncodedOneBattle.Characters.Items;
using TheUncodedOneBattle.Characters;

namespace TheUncodedOneBattle.Players
{
    class Computer : Player {
        private static readonly int thinkingTime = 1000;
        private readonly Random rn = new();

        public override void PickAction(Character character) {
            Console.Write($"Computer is picking an action for {character.Name}: ");
            Thread.Sleep(thinkingTime);

            int rndChoice = rn.Next(CharacterActionHelper.NumberOfValues);
            Console.WriteLine(rndChoice+1);

            character.PerformAction((CharacterAction) rndChoice, this);
        }

        public override Character PickAttackTarget() {
            Console.Write("Computer is choosing the target: ");
            Thread.Sleep(thinkingTime);

            if (AttachedGame == null) throw new Exception("Player isn't attached to the game");
            Party party = AttachedGame.GetOppositeParty(this);

            int target = rn.Next(party.Count);

            Console.WriteLine(target + 1);

            return party[target];
        }

        public override Item PickItem() {
            Console.Write("Computer is choosing the item: ");
            Thread.Sleep(thinkingTime);

            if (AttachedGame == null) throw new Exception("Player isn't attached to the game");
            Party party = AttachedGame.GetPartyOf(this);

            if (party.Items == null) throw new Exception("Party doesn't have any items!");
            int choice = Random.Shared.Next(party.Items.Count);
            Console.WriteLine(choice+1);

            return party.Items[choice];
        }
    }
}
