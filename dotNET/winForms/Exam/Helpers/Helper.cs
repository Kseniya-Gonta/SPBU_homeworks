using System;

namespace Exam.Helpers
{
    public class Helper
    {
        private static readonly Random Random = new Random();
        private static readonly string[] FemaleNames = {"Анна", "Евгения", "Мария"};

        public int GetUpToThreeSeconds()
        {
            return Random.Next(0, 3);
        }

        public int GetUpToTenSeconds()
        {
            return Random.Next(0, 3);
        }

        public int AmountOfStudents()
        {
            return Random.Next(0, 30);
        }

        public int StudentMark()
        {
            return Random.Next(2, 5);
        }

        public string StudentName()
        {
            return FemaleNames[Random.Next(0, FemaleNames.Length)];
        }
    }
}