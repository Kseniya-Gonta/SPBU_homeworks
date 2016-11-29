using System;

namespace InGodWeTrust
{
    public class Botan: Student
    {
        public Botan(string name, Sex sex, int age, string patronymic, int gpa) : base(name, sex, age, patronymic)
        {
            Gpa = gpa;
        }

        public int Gpa { get; }

        public override string ToString()
        {
            return $"Type: Botan, Name: {Name}, Sex: {Sex}, Age: {Age}, Patronymic: {Patronymic}, GPA: {Gpa}";
        }
    }
}