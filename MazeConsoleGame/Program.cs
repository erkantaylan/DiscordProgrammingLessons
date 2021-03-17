using System;
using ConsoleHelper;
using MazeGameBase;

namespace MazeConsoleGame
{
    internal static class Program
    {
        private static readonly string wall = "|";
        private static readonly string airPixel = ",";

        private static readonly string[] maze =
        {
            wall,
            airPixel,
            airPixel,
            airPixel,
            airPixel,
            airPixel,
            airPixel,
            airPixel,
            airPixel,
            wall
        };

        private static void Main(string[] args)
        {
            Console.CursorVisible = false;

            var player = ((char) 2).ToString();
            var position = 1;
            var consoleInput = new ConsoleInput();

            var gameController = new GameController(
                player,
                position,
                maze,
                wall,
                consoleInput,
                new ConsoleRenderer());

            var playerController = new PlayerController(consoleInput, maze, wall, gameController.EndGame, player, position, airPixel);

            gameController.Start(playerController);

            Console.WriteLine("Game Over!");
            Console.ReadKey();
        }
    }
}