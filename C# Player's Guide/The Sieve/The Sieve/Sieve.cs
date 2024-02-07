namespace The_Sieve {
    internal class Sieve {
        private readonly Predicate<int> numberFilter;

        public Sieve(Predicate<int> numberFilter) { 
            this.numberFilter = numberFilter;
        }

        public bool IsGood(int number) => numberFilter(number);
    }
}
