using System;

namespace SloopyJoeBlazor
{
    public class MenuItem
    {
        private static readonly Random _random = new();

        public string[] Proteins { get; set; } = new string[] { "Roast Beef", "Salami", "Turkey", "Ham", 
            "Pastrami", "Tofu" };

        public string[] Condiments { get; set; } =
            new string[] { "yellow mustard", "brown mustard", "honey mustard", "mayo", "relish",
                "french dressing" };

        public string[] Breads { get; set; } = 
            new string[] { "rye", "white", "wheat", "pumpernickel", "a roll" };

        public string Description { get; set; }
        
        public string Price { get; set; }

        public void Generate()
        {
            string randomProtein = Proteins[_random.Next(Proteins.Length)];
            string randomCondiment = Condiments[_random.Next(Condiments.Length)];
            string randomBread = Breads[_random.Next(Breads.Length)];
            Description = randomProtein + " with " + randomCondiment + " on " + randomBread;
            decimal bucks = _random.Next(2, 5);
            decimal cents = _random.Next(1, 98);
            decimal price = bucks + (cents * .01M);
            Price = price.ToString("c");
        }
    }
}
