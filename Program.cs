using System;

namespace Lesson3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Задание 1");
            {
                Random rand = new();
                int[,] arr = new int[5, 5];

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = rand.Next(1, 10); // инициализация массива с помощью рандомных чисел от 0 до 9
                    }
                }

                Console.WriteLine("Наш исходный массив");

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Console.Write(arr[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Элементы диагонали массива");

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    Console.Write(arr[i, i] + " ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Задание 2");
            {
                string[,] arr = new string[5, 2];

                for (int i = 0; i < arr.GetLength(0); i++)
                {

                    Console.WriteLine();
                    Console.WriteLine($"Введите имя контакта - {i + 1}");
                    string userName = Console.ReadLine();
                    arr[i, 0] = userName;

                    Console.WriteLine($"Введите номер телефона или email контакта -  {i + 1}");
                    string telephoneNumberOrEmail = Console.ReadLine();
                    arr[i, 1] = telephoneNumberOrEmail;
                }

                Console.WriteLine("Имя | номер телефона или email");
                Console.WriteLine();

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Console.Write(arr[i, j]);
                        if (j == 0)
                        {
                            Console.Write(" | ");
                        }
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Задание 3");
            {
                Console.WriteLine("Введите вашу строку");
                string str = Console.ReadLine();

                for (int i = str.Length - 1; i >= 0; i--)
                {
                    Console.Write(str[i]);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Задание 4");
            {

            }
        }

    }
}