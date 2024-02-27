namespace TheUncodedOneBattle.Characters.Items
{
    internal class Item {
        public virtual void Use(Character character) {
            throw new NotSupportedException();
        }

        public override string ToString() => $"{GetType().Name}";
    }
}
