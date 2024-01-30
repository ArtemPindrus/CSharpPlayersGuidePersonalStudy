namespace The_Fountain_of_Objects {
    public record struct Vector2(int X, int Y) {
        public static Vector2 operator +(Vector2 first, Vector2 second) => new(first.X+second.X, first.Y+second.Y);

        public override readonly string ToString() => $"(Column: {X}, Row: {Y})";

        public readonly bool IsAdjacentTo(Vector2 vector) => Math.Abs(X - vector.X) <= 1 && Math.Abs(Y - vector.Y) <= 1;
    }
}