using System;
using System.Collections.Generic;

namespace WorkingWithLists
{
    class ShoeCloset
    {
        private readonly List<Shoe> shoes = new();

        public void PrintShoes()
        {
            if (shoes.Count <= 0)
            {
                Console.WriteLine("\nThe shoe closet is empty.");
                return;
            }

            Console.WriteLine("\nThe shoe closet contains:");
            foreach (var shoe in shoes)
            {
                Console.WriteLine($"{shoes.IndexOf(shoe) + 1}: {shoe}");
            }
        }

        public void AddShoe()
        {
            Console.WriteLine("\nAdd a shoe");

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"Press {i} to add a {(Style)i}");
            }

            Console.Write("Enter a style: ");

            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int style) && style >= 0 && style <= 5)
            {
                Console.Write("\nEnter the color: ");
                string color = Console.ReadLine();
                Shoe shoe = new ((Style)style, color);
                shoes.Add(shoe);
            }
        }

        public void RemoveShoe()
        {
            Console.Write("\nEnter the number of the shoe to remove: ");

            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int shoeNumber) &&
                (shoeNumber >= 1) && (shoeNumber <= shoes.Count))
            {
                Console.WriteLine($"\nRemoving {shoes[shoeNumber - 1]}");
                shoes.RemoveAt(shoeNumber - 1);
            }
        }
    }
}
