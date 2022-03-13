using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SloppyJoe
{
    internal class MenuItem
    {
        private static readonly Random randomizer = new Random();
        public string[] Proteins { get; set; } = { "Rast Beef", "Salami", "Turkey", "Ham", "Pastrami", "Tofu" };
        public string[] Condiments { get; set; } = { "yellow mustard", "brown mustard", "honey mustard", "mayo", "relish", "french dressing" };
        public string[] Breads { get; set; } = { "rye", "white", "wheat", "pumpernickel", "a roll" };

        public string Description { get; private set; } = "";
        public string Price { get; private set; } = "";

        public void Generate()
        {
            string randomProtein = Proteins[randomizer.Next(Proteins.Length)];
            string randomCondiment = Condiments[randomizer.Next(Condiments.Length)];
            string randomBread = Breads[randomizer.Next(Breads.Length)];

            Description = randomProtein + " with " + randomCondiment + " on " + randomBread;
            decimal bucks = randomizer.Next(2, 5);
            decimal cents = randomizer.Next(1, 98);
            decimal price = bucks + (cents * .01M);
            Price = price.ToString("c", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
        }
    }
}
