namespace Packing_Inventory {
    internal class Program {
        static void Main() {
            int maxItems = GetInt("Enter the amount of max items in a pack: ");
            float maxWeight = GetFloat("Enter the max weight of the pack: ");
            float maxVolume = GetFloat("Enter the max volume of the pack: ");
            Console.Clear();

            Pack pack = new(maxItems, maxWeight, maxVolume);

            while (true) {
                Console.WriteLine(@"Pick an item to add to the pack: 
1. Arrow
2. Bow
3. Rope
4. Water
5. Food
6. Sword");


                InventoryItem item = GetItem()!;
                if (item == null) {
                    Console.WriteLine("No item found under a chosen number!\n");
                } else {
                    if (pack.Add(item)) Console.WriteLine("Item was added!\n");
                    else Console.WriteLine("Item doesn't fit into the pack!\n");
                }

                Console.WriteLine(pack.ToString());
            }


            //funcs
            static InventoryItem? GetItem() {
                int choice = GetInt("Enter your option: ");

                return choice switch {
                    1 => new Arrow(),
                    2 => new Bow(),
                    3 => new Rope(),
                    4 => new Water(),
                    5 => new Food(),
                    6 => new Sword(),
                    _ => null,
                };
            }
        }

        private static int GetInt(string prompt) {
            int number;
            do {
                Console.Write(prompt);
            } while (!int.TryParse(Console.ReadLine(), out number));

            return number;
        }
        private static float GetFloat(string prompt) {
            float number;
            do {
                Console.Write(prompt);
            } while (!float.TryParse(Console.ReadLine(), out number));

            return number;
        }
    }

    internal class Pack {
        private readonly InventoryItem[] items;

        public float MaxWeight { get; }
        public float MaxVolume { get; }
       
        public int MaxInventoryCount => items.Length;
        public float Weight { get; private set; }
        public float Volume { get; private set; }


        public Pack(int maxAmountOfItems, float maxWeight, float maxVolume) {
            items = new InventoryItem[maxAmountOfItems]; 
            MaxWeight = maxWeight;
            MaxVolume = maxVolume;
        }

        public bool Add(InventoryItem item) { 
            if (Weight + item.Weight > MaxWeight) return false;
            if (Volume + item.Volume > MaxVolume) return false;

            int i = Array.IndexOf(items, null);
            if (i == -1) return false;

            items[i] = item;
            Weight += item.Weight;
            Volume += item.Volume;

            return true;
        }
        public override string ToString() {
            string content = "The pack contains:\n";
            foreach(InventoryItem inventoryItem in items) if (inventoryItem != null) content += inventoryItem.ToString()+"\n";

            return content;
        }
    }



    internal class InventoryItem { 
        public float Weight { get; protected set; }
        public float Volume { get; protected set; }

        public InventoryItem(float weight, float volume) { 
            Weight = weight;
            Volume = volume;
        }

        public override string ToString() {
            return GetType().Name;
        }
    }
    internal class Arrow : InventoryItem {
        private static readonly float defaultWeight = 0.1f;
        private static readonly float defaultVolume = 0.05f;
        public Arrow() : base(defaultWeight, defaultVolume) { 
        
        }
    }
    internal class Bow : InventoryItem {
        private static readonly float defaultWeight = 1f;
        private static readonly float defaultVolume = 4f;
        public Bow() : base(defaultWeight, defaultVolume) {

        }
    }
    internal class Rope : InventoryItem {
        private static readonly float defaultWeight = 1f;
        private static readonly float defaultVolume = 1.5f;
        public Rope() : base(defaultWeight, defaultVolume) {

        }
    }
    internal class Water : InventoryItem {
        private static readonly float defaultWeight = 2f;
        private static readonly float defaultVolume = 3f;
        public Water() : base(defaultWeight, defaultVolume) {

        }
    }
    internal class Food : InventoryItem {
        private static readonly float defaultWeight = 1f;
        private static readonly float defaultVolume = 0.5f;
        public Food() : base(defaultWeight, defaultVolume) {

        }
    }
    internal class Sword : InventoryItem {
        private static readonly float defaultWeight = 5f;
        private static readonly float defaultVolume = 3f;
        public Sword() : base(defaultWeight, defaultVolume) {

        }
    }
}