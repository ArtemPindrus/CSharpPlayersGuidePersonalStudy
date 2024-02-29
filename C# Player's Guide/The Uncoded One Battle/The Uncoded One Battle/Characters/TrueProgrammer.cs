namespace TheUncodedOneBattle.Characters
{
    using Attacks;
    class TrueProgrammer : Character {
        public TrueProgrammer(string Name, int initialHealth = 25) : base(Name, 25, initialHealth, new Punch()) { }
    }
}