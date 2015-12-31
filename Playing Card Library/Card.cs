using System;

namespace PlayingCards
{
    /// <summary>
    /// A playing card of rank and suit
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Primary Constructor
        /// </summary>
        /// <param name="r">Rank</param>
        /// <param name="s">Suit</param>
        public Card(rank r, suit s)
        {
            Rank = r;
            Suit = s;
            IsFaceDown = true;
        }
        /// <summary>
        /// Indicates whether a card is visible to the player.
        /// </summary>
        public bool IsFaceDown { get; private set; }

        public rank Rank { get; private set; }

        public suit Suit { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> A string representing the rank and suit of a card</returns>
        public override string ToString()
        {
            return Rank + " of " + Suit;
        }
    }
}
