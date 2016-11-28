using System;

namespace InGodWeTrust
{
    public class Botan: Student
    {
        public Botan(string name, Sex sex, int age, string patronymic, int gpa) : base(name, sex, age, patronymic)
        {
            this.Gpa = gpa;
        }

        public int Gpa { get; }

        public override void Print()
        {
            Console.Write("Type: Botan, Name: {0}, Sex: {1}, Age: {2}, Patronymic: {3}, GPA: {4}"
                , Name, Sex, Age, Patronymic, Gpa );
        }
    }
}