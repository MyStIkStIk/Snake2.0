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

                    if (map[i, j] == (int)Elements.Head)
                    {
                        SnakeMovementAccess(i, j);
                        return;
                    }
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
                    if (map[i, j] == (int)Elements.Apple)
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
                    if (map[i, j] >= (int)Elements.Head)
                    {
                        map[i, j] += 1;
                    }
                    if (map[i, j] > length + 1)
                    {
                        map[i, j] = 0;
                    }
                }
            }
            map[posY, posX] = 1;
        }//обновление числовых значений массива(змейки)
        private void IsDead()
        {
            if (map[posY, posX] == (int)Elements.Wall || map[posY, posX] >= (int)Elements.Head)
            {
                lose = true;
                YouLose();
            }
            if (map[posY, posX] == (int)Elements.Apple)//eaten logic
            {
                length += 1;
                emptyPlace--;
                if (emptyPlace <= 1)
                {
                    win = true;
                    YouWin();
                }
            }
        }//проверка или не врезалась змейка и на победу
        private void SnakeMovementAccess(int i, int j)//обновление позиции головы и передача координат в переменные
        {
            if (Control.MyDirection == Direct.Right)
            {
                posY = i;
                posX = j + 1;
            }
            else if (Control.MyDirection == Direct.Left)
            {
                posY = i;
                posX = j - 1;
            }
            else if (Control.MyDirection == Direct.Top)
            {
                posY = i - 1;
                posX = j;
            }
            else if (Control.MyDirection == Direct.Bottom)
            {
                posY = i + 1;
                posX = j;
            }
            IsDead();
        }
    }
}
