using System;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Console.WriteLine(GetFullName("Иван", "Иванов", "Иванович"));
            Console.WriteLine(GetFullName("Петр", "Петров", "Петрович"));
            Console.WriteLine(GetFullName("Николай", "Николаев", "Николаевич"));
            Console.WriteLine(GetFullName("Данила", "Данилов", "Данилович"));

            Console.WriteLine("Задание 2");
            Console.WriteLine("Введите числа через пробел для получения суммы:");
            Console.WriteLine(GetSummFromString(Console.ReadLine()));

            Console.WriteLine("Задание 3");
            Console.WriteLine("Введите номер месяца от 1 до 12:");
            bool seasonFlag;
            do
            {
                int monthNumber = int.Parse(Console.ReadLine());
                Seasons resultedSeason = GetSeason(monthNumber);
                Console.WriteLine(TranslateSesonName(resultedSeason));

                if (resultedSeason == Seasons.Error)
                {
                    seasonFlag = true;
                }
                else
                {
                    seasonFlag = false;
                }
            } while (seasonFlag);

            Console.WriteLine("Задание 4");
            Console.WriteLine("Введите номер элемента последовательности фиббоначи:");
            Console.WriteLine(GetFibbonaci(int.Parse(Console.ReadLine())));

            Console.WriteLine("Задание 5");
            string str1 = "Предложение один Теперь предложение два Предложение три";
            NormalizeString(str1);

        }

        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{lastName} {firstName} {patronymic}";
        }

        static double GetSummFromString(string rawData)
        {
            string[] Data = rawData.Split(' ');
            double result = 0.0;

            for (int i = 0; i < Data.Length; i++)
            {
                result += double.Parse(Data[i]);
            }

            return result;
        }

        static Seasons GetSeason(int monthNumber)
        {
            Seasons result;

            switch (monthNumber)
            {
                case 12:
                case 1:
                case 2:
                    result = Seasons.Winter;
                    break;
                case 3:
                case 4:
                case 5:
                    result = Seasons.Spring;
                    break;
                case 6:
                case 7:
                case 8:
                    result = Seasons.Summer;
                    break;
                case 9:
                case 10:
                case 11:
                    result = Seasons.Autumn;
                    break;
                default:
                    result = Seasons.Error;
                    break;
            }

            return result;
        }

        static string TranslateSesonName(Seasons seasonName)
        {
            string result;
            switch (seasonName)
            {
                case Seasons.Winter:
                    result = "зима";
                    break;
                case Seasons.Spring:
                    result = "весна";
                    break;
                case Seasons.Summer:
                    result = "лето";
                    break;
                case Seasons.Autumn:
                    result = "осень";
                    break;
                default:
                    result = "Ошибка: введите число от 1 до 12";
                    break;
            }
            return result;
        }

        enum Seasons
        {
            Winter,
            Spring,
            Summer,
            Autumn,
            Error
        }

        static long GetFibbonaci(int count)
        {
            if (count == 1)
            {
                return 0;
            }
            else if (count == 2)
            {
                return 1;
            }
            else
            {
                return GetFibbonaci(count - 1) + GetFibbonaci(count - 2) + 1;
            }
        }

        static void NormalizeString(string badString)
        {

            string[] sentences = badString.Split(' ');
            string result = "";
            for (int i = 0; i < sentences.Length; i++)
            {

                result += sentences[i];

                if (i < sentences.Length - 2)
                {
                    if (sentences[i + 1].ToString().ToLower() != sentences[i + 1].ToString() && i != 0)
                    {
                        result += ".";
                    }
                }
                if (i != sentences.Length - 1)
                {
                    result += " ";
                }
                else
                {
                    result += ".";
                }

            }
            Console.WriteLine(result);
        }
    }
}
