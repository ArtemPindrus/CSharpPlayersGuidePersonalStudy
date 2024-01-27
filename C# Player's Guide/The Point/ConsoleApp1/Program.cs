class Program {
    static void Main() {
        Point myPoint = new(1,3);
        Console.WriteLine(myPoint.ToString());

        Point myPoint2 = new();
        Console.WriteLine(myPoint2.ToString());
    }
}

class Point { 
    public float X { get; private set; }
    public float Y { get; private set; }

    public Point(float x, float y) { 
        X = x;
        Y = y;
    }
    public Point() {
        X = 0;
        Y = 0;
    }

    public override string ToString() {
        return $"({X}, {Y})";
    }
}