using System;

namespace MazeGameBase
{
    public class PlayerController
    {
        private readonly string air;
        private readonly Action endFunction;
        private readonly IInput input;
        private readonly string[,] maze;
        private readonly string wall;
        public string player;
        public int xPosition;
        public int yPosition;


        public PlayerController(
            IInput input,
            string[,] maze,
            string wall,
            Action endFunction,
            string player,
            int xPosition,
            int yPosition,
            string air)
        {
            this.input = input;
            this.maze = maze;
            this.wall = wall;
            this.endFunction = endFunction;
            this.player = player;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.air = air;
        }

        public void Update()
        {
            ConsoleKey consoleKey = input.Read();
            var speed = 1;
            if (consoleKey == ConsoleKey.Q)
            {
                endFunction.Invoke();
            }
            else if (IsMoveRight(consoleKey))
            {
                Move(xPosition + speed, yPosition);
            }
            else if (IsMoveLeft(consoleKey))
            {
                Move(xPosition - speed, yPosition);
            }
            else if (IsMoveDown(consoleKey))
            {
                Move(xPosition, yPosition + speed);
            }
            else if (IsMoveUp(consoleKey))
            {
                Move(xPosition, yPosition - speed);
            }
        }

        private static bool IsMoveRight(ConsoleKey key)
        {
            return key == ConsoleKey.D
             || key == ConsoleKey.RightArrow;
        }

        private static bool IsMoveLeft(ConsoleKey key)
        {
            return key == ConsoleKey.A
             || key == ConsoleKey.LeftArrow;
        }

        private static bool IsMoveDown(ConsoleKey key)
        {
            return key == ConsoleKey.S
             || key == ConsoleKey.DownArrow;
        }

        private static bool IsMoveUp(ConsoleKey key)
        {
            return key == ConsoleKey.W
             || key == ConsoleKey.UpArrow;
        }

        public void Move(int xDestination, int yDestination)
        {
            if (yDestination == maze.GetLength(0)
                || yDestination == -1
                || maze[yDestination, xDestination] == wall)
            {
                return;
            }

            maze[yPosition, xPosition] = air;
            maze[yDestination, xDestination] = player;
            xPosition = xDestination;
            yPosition = yDestination;
        }
    }
}