using System;

namespace InGodWeTrust.Entities
{
    public class Botan: Student
    {
        public Botan(string name, Sex sex, int age, string patronymic, double gpa
            ,bool isPair, ConsoleColor consoleColor = ConsoleColor.DarkYellow)
            : base(name, sex, age, patronymic, isPair, consoleColor)
        {
            Gpa = gpa;
        }

        public double Gpa { get; }

        public override string ToString()
        {
            return $"Type: Botan, Name: {Name}, Sex: {Sex}, Age: {Age}, Patronymic: {Patronymic}, GPA: {Gpa}";
        }
    }
}