using System;

namespace practice_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] tmp = Console.ReadLine().Split(' ');
            for (int j = 0; j < tmp.Length; j++)
            {
                Console.Write(Task(int.Parse(tmp[j])));
            }
        }

        public static int Task(int n)
        {
            int copy = n;
            int count = 0;
            int s = 0;
            var div = 2;
            while (n % div == 0)
            {
                s += div;
                n /= div;
                count++;
            }

            div = 3;

            while (Math.Pow(div, 2) <= n)
            {
                if (n % div == 0)
                {
                    s += Sum(div);
                    n /= div;
                    count++;
                }
                else
                {
                    div += 2;
                }
            }

            if (n > 1)
            {
                s += Sum(n);
                count++;
            }

            if (count==1)
            {
                s++;
            }

            return Sum(copy) == s ? 1 : 0;
        }

        public static int Sum(int num)
        {
            int s = 0;
            while (num > 0)
            {
                s += num % 10;
                num = num / 10;
            }

            return s;
        }
    }
}