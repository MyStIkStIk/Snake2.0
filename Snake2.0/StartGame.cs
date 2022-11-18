using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snake2._0
{
    internal static class StartGame
    {
        public static int speed = 250;
        static Map map;
        public static void LoadGame()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 6);
            Console.SetBufferSize(40, 6);
            string text = "Press Space for start!";
            Console.SetCursorPosition(40 / 2 - text.Length / 2, 2);
            Console.Write(text);
            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.SetWindowSize(MapSize.Width, MapSize.Height);
                Console.SetBufferSize(MapSize.Width, MapSize.Height);
                map = new Map();
                map.Start();
                Task.Run(() => Control.SetDirection());
                while (!map.lose && !map.win)
                {
                    map.UpdateMap();
                    if (Control.Speed)
                        speed = 70;
                    else
                        speed = 250;
                    Thread.Sleep(speed);
                }
            }
        }
    }
}
