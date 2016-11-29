using System;

namespace InGodWeTrust.Entities
{
    public class CoolParent: Parent
    {
        public CoolParent(string name, int age, Sex sex, int numberOfChildren, double gpaMoney
            ,bool isPair, ConsoleColor consoleColor = ConsoleColor.DarkGreen)
            : base(name, age, sex, numberOfChildren, isPair, consoleColor)
        {
            AmountOfMoney = gpaMoney;
        }

        public double AmountOfMoney { get; }

        public override void Print()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            if (IsPair)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
            Console.ForegroundColor = ConsoleColor;
            var description = $"Type: CoolParent, Name: {Name}, Sex: {Sex}" +
                              $",  Age: {Age}, Number of children: {NumberOfChildren}, ";

            var money = "AmountOfMoney:" + AmountOfMoney;

            Console.Write(description);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(money);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}