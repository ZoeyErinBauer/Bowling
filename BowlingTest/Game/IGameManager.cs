using Bowling.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Game
{
    public interface IGameManager
    {
        void AddFrame(IFrame frame);

        Tuple<int, string> GetScore();

        bool isGameOver();

        string GetGameMessage();

        /// <summary>
        /// This should really have an input mock test something along the lines of Spec Flow but honestly
        /// I've never written e2e tests for a console application
        /// </summary>
        void GameUpdate();

    }
}
