namespace Uniter_of_Adds {
    internal class Program {
        static void Main() {
            Console.WriteLine(Adds.Add(1, 1));
            Console.WriteLine(Adds.Add(1.02, 1.35));
            Console.WriteLine(Adds.Add("text", " some"));
            Console.WriteLine(Adds.Add(DateTime.Now, TimeSpan.FromHours(1)));
        }
    }

    public static class Adds {
        //public static int Add(int a, int b) => a + b;
        //public static double Add(double a, double b) => a + b;
        //public static string Add(string a, string b) => a + b;
        //public static DateTime Add(DateTime a, TimeSpan b) => a + b;

        public static dynamic Add(dynamic a, dynamic b) => a + b;
    }
}