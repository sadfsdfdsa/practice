using System;

namespace practice_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] arr = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                string[] tmp = Console.ReadLine().Split(' ');
                for (int j = 0; j < size; j++)
                {
                    arr[i, j] = int.Parse(tmp[j]);
                }
            }

            // Применение алгоритма Флойда с использованием матрицы смежности
            for (int k = 0; k < size; k++)
            for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                if (arr[i, j] > arr[i, k] + arr[k, j])
                    arr[i, j] = arr[i, k] + arr[k, j];
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(arr[i, j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}