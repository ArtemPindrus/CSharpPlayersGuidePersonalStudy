namespace TheUncodedOneBattle.Characters
{
    using System.Collections;
    using System.Text;
    using TheUncodedOneBattle.Characters.Items;

    internal class Party : IEnumerable<Character> {
        private readonly List<Character> party;
        public List<Item> Items { get; }

        public int Count { get => party.Count; }

        public Character this[int index] { 
            get => party[index];
        }

        public Party(Character[] members, Item[]? items = null) { 
            party = new(members);

            Items = items != null ? new(items) : new();

            foreach (var member in members) member.Attach(this);
        }

        public void Remove(Character character) => party.Remove(character);

        public bool Contains(Character character) => party.Contains(character);

        public string EnumerateParty() {
            StringBuilder result = new();

            for (int i = 0; i < party.Count; i++) result.AppendLine($"{i + 1}. {party[i].Name} ({party[i].CurrentHealth}/{party[i].MaxHealth})");

            return result.ToString();
        }

        public string EnumerateItems() {
            StringBuilder result = new();

            for (int i = 0; i < Items.Count; i++) result.AppendLine($"{i + 1}. {Items[i]}");

            return result.ToString();
        }

        public IEnumerator<Character> GetEnumerator() => party.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
