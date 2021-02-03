using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Frames
{
    /// <summary>
    /// Simple factory to return frames with predefined score amounts
    /// </summary>
    public static class FrameFactory
    {
        public static IFrame CreateFrame(int frameNumber, int scoreOne, int scoreTwo, int? scoreThree = null)
        {
            FrameStatus frameStat = (scoreOne == 10 ? FrameStatus.Strike : 
                                        (scoreOne + scoreTwo == 10 ? FrameStatus.Spare : FrameStatus.None));
            if (frameNumber.Equals(9))
            {
                return new Frame(frameNumber, new Dictionary<ScoreEnum, int>()
                {
                    [ScoreEnum.One] = scoreOne,
                    [ScoreEnum.Two] = scoreTwo,
                    [ScoreEnum.Three] = scoreThree.Value
                },frameStat);
            }
            return new Frame(frameNumber, new Dictionary<ScoreEnum, int>()
            {
                [ScoreEnum.One] = scoreOne,
                [ScoreEnum.Two] = scoreTwo,
            },frameStat);
        }
    }
}
