using System;
using System.IO;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1. Введите произвольный текст, он будет сохранен в файл Задание1.txt");
            string userData = Console.ReadLine();
            File.WriteAllText("Задание 1.txt", userData+"\n");

            Console.WriteLine("Задание 2. Нажмите Enter для сохранения даты и времени в файл Startup.txt");
            Console.ReadLine();
            File.AppendAllText("Startup.txt", DateTime.Now.ToString()+"\n");

            Console.WriteLine("Задание 3. Введите последовательность чисел через пробел от 0...255 для сохранения в Задание3.bin");
            string[] userNumbers = Console.ReadLine().Split(' ');
            byte[] userBytes = new byte[userNumbers.Length];
            for(int i = 0; i<userNumbers.Length;i++)
            {
                userBytes[i] = Byte.Parse(userNumbers[i]);
            }
            File.WriteAllBytes("Задание3.bin", userBytes);


            
            Console.WriteLine("Задание 4. Ниже будут представлена информация о рабочих старше 40 лет:");
            Person[] workers = new Person[]
            {
                new Person("Иван Иванов", "Директор", "best@gazprom.online","+0(000)00-00-000", 1.5, 42),
                new Person("Семен Иванов", "Директор по развитию", "first@gazprom.online","+0(000)00-00-001", 1.2, 41),
                new Person("Дмитрий Иванов", "Коммерческий директор", "money@gazprom.online","+0(000)00-00-002", 1.2, 40),
                new Person("Алексей Иванов", "Директор по внешней политике", "default@gazprom.online","+0(000)00-00-003", 1.2, 39),
                new Person("Вася Пупкин", "Работяга", "info@gazprom.online","Отсутствует", 0.001, 45),

            };
            foreach(var man in workers)
            {
                if (man.Age > 40) man.ShowInfo();
            }

        }
    }
}
