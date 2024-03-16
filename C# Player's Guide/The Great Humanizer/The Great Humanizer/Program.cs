namespace The_Great_Humanizer {
    using Humanizer;
    internal class Program {
        static void Main() {
            DateTime feastTime = DateTime.UtcNow.AddHours(60);
            Console.WriteLine("Where is the feast? "+feastTime.Humanize(true));
        }
    }
}