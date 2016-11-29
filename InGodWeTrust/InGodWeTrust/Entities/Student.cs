namespace InGodWeTrust
{
    public class Student: Human
    {
        public Student(string name, Sex sex, int age, string patronymic)
        {
            Name = name;
            Sex = sex;
            Age = age;
            Patronymic = patronymic;
        }


        public string Patronymic { get; }

        public override string ToString()
        {
            return $"Type: Botan, Name: {Name}, Sex: {Sex}, Age: {Age}, Patronymic: {Patronymic}";
        }
    }
}