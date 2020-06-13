using System;

namespace practice_11
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] keys = new int[10, 10]
            {
                {0, 1, 1, 0, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 0, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            };

            string value = "input";
            
            Console.WriteLine(value);

            char[,] chars = Encrypt(keys, value);
            ShowMatrix(chars);

            string result = Decrypt(keys, chars);
            Console.Write(result);
        }


        public static char[,] Encrypt(int[,] keys, string value)
        {
            char[,] chars = new char[keys.GetLength(1), keys.GetLength(0)];
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < keys.GetLength(1); k++)
                {
                    for (int j = 0; j < keys.GetLength(0); j++)
                    {
                        if (keys[k, j] == 0)
                        {
                            if (count >= value.Length)
                            {
                                return chars;
                            }

                            chars[k, j] = value[count];
                            count++;
                        }
                    }
                }

                keys = Turn(keys);
            }

            return chars;
        }

        public static string Decrypt(int[,] keys, char[,] chars)
        {
            string value = "";
            int[,] tmp = keys;
            for (int i = 0; i < 4; i++)
            {
                for (int p = i; p < 4; p++)
                {
                    tmp = Turn(tmp);
                }

                for (int k = 0; k < tmp.GetLength(1); k++)
                {
                    for (int j = 0; j < tmp.GetLength(0); j++)
                    {
                        if (tmp[k, j] == 0 && chars[k, j] != '\0')
                        {
                            value += chars[k, j];
                        }
                    }
                }
            }

            return value;
        }

        public static int[,] Turn(int[,] keys)
        {
            int[,] tmp = new int[keys.GetLength(1), keys.GetLength(0)];

            for (int i = 0; i < keys.GetLength(1); i++)
            {
                for (int j = 0; j < keys.GetLength(0); j++)
                {
                    tmp[i, j] = keys[keys.GetLength(0) - j - 1, i];
                }
            }

            return tmp;
        }

        public static void ShowMatrix(int[,] keys)
        {
            for (int i = 0; i < keys.GetLength(1); i++)
            {
                for (int j = 0; j < keys.GetLength(0); j++)
                {
                    Console.Write(keys[i, j] + " ");
                }

                Console.Write("\n");
            }

            Console.WriteLine();
        }

        public static void ShowMatrix(char[,] chars)
        {
            for (int i = 0; i < chars.GetLength(1); i++)
            {
                for (int j = 0; j < chars.GetLength(0); j++)
                {
                    if (chars[i, j] == '\0')
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(chars[i, j] + " ");
                    }
                }

                Console.Write("\n");
            }

            Console.WriteLine();
        }
    }
}