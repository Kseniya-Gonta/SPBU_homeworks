using System;

namespace InGodWeTrust
{
    public class Parent : Human
    {
        public Parent(string name, int age, Sex sex, int numberOfChildren)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
            this.NumberOfChildren = numberOfChildren;
        }

        public int NumberOfChildren { get; set; }

        public override void Print()
        {
            Console.Write("Type: Parent, Name: {0}, Sex: {1}, Age: {2}, Number of children: {3}"
                , Name, Sex, Age, NumberOfChildren );
        }
    }
}