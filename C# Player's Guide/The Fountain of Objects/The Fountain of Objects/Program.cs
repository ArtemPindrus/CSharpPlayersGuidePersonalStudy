namespace The_Fountain_of_Objects {
    internal class Program {
        static void Main() {
            Vector2 entrancePos = new(0,0);
            Vector2 fountainPosition = new(0,2);

            Vector2[] spikes = new Vector2[] { new(1,0), new(1,1) };

#pragma warning disable IDE0059 // Unnecessary assignment of a value
            FountainOfObjectsGame game = new(Size.Medium, entrancePos, fountainPosition, spikes);
#pragma warning restore IDE0059 // Unnecessary assignment of a value
        }
    }
}