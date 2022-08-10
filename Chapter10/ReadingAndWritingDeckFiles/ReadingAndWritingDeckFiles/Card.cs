namespace ReadingAndWritingDeckFiles
{
    public class Card
    {
        public Suits Suit { get; }

        public Values Value { get; }

        public Card(Values value, Suits suit)
        {
            Suit = suit;
            Value = value;
        }

        public string Name => $"{Value} of {Suit}";

        public override string ToString() => Name;
    }
}