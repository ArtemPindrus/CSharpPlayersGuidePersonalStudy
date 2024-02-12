namespace Navigating_Operand_City {
    public record BlockOffset(int RowOffset, int ColumnOffset) {
        public static explicit operator BlockOffset(Direction direction) {
            (int rowOffset, int columnOffset) = direction switch {
                Direction.East => (0, 1),
                Direction.West => (0, -1),
                Direction.South => (1, 0),
                Direction.North => (-1, 0),
                _ => throw new ArgumentException($"Operation isn't defined for {direction} direction")
            };

            return new BlockOffset(rowOffset, columnOffset);
        }
    }
}