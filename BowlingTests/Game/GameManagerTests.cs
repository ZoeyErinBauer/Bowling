using Bowling.Frames;
using Bowling.Game;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingTests.Game
{
    [TestOf("GameManager")]
    public class GameManagerTests
    {

        private IGameManager gameManager;


        [OneTimeSetUp]
        public void Setup()
        {
            gameManager = new GameManager();
            gameManager.AddFrame(new Frame(0, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = 7,
                [ScoreEnum.Two] = 2
            },FrameStatus.None));
        }

        [Test, Order(1)]
        public void TestScoreForOneFrame()
        {
            var result = gameManager.GetScore();
            Assert.AreEqual(9, result.Item1);
            Assert.AreEqual("", result.Item2);
        }

        [Test,Order(2)]
        public void TestSpareResponseMessage()
        {
            gameManager.AddFrame(new Frame(1, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = 7,
                [ScoreEnum.Two] = 3
            },FrameStatus.Spare));
            var result = gameManager.GetScore();
            Assert.AreEqual(19, result.Item1);
            Assert.AreEqual("Waiting for next roll to finish calculating score", result.Item2);
        }

        [Test, Order(3)]
        public void TestStrikeResponseMessage()
        {
            gameManager.AddFrame(new Frame(2, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = 10,
                [ScoreEnum.Two] = 0
            },FrameStatus.Strike));
            var result = gameManager.GetScore();
            Assert.AreEqual(39, result.Item1);
            Assert.AreEqual("Waiting on next frame to finish calculating score", result.Item2);
        }



    }
}
