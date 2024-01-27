namespace PlayersGuide {
    internal class Program {
        static void Main() {
            List<Card> deck = new();

            int colorInt = 0;
            int rankInt = 0;
            while (colorInt <= 3) {
                Card.Color color = (Card.Color) colorInt;

                while (rankInt <= 13) {
                    Card.Rank rank = (Card.Rank) rankInt;

                    deck.Add(new Card(color, rank));

                    rankInt++;
                }

                rankInt = 0;
                colorInt++;
            }

            foreach (Card card in deck) { 
                Console.WriteLine(card.CardSummary);
            }
        }
    }

    internal class Card {
        public enum Color {
            Red, Green, Blue, Yellow
        }

        public enum Rank { 
            One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
            DolarSign, PercentSign, Carot, Ampersand
        }

        public string Type { 
            get {
                if ((int)CardRank < 10) return "Number card";
                else return "Sign card";
            } 
        }

        public string CardSummary {
            get {
                return $"The {CardColor} {CardRank}";
            }
        }

        public Color CardColor { get; private set;}
        public Rank CardRank { get; private set; }

        public Card(Color cardColor, Rank cardRank) {
            CardColor = cardColor;
            CardRank = cardRank;
        }
    }
}