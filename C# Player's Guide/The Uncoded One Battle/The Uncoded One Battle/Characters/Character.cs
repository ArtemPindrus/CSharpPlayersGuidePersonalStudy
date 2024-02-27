namespace TheUncodedOneBattle.Characters
{
    using Players;
    using Extensions;
    using Attacks;
    using TheUncodedOneBattle.Characters.Items;

    enum CharacterAction { DoNothing, StandartAttack, UseItem }

    class Character {
        public event EventHandler? Died;

        public Party? AttachedParty { get; private set; }

        public int MaxHealth { get; }
        public int CurrentHealth { get; private set; }

        public string Name { get; private set; }
        protected IAttack StandartAttack { get; }

        public Character(string name, int maxHealth, int initialHealth, IAttack standartAttack) {
            Name = name;
            StandartAttack = standartAttack;

            MaxHealth = maxHealth;
            CurrentHealth = initialHealth;
        }

        public void Attach(Party party) => AttachedParty = party;

        public void PerformAction(CharacterAction action, Player commander) {
            Console.WriteLine($"It's {Name}'s turn...");

            if (action == CharacterAction.DoNothing) Console.WriteLine($"{Name} did NOTHING.");
            else if (action == CharacterAction.StandartAttack) {
                Character target = commander.PickAttackTarget();

                int damage = StandartAttack.Damage;


                Console.WriteLine($"{Name} performed a {StandartAttack} on {target.Name}.");

                ConsoleColor color = damage == 0 ? ConsoleColor.Red : ConsoleColor.Green;
                ConsoleExtensions.WriteLineColor($"{StandartAttack} has dealt {damage}. {target.Name} is now at {target.CurrentHealth - damage}/{target.MaxHealth}", color);

                target.TakeDamage(damage);
            } else if (action == CharacterAction.UseItem) {
                if (AttachedParty == null) throw new Exception("character isn't attached!");
                if (AttachedParty.Items.Count == 0) {
                    ConsoleExtensions.WriteLineColor($"{Name} wasted his turn!", ConsoleColor.Red);
                    return;
                }

                Item item = commander.PickItem();
                item.Use(this);
            } else throw new NotImplementedException($"method for action {action} is not implemented!");

            Console.WriteLine();
        }

        public void TakeDamage(int damage) {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0) {
                CurrentHealth = 0;
                Died?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Heal(int amount) { 
            CurrentHealth += amount;

            if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
        }

        public void Dispose() {
            Died = null;
        }
    }
}