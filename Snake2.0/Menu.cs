using System;

namespace Snake2._0
{
    internal static class Menu
    {
        static bool closeGame = false;
        public static void ShowMenu()
        {
            while (!closeGame)
            {
                MenuText();
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.G:
                        StartGame.LoadGame();
                        break;
                    case ConsoleKey.S:
                        MapSize.ShowMenu();
                        break;
                    case ConsoleKey.Q:
                        closeGame = true;
                        break;
                    default:
                        break;
                }
            }
        }
        static void MenuText()
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.SetWindowSize(40, 15);
            Console.SetBufferSize(40, 15);
            Console.WriteLine("Нажмите G для старта");
            Console.WriteLine("Нажмите S для изменения размера карты");
            Console.WriteLine("Нажмите Q для выхода");
        }
    }
}
