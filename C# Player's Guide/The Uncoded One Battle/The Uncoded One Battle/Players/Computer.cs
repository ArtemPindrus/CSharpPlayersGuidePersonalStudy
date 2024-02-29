namespace TheUncodedOneBattle.Players
{
    using TheUncodedOneBattle.Characters;
    using TheUncodedOneBattle.Actions;
    using System.Security.Cryptography;
    using TheUncodedOneBattle.Items;

    class Computer : IPlayer {
        private static readonly int chanceToUseHealingWhenWounded = 25;
        private static readonly int thinkingTime = 0;

        public ICharacterAction PickAction(Character performant) {
            if (performant.AttachedGame == null) throw new ArgumentException($"{nameof(performant)} is not attached to the game!");
            if (performant.AttachedParty == null) throw new ArgumentException($"{nameof(performant)} isn't attached to any party!");

            Console.Write($"It's {performant.Name}'s turn...\nComputer is choosing the action for {performant.Name}: ");
            Thread.Sleep(thinkingTime);

            if (performant.CurrentHealth <= performant.MaxHealth / 2) {
                List<IItem> partyItems = performant.AttachedParty.Items;
                if (partyItems.Count > 0 && partyItems.Any(x => x is HealingPotion)) {
                    int randomInt = Random.Shared.Next(100);
                    if (randomInt <= chanceToUseHealingWhenWounded) { //use healingPotion
                        Console.WriteLine((int)CharacterActionEnum.UseItem+1); //simulate choice
                        Console.Write("Compute is choosing the item: ");
                        Thread.Sleep(thinkingTime);

                        int targetItem = partyItems.FindIndex(x => x is HealingPotion);
                        Console.WriteLine(targetItem + 1);

                        return new UseItem(partyItems[targetItem], performant);
                    }
                }
            } 

            Console.WriteLine((int) CharacterActionEnum.Attack+1); //simulate choice
            Console.Write("Computer is choosing the target: ");

            Party oppositeParty = performant.AttachedGame.GetOppositeParty(performant.AttachedParty);
            int target = Random.Shared.Next(oppositeParty.Count);
            Console.WriteLine(target+1);

            return new AttackAction(performant, oppositeParty[target]);
        }
    }
}
