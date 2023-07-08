// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

void FillMatrixWithRandom(int[,] matrix)
{
    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(0, 10);
        }
    }
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write($"{matrix[i, j]} \t");
        }
System.Console.WriteLine();
    }
}

System.Console.WriteLine("Введите кол-во строк: ");
int row = Convert.ToInt32(Console.ReadLine());
System.Console.WriteLine("Введите кол-во столбцов: ");
int column = Convert.ToInt32(Console.ReadLine());
int[,] matrix = new int[row, column];
FillMatrixWithRandom(matrix);
PrintMatrix(matrix);

int[] SumOfRowElements(int[,] matrix)
{
    int sum;
    int[] sumOfRowElementsArray = new int[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[i, j];
        }
        sumOfRowElementsArray[i] = sum;
    }
    return sumOfRowElementsArray;
}

int[] RowWithMin(int[] sumOfRowElementsArray)
{
    int count = 0; 
    for (int i = 0; i < sumOfRowElementsArray.Length; i++)
    {
        if (sumOfRowElementsArray[i] == sumOfRowElementsArray.Min()) count++;
    }
    int[] rowWithMin = new int[count];
    int k = 0;
    while (k < rowWithMin.Length)
    {
        for (int i = 0; i < sumOfRowElementsArray.Length; i++)
        {
            if (sumOfRowElementsArray[i] == sumOfRowElementsArray.Min())
            {
                rowWithMin[k] = i + 1;
                k++;
            }
        }
    }
    return rowWithMin;
}
int[] rowWithMin = RowWithMin(SumOfRowElements(matrix));
System.Console.WriteLine($"{String.Join(",",rowWithMin)} строка имеет минимальную сумму элементов");