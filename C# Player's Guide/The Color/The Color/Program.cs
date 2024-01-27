namespace PlayersGuide {
    public class Program {
        public static void Main() {
            Color red = new(Color.Colors.Red);
            Console.WriteLine(red.ToString());

            Color blue = new(0, 0, 255);
            Console.WriteLine(blue.ToString());
        }
    }

    public class Color {
        public enum Colors {
            White, Black, Red, Orange, Yellow, Green, Blue, Purple
        }

        public byte R { get; private set; }
        public byte G { get; private set; }
        public byte B { get; private set; }

        public Color(Colors color) {
            if (color == Colors.White) {
                R = 255;
                G = 255;
                B = 255;
            } else if (color == Colors.Black) {
                R = 0;
                G = 0;
                B = 0;
            } else if (color == Colors.Red) {
                R = 255;
                G = 0;
                B = 0;
            } else if (color == Colors.Orange) {
                R = 255;
                G = 165;
                B = 0;
            } else if (color == Colors.Yellow) {
                R = 255;
                G = 255;
                B = 0;
            } else if (color == Colors.Red) {
                R = 0;
                G = 128;
                B = 0;
            } else if (color == Colors.Blue) {
                R = 0;
                G = 0;
                B = 255;
            } else if (color == Colors.Purple) {
                R = 128;
                G = 0;
                B = 128;
            }
        }
        public Color(byte R, byte G, byte B) {
            this.R = R;
            this.G = G;
            this.B = B;
        }

        public override string ToString() {
            return $"({R}, {G}, {B})";
        }
    }
}