using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Snake2._0
{
    internal static class Speed
    {
        public static bool MySpeed { get; set; } = false;
        public static void SetSpeed()
        {
            while (true)
            {
                string key = Console.ReadKey().Key.ToString();
                if (key == "Spacebar" && MySpeed == false)
                {
                    MySpeed = true;
                }
                else if (key == "Spacebar" && MySpeed == true)
                {
                    MySpeed = false;
                }
                Thread.Sleep(250);
            }
        }
    }
}
