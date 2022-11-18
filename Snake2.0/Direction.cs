using System;
using System.Threading;

namespace Snake2._0
{
    enum Direct
    {
        Top,
        Bottom,
        Left,
        Right
    }
    internal static class Direction
    {
        public static Direct MyDirection { get; set; } = Direct.Right;
        public static bool Speed { get; set; } = false;
        public static void SetDirection()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Spacebar)
                {
                    Speed = true;
                }
                else
                {
                    Speed = false;
                }

                if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W && MyDirection != Direct.Bottom)
                {
                    MyDirection = Direct.Top;
                }
                else if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S && MyDirection != Direct.Top)
                {
                    MyDirection = Direct.Bottom;
                }
                else if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D && MyDirection != Direct.Left)
                {
                    MyDirection = Direct.Right;
                }
                else if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A && MyDirection != Direct.Right)
                {
                    MyDirection = Direct.Left;
                }
            }
        }
    }
}
