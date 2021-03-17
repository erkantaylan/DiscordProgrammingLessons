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
        }

        public void Render(string[] maze)
        {
            foreach (string pixel in maze)
            {
                Console.Write(pixel);
            }
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}