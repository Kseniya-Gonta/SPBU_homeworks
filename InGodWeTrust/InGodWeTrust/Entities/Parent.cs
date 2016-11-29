namespace InGodWeTrust
{
    public class Parent : Human
    {
        public Parent(string name, int age, Sex sex, int numberOfChildren)
        {
            Name = name;
            Age = age;
            Sex = sex;
            NumberOfChildren = numberOfChildren;
        }

        public int NumberOfChildren { get; set; }

        public override string ToString()
        {
            return $"Type: Botan, Name: {Name}, Sex: {Sex}, Age: {Age}, Number of children: {NumberOfChildren}";
    }
    }
}