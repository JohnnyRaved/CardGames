using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PlayingCards;

namespace PlayingCards.Tests
{
    [TestClass()]
    public class DeckTests
    {
        [TestMethod]
        public void NoArgs()
        {
            var deck = new PlayingCards.Deck();
            Assert.IsNotNull(deck);
        }

        [TestMethod]
        public void CardCount()
        {
            var deck = new Deck();
            Assert.IsTrue(deck.Cards.Count == 52);
        }

        [TestMethod]
        public void MyriadDecks()
        {
            List<Deck> list = new List<Deck>();

            for (int i = 0; i < 10000; i++)
            {
                Deck deck = new Deck();
                list.Add(deck);
            }
        }
    }
}