using Extensions;
using TheUncodedOneBattle.Characters;

namespace TheUncodedOneBattle.Actions
{
    internal class AttackAction : ICharacterAction
    {
        public Character Target { get; }
        public Character Performant { get; }

        public AttackAction(Character performant, Character target)
        {
            Performant = performant;
            Target = target;
        }

        public void Perform() {
            int damage = Performant.Attack.Damage;

            ConsoleColor color = damage > 0 ? ConsoleColor.Green : ConsoleColor.Red;
            ConsoleExtensions.WriteLineColor($"{Performant.Name} has dealt {damage} damage with {Performant.Attack} on {Target.Name}!", color);

            if (!Target.TakeDamage(damage)) ConsoleExtensions.WriteLineColor($"The {Target.Name} is now at {Target.HealthStatus}", color);
        }
    }
}
