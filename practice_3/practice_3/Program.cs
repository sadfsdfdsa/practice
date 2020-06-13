using System;

namespace practice_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
                "59б. Даны действительные числа х , у. Определить, принадлежит ли точка с координатами х , у заштрихованной " +
                "части плоскости (рис. 2, а — 2, /с).");

            double x = ReadDouble("Введите x: ");
            double y = ReadDouble("Введите y: ");
            Console.WriteLine($"Точка ({x},{y}) " + (InRegion(x, y) ? "принадлежит" : "не принадлежит") +
                              " окружности x^2+y^2=1");
            Console.ReadLine();
        }

        public static bool InRegion(double x, double y)
        {
            // x^2+y^2<=1^2
            const int r = 1;
            return x * x + y * y <= r;
        }

        public static double ReadDouble(string msg)
        {
            Console.Write(msg);
            var flag = double.TryParse(Console.ReadLine(), out var result);
            return flag ? result : ReadDouble(msg);
        }
    }
}