namespace Navigating_Operand_City {
    internal class Program {
        static void Main() {
            BlockCoordinate starting = new(5,2);
            BlockOffset offset1 = new(10,2); //15,4
            BlockOffset offset2 = (BlockOffset) Direction.North;

            BlockCoordinate resulting = starting + offset1 + offset2;

            Console.WriteLine(resulting[0] + ", " + resulting[1]);
        }
    }
    public enum Direction { North, East, South, West }

}