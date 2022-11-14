using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2._0
{
    internal partial class Map
    {
        private void MoveSnake()
        {
            if (Direction.MyDirection == Direct.Right)
            {
                for (int i = 0; i < y; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        if (map[i, j] == 1 && (map[i, j + 1] == -1 || (map[i, j + 1] >= 1 && map[i, j+ 1] != length + 1)))
                        {
                            lose = true;
                            YouLose();
                            return;
                        }
                        if (map[i, j] == 1 && j < x - 1)
                        {
                            posY = i;
                            posX = j + 1;
                            if (map[i, j + 1] == -2)//eaten logic
                            {
                                length += 1;
                                emptyPlace--;
                                if (emptyPlace <= 1)
                                {
                                    win = true;
                                    YouWin();
                                }
                            }
                            map[i, j + 1] = 1;
                            return;
                        }


                    }
                }
            }
            if (Direction.MyDirection == Direct.Left)
            {
                for (int i = 0; i < y; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        if (map[i, j] == 1 && (j == 0 || map[i, j - 1] >= 1))
                        {
                            lose = true;
                            YouLose();
                            return;
                        }
                        if (map[i, j] == 1 && j > 0)
                        {
                            posY = i;
                            posX = j - 1;
                            if (map[i, j - 1] == -2)
                            {
                                length += 1;
                                emptyPlace--;
                                if (emptyPlace <= 1)
                                {
                                    win = true;
                                    YouWin();
                                }
                            }
                            map[i, j - 1] = 1;
                            return;
                        }
                    }
                }
            }
            if (Direction.MyDirection == Direct.Top)
            {
                for (int i = 0; i < y; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        if (map[i, j] == 1 && (i == 0 || map[i - 1, j] >= 1))
                        {
                            lose = true;
                            YouLose();
                            return;
                        }
                        if (map[i, j] == 1 && i > 0)
                        {
                            posY = i - 1;
                            posX = j;
                            if (map[i - 1, j] == -2)
                            {
                                length += 1;
                                emptyPlace--;
                                if (emptyPlace <= 1)
                                {
                                    win = true;
                                    YouWin();
                                }
                            }
                            map[i - 1, j] = 1;
                            return;
                        }
                    }
                }
            }
            if (Direction.MyDirection == Direct.Bottom)
            {
                for (int i = 0; i < y; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        if (map[i, j] == 1 && (map[i + 1, j] == -1 || map[i + 1, j] >= 1))
                        {
                            lose = true;
                            YouLose();
                            return;
                        }
                        if (map[i, j] == 1 && i < y - 1)
                        {
                            posY = i + 1;
                            posX = j;
                            if (map[i + 1, j] == -2)
                            {
                                length += 1;
                                emptyPlace--;
                                if (emptyPlace <= 1)
                                {
                                    win = true;
                                    YouWin();
                                }
                            }
                            map[i + 1, j] = 1;
                            return;
                        }
                    }
                }
            }
        }
        public void UpdateMap()
        {
            MoveSnake();
            if (!lose && !win)
            {
                for (int i = 0; i < y; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        if (map[i, j] >= 1)
                        {
                            if (i == posY && j == posX) { }
                            else
                                map[i, j] += 1;
                        }
                        if (map[i, j] > length + 1)
                        {
                            map[i, j] = 0;
                        }
                    }
                }
                updatefood = true;
                for (int i = 0; i < y; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        if (map[i,j] == -2)
                        {
                            updatefood = false;
                            break;
                        }
                    }
                }
                if (updatefood)
                {
                    DrawFood();
                    updatefood = false;
                }
                DrawMap();
            }
        }
    }
}
