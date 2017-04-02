using System;

namespace InGodWeTrust.Entities
{
    public abstract class Human
    {
        protected Human(string name, int age, Sex sex, bool isPair, ConsoleColor consoleColor)
        {
            Name = name;
            Age = age;
            Sex = sex;
            ConsoleColor = consoleColor;
            IsPair = isPair;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public ConsoleColor ConsoleColor { get; }
        public  bool IsPair { get; }


        //public virtual void Print(bool isPair)
        public virtual void Print()
        {
            if (IsPair)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
            Console.ForegroundColor = ConsoleColor;
            Console.Write(this);

            Console.ForegroundColor = ConsoleColor.Gray;
            if (IsPair)
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}