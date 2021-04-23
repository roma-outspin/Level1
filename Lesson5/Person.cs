using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }

        public Person(string name, string position, string mail, string phone, double salary, int age)
        {
            Name = name;
            Position = position;
            Mail = mail;
            Phone = phone;
            Salary = salary;
            Age = age;

        }

        public void ShowInfo()
        {
            Console.WriteLine($"ФИО: {Name}\nДолжность: {Position}\nЭлектронная почта: {Mail}\nТелефон: {Phone}\nОклад: {Salary.ToString()}млн.\nВозраст: {Age}\n");
        }
    }
}
