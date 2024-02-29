using TheUncodedOneBattle.Characters;

namespace TheUncodedOneBattle
{
    using System.Collections;
    using System.Text;
    using Items;
    using TheUncodedOneBattle.Players;

    internal class Party : IEnumerable<Character>
    {
        private readonly List<Character> party;
        public List<IItem> Items { get; }
        public IPlayer Commander { get; }

        public int Count { get => party.Count; }

        /// <summary>
        /// returns whether party has any members with health <= maxhealth/2
        /// </summary>
        public bool ContainsWounded {
            get {
                foreach (var member in party) {
                    if (member.CurrentHealth <= member.MaxHealth/2) return true;
                }

                return false;
            }
        }

        public Character this[int index]
        {
            get => party[index];
        }

        public Party(Character[] members, IPlayer commander, IItem[]? items = null)
        {
            party = new(members);
            Commander = commander;

            Items = items != null ? new(items) : new();
        }

        public void Remove(Character character) => party.Remove(character);

        public bool Contains(Character character) => party.Contains(character);

        public string EnumerateParty()
        {
            StringBuilder result = new();

            for (int i = 0; i < party.Count; i++) result.AppendLine($"{i + 1}. {party[i].Name} ({party[i].CurrentHealth}/{party[i].MaxHealth})");

            return result.ToString();
        }

        public string EnumerateItems()
        {
            StringBuilder result = new();

            for (int i = 0; i < Items.Count; i++) result.AppendLine($"{i + 1}. {Items[i].GetType().Name}");

            return result.ToString();
        }

        public IEnumerator<Character> GetEnumerator() => party.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
