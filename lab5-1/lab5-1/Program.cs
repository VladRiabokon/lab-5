using System;

class Program
{
    static void Main()
    {
        int[,] matrix = new int[7, 7];
        Random rand = new Random();

        Console.WriteLine("Початкова матриця:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rand.Next(-100, 100); // Для перевірки модулів значення можуть бути і від'ємними
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        // Знаходимо максимальний по модулю елемент на головній діагоналі
        int maxRow = 0;
        int maxElement = Math.Abs(matrix[0, 0]);
        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            if (Math.Abs(matrix[i, i]) >= maxElement) // Беремо останній максимальний елемент у разі рівності
            {
                maxElement = Math.Abs(matrix[i, i]);
                maxRow = i;
            }
        }

        // Перестановка рядків
        if (maxRow < matrix.GetLength(0) - 1) // Якщо це не останній рядок
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int temp = matrix[maxRow, j];
                matrix[maxRow, j] = matrix[maxRow + 1, j];
                matrix[maxRow + 1, j] = temp;
            }
        }
        else // Якщо це останній рядок
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int temp = matrix[maxRow, j];
                matrix[maxRow, j] = matrix[0, j];
                matrix[0, j] = temp;
            }
        }

        Console.WriteLine("\nПеретворена матриця:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
