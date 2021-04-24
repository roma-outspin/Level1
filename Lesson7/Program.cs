using System;

namespace Lesson7
{
    class Program
    {

        //static void Main(string[] args)
        //{
        //    string secret = "password";
        //    Console.WriteLine("Enter password:");
        //    string input = Console.ReadLine();
        //    if (input == secret)
        //    {
        //        Console.WriteLine("Welcome!");
        //    }
        //    Console.ReadLine();
        //}

        static int SIZE_X = 5;
        static int SIZE_Y = 5;
        static int WIN_SCORE = 4;

        static char[,] field = new char[SIZE_Y, SIZE_X];

        static char PLAYER_DOT = 'X';
        static char AI_DOT = 'O';
        static char EMPTY_DOT = '.';

        static Random random = new Random();


        static void Main(string[] args)
        {

            InitField();
            PrintField();
            do
            {
                PlayerMove();
                Console.WriteLine("Ваш ход на поле");
                PrintField();
                if (CheckWin(PLAYER_DOT))
                {
                    Console.WriteLine("Вы выиграли");
                    break;
                }
                else if (IsFieldFull()) break;
                AiMove();
                Console.WriteLine("Ход Компа на поле");
                PrintField();
                if (CheckWin(AI_DOT))
                {
                    Console.WriteLine("Выиграли Комп");
                    break;
                }
                else if (IsFieldFull()) break;
            } while (true);
            Console.WriteLine("!Конец игры!");
        }

        private static void InitField()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    field[i, j] = EMPTY_DOT;
                }
            }
        }

        private static void PrintField()
        {
            Console.Clear();
            Console.WriteLine("-------");
            for (int i = 0; i < SIZE_Y; i++)
            {
                Console.Write("|");
                for (int j = 0; j < SIZE_X; j++)
                {
                    Console.Write(field[i, j] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------");
        }

        private static void SetSym(int y, int x, char sym)
        {
            field[y, x] = sym;
        }

        private static bool IsCellValid(int y, int x)
        {
            if (x < 0 || y < 0 || x > SIZE_X - 1 || y > SIZE_Y - 1)
            {
                return false;
            }

            return field[y, x] == EMPTY_DOT;
        }

        private static bool IsFieldFull()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (field[i, j] == EMPTY_DOT)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void PlayerMove()
        {
            int x, y;
            do
            {
                Console.WriteLine("Координат по строке ");
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + SIZE_Y);
                x = Int32.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Координат по столбцу ");
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + SIZE_X);
                y = Int32.Parse(Console.ReadLine()) - 1;
            } while (!IsCellValid(y, x));
            SetSym(y, x, PLAYER_DOT);
        }

        private static void AiMove()
        {
            int x, y;
            for (int column = 0; column < SIZE_Y; column++)
            {
                for (int row = 0; row < SIZE_X; row++)
                {
                    if (row + WIN_SCORE <= SIZE_X)
                    {
                        if (CheckLine(column, row, PLAYER_DOT) == WIN_SCORE - 1)
                        {
                            if (MoveAiLine(column, row, AI_DOT)) return;
                        }

                        if (column - WIN_SCORE > -2)
                        {
                            if (CheckDiagLeft(column, row, PLAYER_DOT) == WIN_SCORE - 1)
                            {
                                if (MovaAIDiagLeft(column, row, AI_DOT)) return;
                            }
                        }
                        if (column + WIN_SCORE <= SIZE_Y)
                        {
                            if (CheckDiagRight(column, row, PLAYER_DOT) == WIN_SCORE - 1)
                            {
                                if (MoveAiDiagRight(column, row, AI_DOT)) return;
                            }
                        }
                    }
                    if (column + WIN_SCORE <= SIZE_Y)
                    {
                        if (CheckColumn(column, row, PLAYER_DOT) == WIN_SCORE - 1)
                        {
                            if (MoveAiColumn(column, row, AI_DOT)) return;
                        }
                    }
                }
            }

            do
            {
                x = random.Next(0, SIZE_X);
                y = random.Next(0, SIZE_Y);
            } while (!IsCellValid(y, x));
            SetSym(y, x, AI_DOT);
        }

        private static bool MoveAiLine(int column, int row, char sym)
        {
            for (int j = row; j < WIN_SCORE; j++)
            {
                if ((field[column, j] == EMPTY_DOT))
                {
                    field[column, j] = sym;
                    return true;
                }
            }
            return false;
        }
        private static bool MoveAiColumn(int column, int row, char sym)
        {
            for (int i = column; i < WIN_SCORE; i++)
            {
                if ((field[i, row] == EMPTY_DOT))
                {
                    field[i, row] = sym;
                    return true;
                }
            }
            return false;
        }

        private static bool MovaAIDiagLeft(int column, int row, char sym)
        {
            for (int i = 0, j = 0; j < WIN_SCORE; i--, j++)
            {
                if ((field[i + column, row + j] == EMPTY_DOT))
                {
                    field[i + column, row + j] = sym;
                    return true;
                }
            }
            return false;
        }

        private static bool MoveAiDiagRight(int column, int row, char sym)
        {

            for (int i = 0; i < WIN_SCORE; i++)
            {
                if ((field[i + column, i + row] == EMPTY_DOT))
                {
                    field[i + column, i + row] = sym;
                    return true;
                }
            }
            return false;
        }

        private static bool CheckWin(char sym)
        {
            for (int column = 0; column < SIZE_Y; column++)
            {
                for (int row = 0; row < SIZE_X; row++)
                {
                    if (row + WIN_SCORE <= SIZE_X)
                    {
                        if (CheckLine(column, row, sym) >= WIN_SCORE) return true;

                        if (column - WIN_SCORE > -2)
                        {
                            if (CheckDiagLeft(column, row, sym) >= WIN_SCORE) return true;
                        }
                        if (column + WIN_SCORE <= SIZE_Y)
                        {
                            if (CheckDiagRight(column, row, sym) >= WIN_SCORE) return true;
                        }
                    }
                    if (column + WIN_SCORE <= SIZE_Y)
                    {
                        if (CheckColumn(column, row, sym) >= WIN_SCORE) return true;
                    }
                }
            }
            return false;
        }

        private static int CheckColumn(int column, int row, char sym)
        {
            int result = 0;
            for (int i = column; i < WIN_SCORE + column; i++)
            {
                if ((field[i, row] == sym)) result++;
            }
            return result;
        }

        private static int CheckLine(int column, int row, char sym)
        {
            int result = 0;
            for (int i = row; i < WIN_SCORE + row; i++)
            {
                if ((field[column, i] == sym)) result++;
            }
            return result;
        }

        private static int CheckDiagLeft(int column, int row, char sym)
        {
            int result = 0;
            for (int i = 0, j = 0; j < WIN_SCORE; i--, j++)
            {
                if ((field[i + column, j + row] == sym)) result++;
            }
            return result;

        }

        private static int CheckDiagRight(int column, int row, char sym)
        {
            int result = 0;
            for (int i = 0; i < WIN_SCORE; i++)
            {
                if ((field[i + column, i + row] == sym)) result++;
            }
            return result;
        }
    }
}
