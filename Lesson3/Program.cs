using System;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task1 Вывод элементов двумерного массива по диагонали
            /* 
             * Решения задачи продемонстрировано для двух массивов: зубчатого и двумерного.
             * Используется тройная вложенность циклов: два для перебора элементов, третий цикл для добавления
             * пробелов и создания диагонали.
             */

            int[][] jaggedArray = new int[5][];
            jaggedArray[0] = new int[] { 1, 2, 3, 4, 5 };
            jaggedArray[1] = new int[] { 6, 7, 8 };
            jaggedArray[2] = new int[] { 1 };
            jaggedArray[3] = new int[] { 7, 8, 9, 0 };
            jaggedArray[4] = new int[] { 1, 5 };

            char[,] twoDimArray = {
            { 'a', 'b', 'c', 'd', 'e' },
            { 'f', 'g', 'h', 'i', 'j' },
            { 'k', 'l', 'm', 'n', 'o' },
            { 'p', 'q', 'r', 's', 't' },
            { 'u', 'v', 'w', 'x', 'y' }
            };

            int rows = twoDimArray.GetUpperBound(0) + 1; // Количество элементов вложенного массива (строк)
            int columns = twoDimArray.Length / rows; // Количество вложенных массивов (столбцов)
            int spaceCounter = 0; //Счетчик пробелов для создания диагонали

            //вывод элементов по диагонали при использовании зубчатого массива:
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    for (int n = 0; n < spaceCounter; n++)
                    {
                        Console.Write(' ');
                    }
                    Console.WriteLine(jaggedArray[i][j]);
                    spaceCounter++;
                }
            }

            spaceCounter = 0; // обнуления счетчика, для новой диагонали (необязательно)

            //вывод элементов по диагонали при использовании двумерного массива:
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    for (var n = 0; n < spaceCounter; n++)
                    {
                        Console.Write(' ');
                    }
                    Console.WriteLine(twoDimArray[i, j]);
                    spaceCounter++;
                }
            }

            #endregion

            #region Task2 Телефонный справочник

            string[,] phoneBook = {
            { "Иванов Иван", "123456789" },
            { "Петров Петр", "987654321" },
            { "Борисова Борис", "borya@gg.com" },
            { "Николаев Николай", "kolya@gg.com" },
            { "Аристархов Аристарх", "27354891@mail.ru" } };

            Console.WriteLine("Введите 1 для просмотра всех записей телефонной книги: ");
            if (Console.ReadLine() == "1")
            {
                foreach (var record in phoneBook)
                {
                    Console.WriteLine(record);
                }
            }

            #endregion

            #region Task3 Строка в обратном порядке

            Console.WriteLine("Введите строку, а я верну вам её задом наперед: ");
            var userStr = Console.ReadLine();

            for (int i = userStr.Length - 1; i >= 0; i--)
            {
                Console.Write(userStr[i]);
            }
            Console.WriteLine();

            #endregion

            #region Task4 Поле морского боя
            /*
             * «Морской бой»: вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки.
             */

            char[,] playerField =
            {
                { 'o', 'o', 'o', 'x', 'o', 'x', 'o', 'o', 'o', 'x', },
                { 'o', 'x', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'x', },
                { 'o', 'x', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', },
                { 'o', 'x', 'o', 'o', 'x', 'x', 'x', 'o', 'o', 'x', },
                { 'o', 'x', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', },
                { 'o', 'o', 'o', 'o', 'o', 'o', 'x', 'o', 'o', 'o', },
                { 'o', 'o', 'o', 'o', 'o', 'o', 'x', 'o', 'o', 'o', },
                { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', },
                { 'o', 'x', 'o', 'o', 'o', 'o', 'o', 'x', 'x', 'x', },
                { 'o', 'x', 'o', 'o', 'x', 'o', 'o', 'o', 'o', 'o', },

            };

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(playerField[i, j].ToString().ToUpper());
                }
                Console.WriteLine();
            }

            #endregion

            #region Task5 Смещение массива
            /*
             * Написать программу, которая считывает с консоли число n 
             * и смешает одномерный массив и на n (может быть положительным, или отрицательным). 
             * Для усложнения задачи нельзя пользоваться вспомогательными массивами.
             */

            int[] testedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("Введите целое число на которое необходимо сместить массив чисел {1,2,3,4,5,6,7,8,9}");
            int valueToMove = int.Parse(Console.ReadLine());

            if (valueToMove > 0)
            {
                for (int q = 0; q < valueToMove; q++)
                {
                    bool flag = false;
                    int bufferCurrent = 0;

                    for (int i = 0; i < testedArray.Length; i++)
                    {
                        int temp;
                        int bufferNext;

                        if (i == testedArray.Length - 1)
                        {
                            temp = 0;
                        }
                        else
                        {
                            temp = i + 1;
                        }
                        if (flag)
                        {
                            bufferNext = testedArray[temp];
                            testedArray[temp] = bufferCurrent;
                        }
                        else
                        {
                            bufferNext = testedArray[temp];
                            testedArray[temp] = testedArray[i];
                            flag = true;
                        }

                        bufferCurrent = bufferNext;
                    }
                }
            }
            else if (valueToMove < 0)
            {

                for (int q = 0; q < Math.Abs(valueToMove); q++)
                {
                    bool flag = false;
                    int bufferCurrent = 0;
                    for (int i = testedArray.Length - 1; i >= 0; i--)
                    {
                        int temp;
                        int bufferNext;

                        if (i == 0)
                        {
                            temp = testedArray.Length - 1;
                        }
                        else
                        {
                            temp = i - 1;
                        }

                        if (flag)
                        {
                            bufferNext = testedArray[temp];
                            testedArray[temp] = bufferCurrent;
                        }
                        else
                        {
                            bufferNext = testedArray[temp];
                            testedArray[temp] = testedArray[i];
                            flag = true;
                        }

                        bufferCurrent = bufferNext;
                    }
                }
            }
            else
            {
                Console.WriteLine("Ну, ок... Оставим как есть!");
            }


            for (var i = 0; i < testedArray.Length; i++)
            {
                Console.Write(testedArray[i]);
            }
            Console.WriteLine();

            #endregion


        }
    }
}
