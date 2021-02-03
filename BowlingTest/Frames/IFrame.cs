using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Frames
{
    public interface IFrame
    {
        int GetFrameNumber();

        int GetScore(ScoreEnum scoreEnum);

        //Gets total for this frame
        int GetTotalScore();

        void SetScore(ScoreEnum scoreEnum, int scoreValue);

        void SetFrameStatus(FrameStatus status);

        FrameStatus GetFrameStatus();
    }
}
