using InGodWeTrust.Entities;

namespace InGodWeTrust.Factory
{
    public interface IGod
    {
        Human CreateHuman();
        Human CreateHuman(Sex sex);
        Human CreatePair(Human human);
    }
}