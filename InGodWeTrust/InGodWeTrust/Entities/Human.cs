using System;

namespace InGodWeTrust
{
    public abstract class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }

        //public abstract void Print();

        public virtual void Print(bool isPair)
        {
            if (isPair)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;//FontColor();
            Console.Write(this);

            Console.ForegroundColor = ConsoleColor.Gray;
            if (isPair)
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}