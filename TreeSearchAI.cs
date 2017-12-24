using System;
using System.Collections.Generic;
using System.Text;

namespace SnapBackGame
{
    class TreeSearchAI
    {

        GameState gameState { get; set; }

        public TreeSearchAI(GameState game, int roll)
        {
            gameState = new GameState(game.PlayerPosition, game.ComputerPosition, roll);
        }

        public int Decision()
        {
            int choice = 0;
            GameState parentNodeTakeMove = new GameState(gameState.PlayerPosition, gameState.ComputerPosition);
            parentNodeTakeMove.ComputerMoveForward(gameState.Roll);
            int tilesBetweenParentTake = parentNodeTakeMove.TilesBetweenPlayers();
            int parentTakeChildTakeRollsAvg = AveragePlayerTakeMove(parentNodeTakeMove);
            Console.WriteLine("average tiles take are: {0}", parentTakeChildTakeRollsAvg);
            int parentTakeChildGiveRollsAvg = AveragePlayerGivesMove(parentNodeTakeMove);
            Console.WriteLine("average tiles give are: {0}", parentTakeChildGiveRollsAvg);
            int takeRollValue = tilesBetweenParentTake + parentTakeChildTakeRollsAvg + parentTakeChildGiveRollsAvg;


            GameState parentNodeGiveMove = new GameState(gameState.PlayerPosition, gameState.ComputerPosition);
            parentNodeGiveMove.PlayerMoveBack(gameState.Roll);
            int tilesBetweenParentGive = parentNodeGiveMove.TilesBetweenPlayers();
            int parentGiveChildTakeRollsAvg = AveragePlayerTakeMove(parentNodeGiveMove);
            Console.WriteLine("average tiles take are: {0}", parentGiveChildTakeRollsAvg);
            int parentGiveChildGiveRollsAvg = AveragePlayerGivesMove(parentNodeGiveMove);
            Console.WriteLine("average tiles give are: {0}", parentGiveChildGiveRollsAvg);
            int giveRollValue = tilesBetweenParentGive + parentGiveChildTakeRollsAvg + parentGiveChildGiveRollsAvg;
            if (takeRollValue > giveRollValue || takeRollValue == giveRollValue) { choice = 1;  }
            
            return choice;
        }

        private int AveragePlayerTakeMove(GameState state)
        {
            
            GameState rollOne = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollOne.PlayerMoveForward(1);
            int tilesForwardRollOne = rollOne.TilesBetweenPlayers();
           
            GameState rollTwo = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollTwo.PlayerMoveForward(2);
            int tilesForwardRollTwo = rollTwo.TilesBetweenPlayers();
            
            GameState rollThree = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollThree.PlayerMoveForward(3);
            int tilesForwardRollThree = rollThree.TilesBetweenPlayers();
            
            GameState rollFour = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollFour.PlayerMoveForward(4);
            int tilesForwardRollFour = rollFour.TilesBetweenPlayers();
            
            int totalTiles = tilesForwardRollOne + tilesForwardRollTwo + tilesForwardRollThree + tilesForwardRollFour;
            int averageTiles = totalTiles / 4;
            return averageTiles;
        }
        private int AveragePlayerGivesMove(GameState state)
        {

            GameState rollOne = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollOne.ComputerMoveBack(1);
            int tilesBackRollOne = rollOne.TilesBetweenPlayers();
            
            GameState rollTwo = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollTwo.ComputerMoveBack(2);
            int tilesBackRollTwo = rollTwo.TilesBetweenPlayers();
           
            GameState rollThree = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollThree.ComputerMoveBack(3);
            int tilesBackRollThree = rollThree.TilesBetweenPlayers();
          
            GameState rollFour = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollFour.ComputerMoveBack(4);
            int tilesBackRollFour = rollFour.TilesBetweenPlayers();
         
            int totalTiles = tilesBackRollOne + tilesBackRollTwo + tilesBackRollThree + tilesBackRollFour;
            int averageTiles = totalTiles / 4;
            return averageTiles;
        }

    }
}
