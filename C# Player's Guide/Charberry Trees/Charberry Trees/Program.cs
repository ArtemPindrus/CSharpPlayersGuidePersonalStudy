namespace Charberry_Trees {
    internal class Program {
        static void Main() {
            CharberryTree tree = new();

            _ = new Notifier (tree);
            _ = new Harvester (tree);

            while (true) tree.MaybeGrow();
        }
    }
}