using TheUncodedOneBattle.Characters.Attacks;

namespace TheUncodedOneBattle.Characters
{
    internal class TheUncodedOne : Character {
        public TheUncodedOne(int initialHealth = 15) : base("THE UNCODED ONE", 15, initialHealth, new UnravelingAttack()) { } 
    }
}
