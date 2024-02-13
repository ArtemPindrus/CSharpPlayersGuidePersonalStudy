namespace The_Repeating_Stream {
    class RecentNumbers {
        private readonly object numbersLock = new();

        private int index;
        private readonly int[] numbers = new int[2];

        public bool NumbersAreEqual {
            get {
                lock (numbersLock) { 
                    return numbers[0] == numbers[1];
                }
            }
        }

        public void AddNumber(int number) {
            lock (numbersLock) {
                numbers[index] = number;
                index++;

                if (index == 2) index = 0;
            }
        }
    }
}