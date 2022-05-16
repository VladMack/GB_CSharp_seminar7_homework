Console.Clear();

Console.WriteLine("Введи высоту и ширину массива через пробел:");
int[] lenghts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
int m = lenghts[0];
int n = lenghts[1];
Console.WriteLine();

int[,] numbers = GetArray(m, n, 0, 9);
PrintArray(numbers);
Console.WriteLine();

Console.WriteLine("Выбери, что нужно сделать:");
Console.WriteLine("1. Узнать, есть ли число в массиве");
Console.WriteLine("2. Найти элемент массива по порядковому номеру");
Console.WriteLine("3. Найти элемент по индексам");
int action = int.Parse(Console.ReadLine());
Console.WriteLine();
int nSearch, orderNumber, i, j;
int[] indexes;
switch (action)
{
    case 1:
        Console.WriteLine("Введи искомое число:");
        nSearch = int.Parse(Console.ReadLine());
        Console.WriteLine((FindNumberByValue(nSearch, numbers)) ? "Число есть в массиве." : "Числа в массиве нет.");
        break;
    case 2:
        Console.WriteLine("Введи порядковый номер числа:");
        orderNumber = int.Parse(Console.ReadLine());
        Console.WriteLine(FindElementInOrder(orderNumber, numbers));
        break;
    case 3:
        Console.WriteLine("Введи индексы через пробел:");
        indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        i = indexes[0];
        j = indexes[1];
        Console.WriteLine(FindElementByIndexes(i, j, numbers));
        break;
    default:
        Console.WriteLine("Такого действия нет.");
        break;

}

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

// Проверка наличия в массиве элемента по значению:
bool FindNumberByValue(int number, int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] == number) return true;
        }
    }
    return false;
}

// Поиск элемента по порядковому номеру (номер первого элемента - 1):
string FindElementInOrder(int num, int[,] arr)
{
    int i, j;
    if (num <= 0 || num > arr.Length)
    {
        return "Такого элемента нет.";
    }
    if (num % arr.GetLength(1) == 0)
    {
        i = num / arr.GetLength(1) - 1;
        j = arr.GetLength(1) - 1;
        return $"Число с порядковым номером {num}: {arr[i, j]}.";
    }
    else
    {
        i = num / arr.GetLength(1);
        j = num % arr.GetLength(1) - 1;
        return $"Число с порядковым номером {num}: {arr[i, j]}.";
    }
}

// Поиск элемента по индексам:
string FindElementByIndexes(int i, int j, int[,] ar)
{
    if (i >= 0 && i < ar.GetLength(0) && j >= 0 && j < ar.GetLength(1))
    {
        return $"Элемент с индексами {i}, {j}: {ar[i, j]}.";
    }
    else return $"Элемента с индексами {i}, {j} нет.";
}