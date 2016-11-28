namespace InGodWeTrust
{
    public class Parent : Human
    {
        public Parent(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = Sex.Male;
            this.NumberOfChildren = 1;
        }

        public int NumberOfChildren { get; set; }
    }
}