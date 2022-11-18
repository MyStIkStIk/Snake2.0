using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snake2._0
{
    internal static class StartGame
    {
        static int x = MapSize.Width;
        static int y = MapSize.Height;
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
                Console.SetWindowSize(x, y);
                Console.SetBufferSize(x, y);
                map = new Map(x, y - 1);
                map.DrawMap();
                map.Start();
                Task.Run(() => Direction.SetDirection());
                while (!map.lose && !map.win)
                {
                    Start();
                    if (Direction.Speed)
                        speed = 100;
                    else
                        speed = 250;
                    Thread.Sleep(speed);
                }
            }
        }
        private static void Start()
        {
            map.UpdateMap();
        }
    }
}
