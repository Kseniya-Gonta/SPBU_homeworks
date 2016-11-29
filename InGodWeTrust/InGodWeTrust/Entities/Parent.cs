using System;

namespace InGodWeTrust.Entities
{
    public class Parent : Human
    {
        public Parent(string name, int age, Sex sex, int numberOfChildren
            ,bool isPair, ConsoleColor consoleColor = ConsoleColor.DarkCyan)
            : base(name, age, sex, isPair, consoleColor)
        {
            NumberOfChildren = numberOfChildren;
        }

        public int NumberOfChildren { get; set; }

        public override string ToString()
        {
            return $"Type: Parent, Name: {Name}, Sex: {Sex}, Age: {Age}, Number of children: {NumberOfChildren}";
    }
    }
}