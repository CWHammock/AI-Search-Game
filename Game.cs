using System;
using System.IO;

namespace SnapBackGame
{
    class Game
    {
        // number 1 is the 
        public static readonly int[] gameBoardMaster = { 0,1,0,0,0,0,5,
                                                           0,0,0,0,0,5,
                                                           0,0,0,0,0,5,
                                                           0,0,0,0,9,9 };
        private int[] gameBoardView;
        public Player Player1 { get; set; } 
        public Player Player2 { get; set; }

        public Game()
        {
            gameBoardView = new int[] { 0,1,0,0,0,0,5,
                                          0,0,0,0,0,5,
                                          0,0,0,0,0,5,
                                          0,0,0,0,9,9 };
        
            Player1 = new Player("Human Player");
            Player2 = new Player("AI Player");
        }

        public int Player1Turn()
        {
            
            MarkOnMap(Player1, Player2);
            PrintBoard(gameBoardView);
            PrintBoardToFile(gameBoardView);
            int choice = Player1.HumanTurn();
            if (choice == 1)
            {
                PlayerMoveForward(Player1.Roll, Player1, Player2);
                PrintMoveForward(Player1);

            }
            else
            {
                PlayerMoveBack(Player1.Roll, Player2);
                PrintMoveBack(Player2);
            }

            return Player1.Position;


        }
        public int Player2Turn()
        {
            int choice = Player2.AITurn(Player1.Position, Player2.Position);
            if (choice == 1)
            {
                if (Player2.Position < 24)
                {
                    PlayerMoveForward(Player2.Roll, Player2, Player1);
                    PrintMoveForward(Player2);
                }

            }
            else
            {
                PlayerMoveBack(Player2.Roll, Player1);
                PrintMoveBack(Player1);
            }
            return Player2.Position;
        }
        public void PlayerMoveForward(int moveSpaces, Player player, Player otherPlayer)
        {
            if (player.Position + moveSpaces > 24)
            { 
                PlayerWins(player);
                
            }
            player.Position += moveSpaces;
            if (player.Position == 6 || player.Position == 12 || player.Position == 18)
            {   
                PlayerMoveBack(moveSpaces, otherPlayer);
            }
            //set opponent back the spaces if player lands on a snapback
            else 
            {
                CheckEndSnapBackSpaces(player);
            }
        }
        public void PlayerMoveBack(int moveSpaces, Player player)
        {
            if((
                player.Position - moveSpaces) < 1)
            {
                player.Position = 1;
            } 
            else
            {
                player.Position -= moveSpaces;
            }

        }

        public void MoveForwardOnMap(Player player, int roll, int typeOfPlayer)
        {
            gameBoardView[player.Position] = gameBoardMaster[player.Position];
            
            
        }
        public void MarkOnMap(Player player1, Player player2)
        {
            gameBoardMaster.CopyTo(gameBoardView, 0);
            if (player1.Position < 25 && player2.Position < 25)
            {
                gameBoardView[player1.Position] = 3;
                gameBoardView[player2.Position] = 7;
            }
            else { return; }
        }
        
        //prints a view of the map for human player (3) and AI player (7)
        public void PrintBoard(int[] board)
        {
            int x = 0;
            for (int i = 1; i <= 24; i++)
            {

                Console.Write(board[i] + " ");
                x = x + 1;
                if (x == 6)
                {

                    Console.WriteLine(" ");
                    x = 0;
                }

            }
        }
        public void CheckEndSnapBackSpaces(Player player)
        {
            if (player.Position == 23 || player.Position == 24)
            {
                player.Position = 1;
            }
        }

        public static void WriteToFile(params string[] input)
        {
            File.AppendAllLines(@"C:\Users\Hammock\Desktop\SnapBackGame\ReflexAgent.txt", input);
        }
        public static void PrintBoardToFile(int[] board)
        {
            string stringBoard = String.Join(",", board);
            Game.WriteToFile(stringBoard);
        }
        public void PrintMoveForward(Player player)
        {
            Console.WriteLine("{0} is moved forward to block {1} of 24.", player.Name, player.Position);
            Game.WriteToFile(player.Name + " is moved forward to block " + player.Position.ToString() + " of 24");
        }
        public static void PlayerWins(Player player)
        {
            Console.WriteLine("{0} wins the contest on the {1} move.", player.Name, player.Move);
            Game.WriteToFile(player.Name + " wins the contest on the " + player.Move.ToString() + " move.");
        }
       
        public void PrintMoveBack(Player player)
        {
            Console.WriteLine("{0} is moved back to block {1} of 24.", player.Name, player.Position);
            Game.WriteToFile(player.Name + " is moved back to block " + player.Position.ToString() + " of 24");
        }
    }

}
