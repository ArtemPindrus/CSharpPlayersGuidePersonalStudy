namespace Colored_Items {
    internal class Program {
        static void Main() {
            ColoredItem<Axe> axe = new(new(), ConsoleColor.Green);
            ColoredItem<Sword> sword = new(new(), ConsoleColor.Blue);
            ColoredItem<Bow> bow = new(new(), ConsoleColor.Red);

            axe.Display();
            sword.Display();
            bow.Display();
        }
    }

    public class Item { }
    public class Sword : Item { }
    public class Bow : Item { }
    public class Axe : Item { }

    public class ColoredItem<T> where T : Item { 
        public T Item { get; private set; }
        public ConsoleColor Color { get; private set; }

        public ColoredItem(T item, ConsoleColor associatedColor) {
            Item = item; 
            Color = associatedColor;
        }

        public void Display() { 
            Console.BackgroundColor = Color;
            Console.WriteLine(Item.ToString());
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}