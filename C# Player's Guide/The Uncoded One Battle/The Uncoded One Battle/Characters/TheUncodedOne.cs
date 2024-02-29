namespace TheUncodedOneBattle.Characters
{
    using Attacks;

    internal class TheUncodedOne : Character {
        public TheUncodedOne(int initialHealth = 15) : base("THE UNCODED ONE", 15, initialHealth, new UnravelingAttack()) { } 
    }
}
