using System;
using MazeGameBase;

namespace ConsoleHelper
{
    public class ConsoleInput : IInput
    {
        public ConsoleKey Read()
        {
            return Console.ReadKey(true).Key;
        }
    }
}