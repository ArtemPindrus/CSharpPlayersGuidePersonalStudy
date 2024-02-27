namespace TheUncodedOneBattle.Characters.Attacks {
    internal class UnravelingAttack : IAttack {
        public int Damage => Random.Shared.Next(3);

        public override string ToString() => "Unraveling Attack";
    }
}
