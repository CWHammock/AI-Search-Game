using System;
using System.Collections.Generic;
using System.Text;

namespace SnapBackGame
{
    class StartGame
    {
        static void Main(string[] args)
        {
            Game newGame = new Game();
            while (true)
            {
                int position = newGame.Player1Turn();
                if (position > 24) { break;  }
                position = newGame.Player2Turn();
                if (position > 24) { break; }

            }
            Console.ReadKey();
        }
    }
}
