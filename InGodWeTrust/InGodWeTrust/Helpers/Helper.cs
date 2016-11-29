using System;
using InGodWeTrust.Entities;

namespace InGodWeTrust.Helpers
{
    public class Helper
    {
        private static readonly Random Random = new Random();

        private static readonly string[] FemaleNames = {"Анна", "Евгения", "Мария"};
        private static readonly string[] MaleNames = {"Фёдор", "Константин", "Валентин"};


        public string RandomName(Sex sex)
        {
            return sex == Sex.Female ? FemaleNames[Random.Next(0,3)] : MaleNames[Random.Next(0,3)];
        }

        public string RandomPatronymic(Sex sex)
        {
            return MaleNames[Random.Next(0,3)] + (sex == Sex.Female ? "овна" : "ович");
        }


        public string StudentPatronymicFromParent(string parentName, Sex studentSex)
        {
            return (parentName + ((studentSex == Sex.Female) ? "овна" : "ович"));
        }

        public string ParentNameFromStudent(string studentPatronymic)
        {
            return studentPatronymic.Substring(0, studentPatronymic.Length - 4);
        }

        public int StudentAgeFromParent(int parentAge)
        {
            return parentAge - Random.Next(20, 40);
        }

        public int ParentAgeFromStudent(int parentAge)
        {
            return parentAge + Random.Next(20, 40);
        }

        public double GpaFromMoney(double money)
        {
            return Math.Pow(10, money);
        }

        public double MoneyFromGpa(double gpa)
        {
            return Math.Log10(gpa);
        }
    }
}