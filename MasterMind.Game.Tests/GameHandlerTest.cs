using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MasterMind.Game.Tests
{
    [TestClass]
    public class GameHandlerTest
    {
        [TestMethod]
        public void GameHandlerReturnsASequenceOfColors()
        {
            GameHandler gameHandler = new GameHandler();

            var colors = gameHandler.GetInitialColors();

            Assert.IsNotNull(colors, "GameHandler returns null for initial colors");
        }

        [TestMethod]
        public void GameHandlerReturnsFourColors()
        {
            GameHandler gameHandler = new GameHandler();

            var colors = gameHandler.GetInitialColors();

            Assert.AreEqual(4, colors.Count, "GameHandler does not return the appropriate amount of colors");
        }

        [TestMethod]
        public void GameHandlerReturnsRandomColors()
        {
            GameHandler gameHandler = new GameHandler();

            List<List<GameColors>> colors = new List<List<GameColors>>();

            for (int i = 0; i < 10000; i++)
            {
                colors.Add(gameHandler.GetInitialColors());
            }

            Assert.IsTrue(colors.GroupBy(f => f.First()).Count() > 1, "Colors returned by GameHandler does not appear to be random.");
        }
    }
}
