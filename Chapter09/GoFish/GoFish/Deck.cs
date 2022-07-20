using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GoFish
{
    public class Deck : ObservableCollection<Card>
    {
        private static readonly Random random = Player.Random;

        public Deck()
        {
            Reset();
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
    }
}
