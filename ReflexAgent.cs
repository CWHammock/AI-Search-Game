using System;
using System.Collections.Generic;
using System.Text;

namespace SnapBackGame
{
    class ReflexAgent
    {
        GameState gameState { get; set; }

        public ReflexAgent(GameState game, int roll)
        {
            gameState = new GameState(game.PlayerPosition, game.ComputerPosition, roll);
        }

        public void ShowStats()
        {
            Console.WriteLine("Computer Position is {0}", gameState.ComputerPosition);
            Console.WriteLine("Player Position is {0}", gameState.PlayerPosition);
            Console.WriteLine("Computer roll is {0}", gameState.Roll);
        }
        public int Decision()
        {
            //1 if to move points, 2 if to give points
            int shouldMove = 1;
            if ((gameState.ComputerPosition < gameState.PlayerPosition)  ||
                ((gameState.ComputerPosition + gameState.Roll == 23) ||
                (gameState.ComputerPosition + gameState.Roll == 24)))
            {
                shouldMove = 0;
            }
            
            return shouldMove;
        }

    }
}
