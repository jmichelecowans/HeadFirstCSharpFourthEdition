namespace UsingEnums
{
    class Card
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
    }
}