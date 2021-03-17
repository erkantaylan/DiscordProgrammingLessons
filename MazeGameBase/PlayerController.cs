using System;

namespace MazeGameBase
{
    public class PlayerController
    {
        private readonly string airPixel;
        private readonly Action endFunction;
        private readonly IInput input;
        private readonly string[] maze;
        private readonly string wallPixel;
        public string Pixel;
        public int Position;


        public PlayerController(
            IInput input,
            string[] maze,
            string wallPixel,
            Action endFunction,
            string pixel,
            int position,
            string airPixel)
        {
            this.input = input;
            this.maze = maze;
            this.wallPixel = wallPixel;
            this.endFunction = endFunction;
            Pixel = pixel;
            Position = position;
            this.airPixel = airPixel;
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
                Move(Position + speed);
            }
            else if (IsMoveLeft(consoleKey))
            {
                Move(Position - speed);
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

        public void Move(int destination)
        {
            if (maze[destination] == wallPixel)
            {
                return;
            }

            maze[Position] = airPixel;
            maze[destination] = Pixel;
            Position = destination;
        }
    }
}