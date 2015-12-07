using System;

namespace PlayingCards
{
    public class Card
    {
        public Card(rank r, suit s)
        {
            Rank = r;
            Suit = s;
        }

        public rank Rank { get; private set; }

        public suit Suit { get; private set; }

        public override string ToString()
        {
            return Rank + " of " + Suit;
        }
    }
}
