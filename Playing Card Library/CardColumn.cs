
using System;
using System.Collections.Generic;

namespace PlayingCards
{
    /// <summary>
    /// Represents a column of cards
    /// </summary>
    public class CardColumn
    {
        public Dictionary<int, Card> Column = new Dictionary<int, Card>();
        private List<int> visibleCards = new List<int>();
        public Deck GameDeck { get; private set; }

        /// <summary>
        /// Given a deck of cards and initial card count, creates a CardColumn
        /// </summary>
        /// <param name="deck">Deck of cards</param>
        /// <param name="initialCardCount">Number of cards to put in column</param>
        public CardColumn(Deck deck, int initialCardCount)
        {
            if (deck.Cards.Count < initialCardCount) throw new ArgumentOutOfRangeException();

            GameDeck = deck;
            Column = new Dictionary<int, Card>();
            Column = deck.Deal(Column, initialCardCount);
        }
        
        /// <summary>
        /// Returns a key list of cards visible to the user
        /// </summary>
        /// <returns>Null</returns>
        public List<int> GetVisibleCards()
        {
            List<int> visibleCards = new List<int>();

            foreach (KeyValuePair<int, Card> kvp in Column)
            {
                if (kvp.Value.IsFaceDown == false) visibleCards.Add(kvp.Key);
            }
            return visibleCards;
        }

        /// <summary>
        /// Makes a card 'visible'
        /// </summary>
        /// <param name="card"></param>
        public void TurnCardUp(Card card)
        {
            card.IsFaceDown = false;
        }

        /// <summary>
        /// Marks a card as 'invisible'
        /// </summary>
        /// <param name="card"></param>
        public void TurnCardDown(Card card)
        {
            card.IsFaceDown = true;
        }
    }
}
