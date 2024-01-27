namespace War_Preparations {
    internal class Program {
        static void Main() {
            Sword original = new(Material.Iron, Gemstone.None, 20, 7);

            Sword modified1 = original with { Gemstone = Gemstone.Bitstone, CrossguardWidth = 8 };
            Sword modified2 = original with { Material = Material.Binarium, Length = 10, CrossguardWidth = 5 };

            Console.WriteLine(original);
            Console.WriteLine(modified1);
            Console.WriteLine(modified2);
        }
    }

    public enum Material { Wood, Bronze, Iron, Steel, Binarium }
    public enum Gemstone { None, Emerald, Amber, Sapphire, Diamond, Bitstone }

    public record Sword(Material Material, Gemstone Gemstone, float Length, float CrossguardWidth);
}