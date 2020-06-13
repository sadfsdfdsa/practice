using System;

namespace practice_12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
                @"Выполнить сравнение двух предложенных методов сортировки одномерных массивов, содержащих n элементов, по количеству пересылок и сравнений.
Для этого необходимо выполнить программную реализацию двух методов сортировки, включив в нее подсчет количества пересылок (т.е. перемещений элементов с одного места на другое) и сравнений.
Провести анализ методов сортировки для трех массивов: упорядоченного по возрастанию, упорядоченного по убыванию и неупорядоченного.
Все три массива следует отсортировать обоими методами сортировки.
Найти в литературе теоретические оценки сложности каждого из методов и сравнить их с оценками, полученными на практике.
Сделать выводы о том, насколько отличаются теоретические и практические оценки количества операций, объяснить почему это происходит. Сравнить оценки сложности двух алгоритмов.
Вариант задания определяется парой (X, Y), где X, Y – порядковые номера методов сортировки из приведенного списка:
2. Сортировка перемешиванием.
11. Пирамидальная сортировка.");

            int[] arrSortedUp = {1, 2, 3, 4, 5};
            int[] arrSortedDown = {5, 4, 3, 2, 1,};
            int[] arrSortedNone = {3, 1, 5, 2, 4};

            (int, int) test1 = ShakerSort(arrSortedUp);
            (int, int) test2 = ShakerSort(arrSortedDown);
            (int, int) test3 = ShakerSort(arrSortedNone);


            (int, int) test4 = PyramidSort(arrSortedUp, arrSortedUp.Length);
            (int, int) test5 = PyramidSort(arrSortedDown, arrSortedDown.Length);
            (int, int) test6 = PyramidSort(arrSortedNone, arrSortedNone.Length);

            Console.WriteLine("  UP   DOWN   NONE");

            ShakerSort2(arrSortedUp);
            ShakerSort2(arrSortedDown);

            ShakerSort2(arrSortedNone);

            Console.WriteLine();

            Console.Write(test1);
            Console.Write(test2);
            Console.Write(test3);
            Console.WriteLine();

            Console.Write(test4);
            Console.Write(test5);
            Console.Write(test6);
            Console.WriteLine();
        }

        /* Поменять элементы местами */
        static void Swap(int[] myint, int i, int j)
        {
            int glass = myint[i];
            myint[i] = myint[j];
            myint[j] = glass;
        }

        /* Шейкер-сортировка */
        static void ShakerSort2(int[] myint)
        {
            int left = 0,
                right = myint.Length - 1,
                count = 0;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    count++;
                    if (myint[i] > myint[i + 1])
                        Swap(myint, i, i + 1);
                }

                right--;

                for (int i = right; i > left; i--)
                {
                    count++;
                    if (myint[i - 1] > myint[i])
                        Swap(myint, i - 1, i);
                }

                left++;
            }

            Console.WriteLine("\nКоличество сравнений = {0}", count.ToString());
        }

        public static (int, int) ShakerSort(int[] name)
        {
            int countIf = 0;
            int countChange = 0;

            int b = 0;
            int left = 0; //Левая граница
            int right = name.Length - 1; //Правая граница
            while (left < right)
            {
                for (int i = left; i < right; i++) //Слева направо...
                {
                    if (name[i] > name[i + 1])
                    {
                        b = name[i];
                        name[i] = name[i + 1];
                        name[i + 1] = b;
                        b = i;

                        countChange++;
                    }

                    countIf++;
                }

                right = b; //Сохраним последнюю перестановку как границу
                if (left >= right) break; //Если границы сошлись выходим
                for (int i = right; i > left; i--) //Справа налево...
                {
                    if (name[i - 1] > name[i])
                    {
                        b = name[i];
                        name[i] = name[i - 1];
                        name[i - 1] = b;
                        b = i;

                        countChange++;
                    }

                    countIf++;
                }

                left = b; //Сохраним последнюю перестановку как границу
            }

            return (countIf, countChange);
        }

        static int add2pyramid(int[] arr, int i, int N)
        {
            int imax;
            int buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;

            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }

            return i;
        }

        public static (int, int) PyramidSort(int[] arr, int len)
        {
            int countIf = 0;
            int countChange = 0;

            //step 1: building the pyramid
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
                countChange++;
                countIf++;
            }

            //step 2: sorting
            int buf;
            for (int k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                    countChange++;
                    countIf++;
                }
            }

            return (countIf, countChange);
        }
    }
}