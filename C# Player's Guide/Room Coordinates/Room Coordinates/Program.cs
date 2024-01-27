namespace Room_Coordinates {
    internal class Program {
        static void Main() {
            Coordinate first = new Coordinate(0,0);
            Coordinate second = new Coordinate(1,0);

            Coordinate third = new Coordinate(5,3);
            Coordinate fourth = new Coordinate(6,4);

            Coordinate fifth = new Coordinate(4,3);

            Console.WriteLine(first.IsAdjacentTo(second));
            Console.WriteLine(first.IsAdjacentTo(third));

            Console.WriteLine(third.IsAdjacentTo(fifth));
            Console.WriteLine(third.IsAdjacentTo(fourth));
        }
    }

    public readonly struct Coordinate { 
        public int Row { get; }
        public int Column { get; }

        public Coordinate(int row, int column) { 
            Row = row;
            Column = column;
        }

        public bool IsAdjacentTo(Coordinate coordinate) { 
            int rowDifference = Math.Abs(Row - coordinate.Row);
            int columnDifference = Math.Abs(Column - coordinate.Column);

            return rowDifference + columnDifference == 1;
        }
    }
}