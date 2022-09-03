namespace TwoDecksBlazor
{
    class Card : System.IComparable<Card>
    {
        public Suits Suit { get; }

        public Values Value { get; }

        public Card(Suits suit, Values value)
        {
            Suit = suit;
            Value = value;
        }

        public string Name => $"{Value} of {Suit}";

        public override string ToString() => Name;

        public int CompareTo(Card other) => new CardComparerByValue().Compare(this, other);
    }
}