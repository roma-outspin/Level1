using System;
using System.Globalization;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task1 Среднесуточная температура

            Console.WriteLine("Введите максимальную температуру за сутки: ");
            double max = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите минимальную температуру за сутки: ");
            double min = double.Parse(Console.ReadLine());
            double average = (max + min) / 2;
            Console.WriteLine($"Среднесуточная температура {average}");

            #endregion

            #region Task2 Название месяца по номеру

            Console.WriteLine("Введите номер месяцв от 1 до 12");
            int monthNumber = int.Parse(Console.ReadLine());
            bool isWinter = false;

            switch (monthNumber)
            {
                case 1:
                    Console.WriteLine("Январь");
                    isWinter = true;
                    break;
                case 2:
                    Console.WriteLine("Февраль");
                    isWinter = true;
                    break;
                case 3:
                    Console.WriteLine("Март");
                    break;
                case 4:
                    Console.WriteLine("Апрель");
                    break;
                case 5:
                    Console.WriteLine("Май");
                    break;
                case 6:
                    Console.WriteLine("Июнь");
                    break;
                case 7:
                    Console.WriteLine("Июль");
                    break;
                case 8:
                    Console.WriteLine("Август");
                    break;
                case 9:
                    Console.WriteLine("Сентябрь");
                    break;
                case 10:
                    Console.WriteLine("Октябрь");
                    break;
                case 11:
                    Console.WriteLine("Ноябрь");
                    break;
                case 12:
                    Console.WriteLine("Декабрь");
                    isWinter = true;
                    break;
                default:
                    Console.WriteLine("Надо было вводить чисто от 1 до 12");
                    break;
            }

            #endregion

            #region Task3 Четность/нечетность

            Console.WriteLine("Введите целое число, а я скаже четное оно или нет");
            int userNumber = int.Parse(Console.ReadLine());

            if (userNumber % 2 != 0)
            {
                Console.WriteLine($"Число {userNumber} нечетное");
            }
            else
            {
                Console.WriteLine($"Число {userNumber} четное");
            }

            #endregion

            #region Task4 Копия чека
            // ссылка на оригинал чека https://blanker.ru/files/images/chek.jpg

            string receiptName = "НОВЫЙ ЧЕК";
            int refuelingNumber = 35;
            int cashboxNumber = 4;
            int workerNumber = 354;
            long ITN = 770000_0000; //ИНН
            int xNumber1 = 23;
            int xNumber2 = 2516;
            double priceInRub = 19.5;
            double litres = 70.0;
            double totalCost = priceInRub * litres;
            double customerCash = 1500;
            double oddMoney = customerCash - totalCost;
            long EKLZ = 3297258661;
            int receiptNumber = 924;
            DateTime purchaseDate = new DateTime(2007, 9, 10, 18, 57, 00);
            int xNumber3 = 231;
            int xNumber4 = 82143979;
            int xNumber5 = 144347;
            int xNumber6 = 62988;
            string hrline = "____________________________________";


            Console.WriteLine("Нажмите любую клавишу для вывода чека...");
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("             " + receiptName + "\n\n");
            Console.WriteLine($"АЗС {refuelingNumber:0000} КАССА {cashboxNumber:000} ОПЕРАТОР {workerNumber:0000}");
            Console.WriteLine($"ИНН ОРГ.-ПРОДАВЦА    {ITN:0000} ");
            Console.WriteLine($"ДТ          №  {xNumber1}:{xNumber2}      {Math.Round(totalCost, 2).ToString("N2", CultureInfo.CreateSpecificCulture("sv-SE"))}");
            Console.WriteLine($"RBL        {priceInRub.ToString("N2")} X {litres.ToString("N3")} ");
            Console.WriteLine(hrline + "\n");
            Console.WriteLine($"ИТОГО                       {Math.Round(totalCost, 2).ToString("N2", CultureInfo.CreateSpecificCulture("sv-SE"))}");
            Console.WriteLine(hrline);
            Console.WriteLine($"Рубль России                {Math.Round(totalCost, 2).ToString("N2", CultureInfo.CreateSpecificCulture("sv-SE"))}");
            Console.WriteLine($"Наичными                    {Math.Round(customerCash, 2).ToString("N2", CultureInfo.CreateSpecificCulture("sv-SE"))}");
            Console.WriteLine($"СДАЧА                         {Math.Round(oddMoney, 2).ToString("N2", CultureInfo.CreateSpecificCulture("sv-SE"))}-");
            Console.WriteLine($"ЭКЛЗ {EKLZ}");
            Console.WriteLine($"              СПАСИБО \n             ЗА ПОКУПКУ");
            Console.WriteLine($"ЧЕК {receiptNumber:0000} {purchaseDate:d}   {purchaseDate:t} {xNumber3:0000}");
            Console.WriteLine($"ФИСКАЛЬНЫЙ РЕЖИМ      {xNumber4}\n");
            Console.WriteLine($"{xNumber5:00000000} #{xNumber6:000000}");
            Console.WriteLine("");

            #endregion

            #region Task5 Дождливая зима

            Console.WriteLine("Нажмите любую клавишу для анализа зимы...");
            Console.ReadKey();
            Console.WriteLine("");
            if (isWinter && average > 0)
            {
                Console.WriteLine("Дождливая зима");
            } else
            {
                Console.WriteLine("Обычная зима");
            }

            #endregion

            #region Task6 Расписание недели

            //Режимы работы (входные данные)
            Days shedule1 = (Days)0b_0011110;
            Days shedule2 = (Days)0b_1111111;

            //Виды расписаний(маски)
            Days tuesdayToFriday = Days.Вторник | Days.Среда | Days.Четверг | Days.Пятница;
            Days everyday = Days.Понедельник | Days.Вторник | Days.Среда | Days.Четверг | Days.Пятница | Days.Суббота | Days.Воскресенье;


            Console.WriteLine("Нажмите любую клавишу для вывода режимов работы офисов...");
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine($"Режим работы офиса 1:\n {shedule1}");
            Console.WriteLine($"Режим работы офиса 2:\n {shedule2}");

            if (shedule1==tuesdayToFriday && shedule2 == everyday)
            {
                Console.WriteLine("Входные данные соответствуют битовым маскам");
            }

            #endregion
        }

        [Flags]
        enum Days
        {
            Воскресенье = 0b_1000000,
            Суббота =     0b_0100000,
            Пятница =       0b_0010000,
            Четверг =     0b_0001000,
            Среда =     0b_0000100,
            Вторник =     0b_0000010,
            Понедельник = 0b_0000001
        } 
    }
}
