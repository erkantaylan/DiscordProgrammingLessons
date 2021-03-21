using System;
using ConsoleHelper;
using MazeGameBase;

namespace MazeConsoleGame
{
    internal static class Program
    {
        private static readonly string wall = "|";
        private static readonly string air = "_";

        private static readonly string[,] maze =
        {
            { wall, air, air, air, air, air, air, air, air, air, air, air, air, air, air, air, air, wall},
            { wall, air, air, air, air, air, air, air, air, air, air, air, air, air, air, air, air, wall},
            { wall, air, air, air, air, air, air, air, air, air, air, air, air, air, air, air, air, wall},
            { wall, air, air, air, air, air, air, air, air, air, air, air, air, air, air, air, air, wall},
            { wall, air, air, air, air, air, air, air, air, air, air, air, air, air, air, air, air, wall},
            { wall, air, air, air, air, air, air, air, air, air, air, air, air, air, air, air, air, wall}
        };

        private static void Main(string[] args)
        {
            Console.CursorVisible = false;

            var player = ((char)2).ToString();
            var xPosition = 1;
            var yPosition = 0;
            var consoleInput = new ConsoleInput();

            var gameController = new GameController(
                player,
                xPosition,
                yPosition,
                maze,
                new ConsoleRenderer());

            var playerController = new PlayerController(consoleInput, maze, wall, gameController.EndGame, player, xPosition, yPosition, air);

            gameController.Start(playerController);

            Console.WriteLine("Game Over!");
            Console.ReadKey();
        }
    }
}