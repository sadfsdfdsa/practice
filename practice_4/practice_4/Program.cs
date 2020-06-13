using System;

namespace practice_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
                "726. Дано действительное положительное число е. " +
                "Методом хорд вычислить с точностью е *) корень уравнения /(*) = 0 (ниже, следом за уравнением f(x) = 0, дополнительно задан отрезок, содержащий корень): " +
                "\nб) х^2 — sin(5*PI): = 0, [0.5, 0.6];");

            double x0 = 0.5;
            double x1 = 0.6;
            double e = ReadDouble("Введите точность (0,001): ");
            double x = Method(x0, x1, e);
            Console.WriteLine("x = " + x);
            Console.ReadLine();
        }

        public static double Method(double x_prev, double x_curr, double e)
        {
            double x_next = 0;
            double tmp;

            do
            {
                tmp = x_next;
                x_next = x_curr - f(x_curr) * (x_prev - x_curr) / (f(x_prev) - f(x_curr));
                x_prev = x_curr;
                x_curr = tmp;
            } while (Math.Abs(x_next - x_curr) > e);

            return x_next;
        }

        public static double f(double x)
        {
            return x * x - Math.Sin(x * 5);
        }

        public static double ReadDouble(string msg)
        {
            Console.Write(msg);
            var flag = double.TryParse(Console.ReadLine(), out var result);
            return flag ? result : ReadDouble(msg);
        }
    }
}