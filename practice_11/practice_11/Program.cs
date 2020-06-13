using System;

namespace practice_11
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] keys = new int[10, 10];
            
            Console.Write("Введите строку для шифровки: ");
            string value = Console.ReadLine();
            if (value.Length>100)
            {
                Console.WriteLine($"Длина строки больше 100 символов, все символы, с 1 по {value.Length-100} будут утеряны.");
            }

            Console.WriteLine(
                "Введите матрицу-ключ 10х10 (ввод построчно с разделением символов пробелами) из единиц и нулей: ");
            Console.WriteLine("M | 1 2 3 4 5 6 7 8 9 10");
            Console.WriteLine("------------------------");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + 1 + " | ");
                string[] tmp = Console.ReadLine().Split(' ');
                for (int j = 0; j < 10; j++)
                {
                    try
                    {
                        int tmp_value = int.Parse(tmp[j]);
                        keys[i, j] = tmp_value;
                        if (tmp_value != 0 && tmp_value != 1)
                        {
                            Console.WriteLine("Ошибочный ввод, введите строку заново.");
                            i--;
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ошибочный ввод, введите строку заново.");
                        i--;
                        break;
                    }
                }
            }


            char[,] chars = Encrypt(keys, value);
            Console.WriteLine("Зашифрованная матрица: ");
            ShowMatrix(chars);

            string result = Decrypt(keys, chars);
            Console.Write(result);
            
            Console.ReadLine();
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

                tmp = Turn(tmp);
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