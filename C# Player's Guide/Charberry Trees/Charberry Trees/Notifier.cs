namespace Charberry_Trees {
    public class Notifier {

        public Notifier(CharberryTree target) {
            target.Ripened += Notify;
        }

        private void Notify() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A charberry fruit has ripened!");
            Console.ForegroundColor= ConsoleColor.White;
        }
    }
}
