namespace TheUncodedOneBattle
{
    internal class Battle {
        public Party HeroParty { get; }
        public Party MonsterParty { get; }

        public Battle(Party heroes, Party monsters) {
            HeroParty = heroes;
            MonsterParty = monsters;
        }
    }
}
