namespace Vin_Fletcher_s_Arrows {
    internal class Arrow {
        //enums
        public enum ArrowheadType {
            Steel, Wood, Obsidian
        }
        public enum FletchingType {
            Plastic, TurkeyFeathers, GooseFeathers
        }

        //backing
        private int shaftLength;

        //properties
        public float Cost { get; }
        public ArrowheadType Arrowhead { get; }
        public FletchingType Fletching { get; }
        private int ShaftLength {
            get { return shaftLength; }
            set {
                if (value < 60 || value > 100) throw new ArgumentException("Arrow shaft length must be in a range of 60-100 both including");
                shaftLength = value;
            }
        }

        //constructor
        public Arrow(ArrowheadType arrowhead, FletchingType fletching, int shaftLength) {
            Arrowhead = arrowhead;
            Fletching = fletching;
            ShaftLength = shaftLength;
            Cost = CalculateCost();
        }

        //methods
        float CalculateCost() {
            //For arrowheads, steel costs 10 gold, wood costs 3 gold, and obsidian costs 5 gold.
            //For fletching, plastic costs 10 gold, turkey feathers cost 5 gold, and goose feathers cost 3 gold.
            //For the shaft, the price depends on the length: 0.05 gold per centimeter.
            float cost = 0;

            if (Arrowhead == ArrowheadType.Steel) cost += 10;
            else if (Arrowhead == ArrowheadType.Wood) cost += 3;
            else if (Arrowhead == ArrowheadType.Obsidian) cost += 5;

            if (Fletching == FletchingType.Plastic) cost += 10;
            else if (Fletching == FletchingType.GooseFeathers) cost += 3;
            else if (Fletching == FletchingType.TurkeyFeathers) cost += 5;

            cost += ShaftLength * 0.05f;

            return cost;
        }
        public override string ToString() {
            return @$"Arrow information:
Arrowhead: {Arrowhead}
Fletching: {Fletching}
Shaft length: {ShaftLength}
Cost: {Cost}";
        }
    }
}
