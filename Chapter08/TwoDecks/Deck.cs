using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoDecks
{
    class Deck : ObservableCollection<Card>
    {
        private static Random random = new Random();

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
            List<Card> copy = new List<Card>(this);
            Clear();

            while (copy.Count > 0)
            {
                Card card = copy[random.Next(0, copy.Count)];
                Add(card);
                copy.Remove(card);
            }
        }

        public void Sort()
        {
            List<Card> sortedCards = new List<Card>(this);
            sortedCards.Sort(new CardComparerByValue());
            Clear();

            foreach (Card card in sortedCards)
            {
                Add(card);
            }
        }
    }
}
