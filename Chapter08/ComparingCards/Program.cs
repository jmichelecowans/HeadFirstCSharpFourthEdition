using System;
using System.Collections.Generic;

namespace ComparingCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of cards: ");

            if (int.TryParse(Console.ReadLine()?.Trim(), out int numberOfCards))
            {
                List<Card> cards = new();

                for (int i = 0; i < numberOfCards; i++)
                {
                    cards.Add(RandomCard());
                }

                PrintCards(cards);

                Console.WriteLine("\n... sorting the cards ...\n");
                cards.Sort(new CardComparerByValue());
                PrintCards(cards);
            }
        }

        static Card RandomCard()
        {
            Random random = new Random();
            return new Card((Suits)random.Next(4), (Values)random.Next(1, 14));
        }

        static void PrintCards(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card);
            }
        }
    }
}
