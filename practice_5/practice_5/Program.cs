using System;

namespace practice_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
                "393. Даны натуральное число n, целочисленная квадратная матрица порядка n. Получить Ь(1) ..., Ь(n), гдe Ь(i) — это" +
                "\nг) сумма элементов, предшествующих последнему отрицательному элементу i-и строки (если все элементы строки неотрицательны, то принять b(i) = — 1).");

            int n;
            do
            {
                n = ReadInteger("Введите n: ");
            } while (n <= 0);

            Console.WriteLine("Введите матрицу построчно, используя пробелы в качестве разделителя элементов: ");

            int[] b = new int[n];

            for (int i = 0; i < n; i++)
            {
                string[] tmpString = Console.ReadLine().Split(' ');
                int sum = 0;
                bool flag = false;
                for (int j = n - 1; j >= 0; j--)
                {
                    int tmpValue;
                    try
                    {
                        tmpValue = int.Parse(tmpString[j]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Неверно введено значение в матрице.");
                        Console.ReadLine();
                        return;
                    }

                    if (tmpValue < 0 && !flag)
                    {
                        flag = true;
                    }
                    else if (flag)
                    {
                        sum += tmpValue;
                    }
                }

                b[i] = flag ? sum : -1;
            }

            Console.Write("b: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(b[i] + " ");
            }

            Console.ReadLine();
        }

        public static int ReadInteger(string msg)
        {
            Console.Write(msg);
            var flag = int.TryParse(Console.ReadLine(), out var result);
            return flag ? result : ReadInteger(msg);
        }
    }
}