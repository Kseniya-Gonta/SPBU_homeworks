using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InGodWeTrust.Entities;
using InGodWeTrust.Factory;

namespace InGodWeTrust
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            var day = DateTime.Now.DayOfWeek;
            if (day == DayOfWeek.Sunday)
            {
                Console.WriteLine("Я не работаю по воскресеньям и Вам не советую.");
                return;
            }

            Console.WriteLine("Я умею создавать людей!");
            Console.WriteLine("Введите желаемое количество людей.");

            int numberOfHumans;
            while (!int.TryParse(Console.ReadLine(), out numberOfHumans))
            {
                Console.WriteLine("Нужно ввести число");
            }

            var universityGod = new UniversityGod();
            var pairs = new List<Human>();
            for (var i = 0; i < numberOfHumans; i++)
            {
                universityGod.CreateHuman().Print();
                Console.WriteLine("\n ");
                pairs.Add(universityGod.CreatePair(universityGod.Humans.Last()));

            }

            PrintHelper.PrintPairs(pairs);
        }
    }
}