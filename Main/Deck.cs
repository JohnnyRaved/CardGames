using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PlayingCards
{
    [Serializable]
    public sealed class Deck 
    {
        private const int MaxThreads = 2;
        private const int NumberOfCards = 52;
        private static readonly Random RNG = new Random();

        public static readonly List<suit> Suits = new List<suit>(Enum.GetValues(typeof(suit)).Cast<suit>());
        public static readonly List<rank> Ranks = new List<rank>(Enum.GetValues(typeof(rank)).Cast<rank>());

        public ConcurrentDictionary<int, Card> Cards { get; private set; }

        public Deck()
        {
            Cards = new ConcurrentDictionary<int, Card>(MaxThreads, NumberOfCards);

            var cardIndex = 0;
            foreach (var s in Suits)
            {
                foreach (var r in Ranks)
                {
                    if (!Cards.TryAdd(cardIndex, new Card(r, s)))
                    {
                        Debug.WriteLine("WARNING: TryAdd failed when adding value to dictionary");
                    }
                    cardIndex++;
                }
            }
            Shuffle(Cards);
        }

        private void Shuffle(ConcurrentDictionary<int, Card> deck)
        {
            if (deck != null)
            {
                var n = deck.Count;
                while (n > 1)
                {
                    n--;
                    var k = RNG.Next(n + 1);
                    var value = deck[k];
                    deck[k] = deck[n];
                    deck[n] = value;
                }
            }
            else throw new NullReferenceException();
        }

    }
}

