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

            //1000 is a large enough number to reduce the the chance of getting the same color in the first position
            //beyond probable infinity (1/8)^1000
            for (int i = 0; i < 1000; i++)
            {
                colors.Add(gameHandler.GetInitialColors());
            }

            Assert.IsTrue(colors.GroupBy(f => f.First()).Count() > 1, "Colors returned by GameHandler does not appear to be random.");
        }

        [TestMethod]
        public void GameHandlerReturnsTrueForCorrectResult()
        {
            GameHandler gameHandler = new GameHandler();

            var correctGuess = gameHandler.GetInitialColors();

            Assert.IsTrue(gameHandler.Guess(correctGuess), "GameHandler evaluates a guess incorrectly");
        }

        [TestMethod]
        public void GameHandlerReturnsFalseForIncorrectResult()
        {
            GameHandler gameHandler = new GameHandler();
            
            var incorrectGuess = gameHandler.GetInitialColors().ToArray();

            if (incorrectGuess.First() == GameColors.Black)
                incorrectGuess[0] = GameColors.White;
            else
                incorrectGuess[0] = GameColors.Black;

            Assert.IsFalse(gameHandler.Guess(incorrectGuess.ToList()), "GameHandler evaluates a guess incorrectly");
        }



    }
}
