namespace InGodWeTrust
{
    public class BotanUniversityGod: UniversityGod
    {
        public override Human CreateHuman()
        {
            return new Botan();
        }
    }
}