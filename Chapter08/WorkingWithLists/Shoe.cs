namespace WorkingWithLists
{
    class Shoe
    {
        public Style Style { get; private set; }

        public string Color { get; private set; }

        public string Description => $"A {Color} {Style}";

        public Shoe(Style style, string color)
        {
            Style = style;
            Color = color;
        }

        public override string ToString() => Description;
    }
}
