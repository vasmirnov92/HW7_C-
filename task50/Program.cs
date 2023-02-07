// Задача 50: Напишите программу, которая на вход
// принимает позиции элемента в двумерном массиве, и
// возвращает значение этого элемента или же указание,
// что такого элемента нет.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue+1);
        }
    }
    return result;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]}\t "); // табуляция
        }
        Console.WriteLine();
    }
}

string[] ConsToString(string inMass)
{
    string[] delimiterStrings = {" ", ", ", ", ,", ",", " ," , ".", ". ", ". .", " ."};
    string[] outMass = inMass.Split(delimiterStrings, System.StringSplitOptions.RemoveEmptyEntries);
    return outMass;    
}

int[] StringToInt (string[] outMass)
{
    int[] outInteger = new int[outMass.Length];
    for (int i=0; i < outMass.Length; i++)
    {
        try
        {    
            outInteger[i] = Int32.Parse(outMass[i]);
        }
        catch (FormatException)
        {
            Console.WriteLine();
        }
        catch (OverflowException)
        {
            Console.WriteLine();
        }
    }
    return outInteger;    
}

void FindElement(int[,] matrix, int[] coordinaty)
{
    if (matrix.GetLength(0) < coordinaty[0] || matrix.GetLength(1) < coordinaty[1])
    {
        Console.WriteLine("Элемента с такими координатами в матрице нет.");
    }
    else
    {
        Console.WriteLine($"Элемент матрицы с коррдинатами [{coordinaty[0]};{coordinaty[1]}] = {matrix[(coordinaty[0]-1), (coordinaty[1])-1]}");
    }
}



Console.Clear();
Console.Write("Введите кол-во строк: ");
int row = int.Parse(Console.ReadLine()!);
Console.Write("Введите кол-во столбцов: ");
int col = int.Parse(Console.ReadLine()!);

int[,] array = GetArray(row, col, 0, 10);
PrintArray(array);

Console.Write("Введите координаты элемента матрицы: ");
string inString = Console.ReadLine();
string[] outString = ConsToString(inString);
int[] outInt = StringToInt(outString);
FindElement(array , outInt);
