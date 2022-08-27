//Ну...покодили)

// Программа
Console.Clear();
int[,] game_field = TetrisField();
ArrayPrint(game_field);
System.Console.WriteLine("Нажмите Enter, чтобы начать");
string key = Console.ReadKey().ToString();

Console.Clear();
int[,] el = TetrisElement();
game_field = ArrayMergeElement(game_field, el);
ArrayPrint(game_field);
int[,] middleArray = ArrayMove(game_field);


System.Console.WriteLine("Вы добрались донизу");


// Функции


//Игровое поле

int[,] TetrisField()
{        //Поле для тетриса
    int[,] field = new int[16, 12];
    for (int i = 0; i < field.GetLength(0) - 1; i++)
    {
        for (int j = 0; j < field.GetLength(1); j++)
        {
            field[i, 0] = 1;
            field[i, j] = 0;
        }
    }
    for (int a = 0; a < field.GetLength(1); a++)
    {
        field[field.GetLength(0) - 1, a] = 1;
    }
    for (int b = 0; b < field.GetLength(0); b++)
    {
        field[b, field.GetLength(1) - 1] = 1;

    }
    return field;
}

//Формирование системы игры

int[,] TetrisElement()      //Отрисовка фигуры
{
    int[,] arr = new int[2, 4];
    int a = new Random().Next(0, 7);
    switch (a)
    {
        case 0:         //Линия
            for (int i = 0; i < 4; i++)
            {
                arr[0, i] = 1;
            }
            break;
        case 1:         //Квадрат
            for (int i = 0; i < 2; i++)
            {
                arr[0, i] = 1;
                arr[1, i] = 1;
            }
            break;
        case 2:         //L-влево
            for (int i = 0; i < 3; i++)
            {
                arr[1, i] = 1;
            }
            arr[0, 2] = 1;
            break;
        case 3:         //L-вправо 
            for (int i = 0; i < 3; i++)
            {
                arr[1, i] = 1;
            }
            arr[0, 0] = 1;
            break;
        case 4:         //Пирамида
            for (int i = 0; i < 3; i++)
            {
                arr[1, i] = 1;
            }
            arr[0, 1] = 1;
            break;
        case 5:         //Z-влево
            arr[0, 0] = 1;
            arr[0, 1] = 1;
            arr[1, 1] = 1;
            arr[1, 2] = 1;
            break;
        case 6:         //Z-вправо
            arr[0, 1] = 1;
            arr[0, 2] = 1;
            arr[1, 1] = 1;
            arr[1, 0] = 1;
            break;
    }
    return arr;
}

void ArrayPrint(int[,] array)       //Вывод на печать
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }

}

int[,] ArrayMergeElement(int[,] array, int[,] element)
{     //Слияние элемента с полем
    int[,] arr = array;
    int[,] el = element;
    int lenght = arr.GetLength(1);
    for (int i = lenght / 2 - 2; i < lenght / 2 + 2; i++)
    {
        for (int b = 0; b < el.GetLength(0); b++)
        {
            arr[b, i] = el[b, i - 4];
        }
    }
    return arr;
}

int[,] ArrayMove(int[,] array)      //Движение элемента
{
    int countRow = 1;
    int countColumn = 3;
    int countRightColumn = 7;

    while (!IsDown(array))
    {
        ConsoleKeyInfo key;

        System.Console.WriteLine("Выберите направление для движения фигуры");
        key = Console.ReadKey(true);

        Console.Clear();

        switch (key.Key)
        {
            case ConsoleKey.LeftArrow:
                (countColumn, countRightColumn) = MoveLeft(countColumn, countRightColumn, countRow, array);
                break;
            case ConsoleKey.DownArrow:
                (countRow, countRightColumn, countColumn) = MoveDown(countColumn, countRightColumn, countRow, array);
                break;
            case ConsoleKey.RightArrow:
                (countColumn, countRightColumn) = MoveRight(countColumn, countRightColumn, countRow, array);
                break;
        }
        ArrayPrint(array);
    }
    return array;
}

//Направления движения

(int, int) MoveLeft(int countColumn, int countRightColumn, int countRow, int[,] array)      //Движение элемента влево
{
    if (countColumn > 0)
    {
        for (int x = countRow - 1; x <= countRow; x++)
        {
            for (int y = countColumn; y < countColumn + 5; y++)
            {
                array[x, y - 1] = array[x, y];
                if (y - 1 == 0)
                {
                    array[x, y - 1] = 1;
                }
                if (y == countColumn + 4)
                {
                    array[x, countColumn + 4] = 0;

                }
            }
        }
        countColumn--;
        countRightColumn--;
    }
    return (countColumn, countRightColumn);
}
(int, int) MoveRight(int countColumn, int countRightColumn, int countRow, int[,] array)     //Движение элемента вправо
{
    if (countRightColumn < array.GetLength(1) - 1)
    {
        if (countColumn == 0) countColumn++;
        for (int x = countRow - 1; x <= countRow; x++)
        {
            for (int y = countRightColumn; y > countRightColumn - 4; y--)
            {
                array[x, y + 1] = array[x, y];
                if (countRightColumn + 1 == 11)
                {
                    array[x, 11] = 1;
                }

                if (y == countColumn)
                {
                    array[x, countColumn] = 0;
                }

            }
        }
        countColumn++;
        countRightColumn++;
    }
    return (countColumn, countRightColumn);
}
(int, int, int) MoveDown(int countColumn,int countRightColumn, int countRow, int[,] array)      //Движение элемента вниз
{
    if (countColumn == 0) countColumn++;
    if (countColumn == 8) countColumn--;
    if (countColumn < array.GetLength(1) - 1 && countColumn > 0)
    {
        for (int y = countColumn; y < countColumn + 4; y++)
        {
            for (int x = countRow; x >= countRow - 1; x--)
            {
                array[x + 1, y] = array[x, y];
                if (countRow + 1 == 14)
                {
                    array[15, y] = 1;
                }
            }
            if (countRow > 0)
            {
                array[countRow - 1, y] = 0;
            }
        }
        countRow++;
    }
    return (countRow,countRightColumn,countColumn);
}

//Повороты элемента



//Проверки

bool IsDown(int[,] array)
{     //Проверка нахождения элемента
    int arrayEnd = array.GetLength(0) - 2;
    bool isSetOne = false;
    for (int z = 1; z < array.GetLength(1) - 1; z++)
    {
        if (array[arrayEnd, z] == 1)
        {
            isSetOne = true;
            break;
        }
    }
    return isSetOne;
}

bool FullRow(int [,] array){
    
}