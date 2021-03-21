using System;
using MazeGameBase;

namespace ConsoleHelper
{
    public class ConsoleRenderer : IRenderer
    {
        public void Prepare()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WindowHeight = 10;
            //Cannot change font size without using unsafe code :(
        }

        public void Render(string[,] maze)
        {
            for (int col = 0; col < maze.GetLength(0); col++)
            {
                for (int row = 0; row < maze.GetLength(1); row++)
                {
                    Console.Write(maze[col, row]);
                }
                Console.WriteLine();
            }
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}