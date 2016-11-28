namespace InGodWeTrust
{
    public class StudentUniversityGod: UniversityGod
    {
        //private class Student : Human

        public override Human CreateHuman()
        {
            return new Student();
        }
    }
}