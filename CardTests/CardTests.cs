using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Concurrent;
using System;

namespace PlayingCards.Tests
{
    [TestClass()]
    public class CardTests
    {
        [TestMethod()]
        public void NoArgsExpectsNotNull()
        {
            // Arrange
            var deck = new Deck();

            // Assert
            Assert.IsNotNull(deck);
        }

        [TestMethod()]
        public void CardCountExpects52Cards()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var count = deck.Cards.Count;
            Console.WriteLine("Count is: {0} ", count.ToString());

            // Assert
            Assert.IsTrue(count==52);
        }

        [TestMethod()]
        public void Dealing5CardsExpect5Cards()
        {
            // Arrange
            var newDeck = new Deck();
            var hand = new ConcurrentDictionary<int, Card>();

            // Act
            hand = newDeck.Deal(hand,5);

            // Assert
            Assert.IsTrue(hand.Count == 5);
            Assert.IsTrue(newDeck.Cards.Count == 47);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooManyCardsNeededExpectException()
        {
            // Arrange
            var newDeck = new Deck();
            var hand = new ConcurrentDictionary<int, Card>();

            // Act
            hand = newDeck.Deal(hand, 53);

            // Assert

        }
        [TestMethod()]
        public void ShowDealtCardsToConsole()
        {
            // Arrange
            var newDeck = new Deck();
            var hand = new ConcurrentDictionary<int, Card>();

            // Act
            hand = newDeck.Deal(hand, 5);

            // Show
            foreach (var card in hand)
            {
                Console.WriteLine(card);
            }

        }
    }
}