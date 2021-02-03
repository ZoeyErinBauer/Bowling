using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Frames
{
    /// <summary>
    /// This enum allows for referencing different frames so we only have one score set method 
    /// </summary>
    public enum ScoreEnum
    {
        One,
        Two,
        Three
    }

    public enum FrameStatus
    {
        None,
        Spare,
        Strike
    }
}
