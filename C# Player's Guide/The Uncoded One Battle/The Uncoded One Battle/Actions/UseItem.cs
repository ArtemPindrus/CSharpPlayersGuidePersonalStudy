namespace TheUncodedOneBattle.Actions {
    using Items;
    using TheUncodedOneBattle.Characters;

    internal class UseItem : ICharacterAction {
        public IItem? Item { get; }

        public Character Performant { get; }

        public UseItem(IItem? item, Character performant) { 
            Item = item;
            Performant = performant;
        }

        public void Perform() {
            if (Item != null) Item.Use(Performant);
            else Console.WriteLine($"{Performant.Name} wasted his turn...");
        }
    }
}
