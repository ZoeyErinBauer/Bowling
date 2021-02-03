using Bowling.Frames;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingTests.FrameTests
{
    [TestOf("Frame")]
    public class FrameTests
    {
        private Frame frame;
        [SetUp]
        public void Setup()
        {
            frame = new Frame(1, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = 7
            }
         );
        }

        [Test]
        [TestCase(ExpectedResult = FrameStatus.None)]
        public FrameStatus TestFrameStatus()
        {
            return frame.GetFrameStatus();
        }

        [Test]
        [TestCase(ExpectedResult = 1)]
        public int TestFrameNumber()
        {
            return frame.GetFrameNumber();
        }

        [Test]
        [TestCase(ExpectedResult = 7)]
        public int TestScore()
        {
            return frame.GetScore(ScoreEnum.One);
        }
    }
}
