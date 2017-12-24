using System;
using System.Collections.Generic;
using System.Text;

namespace SnapBackGame
{
    class Propositional
    {
        public GameState GameState { get; set; }

        public Propositional(GameState state, int Roll)

        {
            GameState = new GameState(state.PlayerPosition, state.ComputerPosition, Roll);
        }

        public int Decision()
        {
            int choice = PropositionalCheck();
            return choice;
        }

        private int PropositionalCheck()
        {
            int choice;
            Game.WriteToFile("Calculation is " + (((double)(GameState.TilesBetweenPlayers()) /24.00)));
            if (((double)(GameState.TilesBetweenPlayers()) / 24.00) < .15)
            {
                Game.WriteToFile("Condition 1 met. ");
                choice = 1;
            }
            if ((GameState.PlayerPosition + 3 > 24) || (GameState.PlayerPosition + 4 > 24))
            {
                Game.WriteToFile("Condition 2 met. ");
                choice = 0;
            }
            if (((GameState.PlayerPosition + 3 == 6) || (GameState.PlayerPosition + 3 == 12) ||
                (GameState.PlayerPosition + 3 == 18) || (GameState.PlayerPosition + 4 == 6) ||
                (GameState.PlayerPosition + 4 == 12) || (GameState.PlayerPosition + 4 == 18)) &&
                    (((double)(GameState.TilesBetweenPlayers()) / 24.00) < .15))
            {
                Game.WriteToFile("Condition 3 met. ");
                choice = 0;
            }

            if ((GameState.ComputerPosition + GameState.Roll == 6) ||
                    (GameState.ComputerPosition + GameState.Roll == 12) ||
                    (GameState.ComputerPosition + GameState.Roll == 18))
            {
                Game.WriteToFile("Condition 4 met. ");
                choice = 1;
            }
            if (GameState.ComputerPosition + GameState.Roll > 24)
            {
                Game.WriteToFile("Condition 5 met. ");
                choice = 1;
            }
            if ((GameState.ComputerPosition + GameState.Roll == 23) || 
                (GameState.ComputerPosition + GameState.Roll == 24))
            {
                Game.WriteToFile("Condition 6 met. ");
                choice = 0;
            }
            else { choice = 1;  }
            return choice;
        }
    }
}
