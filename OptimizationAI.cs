using System;
using System.Collections.Generic;
using System.Text;

namespace SnapBackGame
{
    class OptimizationAI
    {

        GameState gameState { get; set; }

        public OptimizationAI(GameState game, int roll)
        {
            gameState = new GameState(game.PlayerPosition, game.ComputerPosition, roll);
        }

        public int Decision()
        {
            int choice = 0;
            GameState parentNodeTakeMove = new GameState(gameState.PlayerPosition, gameState.ComputerPosition);
            parentNodeTakeMove.ComputerMoveForward(gameState.Roll);
            int tilesBetweenParentTake = parentNodeTakeMove.TilesBetweenPlayers();
            int parentTakeChildTake = MaxPlayerTakeMove(parentNodeTakeMove);
            Game.WriteToFile("Parent Take Player Take Max Value: " + parentTakeChildTake);
            int parentTakeChildGive = MaxPlayerGivesMove(parentNodeTakeMove);
            Game.WriteToFile("Parent Take Player Give Max Value: " + parentTakeChildGive);
            int takeRollValue = tilesBetweenParentTake + parentTakeChildTake + parentTakeChildGive;


            GameState parentNodeGiveMove = new GameState(gameState.PlayerPosition, gameState.ComputerPosition);
            parentNodeGiveMove.PlayerMoveBack(gameState.Roll);
            int tilesBetweenParentGive = parentNodeGiveMove.TilesBetweenPlayers();
            int parentGiveChildTake = MaxPlayerTakeMove(parentNodeGiveMove);
            Game.WriteToFile("Parent Give Player Take Max Value: " + parentGiveChildTake);
            int parentGiveChildGive = MaxPlayerGivesMove(parentNodeGiveMove);
            Game.WriteToFile("Parent Take Player Give Max Value: " + parentGiveChildGive);
            int giveRollValue = tilesBetweenParentGive + parentGiveChildTake + parentGiveChildGive;
            if (takeRollValue > giveRollValue || takeRollValue == giveRollValue) { choice = 1; }

            return choice;
        }

        private int MaxPlayerTakeMove(GameState state)
        {
            int maxValue = -99
                ;
            GameState rollOne = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollOne.PlayerMoveForward(1);
            int tilesForwardRollOne = rollOne.TilesBetweenPlayers();
            if (tilesForwardRollOne > maxValue) { maxValue = tilesForwardRollOne; }
            Console.WriteLine("roll value is {0}", tilesForwardRollOne);
            GameState rollTwo = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollTwo.PlayerMoveForward(2);
            int tilesForwardRollTwo = rollTwo.TilesBetweenPlayers();
            if (tilesForwardRollTwo > maxValue) { maxValue = tilesForwardRollTwo; }
            Console.WriteLine("roll value is {0}", tilesForwardRollTwo);
            GameState rollThree = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollThree.PlayerMoveForward(3);
            int tilesForwardRollThree = rollThree.TilesBetweenPlayers();
            if (tilesForwardRollThree > maxValue) { maxValue = tilesForwardRollThree; }
            Console.WriteLine("roll value is {0}", tilesForwardRollThree);
            GameState rollFour = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollFour.PlayerMoveForward(4);
            int tilesForwardRollFour = rollFour.TilesBetweenPlayers();
            if (tilesForwardRollFour > maxValue) { maxValue = tilesForwardRollFour; }
            Console.WriteLine("roll value is {0}", tilesForwardRollFour);

            return maxValue;
        }
        private int MaxPlayerGivesMove(GameState state)
        {
            int maxValue = -99;
            GameState rollOne = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollOne.ComputerMoveBack(1);
            int tilesBackRollOne = rollOne.TilesBetweenPlayers();
            if (tilesBackRollOne > maxValue) { maxValue = tilesBackRollOne; }
            GameState rollTwo = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollTwo.ComputerMoveBack(2);
            int tilesBackRollTwo = rollTwo.TilesBetweenPlayers();
            if (tilesBackRollTwo > maxValue) { maxValue = tilesBackRollTwo; }
            GameState rollThree = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollThree.ComputerMoveBack(3);
            int tilesBackRollThree = rollThree.TilesBetweenPlayers();
            if (tilesBackRollThree > maxValue) { maxValue = tilesBackRollThree; }
            GameState rollFour = new GameState(state.PlayerPosition, state.ComputerPosition);
            rollFour.ComputerMoveBack(4);
            int tilesBackRollFour = rollFour.TilesBetweenPlayers();
            if (tilesBackRollThree > maxValue) { maxValue = tilesBackRollThree; }

            return maxValue;
        }

    }
}
