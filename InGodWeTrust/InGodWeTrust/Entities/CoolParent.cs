using System;

namespace InGodWeTrust
{
    public class CoolParent: Parent
    {
        public CoolParent(string name, int age, Sex sex, int numberOfChildren, int gpaMoney)
            : base(name, age, sex, numberOfChildren)
        {
            this.AmountOfMoney = gpaMoney;
        }

        public int AmountOfMoney { get; }

        public override void Print()
        {
            Console.Write("Type: CoolParent, Name: {0}, Sex: {1}, Age: {2}, Number of children: {3}, AmountOfMoney: {4}"
                , Name, Sex, Age, NumberOfChildren, AmountOfMoney );
        }
    }
}