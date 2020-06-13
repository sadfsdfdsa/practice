using System;
using System.Collections.Generic;

namespace practice_6
{
    internal class Program
    {
        static List<int> listN = new List<int>();
        static List<int> listM = new List<int>();

        public static void Main(string[] args)
        {
            Console.WriteLine(
                "13. Ввести а1, а2, а3, М, N. Построить последовательность чисел ак = 2 * | ак–1 – ак-2 | + ак–3." +
                "\n Построить N элементов последовательности, либо найти первые M ее элементов, кратных трем (в зависимости от того, что выполнится раньше). " +
                "\nНапечатать последовательность и причину остановки.");
            int n = ReadInteger("Введите n ", 1);
            int m = ReadInteger("Введите m ", 1, n);
            int a1 = ReadInteger("Введите a1: ");
            int a2 = ReadInteger("Введите a2: ");
            int a3 = ReadInteger("Введите a3: ");

            Recursion(a3, a2, a1, n, m);

            Console.ReadLine();
        }

        public static void Recursion(int ak1, int ak2, int ak3, int countN, int countM)
        {
            int ak = 2 * Math.Abs(ak1 - ak2) + ak3;

            if (ak % 3 == 0)
            {
                countM--;
                listM.Add(ak);
            }

            countN--;
            listN.Add(ak);

            if (countM == 0)
            {
                PrintList("m");
                return;
            }

            if (countN == 0)
            {
                PrintList("n");
                return;
            }

            Recursion(ak, ak1, ak2, countN, countM);
        }

        public static void PrintList(string list)
        {
            List<int> tmp = list == "n" ? listN : listM;
            Console.WriteLine("Напечатаны первые " + list + " членов последовательности:");
            foreach (var item in tmp)
            {
                Console.Write(item + " ");
            }
        }


        public static int ReadInteger(string msg)
        {
            Console.Write(msg);
            var flag = int.TryParse(Console.ReadLine(), out var result);
            return flag ? result : ReadInteger(msg);
        }

        public static int ReadInteger(string msg, int min)
        {
            Console.Write(msg + $">={min}: ");
            var flag = int.TryParse(Console.ReadLine(), out var result);
            return flag ? result >= min ? result : ReadInteger(msg, min) : ReadInteger(msg, min);
        }
        
        public static int ReadInteger(string msg, int min, int max)
        {
            Console.Write(msg + $"[{min}, {max}]: ");
            var flag = int.TryParse(Console.ReadLine(), out var result);
            return flag ? result >= min && result<=max ? result : ReadInteger(msg, min, max) : ReadInteger(msg, min, max);
        }
    }
}