using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ReadingAndWritingDeckFiles
{
    public class Deck : ObservableCollection<Card>
    {
        private static readonly Random random = new();

        public Deck()
        {
            Reset();
        }

        public Deck(string filename)
        {
            using StreamReader sr = new(filename);

            while (!sr.EndOfStream)
            {
                var nextCard = sr.ReadLine();
                var cardParts = nextCard.Split(" ");

                if (cardParts.Length >= 3)
                {
                    var suit = cardParts[2]?.ToUpper() switch
                    {
                        "CLUBS" => Suits.Clubs,
                        "DIAMONDS" => Suits.Diamonds,
                        "HEARTS" => Suits.Hearts,
                        "SPADES" => Suits.Spades,
                        _ => throw new InvalidDataException($"Unrecognized card suit: {cardParts[2]}"),
                    };

                    var value = cardParts[0]?.ToUpper() switch
                    {
                        "ACE" => Values.Ace,
                        "TWO" => Values.Two,
                        "THREE" => Values.Three,
                        "FOUR" => Values.Four,
                        "FIVE" => Values.Five,
                        "SIX" => Values.Six,
                        "SEVEN" => Values.Seven,
                        "EIGHT" => Values.Eight,
                        "NINE" => Values.Nine,
                        "TEN" => Values.Ten,
                        "JACK" => Values.Jack,
                        "QUEEN" => Values.Queen,
                        "KING" => Values.King,
                        _ => throw new InvalidDataException($"Unrecognized card value: {cardParts[0]}"),
                    };

                    Add(new Card(value, suit));
                }
            }
        }

        public Deck Reset()
        {
            Clear();
            Array allSuits = Enum.GetValues(typeof(Suits));
            Array allValues = Enum.GetValues(typeof(Values));

            for (int i = 0; i < allSuits.Length; i++)
            {
                for (int j = 0; j < allValues.Length; j++)
                {
                    Add(new Card((Values)allValues.GetValue(j), (Suits)allSuits.GetValue(i)));
                }
            }

            return this;
        }

        public Card Deal(int index)
        {
            Card card = base[index];
            RemoveAt(index);
            return card;
        }

        public Deck Shuffle()
        {
            List<Card> copy = new(this);
            Clear();

            while (copy.Count > 0)
            {
                Card card = copy[random.Next(0, copy.Count)];
                Add(card);
                copy.Remove(card);
            }

            return this;
        }

        public Deck Sort()
        {
            List<Card> sortedCards = new(this);
            sortedCards.Sort(new CardComparerByValue());
            Clear();

            foreach (Card card in sortedCards)
            {
                Add(card);
            }

            return this;
        }

        public void WriteCards(string filename)
        {
            using StreamWriter sw = new(filename);

            foreach (var card in this)
            {
                sw.WriteLine(card);
            }
        }
    }
}
