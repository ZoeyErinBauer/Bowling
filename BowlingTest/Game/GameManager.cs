using Bowling.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Game
{
    public class GameManager : IGameManager
    {
        /// <summary>
        /// Frame value could be specified here using a sorted list,(rather than in the frame class),
        /// I was really just looking for an excuse to play with linq.
        /// </summary>
        private readonly List<IFrame> gameFrames;
        private string gameMessage = "";

        public GameManager()
        {
            gameFrames = new List<IFrame>();
        }

        /// <summary>
        /// Used if a frame is needed to be manually added otherwise <see cref="GameUpdate"/> handles this
        /// </summary>
        /// <param name="frame"></param>
        public void AddFrame(IFrame frame)
        {
            gameFrames.Add(frame);
        }

        public void GameUpdate()
        {
            Console.WriteLine($"On Frame {gameFrames.Count+1}");
            int throw1 = GetNumberInput("Enter Throw Score: ");
            int throw2 = 0;
            int throw3 = 0;
            if(throw1 != 10 || (throw1 == 10 && gameFrames.Count>=9))
            {
                throw2 = GetNumberInput("Enter Throw Score: ");
            }
            if (gameFrames.Count >= 9)
            {
                if(throw1 + throw2 >= 10)
                {
                    throw3 = GetNumberInput("Enter Throw Score: ");
                }
                AddFrame(FrameFactory.CreateFrame(9, throw1, throw2, throw3));
            }
            else if (gameFrames.Count == 1)
            {
                AddFrame(FrameFactory.CreateFrame(1, throw1, throw2));
            }
            else
            {
                AddFrame(FrameFactory.CreateFrame(gameFrames.Count - 1, throw1, throw2));
            }
            
            CalculateScore();
            if (isGameOver())
            {
                if(GetNumberInput("Play again? 1. Yes 2. No ") == 1)
                {
                    StartNewGame();
                }
                else
                {
                    Console.WriteLine("Thank you for playing press any key to quit. ");
                    Console.ReadKey();
                }
            }
        }

        private void StartNewGame()
        {
            gameFrames.Clear();
        }
        private IFrame GetCurrentFrame()
        {
            return gameFrames.OrderBy(x => x.GetFrameNumber()).Last();
        }

        public string GetGameMessage()
        {
            return gameMessage;
        }

        public Tuple<int, string> GetScore()
        {
            return new Tuple<int, string>(CalculateScore(), gameMessage);
        }

        public bool isGameOver()
        {
            try
            {
                return (GetCurrentFrame().GetFrameNumber() >= 9);
            }
            //Lazy catch to stop it from erroring out if the game hasn't started yet
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Logic for calculating score is here
        /// </summary>
        /// <returns>Total Score</returns>
        private int CalculateScore()
        {
            int tempTotal = 0;
            gameFrames.OrderBy(x => x.GetFrameNumber());
            foreach (IFrame frame in gameFrames)
            {
                switch (frame.GetFrameStatus())
                {
                    case FrameStatus.None:
                        tempTotal += frame.GetTotalScore();
                        gameMessage = "";
                        break;
                    case FrameStatus.Spare:
                        // Logic here stops the scoring and returns current total if next frame is unavailable
                        tempTotal += frame.GetTotalScore();
                        if (gameFrames.Count > frame.GetFrameNumber() + 1)
                        {
                            tempTotal += gameFrames[frame.GetFrameNumber() + 1].GetScore(ScoreEnum.One);
                            break;
                        }
                        gameMessage = "Waiting for next roll to finish calculating score";
                        break;
                    case FrameStatus.Strike:
                        tempTotal += frame.GetTotalScore();
                        if (gameFrames.Count > frame.GetFrameNumber() + 1)
                        {
                            tempTotal += gameFrames[frame.GetFrameNumber() + 1].GetTotalScore();
                            break;
                        }
                        if(gameFrames.Count == 10)
                        {
                            gameMessage = "Game Over";
                            break;
                        }
                        gameMessage = "Waiting on next frame to finish calculating score";
                        break;
                }
            }
            Console.WriteLine($"Current Score {tempTotal} \n");
            Console.WriteLine($"{gameMessage} \n");
            return tempTotal;
        }

        private int GetNumberInput(string questionText)
        {
            double val = 0;
            string num = "";
            Console.Write(questionText);
            ConsoleKeyInfo chr;
            do
            {
                chr = Console.ReadKey(true);
                if (chr.Key != ConsoleKey.Backspace)
                {
                    bool control = double.TryParse(chr.KeyChar.ToString(), out val);
                    if (control)
                    {
                        num += chr.KeyChar;
                        Console.Write(chr.KeyChar);
                    }
                }
                else

                {
                    if (chr.Key == ConsoleKey.Backspace && num.Length > 0)
                    {
                        num = num.Substring(0, (num.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (chr.Key != ConsoleKey.Enter);
            Console.WriteLine("\n");
            return int.Parse(num);
        }
    }
}
