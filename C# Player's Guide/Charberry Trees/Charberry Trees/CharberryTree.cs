namespace Charberry_Trees {
    public class CharberryTree {
        public event Action? Ripened;

        private readonly Random _random = new();
        public bool Ripe { get; set; }

        public void MaybeGrow() {
            // Only a tiny chance of ripening each time, but we try a lot!
            if (_random.NextDouble() < 0.00000001 && !Ripe) {
                Ripe = true;
                Ripened?.Invoke();
            }
        }
    }
}