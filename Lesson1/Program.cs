using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Последний раз спрашиваю, как тебя зовут?");
            var userName = Console.ReadLine();
            Console.WriteLine($"Привет, {userName}, сегодня {DateTime.Now:D}"); // строка для breakpoint, чтобы отследить значение переменной хранящей имя пользователя
        }
    }
}
