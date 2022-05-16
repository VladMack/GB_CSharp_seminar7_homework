Console.Clear();

Console.WriteLine("Введи высоту и ширину массива через пробел:");
int[] lenghts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
int m = lenghts[0];
int n = lenghts[1];

double[,] numbers = GetArray(m, n, -9, 9);
PrintArray(numbers);

double[,] GetArray(int rows, int columns, double min, double max)
{
    double[,] result = new double[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = Math.Round(new Random().NextDouble() * (max + 1 - min) + min, 1);
        }

    }
    return result;
}

void PrintArray(double[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}  ");
        }
        Console.WriteLine();
    }

}