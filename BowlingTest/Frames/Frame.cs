using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Frames
{
    public class Frame : IFrame
    {
        private readonly int frameNumber;
        private readonly Dictionary<ScoreEnum, int> scoreDictionary;
        private FrameStatus status;

        public Frame(int frameNumber, Dictionary<ScoreEnum, int> scoreDictionary)
        {
            this.frameNumber = frameNumber;
            this.scoreDictionary = scoreDictionary;
            status = FrameStatus.None;
        }

        public Frame(int frameNumber, Dictionary<ScoreEnum,int> scoreDictionary, FrameStatus status)
        {
            this.frameNumber = frameNumber;
            this.scoreDictionary = scoreDictionary;
            this.status = status;
        }

        public int GetFrameNumber()
        {
            return frameNumber;
        }

        public FrameStatus GetFrameStatus()
        {
            return status;
        }

        public int GetScore(ScoreEnum scoreEnum)
        {
            return scoreDictionary[scoreEnum];
        }

        public int GetTotalScore()
        {
            return scoreDictionary.Values.Sum();
        }

        public void SetFrameStatus(FrameStatus status)
        {
            this.status = status;
        }

        public void SetScore(ScoreEnum scoreEnum, int scoreValue)
        {

            scoreDictionary[scoreEnum] = scoreValue;
        }
    }
}

