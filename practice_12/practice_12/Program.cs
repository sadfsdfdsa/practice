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

            int[] arrSortedUp = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            int[] arrSortedDown = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
            int[] arrSortedNone = {3, 10, 6, 1, 8, 5, 2, 9, 4, 7};

            ShakerSort(arrSortedUp);
            ShakerSort(arrSortedDown);
            ShakerSort(arrSortedNone);


            PyramidalSorting(arrSortedUp);
            PyramidalSorting(arrSortedDown);
            PyramidalSorting(arrSortedNone);

            Console.WriteLine();
        }

        public static void ShakerSort(int[] name)
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
                countIf++;
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

                countIf++;
            }

            Console.WriteLine("Массив, отсортированный с помощью шейкер-сортировки:");
            //WriteMas(mas);
            Console.WriteLine("Количество сравнений: " + countIf);
            Console.WriteLine("Количество пересылок: " + countChange);
            Console.WriteLine();
        }

        static int[] MakeSortedTree(int[] mas, int maxElem, int elem, ref int compare, ref int changes)
        {
            //функция, строящая сортировочное дерево

            int maxDescendant = elem; //индекс максимального из двух потомков данного элемента

            int LeftDescendant = elem * 2 + 1; //индекс левого потомка данного элемента

            int RightDescendant = elem * 2 + 2; //индекс правого потомка данного элемента

            while (LeftDescendant < maxElem) //пока не дойдем до границы неотсортированной части массива
            {
                compare++;
                if (RightDescendant >= maxElem
                ) //если мы дошли до последнего элемента в неотсортированной части и правый потомок уже в отсортированной части
                {
                    maxDescendant = LeftDescendant;
                }
                else //если мы еще не дошли до конца неотсортированной части и правый потомок тоже находится в ней
                if (mas[LeftDescendant] > mas[RightDescendant]
                ) //находим максимальный элемент и  записываем его индекс в maxDescendant
                {
                    maxDescendant = LeftDescendant;
                    compare++;
                }
                else
                {
                    maxDescendant = RightDescendant;
                    compare++;
                }

                compare++;
                if (mas[maxDescendant] <= mas[elem]
                ) //если потомок не больше данного элемента, то заканчивам построение сортировочного дерева
                {
                    compare++;
                    break;
                }
                else //если потомок больше данного элемента, то меняем их местами
                {
                    int k = mas[elem]; //вспомогательна переменная
                    mas[elem] = mas[maxDescendant];
                    mas[maxDescendant] = k;
                    changes++;
                    elem = maxDescendant; //данный элемент меняет индекс
                    LeftDescendant = elem * 2 + 1; //индекс левого потомка данного элемента
                    RightDescendant = elem * 2 + 2; //индекс правого потомка данного элемента
                }

                compare++;
            }

            compare++;
            return mas;
        }

        static void PyramidalSorting(int[] mas)
        {
            //функция, в которой выполняется два этапа пирамидальной сортировки
            int changes = 0;
            int compare = 0;
            //первый этап: составляем пирамиду, прогоняя по не ней элементы, имеющие потомков, начиная с самого нижнего

            for (int i = mas.Length / 2 - 1; i >= 0; i--)
            {
                compare++;
                mas = MakeSortedTree(mas, mas.Length, i, ref compare,
                    ref changes); //нижней границы пока нет, так как массив еще не начали сортировать               
            }

            compare++;
            //второй этап: меняем местами первый и последний в неотсортированной части, затем прогоняем новый верхний элемент, составляя пирамиду
            for (int i = mas.Length - 1; i >= 1; i--)
            {
                compare++;
                //меняем местами верхний и нижний элементы неотсортированной части (последний элемент - новый край отсортированной части)
                int k = mas[i];
                mas[i] = mas[0];
                mas[0] = k;
                changes++;
                //составляем пирамиду, передвинув нижний край на один влево. Прогоняем по ней верхний элемент
                mas = MakeSortedTree(mas, i, 0, ref compare, ref changes);
            }

            compare++;
            Console.WriteLine("Массив, отсортированный с помощью пирамидальной сортировки:");
            //WriteMas(mas);
            Console.WriteLine("Количество сравнений: " + compare);
            Console.WriteLine("Количество пересылок: " + changes);
            Console.WriteLine();
        }
    }
}