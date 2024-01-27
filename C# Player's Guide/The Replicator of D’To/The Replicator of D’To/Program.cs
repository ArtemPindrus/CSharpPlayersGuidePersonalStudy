namespace The_Replicator_of_D_To {
    internal class Program {
        static void Main() {
            int[] originalArr = new int[5];
            for (int i = 0; i < 5; i++) {
                Console.Write($"Write the value at index {i}: ");
                originalArr[i] = GetNumber();
            }

            Console.WriteLine("Content of original array:");
            foreach (int i in originalArr){
                Console.WriteLine(i);
            }
            Console.WriteLine();

            int[] copiedArr = new int[5];
            Array.Copy(originalArr, copiedArr, 5);

            Console.WriteLine("Content of copied array: ");
            foreach (int i in copiedArr) { 
                Console.WriteLine(i);
            }
        }
        static int GetNumber() {
            while (true) {
                if (int.TryParse(Console.ReadLine(), out int number)) return number;
                else Console.Write("Error, number expected: ");
            }
        }
    }
}