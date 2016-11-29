using System;

namespace InGodWeTrust
{
    public class CoolParent: Parent
    {
        public CoolParent(string name, int age, Sex sex, int numberOfChildren, int gpaMoney)
            : base(name, age, sex, numberOfChildren)
        {
            AmountOfMoney = gpaMoney;
        }

        public int AmountOfMoney { get; }

        public override void Print(bool isPair)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            if (isPair)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            var description = $"Type: CoolParent, Name: {Name}, Sex: {Sex}" +
                              $",  Age: {Age}, Number of children: {NumberOfChildren}";

            var money = "AmountOfMoney:" + AmountOfMoney;

            Console.Write(description);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(money);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}