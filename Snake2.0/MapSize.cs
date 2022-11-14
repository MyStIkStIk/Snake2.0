using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2._0
{
    internal static class MapSize
    {
        static int width = 30;
        public static int Width { get { return width; } }
        static int height = 15;
        public static int Height { get { return height; } }
        static bool parsed = false;
        public static void ShowMenu()
        {
            Checker:
            Console.Clear();
            Console.WriteLine("Введите ширину игрового поля");
            parsed = int.TryParse(Console.ReadLine(), out width);
            if (!parsed)
            {
                goto Checker;
            }
            Checker2:
            Console.Clear();
            Console.WriteLine("Введите высоту игрового поля");
            parsed = int.TryParse(Console.ReadLine(), out height);
            if (!parsed)
            {
                goto Checker2;
            }
        }
    }
}
