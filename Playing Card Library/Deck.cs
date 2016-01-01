using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PlayingCards
{

    public interface IShuffle
    {
        void Shuffle(Dictionary<int, Card> T);
    }

    /// <summary>
    /// Creates and manages a deck of 52 playing cards.
    /// The key for each card is unique within each deck.
    /// </summary>
    [Serializable]
    public class Deck : IShuffle
    {
        public static readonly List<suit> Suits = new List<suit>(Enum.GetValues(typeof(suit)).Cast<suit>());
        public static readonly List<rank> Ranks = new List<rank>(Enum.GetValues(typeof(rank)).Cast<rank>());

        public Dictionary<int, Card> Cards { get; private set; }

        /// <summary>
        /// Instantiates, shuffles, and returns a deck of cards.
        /// </summary>
        public Deck()
        {
            const int NumberOfCards = 52;
            Cards = new Dictionary<int, Card>(NumberOfCards);

            var cardIndex = 0;
            foreach (var s in Suits)
            {
                foreach (var r in Ranks)
                {
                    Cards.Add(cardIndex, new Card(r, s));
                    cardIndex++;
                }
            }
            ((IShuffle)this).Shuffle(Cards);
        }

        /// <summary>
        /// Shuffles a deck of cards.
        /// </summary>
        /// <param name="T"> A Deck of cards</param>
        void IShuffle.Shuffle(Dictionary<int, Card> T)
        {
            if (T != null)
            {
                Random RNG = new Random();

                var n = T.Count;
                while (n > 1)
                {
                    n--;
                    var k = RNG.Next(n + 1);
                    var value = T[k];
                    T[k] = T[n];
                    T[n] = value;
                }
            }
            else throw new NullReferenceException();
        }

        /// <summary>
        /// Deal removes cards from the deck and returns them in a hand.
        /// </summary>
        /// <param name="hand"> A subset of Cards used for play.</param>
        /// <param name="cardsNeeded"></param>
        /// <returns>hand with the number of cards needed (Requested)</returns>
        public Dictionary<int, Card> Deal(Dictionary<int, Card> hand, int cardsNeeded)
        {
            Debug.Assert(Cards != null, "ERROR: Cards is null upon invocation of Deck.Deal");
            if (Cards.Count < cardsNeeded) throw new ArgumentOutOfRangeException();

            List<int>availableKeys = new List<int>(cardsNeeded);
            availableKeys.AddRange(Cards.Keys.Take(cardsNeeded));
            foreach (var key in availableKeys)
            {
                hand.Add(key, Cards[key]);
                Cards.Remove(key);
            }
            return hand;
        }
    }
}




