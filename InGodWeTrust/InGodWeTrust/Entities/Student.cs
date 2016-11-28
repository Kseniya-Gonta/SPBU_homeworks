using System;

namespace InGodWeTrust
{
    public class Student: Human
    {
        public Student(string name, Sex sex, int age, string patronymic)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
            this.Patronymic = patronymic;
        }


        public string Patronymic { get; }
        public override void Print()
        {
            Console.Write("Type: Student, Name: {0}, Sex: {1}, Age: {2}, Patronymic: {3}"
                , Name, Sex, Age, Patronymic );
        }
    }
}