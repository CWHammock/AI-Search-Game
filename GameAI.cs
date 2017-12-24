using System;
using System.Collections.Generic;
using System.Text;

namespace SnapBackGame
{
    class GameAI
    {

        GameState gameState { get; set; }

        public GameAI(GameState game, int roll)
        {
            gameState = new GameState(game.PlayerPosition, game.ComputerPosition, roll);
        }

        public int Decision()
        {
            int choice = 0;
            GameState parentNodeTakeMove = new GameState(gameState.PlayerPosition, gameState.ComputerPosition);
            parentNodeTakeMove.ComputerMoveForward(gameState.Roll);
            int tilesBetweenParentTake = parentNodeTakeMove.TilesBetweenPlayers();
            if (tilesBetweenParentTake > 0) { tilesBetweenParentTake = 1; }
            if (tilesBetweenParentTake < 0) { tilesBetweenParentTake = -1; }
            int parentTakeChildTakeRolls = PositiveMovesPlayerTakeMove(parentNodeTakeMove);
            Game.WriteToFile("Computer Take Player Take Value: " + parentTakeChildTakeRolls);
            int parentTakeChildGiveRolls = PositivePlayerGivesMove(parentNodeTakeMove);
            Game.WriteToFile("Computer Take Player Give Value: " + parentTakeChildGiveRolls);
            int takeRollValue = tilesBetweenParentTake + parentTakeChildTakeRolls + parentTakeChildGiveRolls;


            GameState parentNodeGiveMove = new GameState(gameState.PlayerPosition, gameState.ComputerPosition);
            parentNodeGiveMove.PlayerMoveBack(gameState.Roll);
            int tilesBetweenParentGive = parentNodeGiveMove.TilesBetweenPlayers();
            if (tilesBetweenParentGive > 0) { tilesBetweenParentGive = 1; }
            if (tilesBetweenParentGive < 0) { tilesBetweenParentGive = -1; }
            int parentGiveChildTakeRolls = PositiveMovesPlayerTakeMove(parentNodeGiveMove);
            Game.WriteToFile("Computer Give Player Take Value: " + parentGiveChildTakeRolls);
            int parentGiveChildGiveRolls = PositivePlayerGivesMove(parentNodeGiveMove);
            Game.WriteToFile("Computer Give Player Give Value: " + parentGiveChildGiveRolls);
            int giveRollValue = tilesBetweenParentGive + parentGiveChildTakeRolls + parentGiveChildGiveRolls;
            if (takeRollValue > giveRollValue || takeRollValue == giveRollValue) { choice = 1; }

            return choice;
        }

        private int PositiveMovesPlayerTakeMove(GameState state)
        {
            
            GameState rollOne = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollOne.PlayerMoveForward(1);
            int tilesForwardRollOne = rollOne.TilesBetweenPlayers();
            if (tilesForwardRollOne > 0) { tilesForwardRollOne = 1; }
            if (tilesForwardRollOne < 0) { tilesForwardRollOne = -1; }

            GameState rollTwo = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollTwo.PlayerMoveForward(2);
            int tilesForwardRollTwo = rollTwo.TilesBetweenPlayers();
            if (tilesForwardRollTwo > 0) { tilesForwardRollTwo = 1; }
            if (tilesForwardRollTwo < 0) { tilesForwardRollTwo = -1; }

            GameState rollThree = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollThree.PlayerMoveForward(3);
            int tilesForwardRollThree = rollThree.TilesBetweenPlayers();
            if (tilesForwardRollThree > 0) { tilesForwardRollThree = 1; }
            if (tilesForwardRollThree < 0) { tilesForwardRollThree = -1; }

            GameState rollFour = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollFour.PlayerMoveForward(4);
            int tilesForwardRollFour = rollFour.TilesBetweenPlayers();
            if (tilesForwardRollFour > 0) { tilesForwardRollFour = 1; }
            if (tilesForwardRollFour < 0) { tilesForwardRollFour = -1; }

            int totalTiles = tilesForwardRollOne + tilesForwardRollTwo + tilesForwardRollThree + tilesForwardRollFour;
            
            return totalTiles;
        }
        private int PositivePlayerGivesMove(GameState state)
        {

            GameState rollOne = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollOne.ComputerMoveBack(1);
            int tilesBackRollOne = rollOne.TilesBetweenPlayers();
            if (tilesBackRollOne > 0) { tilesBackRollOne = 1; }
            if (tilesBackRollOne < 0) { tilesBackRollOne = -1; }

            GameState rollTwo = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollTwo.ComputerMoveBack(2);
            int tilesBackRollTwo = rollTwo.TilesBetweenPlayers();
            if (tilesBackRollTwo > 0) { tilesBackRollTwo = 1; }
            if (tilesBackRollTwo < 0) { tilesBackRollTwo = -1; }

            GameState rollThree = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollThree.ComputerMoveBack(3);
            int tilesBackRollThree = rollThree.TilesBetweenPlayers();
            if (tilesBackRollThree > 0) { tilesBackRollThree = 1; }
            if (tilesBackRollThree < 0) { tilesBackRollThree = -1; }

            GameState rollFour = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollFour.ComputerMoveBack(4);
            int tilesBackRollFour = rollFour.TilesBetweenPlayers();
            if (tilesBackRollFour > 0) { tilesBackRollFour = 1; }
            if (tilesBackRollFour < 0) { tilesBackRollFour = -1; }

            int totalTiles = tilesBackRollOne + tilesBackRollTwo + tilesBackRollThree + tilesBackRollFour;
    
            return totalTiles;
        }

    }
}
