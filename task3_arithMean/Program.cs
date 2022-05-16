Console.Clear();

Console.WriteLine("Введи высоту и ширину массива через пробел:");
int[] lenghts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
int m = lenghts[0];
int n = lenghts[1];

int[,] numbers = GetArray(m, n, 0, 9);
PrintArray(numbers);
Console.WriteLine();
Console.WriteLine(string.Join("  ", FindArithmeticMeans(numbers)));

int[,] GetArray(int rows, int columns, int min, int max)
{
    int[,] result = new int[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = new Random().Next(min, max + 1);
        }

    }
    return result;
}

void PrintArray(int[,] array)
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

double[] FindArithmeticMeans(int[,] array)
{
    double[] averages = new double[array.GetLength(1)];
    double sum = 0;
    for (int j = 0; j < array.GetLength(1); j++)
    {

        for (int i = 0; i < array.GetLength(0); i++)
        {
            sum += array[i, j];
        }
        averages[j] = Math.Round(sum / array.GetLength(0), 2);
        sum = 0;
    }
    return averages;
}