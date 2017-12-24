using System;
using System.Collections.Generic;
using System.Text;

namespace SnapBackGame
{
    class GameState
    {
        public int PlayerPosition { get; set; }
        public int ComputerPosition { get; set; }
        public int Roll { get; set; }

        public GameState()
        {
            PlayerPosition = 0;
            ComputerPosition = 0;
            Roll = 0;
        }

        public GameState(int player1, int player2)
        {
            PlayerPosition = player1;
            ComputerPosition = player2;
            Roll = 0;
        }

        public GameState(int player1, int player2, int roll)
        {
            PlayerPosition = player1;
            ComputerPosition = player2;
            Roll = roll;
        }
        public int TilesBetweenPlayers()
        {
            return ComputerPosition - PlayerPosition;
        }
        public void PlayerMoveForward(int moveSpaces)
        {
            if (PlayerPosition + moveSpaces > 24)
            {
                PlayerPosition = 25;

            }
            else
            {
               PlayerPosition += moveSpaces;
            }
            if (PlayerPosition == 6 || PlayerPosition == 12 || PlayerPosition == 18)
            {
                ComputerMoveBack(moveSpaces);
            }
            //set opponent back the spaces if player lands on a snapback
            else
            {
                CheckEndSnapBackSpacesPlayer();
            }
        }
        public void ComputerMoveBack(int moveSpaces)
        {
            if ((
                ComputerPosition - moveSpaces) < 1)
            {
                ComputerPosition = 1;
            }
            else
            {
                ComputerPosition -= moveSpaces;
            }

        }
        public void CheckEndSnapBackSpacesPlayer()
        {
            if (PlayerPosition == 23 || PlayerPosition == 24)
            {
                PlayerPosition = 1;
            }
        }
        public void ComputerMoveForward(int moveSpaces)
        {
            if (ComputerPosition + moveSpaces > 24)
            {
                ComputerPosition = 25;

            }
            else
            {
                ComputerPosition += moveSpaces;
            }
            if (ComputerPosition == 6 || ComputerPosition == 12 || ComputerPosition == 18)
            {
                PlayerMoveBack(moveSpaces);
            }
            //set opponent back the spaces if player lands on a snapback
            else
            {
                CheckEndSnapBackSpacesComputer();
            }
        }
        public void PlayerMoveBack(int moveSpaces)
        {
            if ((
                PlayerPosition - moveSpaces) < 1)
            {
                PlayerPosition = 1;
            }
            else
            {
                PlayerPosition -= moveSpaces;
            }

        }
        public void CheckEndSnapBackSpacesComputer()
        {
            if (ComputerPosition == 23 || ComputerPosition == 24)
            {
                ComputerPosition = 1;
            }
        }
    }
}
