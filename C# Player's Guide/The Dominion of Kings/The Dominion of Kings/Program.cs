namespace The_Dominion_of_Kings {
    internal class Program {
        static void Main() {
            King Melik = new King("Melik");
            King Casik = new King("Casik");
            King Balik = new King("Balik");
        }
        public static int GetNumber() {
            while (true) {
                if (int.TryParse(Console.ReadLine(), out int number)) return number;
                else Console.WriteLine("Error! Number is expected");
            }
        }
    }
    class King {
        string name;
        int numberOfProvinces;
        int numberOfDuchies;
        int numberOfEstates;
        int points;
        public King(string name) {
            this.name = name;

            Console.WriteLine($@"==========
Information for the King {this.name}:
");

            Console.Write("Enter the number of provinces: ");
            numberOfProvinces = Program.GetNumber();

            Console.Write("Enter the number of duchies: ");
            numberOfDuchies = Program.GetNumber();

            Console.Write("Enter the number of estates: ");
            numberOfEstates = Program.GetNumber();

            points = numberOfProvinces * 6 + numberOfDuchies * 3 + numberOfEstates;
            Console.WriteLine(@$"Points earned: {points}
==========
");
        }
    }
}