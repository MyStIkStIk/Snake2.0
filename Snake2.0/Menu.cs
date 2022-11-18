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
                string key = Console.ReadKey().Key.ToString();
                switch (key)
                {
                    case "G":
                        Start();
                        break;
                    case "S":
                        ChangeSize();
                        break;
                    case "Q":
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
        public static void Start()
        {
            StartGame.LoadGame();
        }
        public static void ChangeSize()
        {
            MapSize.ShowMenu();
        }
    }
}
