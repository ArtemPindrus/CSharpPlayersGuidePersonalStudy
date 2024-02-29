namespace TheUncodedOneBattle.Characters
{
    using Attacks;
    class Skeleton : Character {
        public Skeleton(int initialHealth = 5) : base("SKELETON", 5, initialHealth, new BoneCrunch()) { }
    }
}