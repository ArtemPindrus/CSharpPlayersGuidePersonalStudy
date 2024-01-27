namespace The_Laws_of_Freach {
    internal class Program {
        static void Main(string[] args) {
            //MIN - task
            int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
            int currentSmallest = int.MaxValue; // Start higher than anything in the array.

            foreach (int x in array) {
                if (x < currentSmallest)
                    currentSmallest = x;
            }
            Console.WriteLine(currentSmallest);

            //AVERAGE
            int[] array2 = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
            int total = 0;
            foreach (int x in array2)
                total += x;
            float average = (float)total / array.Length;
            Console.WriteLine(average);
        }
    }
}