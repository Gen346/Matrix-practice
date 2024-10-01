using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        // Задана матриця
        Console.WriteLine("Input number of rows: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Input number of columns: ");
        int m = int.Parse(Console.ReadLine());
        int[,] randomNumberArray = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                randomNumberArray[i, j] = random.Next(-10, 10);
            }
        }
        // Вивести початкову матрицю на екран
        Console.WriteLine("Original Matrix:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(randomNumberArray[i, j] + "\t");
            }
            Console.WriteLine();
        }

        int minNegativeColumn = -1;
        int minNegativeCount = int.MaxValue;

        // Знайти стовпчик з мінімальною кількістю від'ємних елементів
        for (int j = 0; j < m; j++)
        {
            int negativeCount = 0;
            for (int i = 0; i < n; i++)
            {
                if (randomNumberArray[i, j] < 0)
                {
                    negativeCount++;
                }
            }

            if (negativeCount < minNegativeCount)
            {
                minNegativeCount = negativeCount;
                minNegativeColumn = j;
            }
        }

        // Додати значення елементів цього стовпчика до відповідних елементів усіх стовпчиків, крім вибраного
        for (int j = 0; j < m; j++)
        {
            if (j != minNegativeColumn)
            {
                for (int i = 0; i < n; i++)
                {
                    randomNumberArray[i, j] += randomNumberArray[i, minNegativeColumn];
                }
            }
        }

        // Вивести змінену матрицю на екран
        Console.WriteLine("Modified Matrix:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(randomNumberArray[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
