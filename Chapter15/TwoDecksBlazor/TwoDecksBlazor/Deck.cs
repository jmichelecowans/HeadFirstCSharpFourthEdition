using System;
using System.Collections.Generic;

namespace TwoDecksBlazor
{
    class Deck : List<Card>
    {
        private static readonly Random _random = new();

        public Deck()
        {
            Reset();
        }

        public void Reset()
        {
            Clear();
            Array allSuits = Enum.GetValues(typeof(Suits));
            Array allValues = Enum.GetValues(typeof(Values));

            for (int i = 0; i < allSuits.Length; i++)
            {
                for (int j = 0; j < allValues.Length; j++)
                {
                    Add(new Card((Suits)allSuits.GetValue(i), (Values)allValues.GetValue(j)));
                }
            }
        }

        public Card Deal(int index)
        {
            Card card = base[index];
            RemoveAt(index);
            return card;
        }

        public void Shuffle()
        {
            List<Card> copy = new(this);
            Clear();

            while (copy.Count > 0)
            {
                Card card = copy[_random.Next(0, copy.Count)];
                Add(card);
                copy.Remove(card);
            }
        }
    }
}
