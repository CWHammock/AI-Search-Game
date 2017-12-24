using System;
using System.Collections.Generic;
using System.Text;

namespace SnapBackGame
{
    class Player
    {

        public int Position { get; set; }
        public string Name { get; set; }
        public int Move { get; set; }
        public int Roll { get; set; }
        public List<int> RollHistory { get; set; }

        public Player(string name)
        {
            this.Name = name;
            this.Position = 0;
            RollHistory = new List<int>();
        }
        public int HumanTurn()
        {
            this.Roll = PlayerRoll();
            PrintRoll(this, Roll);
            RollHistory.Add(Roll);
            int numChoice = 1; // this.PlayerChoice(this.Roll);
            this.Move += 1;
            return numChoice;
        }
        public int AITurn(int player1Position, int player2Position)
        {
            this.Roll = PlayerRoll();
            PrintRoll(this, Roll);
            GameState gameState = new GameState(player1Position, player2Position);
            ReflexAgent decisionMaker = new ReflexAgent(gameState, Roll);
            int numChoice = decisionMaker.Decision();
            this.Move += 1;
            return numChoice;
        }
        public static int PlayerRoll()
        {
            Random randomNumber = new Random();
            int rand = randomNumber.Next(1, 5);

            return rand;
        }
        public int PlayerChoice(int roll)
        {
            Console.WriteLine("Your roll was {0}, do you want to keep it or give it to computer?", roll);
            Console.WriteLine("Keep it enter number 1       To give it enter number 2");
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2")
            {
                Console.WriteLine("Please enter a valid choice (type 1 or 2): ");
                choice = Console.ReadLine();
            }
            int numChoice;
            bool convert = Int32.TryParse(choice, out numChoice);
            return numChoice;
        }
        public static void PrintRoll(Player player, int roll)
        {
            Console.WriteLine(player.Name + " rolled a " + roll + ".");
            Game.WriteToFile(player.Name + " rolled a  " + roll.ToString() + ".");
        }

    }
}
