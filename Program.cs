//Ну...покодили)

int[,] TetrisField()        //Поле для тетриса
{
    int[,] field = new int[16,12];
    for (int i = 0; i < field.GetLength(0); i++)
    {
        for (int j = 0; j < field.GetLength(1); j++)
        {
                field[i,j] = 0;
        }
    }
    return field;
}
 
int[,] TetrisElement(){        //Отрисовка фигуры
    int[,] arr= new int[2,4];
    int a = new Random().Next(0,7);
    switch (a){
        case 0:         //Линия
            for (int i = 0; i < 4; i++){
                arr[0, i] = 1;
            }
            break;
        case 1:         //Квадрат
            for (int i = 0; i < 2; i++){
                arr[0, i] = 1;
                arr[1, i] = 1;
            }
            break;
        case 2:         //L-влево
            for (int i = 0; i < 3; i++){
                arr[1,i] = 1;
            }
            arr[0,2]=1;
            break;
        case 3:         //L-вправо 
            for (int i = 0; i < 3; i++){
                arr[0,i] = 1;
            }
            arr[1,2]=1;
            break;
        case 4:         //Пирамида
            for (int i = 0; i < 3; i++){
                arr[1,i] = 1;
            }
            arr[0,1]=1;
            break;
        case 5:         //Z-влево
            arr[0,0]=1;
            arr[0,1]=1;
            arr[1,1]=1;
            arr[1,2]=1;
            break;
        case 6:         //Z-вправо
            arr[0,1]=1;
            arr[0,2]=1;
            arr[1,1]=1;
            arr[1,0]=1;
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
            Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine();
    }

}

int[,] 

int[,] ArrayMove(int[,] array){
    ConsoleKey key;
    while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter){
        switch (key){
            case ConsoleKey.LeftArrow:
                
                break;
            case ConsoleKey.RightArrow:
                break;
            case ConsoleKey.DownArrow:
                break;

        }
    }

}


// Программа
Console.Clear();
int[,] game_field = TetrisField();
ArrayPrint(game_field);
int[,] el = TetrisElement();
ArrayPrint(el);