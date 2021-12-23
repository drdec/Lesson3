using System;

namespace Lesson3
{
    class Program
    {
        const char SHIP_SYMBOL = 'X';
        enum Ship
        {
            Monohull,
            DoubleDeck,
            ThreeDeck, 
            FourDeck
        }

        static void Main()
        {
            goto m;

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

                if (str.Length == 0)
                {
                    Console.Write("");
                }
                else
                {
                    for (int i = str.Length - 1; i >= 0; i--)
                    {
                        Console.Write(str[i]);
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine();


            m: //УДАЛИТЬ ПОСЛЕ ЗАВЕРШЕНИЯ РАБОТЫ НАД 4 ЗАДАНИЕМ!!!!!!!!!!!!!!!!!!!


            Console.WriteLine("Задание 4");
            {
                char[,] field = new char[10, 10];

                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        field[i, j] = 'O';
                    }
                }

                int ship1 = 4;
                int ship2 = 3;
                int ship3 = 2;
                int ship4 = 1;

                while (true)
                {
                    if (ship1 == 0 && ship2 == 0 && ship3 == 0 && ship4 == 0)
                    {
                        break;
                    }

                    Console.WriteLine("На данный момент доска выглядит так : ");
                    DrawField(field);

                    Console.WriteLine($"У вас есть {ship1} однопалубных, {ship2} двухпалубных, {ship3} трехпалубных, {ship4} четырехпалубных");

                    Console.WriteLine();

                    Console.WriteLine("Введите 1, чтобы добавить однопалубный корабль, 2 - двухапалубный, 3 - трезпалубный, 4 - черырехпалубный");

                    int n = 0;

                    try
                    {
                        n = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        n = 5;
                    }

                    switch (n)
                    {
                        case 1:
                            if (ship1 > 0)
                            { 
                                ship1--;
                                AddShipToBoard(field, Ship.Monohull);
                            }
                            else
                            {
                                Console.WriteLine("У вас закончились однопалубные корабли!");
                                Console.ReadKey();
                            }
                            break;

                        case 2:
                            if (ship2 > 0)
                            {
                                ship2--;
                                AddShipToBoard(field, Ship.DoubleDeck);
                            }
                            else
                            {
                                Console.WriteLine("У вас закончились двухпалубные корабли");
                                Console.ReadKey();
                            }
                            break;

                        case 3:
                            if (ship3 > 0)
                            {
                                ship3--;
                                AddShipToBoard(field, Ship.ThreeDeck);
                            }
                            else
                            {
                                Console.WriteLine("У вас закончились трехпалуьные корабли");
                                Console.ReadKey();
                            }
                            break;

                        case 4:
                            if (ship4 > 0)
                            {
                                ship4--;
                                AddShipToBoard(field, Ship.FourDeck);
                            }
                            else
                            {
                                Console.WriteLine("У вас закончились четырехпалубные корабли");
                                Console.ReadKey();
                            }
                            break;

                        default:
                            Console.WriteLine("Проверьте правильность ввода");
                            Console.ReadKey();
                            break;
                    }
                    Console.Clear();
                }

                Console.Clear();

                Console.WriteLine("Конечное расположение кораблей выглядит так :");
                DrawField(field);

                Console.ReadKey();
            }
        }

        static void AddShipToBoard(char[,] field,Ship ship)
        {
            bool isShipNotAdded = true;

            Console.Clear();

            while (isShipNotAdded)
            {
                Console.WriteLine("На данный момент доска выглядит так :");
                DrawField(field);

                Console.WriteLine("Напишите координаты\nP.S. координаты начинаются с 0; 0");

                bool isItNotConverting = true;
                int coordinateXBeg = 0;
                int coordinateYBeg = 0;
                int coordinateXEnd = 0;
                int coordinateYEnd = 0;

                while (isItNotConverting)
                {
                    try
                    {
                        if (ship == Ship.Monohull)
                        {
                            Console.WriteLine("Введите координату x (номер строки)");
                            coordinateXBeg = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите координату y (номер столбца)");
                            coordinateYBeg = Convert.ToInt32(Console.ReadLine());

                            if (!(coordinateXBeg >= 0 && coordinateXBeg <= field.GetLength(0) - 1 && coordinateYBeg >= 0 && coordinateYEnd <= field.GetLength(1) - 1))
                            {
                                Console.WriteLine("Вы вышли за пределы вашей доски!!!!!");
                                throw new Exception();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Введите начало корабля по координате x (номер строки)");
                            coordinateXBeg = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите начало корабля по координате y (номер строки)");
                            coordinateYBeg = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите конец корабля по координате x (номер строки)");
                            coordinateXEnd = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите конец корабля по координате y (номер строки)");
                            coordinateYEnd = Convert.ToInt32(Console.ReadLine());

                            if (!(coordinateXBeg >= 0 && coordinateXBeg <= field.GetLength(0) - 1 && coordinateYBeg >= 0 && coordinateYBeg <= field.GetLength(1) - 1))
                            {
                                Console.WriteLine("Вы вышли за пределы вашей доски!!!!!");
                                throw new Exception();
                            }
                            else if (!(coordinateXEnd >= 0 && coordinateXEnd <= field.GetLength(0) - 1 && coordinateYEnd >= 0 && coordinateYEnd <= field.GetLength(1) - 1))
                            {
                                Console.WriteLine("Вы вышли за пределы вашей доски!!!!!");
                                throw new Exception();
                            }

                        }
                        isItNotConverting = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ну, с кем не бывает, попробуй еще раз :) ");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }

                switch (ship)
                {
                    case Ship.Monohull:
                        {
                            if (IsFieldClear(field, coordinateXBeg, coordinateYBeg, Ship.Monohull))
                            {
                                field[coordinateXBeg, coordinateYBeg] = SHIP_SYMBOL;
                                isShipNotAdded = false;
                            }
                            else
                            {
                                Console.WriteLine("Видимо, вы неправильно ввели координаты, либо на том месте уже распологался корабль, пожалуйста, повторите попытку снова.\nДля продолжения нажмите любую кнопку.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        break;

                    case Ship.DoubleDeck:
                    case Ship.ThreeDeck:
                    case Ship.FourDeck:
                        {
                            if (IsFieldClear(field, coordinateXBeg, coordinateYBeg, ship, coordinateXEnd, coordinateYEnd))
                            {
                                PlacingShipsOnTheBoard(field, coordinateXBeg, coordinateYBeg, coordinateXEnd, coordinateYEnd);
                                isShipNotAdded = false;
                            }
                            else
                            {
                                Console.WriteLine("Видимо, вы неправильно ввели координаты, либо на том месте уже распологался корабль, пожалуйста, повторите попытку снова.\nДля продолжения нажмите любую кнопку.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        break;
                }
            }
        }

        static void DrawField(char[,] field)
        {
            for (int i = 0; i< field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i,j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(field[i, j] + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(field[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        static bool IsFieldClear(char[,] field, int x, int y, Ship ship, int x1 = 0, int y1 = 0)
        {
            switch (ship)
            {
                case Ship.Monohull:
                    if (IsEmpty(field, x, y, x, y))
                    {
                        return true;
                    }
                    //{
                    //    if (field[x, y] == 'O')
                    //    {
                    //        if (x == 0 && y == 0)
                    //        {
                    //            if (field[x, y] == 'O' && field[x + 1, y + 1] == 'O' && field[x + 1, y] == 'O')
                    //            {
                    //                return true;
                    //            }
                    //        }
                    //        else if (x == field.GetLength(0) - 1 && y == field.GetLength(1) - 1)
                    //        {
                    //            if (field[x, y] == 'O' && field[x - 1, y - 1] == 'O' && field[x - 1, y] == 'O')
                    //            {
                    //                return true;
                    //            }
                    //        }
                    //        else if (x == 0 && y != 0 && y != field.GetLength(1) - 1)
                    //        {
                    //            if (field[x, y - 1] == 'O' && field[x, y + 1] == 'O' && field[x + 1, y - 1] == 'O' && field[x + 1, y] == 'O' && field[x + 1, y + 1] == 'O')
                    //            {
                    //                return true;
                    //            }
                    //        }
                    //        else if (x == field.GetLength(0) - 1 && y != 0 && y != field.GetLength(1) - 1)
                    //        {
                    //            if (field[x, y - 1] == 'O' && field[x, y + 1] == 'O' && field[x - 1, y - 1] == 'O' && field[x - 1, y] == 'O' && field[x - 1, y + 1] == 'O')
                    //            {
                    //                return true;
                    //            }
                    //        }
                    //        else if (x != 0 && y == 0 && x != field.GetLength(0) - 1)
                    //        {
                    //            if (field[x - 1, y] == 'O' && field[x, y] == 'O' && field[x + 1, y] == 'O' && field[x - 1, y + 1] == 'O' && field[x, y + 1] == 'O' && field[x + 1, y + 1] == 'O')
                    //            {
                    //                return true;
                    //            }
                    //        }
                    //        else if (x != 0 && y == field.GetLength(1) - 1 && x != field.GetLength(0) - 1)
                    //        {
                    //            if (field[x - 1, y] == 'O' && field[x, y] == 'O' && field[x + 1, y] == 'O' && field[x - 1, y - 1] == 'O' && field[x, y - 1] == 'O' && field[x + 1, y - 1] == 'O')
                    //            {
                    //                return true;
                    //            }
                    //        }
                    //        else if (x == field.GetLength(0) - 1 && y == field.GetLength(1) - 1)
                    //        {
                    //            for (int i = x - 1; i <= x; i++)
                    //            {
                    //                for (int j = y - 1; j <= y; j++)
                    //                {
                    //                    if (field[i,j] == SHIP_SYMBOL)
                    //                    {
                    //                        return false;
                    //                    }
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            for (int i = x - 1; i <= x + 1; i++)
                    //            {
                    //                for (int j = y - 1; j <= y + 1; j++)
                    //                {
                    //                    if (field[i,j] == SHIP_SYMBOL)
                    //                    {
                    //                        return false;
                    //                    }
                    //                }
                    //            }

                    //            return true;
                    //        }
                    //    }
                    //}
                    return false;

                case Ship.DoubleDeck:
                    {
                        if ((x == x1 && y1 - y == 1) || (y == y1 && x1 - x == 1))
                        {
                            if (IsEmpty(field, x, y, x1, y1))
                            {
                                return true;
                            }
                        }
                    }
                    return false;

                case Ship.ThreeDeck:
                    {
                        if ((x == x1 && y1 - y == 2) || (y == y1 && x1 - x == 2))
                        {
                            if (IsEmpty(field, x, y, x1, y1))
                            {
                                return true;
                            }
                        }
                    }
                    return false;

                case Ship.FourDeck:
                    {
                        if ((x == x1 && y1 - y == 3) || (y == y1 && x1 - x == 3))
                        {
                            if (IsEmpty(field, x, y, x1, y1))
                            {
                                return true;
                            }
                        }
                    }
                    return false;

                default:
                    return false;
            }
        }

        static void PlacingShipsOnTheBoard(char[,] field, int x, int y, int x1, int y1)
        {
            for (int i = x; i <= x1; i++)
            {
                for (int j = y; j <= y1; j++)
                {
                    field[i, j] = 'X';
                }
            }
        }

        static bool IsEmpty(char[,] field, int x, int y, int x1, int y1)
        {
            if (x == 0 && y == 0)
            {
                for (int i = x; i <= x1 + 1; i++)
                {
                    for (int j = y; j <= y1 + 1; j++)
                    {
                        if (field[i, j] == SHIP_SYMBOL)
                        {
                            return false;
                        }
                    }
                }
            }
            else if (x == field.GetLength(0) - 1 && y == 0)
            {
                for (int i = x - 1; i <= x; i++)
                {
                    for (int j = y; j <= y1 + 1; j++)
                    {
                        if (field[i, j] == SHIP_SYMBOL)
                        {
                            return false;
                        }
                    }
                }
            }
            else if (x == 0 && y == field.GetLength(1) - 1)
            {
                for (int i = x; i <= x1 + 1; i++)
                {
                    for (int j = y - 1; j <= y; j++)
                    {
                        if (field[i, j] == SHIP_SYMBOL)
                        {
                            return false;
                        }
                    }
                }
            }
            else if (x1 == field.GetLength(0) - 1 && y1 == field.GetLength(1) - 1)
            {
                for (int i = x - 1; i <= x1; i++)
                {
                    for (int j = y - 1; j <= y; j++)
                    {
                        if (field[i, j] == SHIP_SYMBOL)
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                for (int i = x - 1; i < x1 + 1; i++)
                {
                    for (int j = y - 1; j <= y1 + 1; j++)
                    {
                        if (field[i,j] == SHIP_SYMBOL)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

    }
}