using System;
using System.Collections.Generic;
using System.Text;

namespace SnapBackGame
{
    class ConstraintAI
    {
        public GameState GameState { get; set; }
        //list of blocks that the computer does not want to step on
        public List<int> ConstraintList = new List<int> { 23, 24 };


        public ConstraintAI(GameState state, int Roll)
            
        {
            GameState = new GameState(state.PlayerPosition, state.ComputerPosition, Roll);
        }

        public int Decision()
        {
            int choice = ConstraintCheck();
            return choice;
        }

        private int ConstraintCheck()
        {
            int choice = 1;
            int computerMove = GameState.ComputerPosition + GameState.Roll;
            if (ConstraintList.Contains(computerMove))
            {
                choice = 0;
                Game.WriteToFile("Checked Constraint List and a move from " + GameState.ComputerPosition
                        + " to " + computerMove
                        + " does show on the list.");
            }
            else
            {
                Game.WriteToFile("Checked Constraint List and a move from " + GameState.ComputerPosition
                        + " to " + computerMove
                        + " does not show on the list.");
            }
            return choice;
        }
    }
}
