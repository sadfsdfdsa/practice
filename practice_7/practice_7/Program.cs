using System;

namespace practice_7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
                "28. Построить код Грэя с заданной длиной кодовых слов. Кодовые слова выписать в лексикографическом порядке.");
            int n = ReadInteger("Введите n ", 1);

            int[] arr;
            if (n>=2)
            {
                arr = new int[(int) Math.Pow(n, n)];
            }
            else
            {
                arr = new int[6];
            }
            Gray(n, ref arr, 0);

            Console.WriteLine("Полученный код: ");
            for (int i = 0; i < (int) Math.Pow(n, n); i++)
            {
                if (arr[i] == 0 && i > n)
                {
                    break;
                }

                Console.Write(ToNChars(Convert.ToString(arr[i], 2), n) + " ");
            }

            Console.ReadLine();
        }

        public static string ToNChars(string str, int n)
        {
            return new String('0', n - str.Length) + str;
        }

        public static void Gray(int n, ref int[] m, int depth)
        {
            int i, t = (1 << (depth - 1));

            if (depth == 0)
                m[0] = 0;

            else
            {
                //массив хранит десятичные записи двоичных слов
                for (i = 0; i < t; i++)
                    m[t + i] = m[t - i - 1] + (1 << (depth - 1));
            }

            if (depth != n)
                Gray(n, ref m, depth + 1);
        }

        public static int ReadInteger(string msg, int min)
        {
            Console.Write(msg + $">={min}: ");
            var flag = int.TryParse(Console.ReadLine(), out var result);
            return flag ? result >= min ? result : ReadInteger(msg, min) : ReadInteger(msg, min);
        }
    }
}