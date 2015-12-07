using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayingCards;

namespace PlayingCardTests
{
    [TestClass]
    public class Construction
    {    
         [TestMethod]
        public void NoArgs()
        {
            var deck = new Deck();
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
                foreach (var card in deck.Cards)
                {
                    Console.Write(card +", ");
                }
            }
        }
    }
}
