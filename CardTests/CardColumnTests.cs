using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PlayingCards;

namespace CardTests
{
    [TestClass]
    public class CardColumnTests
    {
        [TestMethod]
        public void NewCardColumnNotNull()
        {
            // Arrange
            var gameDeck = new Deck();

            // Act
            var gameColumn1 = new CardColumn(gameDeck, 10);

            // Assert
            Assert.IsNotNull(gameColumn1);
        }

        [TestMethod]
        public void NewCardColumnWith10Cards()
        {
            // Arrange
            var gameDeck = new Deck();

            // Act
            var gameColumn1 = new CardColumn(gameDeck, 10);

            // Assert
            Assert.AreEqual(gameColumn1.Column.Count, 10);
        }

        [TestMethod]
        public void GetCardsUpFromColumnWithNone_NotNull()
        {
            // Arrange
            var gameDeck = new Deck();
            var gameColumn = new CardColumn(gameDeck, 10);

            // Act
            List<int> cardsUpList;
            cardsUpList = gameColumn.GetVisibleCards();

            // Assert
            Assert.IsNotNull(cardsUpList);
        }

        [TestMethod]
        public void GetCardsUpFromColumnWithOne()
        {
            // Arrange
            var gameDeck = new Deck();
            var gameColumn = new CardColumn(gameDeck, 10);
            gameColumn.TurnCardUp(gameColumn.Column[5]);

            // Act
            List<int> cardsUpList;
            cardsUpList = gameColumn.GetVisibleCards();

            // Assert
            Assert.AreEqual(cardsUpList.Count, 1);
        }

        [TestMethod]
        public void GetCardsUpWithUpperLimit()
        {
            // Arrange
            var gameDeck = new Deck();
            var gameColumn = new CardColumn(gameDeck, 10);
            for (int i = 0; i < 10; i++)
            {
                gameColumn.TurnCardUp(gameColumn.Column[i]);
            }

            // Act
            List<int> cardsUpList;
            cardsUpList = gameColumn.GetVisibleCards();

            // Assert
            Assert.AreEqual(cardsUpList.Count, 10);

        }

    }
}
