using System;

namespace InGodWeTrust.Entities
{
    public class Student: Human
    {
        public Student(string name, Sex sex, int age, string patronymic
            ,bool isPair, ConsoleColor consoleColor = ConsoleColor.DarkMagenta)
            : base(name, age, sex, isPair, consoleColor)
        {
            Patronymic = patronymic;
        }


        public string Patronymic { get; }

        public override string ToString()
        {
            return $"Type: Student, Name: {Name}, Sex: {Sex}, Age: {Age}, Patronymic: {Patronymic}";
        }
    }
}