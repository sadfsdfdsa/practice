using System;

namespace practice_9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
                "Напишите рекурсивный метод создания двунаправленного списка, в информационные поля элементов которого последовательно заносятся номера с 1 до N (N водится с клавиатуры)." +
                "\nПервый включенный в список элемент, имеющий номер 1, оказывается в голове списка (первым)." +
                "\nРазработайте рекурсивные методы поиска и удаления элементов списка.");

            int n = ReadInteger("Введите n ", 1);
            Point lst = CreateList(new Point(n), n);
            ShowList(lst);
            int value = ReadInteger("Введите значение, индекс которого вы хотите найти  ", 1);
            Console.WriteLine("Индекс (индексируется с 1) = " + Find(value, lst));
            value = ReadInteger("Введите значение, которое вы хотите удалить  ", 1);
            Console.WriteLine("Удаление произошло: " + Delete(value, ref lst));
            ShowList(lst);
        }

        public static void ShowList(Point point)
        {
            Point tmp = point;
            Console.Write("Список: ");
            while (tmp.next != null)
            {
                Console.Write(tmp.data + " ");
                tmp = tmp.next;
            }

            Console.WriteLine();
        }

        public static Point CreateList(Point point, int n)
        {
            if (n == 0)
            {
                return point;
            }

            Point tmp = new Point(n);
            point.prev = tmp;
            tmp.next = point;
            n--;

            return CreateList(tmp, n);
        }

        public static int Find(int value, Point point, int count = 1)
        {
            if (value == point.data)
            {
                return count;
            }

            if (point.next == null)
            {
                return -1;
            }

            count++;
            return Find(value, point.next, count);
        }

        public static bool Delete(int value, ref Point point)
        {
            if (value == point.data)
            {
                if (point.prev != null)
                {
                    point.prev.next = point.next;
                }
                else
                {
                    point = point.next;
                    point.prev = null;
                }

                return true;
            }

            if (point.next == null)
            {
                return false;
            }

            return Delete(value, ref point.next);
        }

        public class Point
        {
            public Point prev;
            public Point next;
            public int data;

            public Point(int value)
            {
                prev = null;
                next = null;
                data = value;
            }
        }

        public static int ReadInteger(string msg, int min)
        {
            Console.Write(msg + $">={min}: ");
            var flag = int.TryParse(Console.ReadLine(), out var result);
            return flag ? result >= min ? result : ReadInteger(msg, min) : ReadInteger(msg, min);
        }
    }
}