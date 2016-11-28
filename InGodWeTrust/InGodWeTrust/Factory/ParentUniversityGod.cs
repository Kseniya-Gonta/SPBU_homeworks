namespace InGodWeTrust
{
    public class ParentUniversityGod: UniversityGod
    {
        public override Human CreateHuman()
        {
            return new Parent();
        }
    }
}