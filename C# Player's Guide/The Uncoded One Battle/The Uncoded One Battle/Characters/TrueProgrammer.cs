using TheUncodedOneBattle.Characters.Attacks;

namespace TheUncodedOneBattle.Characters
{
    class TrueProgrammer : Character {
        public TrueProgrammer(string Name, int initialHealth = 25) : base(Name, 25, initialHealth, new Punch()) { }
    }
}