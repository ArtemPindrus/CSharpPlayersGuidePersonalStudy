namespace TheUncodedOneBattle.Attacks
{
    internal class BoneCrunch : IAttack
    {
        public int Damage => Random.Shared.Next(2);

        public override string ToString() => "BONE CRUNCH";
    }
}
