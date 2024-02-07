namespace Charberry_Trees {
    public class Harvester {
        private readonly CharberryTree target;
        private int fruitBuffer;

        public Harvester(CharberryTree target) {
            this.target = target;
            target.Ripened += Harvest;
        }

        private void Harvest() {
            target.Ripe = false;
            fruitBuffer++;

            Console.WriteLine("Current fruit number at the harvester: " + fruitBuffer);
        }
    }
}
