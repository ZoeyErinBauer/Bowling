using Bowling.Game;
using System;

namespace BowlingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameManager gameManager = new GameManager();
            //Starts the game
            while (!gameManager.isGameOver())
            {
                gameManager.GameUpdate();

            }

        }
    }
}
