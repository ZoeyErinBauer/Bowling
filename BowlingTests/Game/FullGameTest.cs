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
    public class FullGameTest
    {
        private IGameManager gameManager;


        [OneTimeSetUp]
        public void Setup()
        {
            gameManager = new GameManager();
            gameManager.AddFrame(new Frame(0, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = 4,
                [ScoreEnum.Two] = 3
            }, FrameStatus.None));
            gameManager.AddFrame(new Frame(1, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = 7,
                [ScoreEnum.Two] = 3
            }, FrameStatus.Spare));
            gameManager.AddFrame(new Frame(2, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = 5,
                [ScoreEnum.Two] = 2
            }, FrameStatus.None));
            gameManager.AddFrame(new Frame(3, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = 8,
                [ScoreEnum.Two] = 1
            }, FrameStatus.None));
            gameManager.AddFrame(new Frame(4, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = 4,
                [ScoreEnum.Two] = 6
            }, FrameStatus.Spare));
            gameManager.AddFrame(new Frame(5, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = 2,
                [ScoreEnum.Two] = 4
            }, FrameStatus.None));
            gameManager.AddFrame(new Frame(6, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = 8,
                [ScoreEnum.Two] = 0
            }, FrameStatus.None));
            gameManager.AddFrame(new Frame(7, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = 8,
                [ScoreEnum.Two] = 0
            }, FrameStatus.None));
            gameManager.AddFrame(new Frame(8, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = 8,
                [ScoreEnum.Two] = 2
            }, FrameStatus.Spare));
            gameManager.AddFrame(new Frame(9, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = 10,
                [ScoreEnum.Two] = 1,
                [ScoreEnum.Three] = 7
            }, FrameStatus.Strike));
        }


        [Test]
        public void CheckFinalScore()
        {
            var result = gameManager.GetScore();
            Assert.AreEqual(110, result.Item1);
            Assert.AreEqual("Game Over", result.Item2);
        }
    }
}
