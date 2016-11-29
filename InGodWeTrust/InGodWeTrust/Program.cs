using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InGodWeTrust
{
    internal class Program
    {
        private static void PrintPairs(List<Human> pairs)
        {
            if (pairs == null)
            {
                throw new ArgumentNullException();
            }
            var amount = pairs.Count;
            pairs.Reverse();

            var topPosition = Console.CursorTop - 1;
            var top = topPosition;
            Console.SetCursorPosition(0, topPosition);

            for (var i = 0; i < amount; i++)
            {
                pairs[i].Print(true);
                topPosition -= 2;
                Console.SetCursorPosition(0, topPosition);
            }
            Console.SetCursorPosition(0, top + 1);
        }

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
                universityGod.CreateHuman().Print(false);
                Console.WriteLine("\n ");
                pairs.Add(universityGod.CreatePair(universityGod.Humans.Last()));

            }

            PrintPairs(pairs);
        }
    }
}