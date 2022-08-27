namespace BasketballRoster.ViewModel
{
    class PlayerViewModel
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public override string ToString() => $"{Name} (#{Number})";
    }
}
