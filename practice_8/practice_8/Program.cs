using System;
using System.Collections.Generic;
using System.Linq;

namespace practice_8
{
    internal class Program
    {
        public static List<int>[] graph;

        public static int[] used, d, up;

        public static List<int> ArtPoints;
        public static int time;

        //Function to get a random number 
        public static readonly Random random = new Random();
        public static readonly object syncLock = new object();

        public static void Main(string[] args)
        {
            // Console.WriteLine(
            //     "14. Граф задан матрицей инциденций. Найти все его точки сочленения.");

            int n = ReadInteger("Введите количество вершин ", 2);
            int m = ReadInteger("Введите количество ребер (строк в матрице инцеденций ", 1);
            Console.WriteLine("Матрица инциденций вводится построчно, пример: 0 1 0 1 - связаны ребром вершины 2 и 4");

            graph = new List<int>[n + 1];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            used = new int[n + 1];

            d = new int[n + 1];
            up = new int[n + 1];
            ArtPoints = new List<int>();

            Console.WriteLine("Введите матрицу: ");
            for (int i = 0; i < m; i++)
            {
                // string[] tmpString = Console.ReadLine().Split(' ');
                string[] tmpString = Generator(n);
                foreach (string item in tmpString)
                {
                    Console.Write(item+" ");
                }
                Console.Write("\n");
                int a = Array.IndexOf(tmpString, "1");
                int b = Array.LastIndexOf(tmpString, "1");

                if (a != -1 && b != -1 && a != b)
                {
                    graph[a].Add(b);
                    graph[b].Add(a);
                }
            }

            time = 1;

            for (int i = 1; i <= n; i++)
                if (used[i] != 1)
                {
                    dfs(i);
                }

            if (ArtPoints.Count > 0)
            {
                Console.Write("Точки сочленения под номерами: ");
                foreach (int point in ArtPoints)
                {
                    Console.Write((point + 1) + " ");
                }
            }
            else
            {
                Console.WriteLine("Точек сочленения нет");
            }


            Console.ReadLine();
        }

        public static string[] Generator(int n)
        {
            string[] tmp = new string[n];
            int a, b;
            lock (syncLock)
            {
                a = random.Next(0, n);
            }

            lock (syncLock)
            {
                do
                {
                    b = random.Next(0, n);
                } while (b == a);
            }

            tmp[a] = "1";
            tmp[b] = "1";
            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] != "1")
                {
                    tmp[i] = "0";
                }
            }

            return tmp;
        }


        public static void dfs(int v, int p = -1)
        {
            int i, to, children;

            used[v] = 1;

            d[v] = up[v] = time++;

            children = 0;

            for (i = 0; i < graph[v].Count; i++)
            {
                to = graph[v][i];

                if (to == p) continue;

                if (used[to] == 1)
                    up[v] = Math.Min(up[v], d[to]);
                else
                {
                    dfs(to, v);
                    up[v] = Math.Min(up[v], up[to]);
                    if ((up[to] >= d[v]) && (p != -1)) ArtPoints.Add(v);
                    children++;
                }
            }

            if ((p == -1) && (children > 1)) ArtPoints.Add(v);
        }


        public static int ReadInteger(string msg, int min)
        {
            Console.Write(msg + $">={min}: ");
            var flag = int.TryParse(Console.ReadLine(), out var result);
            return flag ? result >= min ? result : ReadInteger(msg, min) : ReadInteger(msg, min);
        }
    }
}