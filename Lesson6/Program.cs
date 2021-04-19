using System;
using System.Diagnostics;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");

            do
            {
                Console.Write("Команда: ");
            } while (ComandHandler(Console.ReadLine()));

            Console.WriteLine("Задание 2");
            string[,] testedArray = GenerateRndArray(4, 4);
            //string exampleError = "qwerty";
            string exampleError = "55";
            testedArray[3, 1] = exampleError;
            try
            {
                Console.WriteLine(MatrixSumm(testedArray));
            }
            catch (MyArraySizeException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            catch (MyArrayDataException ex)
            {
                Console.WriteLine($"В массиве не цифра под индексом {ex.X},{ex.Y} ");
            }

        }
        #region Методы для Задания 1
        static bool ComandHandler(string userCommand)
        {

            string[] command = userCommand.Trim(' ').Split(' ');
            if (command[0].ToLower() == "idkill")
            {
                KillProcessById(command);
            }
            else if (command[0].ToLower() == "namekill")
            {
                KillProcessByName(command);
            }
            else if (command[0].ToLower() == "showtasks")
            {
                ShowProcesses();
            }
            else if (command[0].ToLower() == "help")
            {
                Console.WriteLine("Список команд: \nidkill\tдля завершения процесса по ID\n" +
                    "namekill\tдля завершения процесса по имени\n" +
                    "showtasks\tдля получения списка запущенных процессов\n" +
                    "help\tдля получения справки\n" +
                    "exit\tдля выхода из приложения");
            }
            else if (command[0].ToLower() == "exit")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Ошибка при вводе команды, введите help для получения справки");
            }

            return true;
        }

        static void KillProcessById(string[] id)
        {
            try
            {
                Process.GetProcessById(int.Parse(id[1])).Kill();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка ввода! {ex.Message}");
            }

        }

        static void KillProcessByName(string[] id)
        {

            try
            {
                Process[] procToKill = Process.GetProcessesByName(id[1]);
                foreach (var task in procToKill)
                {
                    task.Kill();
                }
                if (procToKill.Length == 0)
                {
                    Console.WriteLine("Процесс с таким именем не найден!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка ввода! {ex.Message}");
            }

        }

        static void ShowProcesses()
        {
            Process[] tasks = Process.GetProcesses();
            foreach (var task in tasks)
            {
                Console.WriteLine($"[ID: {task.Id}] \t [Name: {task.ProcessName}]");
            }
        }
        #endregion

        #region Методы для Задания 2
        static string[,] GenerateRndArray(int row, int column)
        {
            Random rnd = new Random();
            string[,] buffer = new string[row, column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    buffer[i, j] = rnd.Next(0, 1000).ToString();
                }
            }
            return buffer;

        }
        static long MatrixSumm(string[,] userData)
        {
            long result = 0;
            if (userData.GetLength(0) != 4 || userData.GetLength(1) != 4)
            {
                throw new MyArraySizeException();
            }
                
            for (int i = 0; i < userData.GetLength(0); i++)
            {
                for (int j = 0; j < userData.GetLength(1); j++)
                {
                    try
                    {
                        result += int.Parse(userData[i, j]);
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                        throw new MyArrayDataException(i, j);
                    }

                }
            }
            return result;
        }
        #endregion
    }
}
