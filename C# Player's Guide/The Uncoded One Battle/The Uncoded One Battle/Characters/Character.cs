namespace TheUncodedOneBattle.Characters
{
    using Attacks;
    using Extensions;
    using TheUncodedOneBattle.Actions;

    class Character {
        public event EventHandler? Died;

        public Party? AttachedParty { get; private set; }
        public Game? AttachedGame { get; private set; }

        public int MaxHealth { get; }
        public int CurrentHealth { get; private set; }
        public string HealthStatus => $"{CurrentHealth}/{MaxHealth}";

        public string Name { get; private set; }
        public IAttack Attack { get; }

        public Character(string name, int maxHealth, int initialHealth, IAttack standartAttack) {
            Name = name;
            Attack = standartAttack;

            MaxHealth = maxHealth;
            CurrentHealth = initialHealth;
        }

        public void AttachGame(Game game) => AttachedGame = game;
        public void AttachParty(Party party) => AttachedParty = party;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="damage"></param>
        /// <returns>returns whether character died</returns>
        public bool TakeDamage(int damage) {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0) {
                CurrentHealth = 0;
                Died?.Invoke(this, EventArgs.Empty);
                return true;
            }

            return false;
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