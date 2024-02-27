namespace TheUncodedOneBattle.Characters.Items {
    using Extensions;
    internal class HealingPotion : Item {
        private readonly int strength = 10;

        public override void Use(Character character) {
            if (character.AttachedParty == null) throw new Exception("character that uses potion is not attached to party");

            character.Heal(strength);
            ConsoleExtensions.WriteLineColor($"{character.Name} has been healed by {strength}", ConsoleColor.Green);

            character.AttachedParty.Items.Remove(this);
            ConsoleExtensions.WriteLineColor($"Items: \n{character.AttachedParty.EnumerateItems()}", ConsoleColor.Yellow);
        }
    }
}
