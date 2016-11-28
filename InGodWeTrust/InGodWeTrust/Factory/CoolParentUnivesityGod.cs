namespace InGodWeTrust
{
    public class CoolParentUnivesityGod: UniversityGod
    {
        public override Human CreateHuman()
        {
            return new CoolParent();
        }
    }
}