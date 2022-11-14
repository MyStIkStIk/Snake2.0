using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        public static void SetDirection()
        {
            while (true)
            {
                string key = Console.ReadKey().Key.ToString();
                if (key == "UpArrow" && MyDirection != Direct.Bottom)
                {
                    MyDirection = Direct.Top;
                }
                else if (key == "DownArrow" && MyDirection != Direct.Top)
                {
                    MyDirection = Direct.Bottom;
                }
                else if (key == "RightArrow" && MyDirection != Direct.Left)
                {
                    MyDirection = Direct.Right;
                }
                else if (key == "LeftArrow" && MyDirection != Direct.Right)
                {
                    MyDirection = Direct.Left;
                }
                Thread.Sleep(250);
            }
        }
    }
}
