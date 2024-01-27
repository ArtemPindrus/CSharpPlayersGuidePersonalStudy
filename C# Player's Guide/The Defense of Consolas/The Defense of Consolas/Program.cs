namespace The_Defense_of_Consolas {
    internal class Program {
        static void Main() {
            Console.Write("Enter the value of city row: ");
            int cityRow = GetNumber();
            Console.Write("Enter the value of city column: ");
            int cityCol = GetNumber();
            var ourCity = new City(cityRow, cityCol);

            var defenderLeft = new Defender(PositionRelativeToCity.left, ourCity);
            var defenderRight = new Defender(PositionRelativeToCity.right, ourCity);
            var defenderTop = new Defender(PositionRelativeToCity.top, ourCity);
            var defenderBottom = new Defender(PositionRelativeToCity.bottom, ourCity);

            Console.WriteLine("Deploy to:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"({defenderLeft.defenderRow}, {defenderLeft.defenderCol})");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"({defenderRight.defenderRow}, {defenderRight.defenderCol})");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"({defenderTop.defenderRow}, {defenderTop.defenderCol})");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"({defenderBottom.defenderRow}, {defenderBottom.defenderCol})");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Title = "Defense of Consolas";
            Console.Beep();
        }
        static int GetNumber() {
            while (true) {
                if (int.TryParse(Console.ReadLine(), out int number)) return number;
                else Console.WriteLine("Error! Number expected");
            }
        }
    }
    class Defender {
        public readonly int defenderRow;
        public readonly int defenderCol;
        public Defender(PositionRelativeToCity position, City city) {
            switch (position) {
                case PositionRelativeToCity.top: {
                    defenderRow = city.cityRow + 1;
                    defenderCol = city.cityCol;
                    break;
                }
                case PositionRelativeToCity.bottom: { 
                    defenderRow = city.cityRow -1;
                    defenderCol = city.cityCol;
                    break;
                }
                case PositionRelativeToCity.right: {
                    defenderRow = city.cityRow;
                    defenderCol = city.cityCol +1;
                    break;
                }
                case PositionRelativeToCity.left: {
                    defenderRow = city.cityRow;
                    defenderCol = city.cityCol - 1;
                    break;
                }
            }
        }
    }
    enum PositionRelativeToCity { 
        left, right, top, bottom
    }

    class City {
        public int cityRow;
        public int cityCol;
        public City(int cityRow, int cityCol) { 
            this.cityRow = cityRow;
            this.cityCol = cityCol;
        }
    }
}