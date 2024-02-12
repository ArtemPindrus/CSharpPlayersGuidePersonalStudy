namespace Navigating_Operand_City {
    public record BlockCoordinate(int Row, int Column) {
        public int this[int index] {
            get {
                if (index == 0) return Row;
                else if (index == 1) return Column;
                else throw new IndexOutOfRangeException("Index of [0,1] range is expected.");
            }
        }

        public static BlockCoordinate operator +(BlockCoordinate coordinate, BlockOffset offset) => 
            new(coordinate.Row+offset.RowOffset, coordinate.Column+offset.ColumnOffset);
        public static BlockCoordinate operator +(BlockOffset offset, BlockCoordinate coordinate) => coordinate + offset;

        public static BlockCoordinate operator +(BlockCoordinate coordinate, Direction direction) {
            (int rowDelta, int columnDelta) = direction switch {
                Direction.East => (0, 1),
                Direction.West => (0, -1),
                Direction.South => (1, 0),
                Direction.North => (-1, 0),
                _ => throw new ArgumentException($"Operation isn't defined for {direction} direction")
            };

            return new(coordinate.Row + rowDelta, coordinate.Column + columnDelta);
        }
        public static BlockCoordinate operator +(Direction direction, BlockCoordinate coordinate) => coordinate + direction;
    }

}