using System;

namespace ReadingAndWritingDeckFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "deckofcards.txt";
            Deck deck = new();
            deck.Shuffle();
            for (int i = deck.Count - 1; i > 10; i--)
                deck.RemoveAt(i);
            deck.WriteCards(filename);
            Deck cardsToRead = new(filename);
            foreach (var card in cardsToRead)
                Console.WriteLine(card.Name);
        }
    }
}
