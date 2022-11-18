namespace Snake2._0
{
    internal partial class Map
    {
        int posX = 0;//обновленная позиция головы
        int posY = 0;
        int length;//для очистки последнего элемента
        private void MoveSnake()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (IsDead(i, j))
                        return;
                    if (SnakeMovementAccess(i, j))
                        return;
                }
            }
        }
        public void UpdateMap()
        {
            MoveSnake();
            if (!lose && !win)
            {
                UpdateSnake();
                if (IsFoodConsist())
                {
                    DrawFood();
                }
                DrawMap();
            }
        }
        private bool IsFoodConsist()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (map[i, j] == -2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void UpdateSnake()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (map[i, j] >= 1)
                    {
                        if (i == posY && j == posX) { }//не инкрементировать обновленную позицию головы
                        else
                            map[i, j] += 1;
                    }
                    if (map[i, j] > length + 1)
                    {
                        map[i, j] = 0;
                    }
                }
            }
        }//обновление числовых значений массива(змейки)
        private bool IsDead(int i, int j)
        {
            if ((Control.MyDirection == Direct.Right && map[i, j] == 1) &&   (map[i, j + 1] == -1 || (map[i, j + 1] >= 1 && map[i, j + 1] <= length))  )
            {
                lose = true;
                YouLose();
                return true;
            }
            else if ((Control.MyDirection == Direct.Left && map[i, j] == 1) &&   (map[i, j - 1] == -1 || (map[i, j - 1] >= 1 && map[i, j - 1] <= length))  )
            {
                lose = true;
                YouLose();
                return true;
            }
            else if ((Control.MyDirection == Direct.Top && map[i, j] == 1) &&   (map[i - 1, j] == -1 || (map[i - 1, j] >= 1 && map[i - 1, j] <= length))  )
            {
                lose = true;
                YouLose();
                return true;
            }
            else if ((Control.MyDirection == Direct.Bottom && map[i, j] == 1) &&   (map[i + 1, j] == -1 || (map[i + 1, j] >= 1 && map[i + 1, j] <= length))  )
            {
                lose = true;
                YouLose();
                return true;
            }
            else
                return false;
        }//проверка или не врезалась змейка
        private bool SnakeMovementAccess(int i, int j)//обновление позиции головы и передача координат в переменные
        {
            if ((map[i, j] == 1 && j < x - 1) && (Control.MyDirection == Direct.Right))
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
                return true;
            }
            else if ((map[i, j] == 1 && j > 0) && (Control.MyDirection == Direct.Left))
            {
                posY = i;
                posX = j - 1;
                if (map[i, j - 1] == -2)//eaten logic
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
                return true;
            }
            else if ((map[i, j] == 1 && i > 0) && (Control.MyDirection == Direct.Top))
            {
                posY = i - 1;
                posX = j;
                if (map[i - 1, j] == -2)//eaten logic
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
                return true;
            }
            else if ((map[i, j] == 1 && i < y - 1) && (Control.MyDirection == Direct.Bottom))
            {
                posY = i + 1;
                posX = j;
                if (map[i + 1, j] == -2)//eaten logic
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
                return true;
            }
            else
                return false;
        }
    }
}
