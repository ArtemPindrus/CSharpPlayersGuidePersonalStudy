namespace The_Three_Lenses {
    internal class Program {
        static void Main() {
            int[] nums = {1, 9, 2, 8, 3, 7, 4, 6, 5};

            IEnumerable<int> procedural = ProduceValidNumsProcedural(nums);
            IEnumerable<int> keywordsQueries = ProduceValidNumsKeywordQueries(nums);
            IEnumerable<int> methodBased = ProduceValidNumsMethodQueries(nums);

            WriteOut(procedural);
            WriteOut(keywordsQueries);
            WriteOut(methodBased);
        }

        private static void WriteOut<T>(IEnumerable<T> collection) {
            foreach (T x in collection) Console.Write(x + ", ");
            (int left, int top) = Console.GetCursorPosition();

            Console.SetCursorPosition(left-2, top);
            Console.WriteLine(" ");
        }

        private static IEnumerable<int> ProduceValidNumsProcedural(params int[] nums) {
            List<int> evenDoubledSortedNums = new();

            foreach (int num in nums) { 
                if (num % 2 == 0) evenDoubledSortedNums.Add(num*2);
            }

            evenDoubledSortedNums.Sort();

            return evenDoubledSortedNums;
        }

        private static IEnumerable<int> ProduceValidNumsKeywordQueries(params int[] nums) {
            return from num in nums
                   where num % 2 == 0
                   orderby num
                   select num * 2;
        }

        private static IEnumerable<int> ProduceValidNumsMethodQueries(params int[] nums) => 
            nums.Where(x => x % 2 == 0).OrderBy(x => x).Select(x => x * 2);

    }
}